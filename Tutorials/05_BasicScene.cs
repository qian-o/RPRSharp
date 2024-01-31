using System.Numerics;
using RPRSharp;
using Tutorials.Helpers;

namespace Tutorials;

public unsafe class BasicScene : BaseTutorial
{
    public override void Run()
    {
        // for Debugging you can enable Radeon ProRender API trace
        // set this before any RPR API calls
        // Rpr.ContextSetParameterByKey1u(default, ContextInfo.TRACING_ENABLED, 1);

        // Create the RPR context
        int pluginID = Rpr.RegisterPlugin(RprHelper.Northstar64);

        if (pluginID == -1)
        {
            Console.WriteLine("Failed to register plugin");
            return;
        }

        int[] plugins = [pluginID];
        Rpr.CreateContext(RprHelper.ApiVersion, plugins, plugins.Length, RprHelper.ContextCreationFlags, RprHelper.ContextProperties, "", out Context context).CheckStatus();
        Rpr.ContextSetActivePlugin(context, plugins[0]).CheckStatus();

        Console.WriteLine("Context successfully created.");

        // Create a scene. A scene is a container of nodes we want to render.
        // RPR can manage multiple scenes per context.
        Rpr.ContextCreateScene(context, out Scene scene).CheckStatus();
        Rpr.ContextSetScene(context, scene).CheckStatus();

        // Create the camera
        Camera camera;
        {
            Rpr.ContextCreateCamera(context, out camera).CheckStatus();

            // Set the camera transform
            Rpr.CameraLookAt(camera, 0.0f, 5.0f, 10.0f, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f).CheckStatus();

            // Attach the camera to the scene
            // Meaning this camera will be used to render the scene
            // ( a scene may hava multiple cameras )
            Rpr.SceneSetCamera(scene, camera).CheckStatus();
        }

        // Create cube mesh
        Shape cube;
        {
            RprHelper.CreateMesh(context, RprHelper.Cube, RprHelper.CubeIndices, RprHelper.CubeNumFaceVertices, out cube).CheckStatus();

            // Create a transform for the cube
            Matrix4x4 m = Matrix4x4.CreateTranslation(-2.0f, 1.0f, 0.0f);
            Rpr.ShapeSetTransform(cube, true, m.ToArray(true)).CheckStatus();

            // Attach the cube to the scene
            Rpr.SceneAttachShape(scene, cube).CheckStatus();
        }

        // Create a simple point light
        Light light;
        {
            Rpr.ContextCreatePointLight(context, out light).CheckStatus();

            // Set the light transform
            Matrix4x4 m = Matrix4x4.CreateTranslation(2.0f, 10.0f, 2.0f);
            Rpr.LightSetTransform(light, true, m.ToArray(true)).CheckStatus();

            // Set light radiant power
            Rpr.PointLightSetRadiantPower3f(light, 150.0f, 150.0f, 150.0f).CheckStatus();

            // Attach the light to the scene
            Rpr.SceneAttachLight(scene, light).CheckStatus();
        }

        // Create framebuffer to store rendering result
        // For basic rendering We need 2 framebuffers:
        // 'frame_buffer' will be used to store the Color AOV.
        // 'frame_buffer_resolved' is the resolution of 'frame_buffer', meaning that 'frame_buffer' is not supposed to be displayed and should only be used internally.
        //                         however 'frame_buffer_resolved' is the correct rendering that can be displayed on the screen. 
        FramebufferDesc desc = new()
        {
            FbWidth = 800,
            FbHeight = 600
        };
        FramebufferFormat fmt = new()
        {
            NumComponents = 4,
            Type = ComponentType.Float32
        };
        Rpr.ContextCreateFrameBuffer(context, fmt, desc, out Framebuffer frame_buffer).CheckStatus();
        Rpr.ContextCreateFrameBuffer(context, fmt, desc, out Framebuffer frame_buffer_resolved).CheckStatus();

        // attach 'frame_buffer' to the Color AOV ( this is the main AOV for final rendering )
        Rpr.ContextSetAOV(context, Aov.Color, frame_buffer).CheckStatus();

        // define number of iterations.
        // The higher iterations we use, the better the quality will be.
        // Note that having RPR_CONTEXT_ITERATIONS=N  is pretty much the same thing that calling rprContextRender N times.
        //      However, performances are better when using the RPR_CONTEXT_ITERATIONS.
        Rpr.ContextSetParameterByKey1u(context, ContextInfo.Iterations, 60).CheckStatus();

        // Start the rendering.
        // Note that this call is synchronous ( as most of the RPR API ).
        //      There are ways to call rprContextRender in a separate thread but this won't be done in this tutorial.
        Rpr.ContextRender(context).CheckStatus();

        // 'frame_buffer' is not supposed to be used for rendering, we need to process it with rprContextResolveFrameBuffer.
        // This function transforms the raw 'frame_buffer' into a new 'frame_buffer_resolved' that can be displayed on screen as final rendering.
        // Note that 'frame_buffer' is not modified, so you can call rprContextResolveFrameBuffer multiple times with the same 'frame_buffer' to generate different 'frame_buffer_resolved'.The 'noDisplayGamma'=false argument means we want to use display gamma (defined by RPR_CONTEXT_DISPLAY_GAMMA) which makes sense in this case as 'frame_buffer' represents COLOR.
        // If the framebuffer doesn't represent Color ( for example: Normals, Depth, UVs ... ) then 'noDisplayGamma' should be set to true. 
        Rpr.ContextResolveFrameBuffer(context, frame_buffer, frame_buffer_resolved, false).CheckStatus();

        // Save the result to a file
        Rpr.FrameBufferSaveToFile(frame_buffer_resolved, "05_BasicScene_00.png").CheckStatus();

        Console.WriteLine("rendering 00 finished.");

        //
        // At this point, we have our first RPR rendering, saved in the 05_BasicScene_00.png file.
        // We are going to complexify this scene in order to demonstrate more RPR features.
        //

        // add a new shape representing the floor of the scene.
        Shape plane;
        {
            RprHelper.CreateMesh(context, RprHelper.Plane, RprHelper.PlaneIndices, RprHelper.PlaneNumFaceVertices, out plane).CheckStatus();

            // Attach the plane to the scene
            Rpr.SceneAttachShape(scene, plane).CheckStatus();
        }

        // use the instance feature to create another cube base of the first one.
        Shape cube_instance;
        {
            Rpr.ContextCreateInstance(context, cube, out cube_instance).CheckStatus();

            // Create a transform for the cube
            Matrix4x4 m = Matrix4x4.CreateRotationY(0.5f) * Matrix4x4.CreateTranslation(2.0f, 1.0f, -3.0f);
            Rpr.ShapeSetTransform(cube_instance, true, m.ToArray(true)).CheckStatus();

            // Attach the cube to the scene
            Rpr.SceneAttachShape(scene, cube_instance).CheckStatus();
        }

        // Create materials

        // Before creation materials, we need a Material System.
        // This object is just the containers for all materials of the scene.
        // In most of the cases, you will need 1 single Material System per RPR context.
        Rpr.ContextCreateMaterialSystem(context, 0, out MaterialSystem matsys).CheckStatus();

        // Create a diffuse material
        MaterialNode diffuse1;
        {
            Rpr.MaterialSystemCreateNode(matsys, MaterialNodeType.Diffuse, out diffuse1).CheckStatus();

            // set the color
            Rpr.MaterialNodeSetInputFByKey(diffuse1, MaterialNodeInput.Color, 0.6f, 0.4f, 1.0f, 0.0f).CheckStatus();

            // set it to the cube
            Rpr.ShapeSetMaterial(cube, diffuse1).CheckStatus();
        }

        // Do the same thing for instance and floor
        MaterialNode diffuse2;
        {
            Rpr.MaterialSystemCreateNode(matsys, MaterialNodeType.Diffuse, out diffuse2).CheckStatus();

            // set the color
            Rpr.MaterialNodeSetInputFByKey(diffuse2, MaterialNodeInput.Color, 1.0f, 0.5f, 0.0f, 0.0f).CheckStatus();

            // set it to the cube
            Rpr.ShapeSetMaterial(cube_instance, diffuse2).CheckStatus();
        }
        MaterialNode diffuse3;
        {
            Rpr.MaterialSystemCreateNode(matsys, MaterialNodeType.Diffuse, out diffuse3).CheckStatus();

            // set the color
            Rpr.MaterialNodeSetInputFByKey(diffuse3, MaterialNodeInput.Color, 0.1f, 0.8f, 1.0f, 0.0f).CheckStatus();

            // set it to the cube
            Rpr.ShapeSetMaterial(plane, diffuse3).CheckStatus();
        }

        // Let's render our current scene

        // Note that when the scene has been changed, it's important to clear the framebuffer.
        // rprContextRender always accumulates the rendering to 'frame_buffer'.
        // meaning you will have a blending of the rendering and the previous one.
        Rpr.FrameBufferClear(frame_buffer).CheckStatus();

        Rpr.ContextRender(context).CheckStatus();
        Rpr.ContextResolveFrameBuffer(context, frame_buffer, frame_buffer_resolved, false).CheckStatus();
        Rpr.FrameBufferSaveToFile(frame_buffer_resolved, "05_BasicScene_01.png").CheckStatus();

        Console.WriteLine("rendering 01 finished.");

        // We will now learn how to add images.

        MaterialNode diffuse4;
        Image image1;
        MaterialNode materialImage1;
        {
            string pathImageFileA = Path.Combine("Resources", "Textures", "lead_rusted_Base_Color.jpg");
            Rpr.ContextCreateImageFromFile(context, pathImageFileA, out image1).CheckStatus();

            Rpr.MaterialSystemCreateNode(matsys, MaterialNodeType.ImageTexture, out materialImage1).CheckStatus();
            Rpr.MaterialNodeSetInputImageDataByKey(materialImage1, MaterialNodeInput.Data, image1).CheckStatus();

            Rpr.MaterialSystemCreateNode(matsys, MaterialNodeType.Diffuse, out diffuse4).CheckStatus();
            Rpr.MaterialNodeSetInputNByKey(diffuse4, MaterialNodeInput.Color, materialImage1).CheckStatus();

            Rpr.ShapeSetMaterial(cube, diffuse4).CheckStatus();
        }

        MaterialNode uv_scaled_node;
        MaterialNode diffuse5;
        Image image2;
        MaterialNode materialImage2;
        MaterialNode uv_node;
        {
            string pathImageFileA = Path.Combine("Resources", "Textures", "amd.png");
            Rpr.ContextCreateImageFromFile(context, pathImageFileA, out image2).CheckStatus();

            Rpr.MaterialSystemCreateNode(matsys, MaterialNodeType.ImageTexture, out materialImage2).CheckStatus();
            Rpr.MaterialNodeSetInputImageDataByKey(materialImage2, MaterialNodeInput.Data, image2).CheckStatus();

            Rpr.MaterialSystemCreateNode(matsys, MaterialNodeType.Diffuse, out diffuse5).CheckStatus();
            Rpr.MaterialNodeSetInputNByKey(diffuse5, MaterialNodeInput.Color, materialImage2).CheckStatus();

            // create a Lookup material and define it as a "UV Lookup" meaning the output of this material is the UV from the shape.
            // Lookup nodes are useful to create procedural materials.
            // UV-Lookup are often used to scale textures on shapes.
            Rpr.MaterialSystemCreateNode(matsys, MaterialNodeType.InputLookup, out uv_node).CheckStatus();
            Rpr.MaterialNodeSetInputUByKey(uv_node, MaterialNodeInput.Value, (uint)MaterialNodeLookupValue.Uv).CheckStatus();

            // adjust the texture scale by multiplying the the UV by a constant.
            Rpr.MaterialSystemCreateNode(matsys, MaterialNodeType.Arithmetic, out uv_scaled_node).CheckStatus();
            Rpr.MaterialNodeSetInputUByKey(uv_scaled_node, MaterialNodeInput.Op, (uint)MaterialNodeArithmeticOperation.Mul).CheckStatus();
            Rpr.MaterialNodeSetInputNByKey(uv_scaled_node, MaterialNodeInput.Color0, uv_node).CheckStatus();
            Rpr.MaterialNodeSetInputFByKey(uv_scaled_node, MaterialNodeInput.Color1, 6.0f, 12.0f, 0.0f, 0.0f).CheckStatus();

            // apply this modified UV to the image material.
            Rpr.MaterialNodeSetInputNByKey(materialImage2, MaterialNodeInput.Uv, uv_scaled_node).CheckStatus();

            Rpr.ShapeSetMaterial(plane, diffuse5).CheckStatus();
        }

        // create a simple reflection material and apply it on the cube_instance.
        MaterialNode reflection1;
        {
            Rpr.MaterialSystemCreateNode(matsys, MaterialNodeType.Reflection, out reflection1).CheckStatus();
            Rpr.MaterialNodeSetInputFByKey(reflection1, MaterialNodeInput.Color, 1.0f, 1.0f, 1.0f, 0.0f).CheckStatus();
            Rpr.ShapeSetMaterial(cube_instance, reflection1).CheckStatus();
        }

        // remove the point light: we are going to replace it by an Environment Light.
        Rpr.SceneDetachLight(scene, light).CheckStatus();

        // create an environment light
        Light lightEnv;
        Image imgEnvLight;
        {
            Rpr.ContextCreateEnvironmentLight(context, out lightEnv).CheckStatus();

            string pathImageFile = Path.Combine("Resources", "Textures", "turning_area_4k.hdr");
            Rpr.ContextCreateImageFromFile(context, pathImageFile, out imgEnvLight).CheckStatus();

            // Set an image for the Env light to take the radiance values from.
            Rpr.EnvironmentLightSetImage(lightEnv, imgEnvLight).CheckStatus();

            // adjust the intensity of the Env light.
            Rpr.EnvironmentLightSetIntensityScale(lightEnv, 0.8f).CheckStatus();

            // Set the Env light as the environment light of the scene.
            Rpr.SceneAttachLight(scene, lightEnv).CheckStatus();
        }

        // move camera
        Rpr.CameraLookAt(camera, 0.0f, 4.0f, 10.0f, 0.0f, 1.0f, 0.0f, 0.0f, 1.0f, 0.0f).CheckStatus();

        // modify display gamma. In most of the cases, display gamma should be around 2.2.
        // This makes image brightness looking better on majority of monitors.
        // Gamma is applied during the "rprContextResolveFrameBuffer" call.
        Rpr.ContextSetParameterByKey1f(context, ContextInfo.DisplayGamma, 2.2f).CheckStatus();

        // render the current scene the smae way we did for _05_BasicScene_01.png
        Rpr.FrameBufferClear(frame_buffer).CheckStatus();
        Rpr.ContextRender(context).CheckStatus();
        Rpr.ContextResolveFrameBuffer(context, frame_buffer, frame_buffer_resolved, false).CheckStatus();
        Rpr.FrameBufferSaveToFile(frame_buffer_resolved, "05_BasicScene_02.png").CheckStatus();

        Console.WriteLine("rendering 02 finished.");

        // the scene can be dynamically animated by updating parameters

        // example:

        // move camera
        Rpr.CameraLookAt(camera, 0.0f, 4.0f, 9.0f, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f).CheckStatus();

        // move cube
        Matrix4x4 cubeMatrix = Matrix4x4.CreateScale(1.0f, 1.0f, 4.0f) * Matrix4x4.CreateRotationY(0.7f) * Matrix4x4.CreateTranslation(1.0f, 1.0f, -3.0f);
        Rpr.ShapeSetTransform(cube_instance, true, cubeMatrix.ToArray(true)).CheckStatus();

        // change scaling of the AMD logo on the floor
        Rpr.MaterialNodeSetInputFByKey(uv_scaled_node, MaterialNodeInput.Color1, 10.0f, 20.0f, 0.0f, 0.0f).CheckStatus();

        // replace the material on cuve by an emissive one.
        MaterialNode emissive1;
        {
            Rpr.MaterialSystemCreateNode(matsys, MaterialNodeType.Emissive, out emissive1).CheckStatus();
            Rpr.MaterialNodeSetInputFByKey(emissive1, MaterialNodeInput.Color, 6.0f, 3.0f, 0.0f, 0.0f).CheckStatus();
            Rpr.ShapeSetMaterial(cube, emissive1).CheckStatus();
        }

        // move cube
        cubeMatrix = Matrix4x4.CreateScale(0.5f) * Matrix4x4.CreateRotationY(0.0f) * Matrix4x4.CreateTranslation(-2.0f, 0.7f, 0.0f);
        Rpr.ShapeSetTransform(cube, true, cubeMatrix.ToArray(true)).CheckStatus();

        Rpr.ShapeSetVisibilityFlag(cube, ShapeInfo.VisibilityShadow, false).CheckStatus();

        // emove the Env light, and use the point light again.
        Rpr.SceneDetachLight(scene, lightEnv).CheckStatus();
        Rpr.SceneAttachLight(scene, light).CheckStatus();

        // slightly increase the iteration count for this scene.
        Rpr.ContextSetParameterByKey1u(context, ContextInfo.Iterations, 120).CheckStatus();

        // render the current scene the smae way we did for _05_BasicScene_01.png
        Rpr.FrameBufferClear(frame_buffer).CheckStatus();
        Rpr.ContextRender(context).CheckStatus();
        Rpr.ContextResolveFrameBuffer(context, frame_buffer, frame_buffer_resolved, false).CheckStatus();
        Rpr.FrameBufferSaveToFile(frame_buffer_resolved, "05_BasicScene_03.png").CheckStatus();

        Console.WriteLine("rendering 03 finished.");

        // Release the stuff we created
        // Order of delete calls doesn't matter, as long as you delete the Context in last.

        // In RPR, you can only rprObjectDelete an object when it's no longer used in the scene: 
        // calling a rprContextRender with delete object will lead into unstable behaviour.
        Rpr.ObjectDelete(diffuse1).CheckStatus();
        Rpr.ObjectDelete(diffuse2).CheckStatus();
        Rpr.ObjectDelete(diffuse3).CheckStatus();
        Rpr.ObjectDelete(diffuse4).CheckStatus();
        Rpr.ObjectDelete(diffuse5).CheckStatus();
        Rpr.ObjectDelete(emissive1).CheckStatus();
        Rpr.ObjectDelete(reflection1).CheckStatus();
        Rpr.ObjectDelete(uv_scaled_node).CheckStatus();
        Rpr.ObjectDelete(uv_node).CheckStatus();
        Rpr.ObjectDelete(materialImage1).CheckStatus();
        Rpr.ObjectDelete(materialImage2).CheckStatus();
        Rpr.ObjectDelete(matsys).CheckStatus();
        Rpr.ObjectDelete(image1).CheckStatus();
        Rpr.ObjectDelete(image2).CheckStatus();
        Rpr.ObjectDelete(lightEnv).CheckStatus();
        Rpr.ObjectDelete(imgEnvLight).CheckStatus();
        Rpr.ObjectDelete(light).CheckStatus();
        Rpr.ObjectDelete(plane).CheckStatus();
        Rpr.ObjectDelete(cube_instance).CheckStatus();
        Rpr.ObjectDelete(cube).CheckStatus();
        Rpr.ObjectDelete(camera).CheckStatus();
        Rpr.ObjectDelete(scene).CheckStatus();
        Rpr.ObjectDelete(frame_buffer).CheckStatus();
        Rpr.ObjectDelete(frame_buffer_resolved).CheckStatus();
        Rpr.ObjectDelete(context).CheckStatus();
    }
}

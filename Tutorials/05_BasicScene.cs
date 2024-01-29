using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using RPRSharp;
using RPRSharp.Enums;
using RPRSharp.Structs;
using Tutorials.Helpers;

namespace Tutorials;

public unsafe class BasicScene : BaseTutorial
{
    public override void Run()
    {
        // Create the RPR context
        int pluginID = Rpr.RegisterPlugin(Common.Northstar64);

        if (pluginID == -1)
        {
            Console.WriteLine("Failed to register plugin");
            return;
        }

        int[] plugins = [pluginID];
        Rpr.CreateContext(Rpr.API_VERSION, plugins, plugins.Length, ContextCreationFlags, ContextProperties, "", out Context context).CheckStatus();
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
            Rpr.CameraLookAt(camera, 0, 5, 10, 0, 0, 0, 0, 1, 0).CheckStatus();

            // Attach the camera to the scene
            // Meaning this camera will be used to render the scene
            // ( a scene may hava multiple cameras )
            Rpr.SceneSetCamera(scene, camera).CheckStatus();
        }

        // Create cube mesh
        Shape cube;
        {
            Vertex[] cubeData = Vertex.Cube();
            int[] indices = Vertex.Indices();
            int[] numFaceVertices = Vertex.NumFaceVertices();

            float* cubeVertices = (float*)Unsafe.AsPointer(ref cubeData[0]);
            float* cubeNormals = (float*)((byte*)cubeVertices + Marshal.OffsetOf<Vertex>(nameof(Vertex.Norm)));
            float* cubeUVs = (float*)((byte*)cubeVertices + Marshal.OffsetOf<Vertex>(nameof(Vertex.Tex)));
            int* cubeIndices = (int*)Unsafe.AsPointer(ref indices[0]);
            int* cubeNumVertices = (int*)Unsafe.AsPointer(ref numFaceVertices[0]);

            Rpr.ContextCreateMesh(context,
                                  cubeVertices, cubeData.Length, sizeof(Vertex),
                                  cubeNormals, cubeData.Length, sizeof(Vertex),
                                  cubeUVs, cubeData.Length, sizeof(Vertex),
                                  cubeIndices, sizeof(int),
                                  cubeIndices, sizeof(int),
                                  cubeIndices, sizeof(int),
                                  cubeNumVertices, numFaceVertices.Length,
                                  out cube).CheckStatus();

            // Attach the cube to the scene
            Rpr.SceneAttachShape(scene, cube).CheckStatus();

            // Create a transform for the cube
            Matrix4x4 m = Matrix4x4.CreateTranslation(-2.0f, 1.0f, 0.0f);
            Rpr.ShapeSetTransform(cube, true, m.ToArray(true)).CheckStatus();
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
        FrameBufferDesc desc = new()
        {
            FbWidth = 800,
            FbHeight = 600
        };
        FrameBufferFormat fmt = new()
        {
            NumComponents = 4,
            Type = ComponentType.FLOAT32
        };
        Rpr.ContextCreateFrameBuffer(context, fmt, desc, out FrameBuffer frame_buffer).CheckStatus();
        Rpr.ContextCreateFrameBuffer(context, fmt, desc, out FrameBuffer frame_buffer_resolved).CheckStatus();

        // attach 'frame_buffer' to the Color AOV ( this is the main AOV for final rendering )
        Rpr.ContextSetAOV(context, Aov.COLOR, frame_buffer).CheckStatus();

        // define number of iterations.
        // The higher iterations we use, the better the quality will be.
        // Note that having RPR_CONTEXT_ITERATIONS=N  is pretty much the same thing that calling rprContextRender N times.
        //      However, performances are better when using the RPR_CONTEXT_ITERATIONS.
        Rpr.ContextSetParameterByKey1u(context, ContextInfo.ITERATIONS, 60).CheckStatus();

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
    }
}

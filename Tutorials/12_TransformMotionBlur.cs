using System.Numerics;
using RPRSharp;
using Tutorials.Helpers;
using Tutorials.Models;

namespace Tutorials;

// This demo covers shape and camera matrix transform changed over time for a blur effect.
// Note that this is different compared to a Deformation motion blur ( illustrated in another Demo ) where we set each vertex individually over time.
// Here it's simpler: we just change the transform matrix.
// This demo also illustrates how we can export the blur with the RPR_AOV_VELOCITY AOV.
public class TransformMotionBlur : BaseTutorial
{
    public override void Run()
    {
        // for Debugging you can enable Radeon ProRender API trace
        // set this before any RPR API calls
        // Rpr.ContextSetParameterByKey1u(default, ContextInfo.TRACING_ENABLED, 1);

        Console.WriteLine("-- Radeon ProRender SDK Demo --");

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

        // Create material system
        Rpr.ContextCreateMaterialSystem(context, 0, out MaterialSystem materialSystem).CheckStatus();

        // Create the scene
        Rpr.ContextCreateScene(context, out Scene scene).CheckStatus();
        Rpr.ContextSetScene(context, scene).CheckStatus();

        // Create a camera
        Rpr.ContextCreateCamera(context, out Camera camera).CheckStatus();
        Rpr.CameraLookAt(camera, 10.0f, 10.0f, 10.0f, 0.0f, 1.0f, 0.0f, 0.0f, 1.0f, 0.0f).CheckStatus();
        Rpr.SceneSetCamera(scene, camera).CheckStatus();

        // Create framebuffer
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

        Rpr.ContextCreateFrameBuffer(context, fmt, desc, out FrameBuffer fb_color).CheckStatus();
        Rpr.ContextCreateFrameBuffer(context, fmt, desc, out FrameBuffer fb_color_resolved).CheckStatus();
        Rpr.ContextSetAOV(context, Aov.COLOR, fb_color).CheckStatus();

        // Optional : add a Velocity AOV. this could be useful for debugging or post processing
        Rpr.ContextCreateFrameBuffer(context, fmt, desc, out FrameBuffer fb_velocity).CheckStatus();
        Rpr.ContextCreateFrameBuffer(context, fmt, desc, out FrameBuffer fb_velocity_resolved).CheckStatus();
        Rpr.ContextSetAOV(context, Aov.VELOCITY, fb_velocity).CheckStatus();

        RprGarbageCollector gc = new();

        // Create a teapot shape
        Shape teapot01;
        {
            string teapotFile = Path.Combine("Resources", "Meshes", "teapot.obj");
            RprHelper.AssimpParsing(context, gc, teapotFile, out Shape[] shapes).CheckStatus();
            teapot01 = shapes[0];

            Matrix4x4 transform = Matrix4x4.CreateRotationX(MathF.PI);
            Rpr.ShapeSetTransform(teapot01, true, transform.ToArray(true)).CheckStatus();

            Rpr.SceneAttachShape(scene, teapot01).CheckStatus();
        }

        // Create the floor
        RprHelper.CreateAMDFloor(context, scene, materialSystem, gc, 1.0f, 1.0f).CheckStatus();

        // Create an environment light
        RprHelper.CreateNatureEnvLight(context, scene, gc, 0.8f).CheckStatus();

        // Create a DIFFUSE material for the teapot
        MaterialNode diffuse1;
        Image img;
        MaterialNode imgSampler;
        {
            string textestFile = Path.Combine("Resources", "Textures", "textest.png");

            Rpr.MaterialSystemCreateNode(materialSystem, MaterialNodeType.DIFFUSE, out diffuse1).CheckStatus();
            Rpr.ContextCreateImageFromFile(context, textestFile, out img).CheckStatus();
            Rpr.MaterialSystemCreateNode(materialSystem, MaterialNodeType.IMAGE_TEXTURE, out imgSampler).CheckStatus();
            Rpr.MaterialNodeSetInputImageDataByKey(imgSampler, MaterialNodeInput.DATA, img).CheckStatus();
            Rpr.MaterialNodeSetInputNByKey(diffuse1, MaterialNodeInput.COLOR, imgSampler).CheckStatus();
            Rpr.ShapeSetMaterial(teapot01, diffuse1).CheckStatus();
        }

        // First, Render scene without any motion blur
        Rpr.ContextSetParameterByKey1f(context, ContextInfo.DISPLAY_GAMMA, 2.2f).CheckStatus();
        Rpr.ContextSetParameterByKey1u(context, ContextInfo.ITERATIONS, 200).CheckStatus();
        Rpr.ContextRender(context).CheckStatus();
        Rpr.ContextResolveFrameBuffer(context, fb_color, fb_color_resolved, false).CheckStatus();
        Rpr.ContextResolveFrameBuffer(context, fb_velocity, fb_velocity_resolved, true).CheckStatus();

        Rpr.FrameBufferSaveToFile(fb_color_resolved, "12_TransformMotionBlur_00.png").CheckStatus();

        Console.WriteLine("rendering 00 finished.");

        // Activate the motion by setting an exposure greater than 0.0f
        Rpr.CameraSetExposure(camera, 1.0f).CheckStatus();

        // Apply a rotation motion blur to the teapot
        // Note that rotation_x(MY_PI) is the transform at exposure=0 ( before motion blur ), and  rotation_y(0.5f)  is the real motion blur effect.
        {
            Matrix4x4 transform = Matrix4x4.CreateRotationX(MathF.PI) * Matrix4x4.CreateRotationY(0.1f);
            Rpr.ShapeSetMotionTransform(teapot01, true, transform.ToArray(true), 1).CheckStatus();
            Rpr.ShapeSetMotionTransformCount(teapot01, 1).CheckStatus();
        }

        // Render the scene
        Rpr.FrameBufferClear(fb_color).CheckStatus();
        Rpr.FrameBufferClear(fb_velocity).CheckStatus();
        Rpr.ContextRender(context).CheckStatus();
        Rpr.ContextResolveFrameBuffer(context, fb_color, fb_color_resolved, false).CheckStatus();
        Rpr.ContextResolveFrameBuffer(context, fb_velocity, fb_velocity_resolved, true).CheckStatus();
        Rpr.FrameBufferSaveToFile(fb_color_resolved, "12_TransformMotionBlur_01.png").CheckStatus();
        Rpr.FrameBufferSaveToFile(fb_velocity_resolved, "12_TransformMotionBlur_01v.png").CheckStatus();

        Console.WriteLine("rendering 01 finished.");

        // Same that previous rendering, but instead of a rotation we do a  (0.0f,0.0f,-0.3f)  blur translation of the teapot
        Matrix4x4 m1 = Matrix4x4.CreateRotationX(MathF.PI) * Matrix4x4.CreateTranslation(new Vector3(0.0f, 0.0f, -0.3f));
        Rpr.ShapeSetMotionTransform(teapot01, true, m1.ToArray(true), 1).CheckStatus();
        Rpr.ShapeSetMotionTransformCount(teapot01, 1).CheckStatus();
        Rpr.FrameBufferClear(fb_color).CheckStatus();
        Rpr.FrameBufferClear(fb_velocity).CheckStatus();
        Rpr.ContextRender(context).CheckStatus();
        Rpr.ContextResolveFrameBuffer(context, fb_color, fb_color_resolved, false).CheckStatus();
        Rpr.ContextResolveFrameBuffer(context, fb_velocity, fb_velocity_resolved, true).CheckStatus();
        Rpr.FrameBufferSaveToFile(fb_color_resolved, "12_TransformMotionBlur_02.png").CheckStatus();
        Rpr.FrameBufferSaveToFile(fb_velocity_resolved, "12_TransformMotionBlur_02v.png").CheckStatus();

        Console.WriteLine("rendering 02 finished.");

        // Now, we do a movement of the camera instead of shape. This is pretty much the same API.
        float[] camMat1 = RprHelper.CameraLookAtToMatrix(new Vector3(9.0f, 9.0f, 9.0f), new Vector3(0.0f, 1.0f, 0.0f), new Vector3(0.0f, 1.0f, 0.0f));
        Rpr.CameraSetMotionTransform(camera, false, camMat1, 1).CheckStatus();

        // enable motion blur on camera
        Rpr.CameraSetMotionTransformCount(camera, 1).CheckStatus();

        // disable motion blur of teapot
        Rpr.ShapeSetMotionTransformCount(teapot01, 0).CheckStatus();

        // Render the scene
        Rpr.FrameBufferClear(fb_color).CheckStatus();
        Rpr.FrameBufferClear(fb_velocity).CheckStatus();
        Rpr.ContextRender(context).CheckStatus();
        Rpr.ContextResolveFrameBuffer(context, fb_color, fb_color_resolved, false).CheckStatus();
        Rpr.ContextResolveFrameBuffer(context, fb_velocity, fb_velocity_resolved, true).CheckStatus();
        Rpr.FrameBufferSaveToFile(fb_color_resolved, "12_TransformMotionBlur_03.png").CheckStatus();
        Rpr.FrameBufferSaveToFile(fb_velocity_resolved, "12_TransformMotionBlur_03v.png").CheckStatus();

        Console.WriteLine("rendering 03 finished.");

        // Release the stuff we created
        gc.Clear();
        Rpr.ObjectDelete(fb_color).CheckStatus();
        Rpr.ObjectDelete(fb_color_resolved).CheckStatus();
        Rpr.ObjectDelete(fb_velocity).CheckStatus();
        Rpr.ObjectDelete(fb_velocity_resolved).CheckStatus();
        Rpr.ObjectDelete(imgSampler).CheckStatus();
        Rpr.ObjectDelete(img).CheckStatus();
        Rpr.ObjectDelete(diffuse1).CheckStatus();
        Rpr.ObjectDelete(camera).CheckStatus();
        Rpr.ObjectDelete(scene).CheckStatus();
        Rpr.ObjectDelete(materialSystem).CheckStatus();
        Rpr.ObjectDelete(context).CheckStatus();
    }
}

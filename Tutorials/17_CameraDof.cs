using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using RPRSharp;
using Tutorials.Helpers;
using Tutorials.Models;

namespace Tutorials;

//
// This demo shows how to configure camera Depth of Field. This effect makes background and/or foreground blurry.
// 
// This demo also shows how to use Adaptive Sampling (AS).
// AS can be used instead of "Classic" rendering for faster image convergence.
// - In Classic rendering ( used in most of the demos ) we just define a number of iterations ( also called SPP ) with RPR_CONTEXT_ITERATIONS and call rprContextRender.
//   The higher RPR_CONTEXT_ITERATIONS the "more converged" ( less noisy ) the result will be. If image is still too noisy, you can call rprContextRender again, and continue the process until you have the desired quality.
// - For AS you decide the level of quality that you want ( with RPR_CONTEXT_ADAPTIVE_SAMPLING_THRESHOLD ), then the framebuffer is subdivided into small tiles and when a tile reach the level of quality, it stops to be computed. 
//   The number of active tiles is get with RPR_CONTEXT_ACTIVE_PIXEL_COUNT: when this reach 0 this means the rendering is finished.
//
// Note that AS is being used in this Depth of Field demo but can be used in any other rendering use-cases. There is no particular
// reason we choose to implemented Adaptive Sampling in this specific demo. 
// Also there is no rendering difference between AS and Classic except the noise level for the same rendering time.

// If RenderUsingAdaptiveSampling == true rendering will be done with Adaptive Sampling, otherwise Classic rendering will be done.
public unsafe class CameraDof : BaseTutorial
{
    public const bool RenderUsingAdaptiveSampling = true;
    public const float MyPi = 3.14159265359f;

    struct Teapot(float x, float z, float rot, float r, float g, float b)
    {
        public float X = x;

        public float Z = z;

        public float Rot = rot;

        public float R = r / 255.0f;

        public float G = g / 255.0f;

        public float B = b / 255.0f;

        public Shape Shape;

        public MaterialNode Material;
    }

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

        // Create material system.
        Rpr.ContextCreateMaterialSystem(context, 0, out MaterialSystem materialSystem).CheckStatus();

        // Create the scene.
        Rpr.ContextCreateScene(context, out Scene scene).CheckStatus();

        // Create a camera.
        Vector3 eyePos = new(4.0f, 4.0f, 15.0f);

        Camera camera;
        {
            Rpr.ContextCreateCamera(context, out camera).CheckStatus();
            Rpr.CameraLookAt(camera, eyePos.X, eyePos.Y, eyePos.Z, 1.5f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f).CheckStatus();
            Rpr.SceneSetCamera(scene, camera).CheckStatus();
        }

        // Set scene to render for the context.
        Rpr.ContextSetScene(context, scene).CheckStatus();

        RprGarbageCollector gc = new();

        // Create an environment light
        RprHelper.CreateNatureEnvLight(context, scene, gc, 0.8f);

        // Define the teapots list used in the scene.
        Teapot[] posList =
        [
            new Teapot(5.0f, 2.0f, 1.6f, 122.0f, 63.0f, 0.0f), // brown
            new Teapot(-5.0f, 3.0f, 5.6f, 122.0f, 0.0f, 14.0f),
            new Teapot(0.0f, -3.0f, 3.2f, 119.0f, 0.0f, 93.0f),
            new Teapot(1.0f, 3.0f, 1.2f, 7.0f, 0.0f, 119.0f),
            new Teapot(3.0f, 9.0f, -1.7f, 0.0f, 59.0f, 119.0f),
            new Teapot(-6.0f, 12.0f, 2.2f, 0.0f, 119.0f, 99.0f),
            new Teapot(9.0f, -6.0f, 4.8f, 0.0f, 119.0f, 1.0f), // green
            new Teapot(9.0f, 7.0f, 2.5f, 219.0f, 170.0f, 0.0f), // yellow
            new Teapot(-9.0f, -7.0f, 5.8f, 112.0f, 216.0f, 202.0f),
        ];

        Teapot* posListPtr = (Teapot*)Unsafe.AsPointer(ref posList[0]);

        // create teapots.
        for (int i = 0; i < posList.Length; i++)
        {
            Teapot shape = *posListPtr;

            Shape teapot01;

            if (i == 0)
            {
                // create from OBJ for the first teapot.
                string teapotFile = Path.Combine("Resources", "Meshes", "teapot.obj");

                RprHelper.AssimpParsing(context, gc, teapotFile, out Shape[] shapes);

                teapot01 = shapes[0];
            }
            else
            {
                // other teapots will be instances of the first one.
                Rpr.ContextCreateInstance(context, posList[0].Shape, out teapot01);
            }

            Rpr.SceneAttachShape(scene, teapot01).CheckStatus();

            // random transforms of teapot on the floor.

            Matrix4x4 m = Matrix4x4.Identity;

            if (i % 4 == 0)
            {
                m = Matrix4x4.CreateRotationX(MyPi)
                    * Matrix4x4.CreateRotationY(shape.Rot)
                    * Matrix4x4.CreateTranslation(shape.X, 0.0f, shape.Z);
            }

            if (i % 4 == 1)
            {
                m = Matrix4x4.CreateRotationY(0.45f)
                    * Matrix4x4.CreateRotationX(MyPi + 1.9f)
                    * Matrix4x4.CreateTranslation(0.0f, 2.65f, 0.0f)
                    * Matrix4x4.CreateRotationY(shape.Rot)
                    * Matrix4x4.CreateTranslation(shape.X, 0.0f, shape.Z);
            }

            if (i % 4 == 2)
            {
                m = Matrix4x4.CreateRotationY(-0.57f)
                    * Matrix4x4.CreateRotationX(MyPi + 1.9f)
                    * Matrix4x4.CreateTranslation(0.0f, 2.65f, 0.0f)
                    * Matrix4x4.CreateRotationY(shape.Rot)
                    * Matrix4x4.CreateTranslation(shape.X, 0.0f, shape.Z);
            }

            if (i % 4 == 3)
            {
                m = Matrix4x4.CreateRotationZ(-0.2f)
                    * Matrix4x4.CreateRotationX(0.42f)
                    * Matrix4x4.CreateTranslation(0.0f, 3.38f, 0.0f)
                    * Matrix4x4.CreateRotationY(shape.Rot)
                    * Matrix4x4.CreateTranslation(shape.X, 0.0f, shape.Z);
            }

            Rpr.ShapeSetTransform(teapot01, true, m.ToArray(true)).CheckStatus();

            (*posListPtr).Shape = teapot01;

            posListPtr++;
        }

        // create the material system.
        Rpr.ContextCreateMaterialSystem(context, 0, out MaterialSystem matsys).CheckStatus();

        // create the floor
        RprHelper.CreateAMDFloor(context, scene, matsys, gc, 1.0f, 1.0f).CheckStatus();

        // Create a material for the teapots.
        posListPtr = (Teapot*)Unsafe.AsPointer(ref posList[0]);
        for (int i = 0; i < posList.Length; i++)
        {
            Teapot shape = *posListPtr;

            Rpr.MaterialSystemCreateNode(matsys, MaterialNodeType.Uberv2, out MaterialNode material).CheckStatus();

            Rpr.MaterialNodeSetInputFByKey(material, MaterialNodeInput.UberDiffuseColor, shape.R, shape.G, shape.B, 1.0f).CheckStatus();
            Rpr.MaterialNodeSetInputFByKey(material, MaterialNodeInput.UberDiffuseWeight, 1.0f, 1.0f, 1.0f, 1.0f).CheckStatus();

            Rpr.MaterialNodeSetInputFByKey(material, MaterialNodeInput.UberReflectionColor, 0.5f, 0.5f, 0.5f, 1.0f).CheckStatus();
            Rpr.MaterialNodeSetInputFByKey(material, MaterialNodeInput.UberReflectionWeight, 0.9f, 0.9f, 0.9f, 1.0f).CheckStatus();
            Rpr.MaterialNodeSetInputFByKey(material, MaterialNodeInput.UberReflectionRoughness, 0.1f, 0.0f, 0.0f, 0.0f).CheckStatus();
            Rpr.MaterialNodeSetInputUByKey(material, MaterialNodeInput.UberReflectionMode, (uint)UbermaterialIorMode.Metalness).CheckStatus();
            Rpr.MaterialNodeSetInputFByKey(material, MaterialNodeInput.UberReflectionMetalness, 0.0f, 0.0f, 0.0f, 1.0f).CheckStatus();

            Rpr.ShapeSetMaterial(shape.Shape, material).CheckStatus();

            (*posListPtr).Material = material;

            posListPtr++;
        }

        // Create framebuffer
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
        Rpr.ContextSetAOV(context, Aov.Color, frame_buffer).CheckStatus();

        // for Adaptive Sampling, we always need a Variance AOV.
        // This AOV keep track of active pixels ( pixels where color has changed between two rendering iterations )
        Framebuffer frame_buffer_variance;
        if (RenderUsingAdaptiveSampling)
        {
            Rpr.ContextCreateFrameBuffer(context, fmt, desc, out frame_buffer_variance).CheckStatus();
            Rpr.ContextSetAOV(context, Aov.Variance, frame_buffer_variance).CheckStatus();
        }

        // setting the Focal Length modifies the "Field of View" of the camera.
        Rpr.CameraSetFocalLength(camera, 25.0f).CheckStatus();

        // This is the most important part of this Depth of Field Demo :  here we change the focus.
        // Note that FocusDistance should be the distance between the eye and the point we focus ( in this case, the top of the blue teapot )
        // Then we adjust FStop. This parameters set the blur effect we want to give to the non-focused parts.  1/~0.0 = FLT_MAX is the default value, meaning no blur effect.
        //                       The more we increase the denominator the more blur effect we have.
        Vector3 focusPoint = new(3.0f, 3.6f, 9.0f);
        Vector3 eyeToFocus = focusPoint - eyePos;
        Rpr.CameraSetFocusDistance(camera, eyeToFocus.Length()).CheckStatus();
        Rpr.CameraSetFStop(camera, 1.0f / 11.0f).CheckStatus();

        // This Demo rendering is a good opportunity to show the ApertureBlades feature.
        // With this function you can modify the shape of lens flares.
        // With 5, you will notice pentagon artifacts.
        // ( You can try to comment-out this line and see the difference - it should switch to Hexagon, default value of the renderer )
        Rpr.CameraSetApertureBlades(camera, 5).CheckStatus();

        // set rendering gamma
        Rpr.ContextSetParameterByKey1f(context, ContextInfo.DisplayGamma, 2.2f).CheckStatus();

        // By default, there is no radiance clamp ( RPR_CONTEXT_RADIANCE_CLAMP = FLT_MAX )
        // On this kind of scene, adding some radiance clamping helps to reduce the fireflies and to have a faster image convergence
        // ( You can try to comment-out this line and see the difference )
        Rpr.ContextSetParameterByKey1f(context, ContextInfo.RadianceClamp, 2.0f).CheckStatus();

        // Render the scene.
        Stopwatch stopwatch = Stopwatch.StartNew();

        if (RenderUsingAdaptiveSampling)
        {
            // Adaptive Sampling works with dividing the framebuffer into tiles - this is tile size in pixels - recommended : [4, 16]
            Rpr.ContextSetParameterByKey1u(context, ContextInfo.AdaptiveSamplingTileSize, 8).CheckStatus();

            // minimum of iterations a pixel must do before activating Adaptive Sampling - recommended to set 10 or more
            Rpr.ContextSetParameterByKey1u(context, ContextInfo.AdaptiveSamplingMinSpp, 10).CheckStatus();

            // between 0 and 1 -  lower value means better final image 
            Rpr.ContextSetParameterByKey1f(context, ContextInfo.AdaptiveSamplingThreshold, 0.008f).CheckStatus();

            // iteration between each  RPR_CONTEXT_ACTIVE_PIXEL_COUNT  test.
            // it's better to keep this number high enough.  ( =1 would kill performance )...  but not too high otherwise you lose the advantage of Adaptive Sampling.
            Rpr.ContextSetParameterByKey1u(context, ContextInfo.Iterations, 100).CheckStatus();

            // call rprContextRender until all pixels are inactive
            for (int iActivePxlIteration = 0; ; iActivePxlIteration++)
            {
                // adds more SPP to the current framebuffer
                Rpr.ContextRender(context).CheckStatus();

                // get the number of active pixels
                uint activePixelCount = 0;
                Rpr.ContextGetInfo(context, ContextInfo.ActivePixelCount, sizeof(uint), &activePixelCount, out _).CheckStatus();

                Console.WriteLine($"Iteration {iActivePxlIteration} - {activePixelCount} active pixels remaining...");

                // end when no more pixel have changed.
                if (activePixelCount == 0)
                {
                    break;
                }
            }
        }
        else
        {
#pragma warning disable CS0162
            // Classic rendering
            Rpr.ContextSetParameterByKey1u(context, ContextInfo.Iterations, 4000).CheckStatus();
            Rpr.ContextRender(context).CheckStatus();
#pragma warning restore CS0162
        }

        stopwatch.Stop();

        Console.WriteLine($"Rendering took : {stopwatch.Elapsed.TotalSeconds} seconds.");

        Rpr.ContextResolveFrameBuffer(context, frame_buffer, frame_buffer_resolved, false);
        Rpr.FrameBufferSaveToFile(frame_buffer_resolved, "17_CameraDof.png").CheckStatus();

        // Release the resources.
        if (RenderUsingAdaptiveSampling)
        {
            Rpr.ObjectDelete(frame_buffer_variance).CheckStatus();
        }

        foreach (var shape in posList)
        {
            Rpr.ObjectDelete(shape.Shape).CheckStatus();
            Rpr.ObjectDelete(shape.Material).CheckStatus();
        }

        Rpr.ObjectDelete(frame_buffer).CheckStatus();
        Rpr.ObjectDelete(frame_buffer_resolved).CheckStatus();
        Rpr.ObjectDelete(scene).CheckStatus();
        Rpr.ObjectDelete(camera).CheckStatus();
        Rpr.ObjectDelete(matsys).CheckStatus();
        Rpr.ObjectDelete(materialSystem).CheckStatus();
        gc.Clear();
        Rpr.ObjectDelete(context).CheckStatus();
    }
}

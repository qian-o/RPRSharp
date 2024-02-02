using System.Numerics;
using System.Runtime.InteropServices;
using RPRSharp;
using Tutorials.Helpers;
using Tutorials.Models;

namespace Tutorials;

/// <summary>
/// This demo covers vertices deformation over time for a blur effect.
/// </summary>
public unsafe class DeformationMotionBlur : BaseTutorial
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

        // Create a camera
        Camera camera;
        {
            Rpr.ContextCreateCamera(context, out camera).CheckStatus();
            Rpr.CameraLookAt(camera, 0.0f, 5.0f, 20.0f, 0.0f, 1.0f, 0.0f, 0.0f, 1.0f, 0.0f).CheckStatus();
            Rpr.CameraSetFocalLength(camera, 75.0f).CheckStatus();
            Rpr.SceneSetCamera(scene, camera).CheckStatus();
        }

        // Set scene to render for the context
        Rpr.ContextSetScene(context, scene).CheckStatus();

        // Create framebuffer to store rendering result
        FramebufferDesc desc = new()
        {
            FbWidth = 800,
            FbHeight = 600
        };

        // 4 component 32-bit float format
        FramebufferFormat fmt = new()
        {
            NumComponents = 4,
            Type = ComponentType.Float32
        };

        Rpr.ContextCreateFrameBuffer(context, fmt, desc, out Framebuffer frame_buffer).CheckStatus();
        Rpr.ContextCreateFrameBuffer(context, fmt, desc, out Framebuffer frame_buffer_resolved).CheckStatus();

        // Set the framebuffer for the context
        Rpr.ContextSetAOV(context, Aov.Color, frame_buffer).CheckStatus();

        const float shiftX = 0.3f;
        const float shiftY = 0.3f;

        const int cubeNumberOfVertices = 24;
        const int numberOfBlurKeyTime = 2;

        // Create geometry
        Vertex[] cubeDataMotionBlur =
        [
            new Vertex { Position = new Vector3(-1.0f, 1.0f, -1.0f), Normal = new Vector3(0.0f, 1.0f, 0.0f), TexCoord = new Vector2(0.0f, 0.0f) },
            new Vertex { Position = new Vector3(1.0f, 1.0f, -1.0f), Normal = new Vector3(0.0f, 1.0f, 0.0f), TexCoord = new Vector2(1.0f, 0.0f) },
            new Vertex { Position = new Vector3(1.0f, 1.0f, 1.0f), Normal = new Vector3(0.0f, 1.0f, 0.0f), TexCoord = new Vector2(1.0f, 1.0f) },
            new Vertex { Position = new Vector3(-1.0f, 1.0f, 1.0f), Normal = new Vector3(0.0f, 1.0f, 0.0f), TexCoord = new Vector2(0.0f, 1.0f) },

            new Vertex { Position = new Vector3(-1.0f, -1.0f, -1.0f), Normal = new Vector3(0.0f, -1.0f, 0.0f), TexCoord = new Vector2(0.0f, 0.0f) },
            new Vertex { Position = new Vector3(1.0f, -1.0f, -1.0f), Normal = new Vector3(0.0f, -1.0f, 0.0f), TexCoord = new Vector2(1.0f, 0.0f) },
            new Vertex { Position = new Vector3(1.0f, -1.0f, 1.0f), Normal = new Vector3(0.0f, -1.0f, 0.0f), TexCoord = new Vector2(1.0f, 1.0f) },
            new Vertex { Position = new Vector3(-1.0f, -1.0f, 1.0f), Normal = new Vector3(0.0f, -1.0f, 0.0f), TexCoord = new Vector2(0.0f, 1.0f) },

            new Vertex { Position = new Vector3(-1.0f, -1.0f, 1.0f), Normal = new Vector3(-1.0f, 0.0f, 0.0f), TexCoord = new Vector2(0.0f, 0.0f) },
            new Vertex { Position = new Vector3(-1.0f, -1.0f, -1.0f), Normal = new Vector3(-1.0f, 0.0f, 0.0f), TexCoord = new Vector2(1.0f, 0.0f) },
            new Vertex { Position = new Vector3(-1.0f, 1.0f, -1.0f), Normal = new Vector3(-1.0f, 0.0f, 0.0f), TexCoord = new Vector2(1.0f, 1.0f) },
            new Vertex { Position = new Vector3(-1.0f, 1.0f, 1.0f), Normal = new Vector3(-1.0f, 0.0f, 0.0f), TexCoord = new Vector2(0.0f, 1.0f) },

            new Vertex { Position = new Vector3(1.0f, -1.0f, 1.0f), Normal = new Vector3(1.0f, 0.0f, 0.0f), TexCoord = new Vector2(0.0f, 0.0f) },
            new Vertex { Position = new Vector3(1.0f, -1.0f, -1.0f), Normal = new Vector3(1.0f, 0.0f, 0.0f), TexCoord = new Vector2(1.0f, 0.0f) },
            new Vertex { Position = new Vector3(1.0f, 1.0f, -1.0f), Normal = new Vector3(1.0f, 0.0f, 0.0f), TexCoord = new Vector2(1.0f, 1.0f) },
            new Vertex { Position = new Vector3(1.0f, 1.0f, 1.0f), Normal = new Vector3(1.0f, 0.0f, 0.0f), TexCoord = new Vector2(0.0f, 1.0f) },

            new Vertex { Position = new Vector3(-1.0f, -1.0f, -1.0f), Normal = new Vector3(0.0f, 0.0f, -1.0f), TexCoord = new Vector2(0.0f, 0.0f) },
            new Vertex { Position = new Vector3(1.0f, -1.0f, -1.0f), Normal = new Vector3(0.0f, 0.0f, -1.0f), TexCoord = new Vector2(1.0f, 0.0f) },
            new Vertex { Position = new Vector3(1.0f, 1.0f, -1.0f), Normal = new Vector3(0.0f, 0.0f, -1.0f), TexCoord = new Vector2(1.0f, 1.0f) },
            new Vertex { Position = new Vector3(-1.0f, 1.0f, -1.0f), Normal = new Vector3(0.0f, 0.0f, -1.0f), TexCoord = new Vector2(0.0f, 1.0f) },

            new Vertex { Position = new Vector3(-1.0f, -1.0f, 1.0f), Normal = new Vector3(0.0f, 0.0f, 1.0f), TexCoord = new Vector2(0.0f, 0.0f) },
            new Vertex { Position = new Vector3(1.0f, -1.0f, 1.0f), Normal = new Vector3(0.0f, 0.0f, 1.0f), TexCoord = new Vector2(1.0f, 0.0f) },
            new Vertex { Position = new Vector3(1.0f, 1.0f, 1.0f), Normal = new Vector3(0.0f, 0.0f, 1.0f), TexCoord = new Vector2(1.0f, 1.0f) },
            new Vertex { Position = new Vector3(-1.0f, 1.0f, 1.0f), Normal = new Vector3(0.0f, 0.0f, 1.0f), TexCoord = new Vector2(0.0f, 1.0f) },

            // vertices at camera exposure = 1.0 : slightly deform the Cube
            new Vertex { Position = new Vector3(-1.0f + shiftX, 1.0f, 1.0f), Normal = new Vector3(0.0f, 0.0f, 1.0f), TexCoord = new Vector2(0.0f, 1.0f) },
            new Vertex { Position = new Vector3(1.0f + shiftX, 1.0f + shiftY, 1.0f), Normal = new Vector3(0.0f, 0.0f, 1.0f), TexCoord = new Vector2(1.0f, 1.0f) },
            new Vertex { Position = new Vector3(1.0f + shiftX, 1.0f + shiftY, -1.0f), Normal = new Vector3(0.0f, 0.0f, -1.0f), TexCoord = new Vector2(1.0f, 0.0f) },
            new Vertex { Position = new Vector3(-1.0f + shiftX, 1.0f, -1.0f), Normal = new Vector3(0.0f, 0.0f, -1.0f), TexCoord = new Vector2(0.0f, 0.0f) },

            new Vertex { Position = new Vector3(-1.0f, -1.0f, -1.0f), Normal = new Vector3(0.0f, -1.0f, 0.0f), TexCoord = new Vector2(0.0f, 0.0f) },
            new Vertex { Position = new Vector3(1.0f, -1.0f, -1.0f), Normal = new Vector3(0.0f, -1.0f, 0.0f), TexCoord = new Vector2(1.0f, 0.0f) },
            new Vertex { Position = new Vector3(1.0f, -1.0f, 1.0f), Normal = new Vector3(0.0f, -1.0f, 0.0f), TexCoord = new Vector2(1.0f, 1.0f) },
            new Vertex { Position = new Vector3(-1.0f, -1.0f, 1.0f), Normal = new Vector3(0.0f, -1.0f, 0.0f), TexCoord = new Vector2(0.0f, 1.0f) },

            new Vertex { Position = new Vector3(-1.0f, -1.0f, 1.0f), Normal = new Vector3(-1.0f, 0.0f, 0.0f), TexCoord = new Vector2(0.0f, 0.0f) },
            new Vertex { Position = new Vector3(-1.0f, -1.0f, -1.0f), Normal = new Vector3(-1.0f, 0.0f, 0.0f), TexCoord = new Vector2(1.0f, 0.0f) },
            new Vertex { Position = new Vector3(-1.0f + shiftX, 1.0f, -1.0f), Normal = new Vector3(-1.0f, 0.0f, 0.0f), TexCoord = new Vector2(1.0f, 1.0f) },
            new Vertex { Position = new Vector3(-1.0f + shiftX, 1.0f, 1.0f), Normal = new Vector3(-1.0f, 0.0f, 0.0f), TexCoord = new Vector2(0.0f, 1.0f) },

            new Vertex { Position = new Vector3(1.0f, -1.0f, 1.0f), Normal = new Vector3(1.0f, 0.0f, 0.0f), TexCoord = new Vector2(0.0f, 0.0f) },
            new Vertex { Position = new Vector3(1.0f, -1.0f, -1.0f), Normal = new Vector3(1.0f, 0.0f, 0.0f), TexCoord = new Vector2(1.0f, 0.0f) },
            new Vertex { Position = new Vector3(1.0f + shiftX, 1.0f + shiftY, -1.0f), Normal = new Vector3(1.0f, 0.0f, 0.0f), TexCoord = new Vector2(1.0f, 1.0f) },
            new Vertex { Position = new Vector3(1.0f + shiftX, 1.0f + shiftY, 1.0f), Normal = new Vector3(1.0f, 0.0f, 0.0f), TexCoord = new Vector2(0.0f, 1.0f) },

            new Vertex { Position = new Vector3(-1.0f, -1.0f, -1.0f), Normal = new Vector3(0.0f, 0.0f, -1.0f), TexCoord = new Vector2(0.0f, 0.0f) },
            new Vertex { Position = new Vector3(1.0f, -1.0f, -1.0f), Normal = new Vector3(0.0f, 0.0f, -1.0f), TexCoord = new Vector2(1.0f, 0.0f) },
            new Vertex { Position = new Vector3(1.0f + shiftX, 1.0f + shiftY, -1.0f), Normal = new Vector3(0.0f, 0.0f, -1.0f), TexCoord = new Vector2(1.0f, 1.0f) },
            new Vertex { Position = new Vector3(-1.0f + shiftX, 1.0f, -1.0f), Normal = new Vector3(0.0f, 0.0f, -1.0f), TexCoord = new Vector2(0.0f, 1.0f) },

            new Vertex { Position = new Vector3(-1.0f, -1.0f, 1.0f), Normal = new Vector3(0.0f, 0.0f, 1.0f), TexCoord = new Vector2(0.0f, 0.0f) },
            new Vertex { Position = new Vector3(1.0f, -1.0f, 1.0f), Normal = new Vector3(0.0f, 0.0f, 1.0f), TexCoord = new Vector2(1.0f, 0.0f) },
            new Vertex { Position = new Vector3(1.0f + shiftX, 1.0f + shiftY, 1.0f), Normal = new Vector3(0.0f, 0.0f, 1.0f), TexCoord = new Vector2(1.0f, 1.0f) },
            new Vertex { Position = new Vector3(-1.0f + shiftX, 1.0f, 1.0f), Normal = new Vector3(0.0f, 0.0f, 1.0f), TexCoord = new Vector2(0.0f, 1.0f) }
        ];

        // Create cube mesh
        Shape cube;
        {
            // 0-terminated list of mesh extra properties.  (key+value)
            MeshInfo[] meshProperties = new MeshInfo[16];

            // first key: specify that we want to use mesh deformation on this rpr_shape.
            meshProperties[0] = MeshInfo.MotionDimension;

            // 2 key times are used in cube_data_motionBlur ( exposure = 0.0 and  exposure = 1.0 )
            // More key times can be used if needed, for example, 3 key times would mean :  exposure = 0.0; 0.5; 1.0
            meshProperties[1] = (MeshInfo)numberOfBlurKeyTime;

            // key=0 means end of mesh properties.
            meshProperties[2] = 0;

            int[] indices = RprHelper.CubeIndices;
            int[] numFaceVertices = RprHelper.CubeNumFaceVertices;

            fixed (int* indicesPtr = &indices[0])
            fixed (int* numFaceVerticesPtr = &numFaceVertices[0])
            fixed (Vertex* cubeDataMotionBlurPtr = &cubeDataMotionBlur[0])
            {
                float*[] texcoords = [(float*)((byte*)cubeDataMotionBlurPtr + Marshal.OffsetOf<Vertex>(nameof(Vertex.TexCoord)))];
                long[] numTexcoords = [cubeNumberOfVertices * numberOfBlurKeyTime];
                int[] texcoordStride = [sizeof(Vertex)];
                int*[] texcoordIndices = [indicesPtr];
                int[] tidxStride = [sizeof(int)];

                fixed (float** texcoordsPtr = &texcoords[0])
                fixed (long* numTexcoordsPtr = &numTexcoords[0])
                fixed (int* texcoordStridePtr = &texcoordStride[0])
                fixed (int** texcoordIndicesPtr = &texcoordIndices[0])
                fixed (int* tidxStridePtr = &tidxStride[0])
                fixed (MeshInfo* meshPropertiesPtr = &meshProperties[0])
                {
                    Rpr.ContextCreateMeshEx2(context,
                                             (float*)cubeDataMotionBlurPtr, cubeNumberOfVertices * numberOfBlurKeyTime, sizeof(Vertex),
                                             (float*)((byte*)cubeDataMotionBlurPtr + Marshal.OffsetOf<Vertex>(nameof(Vertex.Normal))), cubeNumberOfVertices * numberOfBlurKeyTime, sizeof(Vertex),
                                             null, 0, 0,
                                             1,
                                             texcoordsPtr, numTexcoordsPtr, texcoordStridePtr,
                                             indicesPtr, sizeof(int),
                                             indicesPtr, sizeof(int),
                                             texcoordIndicesPtr, texcoordStridePtr,
                                             numFaceVerticesPtr, 12, meshPropertiesPtr, out cube).CheckStatus();
                }
            }
        
            // Add cube to the scene
            Rpr.SceneAttachShape(scene, cube).CheckStatus();

            // Create a transform: -2 unit along X axis and 1 unit up Y axis
            Matrix4x4 transform = Matrix4x4.CreateTranslation(new Vector3(-2.0f, 1.0f, 0.0f));

            // Set the transform to the cube
            Rpr.ShapeSetTransform(cube, true, transform.ToArray(true)).CheckStatus();
        }

        // Create plane mesh
        Shape plane;
        {
            RprHelper.CreateMesh(context, RprHelper.Plane, RprHelper.PlaneIndices, RprHelper.PlaneNumFaceVertices, out plane).CheckStatus();

            // Add plane to the scene
            Rpr.SceneAttachShape(scene, plane).CheckStatus();
        }

        // Create a point light
        Light light;
        {
            Rpr.ContextCreatePointLight(context, out light).CheckStatus();

            // Create a transform: move 5 units in Y axis, 2 units in Z axis
            Matrix4x4 transform = Matrix4x4.CreateTranslation(new Vector3(0.0f, 8.0f, 2.0f));

            // Set the transform to the light
            Rpr.LightSetTransform(light, true, transform.ToArray(true)).CheckStatus();

            // Set light radiant power
            Rpr.PointLightSetRadiantPower3f(light, 200.0f, 200.0f, 200.0f).CheckStatus();

            // Add light to the scene
            Rpr.SceneAttachLight(scene, light).CheckStatus();
        }

        // apply material on cube
        MaterialNode diffuseA;
        MaterialNode diffuseB;
        MaterialNode uv_node;
        MaterialNode uv_scaled_node;
        MaterialNode checker;
        MaterialNode layered;
        {
            Rpr.MaterialSystemCreateNode(materialSystem, MaterialNodeType.Diffuse, out diffuseA).CheckStatus();
            Rpr.MaterialNodeSetInputFByKey(diffuseA, MaterialNodeInput.Color, 0.0f, 0.5f, 1.0f, 0.0f).CheckStatus();

            Rpr.MaterialSystemCreateNode(materialSystem, MaterialNodeType.Diffuse, out diffuseB).CheckStatus();
            Rpr.MaterialNodeSetInputFByKey(diffuseB, MaterialNodeInput.Color, 0.5f, 0.20f, 1.0f, 0.0f).CheckStatus();

            Rpr.MaterialSystemCreateNode(materialSystem, MaterialNodeType.InputLookup, out uv_node).CheckStatus();
            Rpr.MaterialNodeSetInputUByKey(uv_node, MaterialNodeInput.Value, (uint)MaterialNodeLookupValue.Uv).CheckStatus();

            Rpr.MaterialSystemCreateNode(materialSystem, MaterialNodeType.Arithmetic, out uv_scaled_node).CheckStatus();
            Rpr.MaterialNodeSetInputUByKey(uv_scaled_node, MaterialNodeInput.Op, (uint)MaterialNodeArithmeticOperation.Mul).CheckStatus();
            Rpr.MaterialNodeSetInputNByKey(uv_scaled_node, MaterialNodeInput.Color0, uv_node).CheckStatus();
            Rpr.MaterialNodeSetInputFByKey(uv_scaled_node, MaterialNodeInput.Color1, 0.7f, 0.7f, 0.0f, 0.0f).CheckStatus();

            Rpr.MaterialSystemCreateNode(materialSystem, MaterialNodeType.CheckerTexture, out checker).CheckStatus();
            Rpr.MaterialNodeSetInputNByKey(checker, MaterialNodeInput.Uv, uv_scaled_node).CheckStatus();

            // Create a layered material
            Rpr.MaterialSystemCreateNode(materialSystem, MaterialNodeType.Blend, out layered).CheckStatus();
            Rpr.MaterialNodeSetInputNByKey(layered, MaterialNodeInput.Color0, diffuseA).CheckStatus();
            Rpr.MaterialNodeSetInputNByKey(layered, MaterialNodeInput.Color1, diffuseB).CheckStatus();
            Rpr.MaterialNodeSetInputNByKey(layered, MaterialNodeInput.Weight, checker).CheckStatus();

            Rpr.ShapeSetMaterial(cube, layered).CheckStatus();
        }

        MaterialNode diffuseC;
        {
            Rpr.MaterialSystemCreateNode(materialSystem, MaterialNodeType.Diffuse, out diffuseC).CheckStatus();
            Rpr.MaterialNodeSetInputFByKey(diffuseC, MaterialNodeInput.Color, 1.0f, 0.2f, 0.0f, 0.0f).CheckStatus();

            Rpr.ShapeSetMaterial(plane, diffuseC).CheckStatus();
        }

        // set exposure for motion blur
        Rpr.CameraSetExposure(camera, 1.0f).CheckStatus();

        // Render the scene
        Rpr.ContextSetParameterByKey1f(context, ContextInfo.DisplayGamma, 2.2f).CheckStatus();
        Rpr.ContextSetParameterByKey1u(context, ContextInfo.Iterations, 200).CheckStatus();
        Rpr.FrameBufferClear(frame_buffer).CheckStatus();
        Rpr.ContextRender(context).CheckStatus();
        Rpr.ContextResolveFrameBuffer(context, frame_buffer, frame_buffer_resolved, false).CheckStatus();

        Console.WriteLine("Rendering finished.");

        // Save the result to file
        Rpr.FrameBufferSaveToFile(frame_buffer_resolved, "13_DeformationMotionBlur_00.png").CheckStatus();

        // Release the resources
        Rpr.ObjectDelete(camera).CheckStatus();
        Rpr.ObjectDelete(light).CheckStatus();
        Rpr.ObjectDelete(diffuseA).CheckStatus();
        Rpr.ObjectDelete(diffuseB).CheckStatus();
        Rpr.ObjectDelete(diffuseC).CheckStatus();
        Rpr.ObjectDelete(uv_node).CheckStatus();
        Rpr.ObjectDelete(uv_scaled_node).CheckStatus();
        Rpr.ObjectDelete(checker).CheckStatus();
        Rpr.ObjectDelete(layered).CheckStatus();
        Rpr.ObjectDelete(plane).CheckStatus();
        Rpr.ObjectDelete(cube).CheckStatus();
        Rpr.ObjectDelete(materialSystem).CheckStatus();
        Rpr.ObjectDelete(frame_buffer).CheckStatus();
        Rpr.ObjectDelete(frame_buffer_resolved).CheckStatus();
        Rpr.ObjectDelete(scene).CheckStatus();
        Rpr.ObjectDelete(context).CheckStatus();
    }
}

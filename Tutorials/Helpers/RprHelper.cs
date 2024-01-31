using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using RPRSharp;
using Silk.NET.Core.Native;
using Tutorials.Models;
using Assimp = Silk.NET.Assimp.Assimp;
using AssimpFace = Silk.NET.Assimp.Face;
using AssimpMesh = Silk.NET.Assimp.Mesh;
using AssimpNode = Silk.NET.Assimp.Node;
using AssimpScene = Silk.NET.Assimp.Scene;
using PostProcessSteps = Silk.NET.Assimp.PostProcessSteps;
using Scene = RPRSharp.Scene;

namespace Tutorials.Helpers;

public unsafe class RprHelper
{
    static RprHelper()
    {
        ContextProperties =
        [
            Int32ToContextProperties((int)ContextInfo.PrecompiledBinaryPath),
            StringToContextProperties(Path.Combine("AMD Radeon ProRender SDK", "hipbin")),
            Int32ToContextProperties(0)
        ];

        Northstar64 = Core.GetPlatform() switch
        {
            Platform.CentOS => Path.Combine("AMD Radeon ProRender SDK", "binCentOS7", "libNorthstar64.so"),
            Platform.Ubuntu => Path.Combine("AMD Radeon ProRender SDK", "binUbuntu20", "libNorthstar64.so"),
            Platform.MacOS => Path.Combine("AMD Radeon ProRender SDK", "binMacOS", "libNorthstar64.dylib"),
            Platform.Windows => Path.Combine("AMD Radeon ProRender SDK", "binWin64", "Northstar64.dll"),
            _ => string.Empty,
        };
    }

    public static ApiVersion ApiVersion => new(3, 1, 5);

    public static CreationFlags ContextCreationFlags => CreationFlags.EnableGpu1;

    public static ContextProperties[] ContextProperties { get; }

    public static string Northstar64 { get; }

    public static Vertex[] Cube =>
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
        new Vertex { Position = new Vector3(-1.0f, 1.0f, 1.0f), Normal = new Vector3(0.0f, 0.0f, 1.0f), TexCoord = new Vector2(0.0f, 1.0f) }
    ];

    public static int[] CubeIndices =>
    [
        .. new int[] { 3, 1, 0 },
        .. new int[] { 2, 1, 3 },

        .. new int[] { 6, 4, 5 },
        .. new int[] { 7, 4, 6 },

        .. new int[] { 11, 9, 8 },
        .. new int[] { 10, 9, 11 },

        .. new int[] { 14, 12, 13 },
        .. new int[] { 15, 12, 14 },

        .. new int[] { 19, 17, 16 },
        .. new int[] { 18, 17, 19 },

        .. new int[] { 22, 20, 21 },
        .. new int[] { 23, 20, 22 }
    ];

    public static int[] CubeNumFaceVertices => [3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3];

    public static Vertex[] Plane =>
    [
        new Vertex { Position = new Vector3(-15.0f, 0.0f, -15.0f), Normal = new Vector3(0.0f, 1.0f, 0.0f), TexCoord = new Vector2(0.0f, 1.0f) },
        new Vertex { Position = new Vector3(-15.0f, 0.0f, 15.0f), Normal = new Vector3(0.0f, 1.0f, 0.0f), TexCoord = new Vector2(0.0f, 0.0f) },
        new Vertex { Position = new Vector3(15.0f, 0.0f, 15.0f), Normal = new Vector3(0.0f, 1.0f, 0.0f), TexCoord = new Vector2(1.0f, 0.0f) },
        new Vertex { Position = new Vector3(15.0f, 0.0f, -15.0f), Normal = new Vector3(0.0f, 1.0f, 0.0f), TexCoord = new Vector2(1.0f, 1.0f) }
    ];

    public static int[] PlaneIndices =>
    [
        .. new int[] { 3, 1, 0 },
        .. new int[] { 2, 1, 3 }
    ];

    public static int[] PlaneNumFaceVertices => [3, 3];

    /// <summary>
    /// Convert simple data types based on ParameterType.
    /// </summary>
    /// <param name="parameterType">parameterType</param>
    /// <param name="bytes">bytes</param>
    /// <returns></returns>
    public static object? GetValue(ParameterType parameterType, byte[] bytes)
    {
        fixed (byte* bytesPtr = bytes)
        {
            return parameterType switch
            {
                ParameterType.Float => BitConverter.ToSingle(bytes),
                ParameterType.Float2 => new Vector2(BitConverter.ToSingle(bytes), BitConverter.ToSingle(bytes, 4)),
                ParameterType.Float3 => new Vector3(BitConverter.ToSingle(bytes), BitConverter.ToSingle(bytes, 4), BitConverter.ToSingle(bytes, 8)),
                ParameterType.Float4 => new Vector4(BitConverter.ToSingle(bytes), BitConverter.ToSingle(bytes, 4), BitConverter.ToSingle(bytes, 8), BitConverter.ToSingle(bytes, 12)),
                ParameterType.String => SilkMarshal.PtrToString((nint)bytesPtr),
                ParameterType.Uint => BitConverter.ToUInt32(bytes),
                ParameterType.Ulong => BitConverter.ToUInt64(bytes),
                ParameterType.Longlong => BitConverter.ToInt64(bytes),
                _ => bytes,
            };
        }
    }

    public static Status CreateMesh(Context context, Vertex[] vertices, int[] indices, int[] numFaceVertices, out Shape shape)
    {
        float* meshVertices = (float*)Unsafe.AsPointer(ref vertices[0]);
        float* meshNormals = (float*)((byte*)meshVertices + Marshal.OffsetOf<Vertex>(nameof(Vertex.Normal)));
        float* meshUVs = (float*)((byte*)meshVertices + Marshal.OffsetOf<Vertex>(nameof(Vertex.TexCoord)));
        int* meshIndices = (int*)Unsafe.AsPointer(ref indices[0]);
        int* meshNumVertices = (int*)Unsafe.AsPointer(ref numFaceVertices[0]);

        return Rpr.ContextCreateMesh(context,
                                     meshVertices, vertices.Length, sizeof(Vertex),
                                     meshNormals, vertices.Length, sizeof(Vertex),
                                     meshUVs, vertices.Length, sizeof(Vertex),
                                     meshIndices, sizeof(int),
                                     meshIndices, sizeof(int),
                                     meshIndices, sizeof(int),
                                     meshNumVertices, numFaceVertices.Length,
                                     out shape);
    }

    public static Status CreateAMDFloor(Context context, Scene scene, MaterialSystem matsys, RprGarbageCollector gc, float scaleX, float scaleY, float translationX = 0.0f, float translationY = 0.0f, float translationZ = 0.0f)
    {
        try
        {
            // Create a plane mesh
            Shape plane;
            {
                CreateMesh(context, Plane, PlaneIndices, PlaneNumFaceVertices, out plane).CheckStatus();
                gc.Add(plane);

                // Set the plane transform
                Matrix4x4 transform = Matrix4x4.CreateScale(scaleX, 1.0f, scaleY) * Matrix4x4.CreateTranslation(translationX, translationY, translationZ);
                Rpr.ShapeSetTransform(plane, true, transform.ToArray(true));

                // Attach the plane to the scene
                Rpr.SceneAttachShape(scene, plane);
            }

            // create a DIFFUSE material for the Floor
            {
                string pathImageFile = Path.Combine("Resources", "Textures", "amd.png");
                Rpr.ContextCreateImageFromFile(context, pathImageFile, out Image image).CheckStatus();
                gc.Add(image);

                Rpr.MaterialSystemCreateNode(matsys, MaterialNodeType.ImageTexture, out MaterialNode materialImage).CheckStatus();
                gc.Add(materialImage);
                Rpr.MaterialNodeSetInputImageDataByKey(materialImage, MaterialNodeInput.InputData, image);

                Rpr.MaterialSystemCreateNode(matsys, MaterialNodeType.Diffuse, out MaterialNode diffuse).CheckStatus();
                gc.Add(diffuse);
                Rpr.MaterialNodeSetInputNByKey(diffuse, MaterialNodeInput.InputColor, materialImage);

                Rpr.MaterialSystemCreateNode(matsys, MaterialNodeType.InputLookup, out MaterialNode uv_node).CheckStatus();
                gc.Add(uv_node);
                Rpr.MaterialNodeSetInputUByKey(uv_node, MaterialNodeInput.InputValue, (uint)MaterialNodeLookupValue.Uv);

                Rpr.MaterialSystemCreateNode(matsys, MaterialNodeType.Arithmetic, out MaterialNode uv_scaled_node).CheckStatus();
                gc.Add(uv_scaled_node);
                Rpr.MaterialNodeSetInputUByKey(uv_scaled_node, MaterialNodeInput.InputOp, (uint)MaterialNodeArithmeticOperation.OpMul).CheckStatus();
                Rpr.MaterialNodeSetInputNByKey(uv_scaled_node, MaterialNodeInput.InputColor0, uv_node).CheckStatus();
                Rpr.MaterialNodeSetInputFByKey(uv_scaled_node, MaterialNodeInput.InputColor1, 2.0f, 4.0f, 0.0f, 0.0f).CheckStatus();

                Rpr.MaterialNodeSetInputNByKey(materialImage, MaterialNodeInput.InputUv, uv_scaled_node).CheckStatus();

                Rpr.ShapeSetMaterial(plane, diffuse);
            }

            return Status.Success;
        }
        catch (Exception)
        {
            return Status.ErrorInvalidParameter;
        }
    }

    public static Status CreateNatureEnvLight(Context context, Scene scene, RprGarbageCollector gc, float power)
    {
        try
        {
            Rpr.ContextCreateEnvironmentLight(context, out Light lightEnv).CheckStatus();
            gc.Add(lightEnv);

            string pathImageFile = Path.Combine("Resources", "Textures", "turning_area_4k.hdr");
            Rpr.ContextCreateImageFromFile(context, pathImageFile, out Image imgEnvLight).CheckStatus();
            gc.Add(imgEnvLight);

            // Set an image for the Env light to take the radiance values from.
            Rpr.EnvironmentLightSetImage(lightEnv, imgEnvLight).CheckStatus();

            // adjust the intensity of the Env light.
            Rpr.EnvironmentLightSetIntensityScale(lightEnv, power).CheckStatus();

            // Set the Env light as the environment light of the scene.
            Rpr.SceneAttachLight(scene, lightEnv).CheckStatus();

            return Status.Success;
        }
        catch (Exception)
        {
            return Status.ErrorInvalidParameter;
        }
    }

    public static unsafe Status AssimpParsing(Context context, RprGarbageCollector gc, string file, out Shape[] shapes)
    {
        using Assimp importer = Assimp.GetApi();
        AssimpScene* assimpScene = importer.ImportFile(file, (uint)(PostProcessSteps.Triangulate | PostProcessSteps.GenerateNormals | PostProcessSteps.CalculateTangentSpace | PostProcessSteps.FlipUVs | PostProcessSteps.PreTransformVertices));

        List<Shape> meshes = [];

        ProcessNode(assimpScene->MRootNode);

        shapes = [.. meshes];

        return Status.Success;

        void ProcessNode(AssimpNode* node)
        {
            for (uint i = 0; i < node->MNumMeshes; i++)
            {
                AssimpMesh* mesh = assimpScene->MMeshes[node->MMeshes[i]];

                meshes.Add(ProcessMesh(mesh));
            }

            for (uint i = 0; i < node->MNumChildren; i++)
            {
                ProcessNode(node->MChildren[i]);
            }
        }

        Shape ProcessMesh(AssimpMesh* mesh)
        {
            Vertex[] vertices = new Vertex[mesh->MNumVertices];

            for (uint i = 0; i < mesh->MNumVertices; i++)
            {
                vertices[i].Position = (*&mesh->MVertices[i]);
                vertices[i].Normal = (*&mesh->MNormals[i]);

                if (mesh->MTextureCoords[0] != null)
                {
                    Vector3 texCoord = (*&mesh->MTextureCoords[0][i]);

                    vertices[i].TexCoord = new Vector2(texCoord.X, texCoord.Y);
                }
            }

            int[] indices = new int[mesh->MNumFaces * 3];
            int[] numFaceVertices = new int[mesh->MNumFaces];

            for (uint i = 0; i < mesh->MNumFaces; i++)
            {
                AssimpFace face = mesh->MFaces[i];

                for (uint j = 0; j < face.MNumIndices; j++)
                {
                    indices[i * 3 + j] = (int)face.MIndices[j];
                }

                numFaceVertices[i] = (int)face.MNumIndices;
            }

            CreateMesh(context, vertices, indices, numFaceVertices, out Shape shape);
            gc.Add(shape);

            return shape;
        }
    }

    public static float[] CameraLookAtToMatrix(Vector3 pos, Vector3 at, Vector3 up)
    {
        Vector3 dir = Vector3.Normalize(at - pos);
        Vector3 right = Vector3.Normalize(Vector3.Cross(dir, up));

        // Warning: For rprCameraSetMotionTransform, we need to make sure to have both 'right' and 'up2' correctly orthogonal to 'directionVector'
        //           otherwise it may result into bad blur rendering.
        Vector3 up2 = Vector3.Normalize(Vector3.Cross(right, dir));

        return
        [
            .. new float[] { right.X, right.Y, right.Z, 0.0f },
            .. new float[] { up2.X, up2.Y, up2.Z, 0.0f },
            .. new float[] { -dir.X, -dir.Y, -dir.Z, 0.0f },
            .. new float[] { pos.X, pos.Y, pos.Z, 1.0f }
        ];
    }

    public static ContextProperties Int32ToContextProperties(int i)
    {
        return new ContextProperties() { Handle = (void*)i };
    }

    public static ContextProperties StringToContextProperties(string str)
    {
        return new ContextProperties() { Handle = (void*)Marshal.StringToHGlobalAnsi(str) };
    }
}

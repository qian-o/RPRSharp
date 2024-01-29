using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using RPRSharp;
using RPRSharp.Enums;
using RPRSharp.Structs;
using Silk.NET.Core.Native;
using Tutorials.Models;

namespace Tutorials.Helpers;

public unsafe class RprHelper
{
    public static Vertex[] Cube =>
    [
        new Vertex { Pos = new Vector3(-1.0f, 1.0f, -1.0f), Norm = new Vector3(0.0f, 1.0f, 0.0f), Tex = new Vector2(0.0f, 0.0f) },
        new Vertex { Pos = new Vector3(1.0f, 1.0f, -1.0f), Norm = new Vector3(0.0f, 1.0f, 0.0f), Tex = new Vector2(1.0f, 0.0f) },
        new Vertex { Pos = new Vector3(1.0f, 1.0f, 1.0f), Norm = new Vector3(0.0f, 1.0f, 0.0f), Tex = new Vector2(1.0f, 1.0f) },
        new Vertex { Pos = new Vector3(-1.0f, 1.0f, 1.0f), Norm = new Vector3(0.0f, 1.0f, 0.0f), Tex = new Vector2(0.0f, 1.0f) },

        new Vertex { Pos = new Vector3(-1.0f, -1.0f, -1.0f), Norm = new Vector3(0.0f, -1.0f, 0.0f), Tex = new Vector2(0.0f, 0.0f) },
        new Vertex { Pos = new Vector3(1.0f, -1.0f, -1.0f), Norm = new Vector3(0.0f, -1.0f, 0.0f), Tex = new Vector2(1.0f, 0.0f) },
        new Vertex { Pos = new Vector3(1.0f, -1.0f, 1.0f), Norm = new Vector3(0.0f, -1.0f, 0.0f), Tex = new Vector2(1.0f, 1.0f) },
        new Vertex { Pos = new Vector3(-1.0f, -1.0f, 1.0f), Norm = new Vector3(0.0f, -1.0f, 0.0f), Tex = new Vector2(0.0f, 1.0f) },

        new Vertex { Pos = new Vector3(-1.0f, -1.0f, 1.0f), Norm = new Vector3(-1.0f, 0.0f, 0.0f), Tex = new Vector2(0.0f, 0.0f) },
        new Vertex { Pos = new Vector3(-1.0f, -1.0f, -1.0f), Norm = new Vector3(-1.0f, 0.0f, 0.0f), Tex = new Vector2(1.0f, 0.0f) },
        new Vertex { Pos = new Vector3(-1.0f, 1.0f, -1.0f), Norm = new Vector3(-1.0f, 0.0f, 0.0f), Tex = new Vector2(1.0f, 1.0f) },
        new Vertex { Pos = new Vector3(-1.0f, 1.0f, 1.0f), Norm = new Vector3(-1.0f, 0.0f, 0.0f), Tex = new Vector2(0.0f, 1.0f) },

        new Vertex { Pos = new Vector3(1.0f, -1.0f, 1.0f), Norm = new Vector3(1.0f, 0.0f, 0.0f), Tex = new Vector2(0.0f, 0.0f) },
        new Vertex { Pos = new Vector3(1.0f, -1.0f, -1.0f), Norm = new Vector3(1.0f, 0.0f, 0.0f), Tex = new Vector2(1.0f, 0.0f) },
        new Vertex { Pos = new Vector3(1.0f, 1.0f, -1.0f), Norm = new Vector3(1.0f, 0.0f, 0.0f), Tex = new Vector2(1.0f, 1.0f) },
        new Vertex { Pos = new Vector3(1.0f, 1.0f, 1.0f), Norm = new Vector3(1.0f, 0.0f, 0.0f), Tex = new Vector2(0.0f, 1.0f) },

        new Vertex { Pos = new Vector3(-1.0f, -1.0f, -1.0f), Norm = new Vector3(0.0f, 0.0f, -1.0f), Tex = new Vector2(0.0f, 0.0f) },
        new Vertex { Pos = new Vector3(1.0f, -1.0f, -1.0f), Norm = new Vector3(0.0f, 0.0f, -1.0f), Tex = new Vector2(1.0f, 0.0f) },
        new Vertex { Pos = new Vector3(1.0f, 1.0f, -1.0f), Norm = new Vector3(0.0f, 0.0f, -1.0f), Tex = new Vector2(1.0f, 1.0f) },
        new Vertex { Pos = new Vector3(-1.0f, 1.0f, -1.0f), Norm = new Vector3(0.0f, 0.0f, -1.0f), Tex = new Vector2(0.0f, 1.0f) },

        new Vertex { Pos = new Vector3(-1.0f, -1.0f, 1.0f), Norm = new Vector3(0.0f, 0.0f, 1.0f), Tex = new Vector2(0.0f, 0.0f) },
        new Vertex { Pos = new Vector3(1.0f, -1.0f, 1.0f), Norm = new Vector3(0.0f, 0.0f, 1.0f), Tex = new Vector2(1.0f, 0.0f) },
        new Vertex { Pos = new Vector3(1.0f, 1.0f, 1.0f), Norm = new Vector3(0.0f, 0.0f, 1.0f), Tex = new Vector2(1.0f, 1.0f) },
        new Vertex { Pos = new Vector3(-1.0f, 1.0f, 1.0f), Norm = new Vector3(0.0f, 0.0f, 1.0f), Tex = new Vector2(0.0f, 1.0f) }
    ];

    public static Vertex[] Plane =>
    [
        new Vertex { Pos = new Vector3(-15.0f, 0.0f, -15.0f), Norm = new Vector3(0.0f, 1.0f, 0.0f), Tex = new Vector2(0.0f, 1.0f) },
        new Vertex { Pos = new Vector3(-15.0f, 0.0f, 15.0f), Norm = new Vector3(0.0f, 1.0f, 0.0f), Tex = new Vector2(0.0f, 0.0f) },
        new Vertex { Pos = new Vector3(15.0f, 0.0f, 15.0f), Norm = new Vector3(0.0f, 1.0f, 0.0f), Tex = new Vector2(1.0f, 0.0f) },
        new Vertex { Pos = new Vector3(15.0f, 0.0f, -15.0f), Norm = new Vector3(0.0f, 1.0f, 0.0f), Tex = new Vector2(1.0f, 1.0f) }
    ];

    public static int[] Indices =>
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

    public static int[] NumFaceVertices => [3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3];

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
                ParameterType.FLOAT => BitConverter.ToSingle(bytes),
                ParameterType.FLOAT2 => new Vector2(BitConverter.ToSingle(bytes), BitConverter.ToSingle(bytes, 4)),
                ParameterType.FLOAT3 => new Vector3(BitConverter.ToSingle(bytes), BitConverter.ToSingle(bytes, 4), BitConverter.ToSingle(bytes, 8)),
                ParameterType.FLOAT4 => new Vector4(BitConverter.ToSingle(bytes), BitConverter.ToSingle(bytes, 4), BitConverter.ToSingle(bytes, 8), BitConverter.ToSingle(bytes, 12)),
                ParameterType.STRING => SilkMarshal.PtrToString((nint)bytesPtr),
                ParameterType.UINT => BitConverter.ToUInt32(bytes),
                ParameterType.ULONG => BitConverter.ToUInt64(bytes),
                ParameterType.LONGLONG => BitConverter.ToInt64(bytes),
                _ => bytes,
            };
        }
    }

    public static Status CreateMesh(Context context, Vertex[] vertices, int[] indices, int[] numFaceVertices, out Shape shape)
    {
        float* cubeVertices = (float*)Unsafe.AsPointer(ref vertices[0]);
        float* cubeNormals = (float*)((byte*)cubeVertices + Marshal.OffsetOf<Vertex>(nameof(Vertex.Norm)));
        float* cubeUVs = (float*)((byte*)cubeVertices + Marshal.OffsetOf<Vertex>(nameof(Vertex.Tex)));
        int* cubeIndices = (int*)Unsafe.AsPointer(ref indices[0]);
        int* cubeNumVertices = (int*)Unsafe.AsPointer(ref numFaceVertices[0]);

        return Rpr.ContextCreateMesh(context,
                                     cubeVertices, vertices.Length, sizeof(Vertex),
                                     cubeNormals, vertices.Length, sizeof(Vertex),
                                     cubeUVs, vertices.Length, sizeof(Vertex),
                                     cubeIndices, sizeof(int),
                                     cubeIndices, sizeof(int),
                                     cubeIndices, sizeof(int),
                                     cubeNumVertices, numFaceVertices.Length,
                                     out shape);
    }

    public static Status CreateAMDFloor(Context context, Scene scene, MaterialSystem matsys, RprGarbageCollector gc, float scaleX, float scaleY, float translationX, float translationY, float translationZ)
    {
        try
        {
            // Create a plane mesh
            Shape plane;
            {
                CreateMesh(context, Plane, Indices, NumFaceVertices, out plane).CheckStatus();
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

                Rpr.MaterialSystemCreateNode(matsys, MaterialNodeType.IMAGE_TEXTURE, out MaterialNode materialImage).CheckStatus();
                gc.Add(materialImage);
                Rpr.MaterialNodeSetInputImageDataByKey(materialImage, MaterialNodeInput.DATA, image);

                Rpr.MaterialSystemCreateNode(matsys, MaterialNodeType.DIFFUSE, out MaterialNode diffuse).CheckStatus();
                gc.Add(diffuse);
                Rpr.MaterialNodeSetInputNByKey(diffuse, MaterialNodeInput.COLOR, materialImage);

                Rpr.MaterialSystemCreateNode(matsys, MaterialNodeType.INPUT_LOOKUP, out MaterialNode uv_node).CheckStatus();
                gc.Add(uv_node);
                Rpr.MaterialNodeSetInputUByKey(uv_node, MaterialNodeInput.VALUE, (uint)MaterialNodeLookup.UV);

                Rpr.MaterialSystemCreateNode(matsys, MaterialNodeType.ARITHMETIC, out MaterialNode uv_scaled_node).CheckStatus();
                gc.Add(uv_scaled_node);
                Rpr.MaterialNodeSetInputUByKey(uv_scaled_node, MaterialNodeInput.OP, (uint)MaterialNodeOp.MUL).CheckStatus();
                Rpr.MaterialNodeSetInputNByKey(uv_scaled_node, MaterialNodeInput.COLOR0, uv_node).CheckStatus();
                Rpr.MaterialNodeSetInputFByKey(uv_scaled_node, MaterialNodeInput.COLOR1, 2.0f, 4.0f, 0.0f, 0.0f).CheckStatus();

                Rpr.MaterialNodeSetInputNByKey(materialImage, MaterialNodeInput.UV, uv_scaled_node).CheckStatus();

                Rpr.ShapeSetMaterial(plane, diffuse);
            }

            return Status.SUCCESS;
        }
        catch (Exception)
        {
            return Status.ERROR_INVALID_PARAMETER;
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

            return Status.SUCCESS;
        }
        catch (Exception)
        {
            return Status.ERROR_INVALID_PARAMETER;
        }
    }
}

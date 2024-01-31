using System.Reflection;
using Silk.NET.Core.Native;

namespace RPRSharp;

public static unsafe partial class Rpr
{
    public const int ObjectName = 0x777777;
    public const int ObjectUniqueId = 0x777778;
    public const int ObjectCustomPtr = 0x777779;
    public const int InstanceParentShape = 0x1601;

    public static int RegisterPlugin(string path)
    {
        char* ptr1 = (char*)SilkMarshal.StringToPtr(path);

        int pluginId = rprRegisterPlugin(ptr1);

        SilkMarshal.Free((nint)ptr1);

        return pluginId;
    }

    public static Status CreateContext(ApiVersion apiVersion, int[] pluginIDs, long pluginCount, CreationFlags creationFlags, ContextProperties[] props, string cachePath, out Context context)
    {
        uint version = apiVersion.Major << 20 | apiVersion.Minor << 8 | apiVersion.Revision;

        fixed (int* ptr1 = pluginIDs)
        fixed (ContextProperties* ptr2 = props)
        fixed (Context* ptr3 = &context)
        {
            char* ptr4 = (char*)SilkMarshal.StringToPtr(cachePath);

            Status status = rprCreateContext(version, ptr1, pluginCount, (uint)creationFlags, ptr2, ptr4, ptr3);

            SilkMarshal.Free((nint)ptr4);

            return status;
        }
    }

    public static Status ContextSetActivePlugin(Context context, int pluginID)
    {
        return rprContextSetActivePlugin(context, pluginID);
    }

    public static Status ContextGetInfo(Context context, ContextInfo contextInfo, long size, void* data, out long sizeRet)
    {
        fixed (long* ptr1 = &sizeRet)
        {
            return rprContextGetInfo(context, contextInfo, size, data, ptr1);
        }
    }

    public static Status ContextGetParameterInfo(Context context, int paramIdx, ParameterInfo parameterInfo, long size, void* data, out long sizeRet)
    {
        fixed (long* ptr1 = &sizeRet)
        {
            return rprContextGetParameterInfo(context, paramIdx, parameterInfo, size, data, ptr1);
        }
    }

    public static Status ContextGetAOV(Context context, Aov aov, out Framebuffer framebuffer)
    {
        fixed (Framebuffer* ptr1 = &framebuffer)
        {
            return rprContextGetAOV(context, aov, ptr1);
        }
    }

    public static Status ContextSetAOV(Context context, Aov aov, Framebuffer frameBuffer)
    {
        return rprContextSetAOV(context, aov, frameBuffer);
    }

    public static Status ContextAttachRenderLayer(Context context, string renderLayerString)
    {
        char* ptr1 = (char*)SilkMarshal.StringToPtr(renderLayerString);

        Status status = rprContextAttachRenderLayer(context, ptr1);

        SilkMarshal.Free((nint)ptr1);

        return status;
    }

    public static Status ContextDetachRenderLayer(Context context, string renderLayerString)
    {
        char* ptr1 = (char*)SilkMarshal.StringToPtr(renderLayerString);

        Status status = rprContextDetachRenderLayer(context, ptr1);

        SilkMarshal.Free((nint)ptr1);

        return status;
    }

    public static Status FrameBufferSetLPE(Framebuffer frame_buffer, string lpe)
    {
        char* ptr1 = (char*)SilkMarshal.StringToPtr(lpe);

        Status status = rprFrameBufferSetLPE(frame_buffer, ptr1);

        SilkMarshal.Free((nint)ptr1);

        return status;
    }

    public static Status ContextSetAOVindexLookup(Context context, int key, float colorR, float colorG, float colorB, float colorA)
    {
        return rprContextSetAOVindexLookup(context, key, colorR, colorG, colorB, colorA);
    }

    public static Status ContextSetCuttingPlane(Context context, int index, float a, float b, float c, float d)
    {
        return rprContextSetCuttingPlane(context, index, a, b, c, d);
    }

    public static Status ContextSetAOVindicesLookup(Context context, int keyOffset, int keyCount, float[] colorRGBA)
    {
        fixed (float* ptr1 = colorRGBA)
        {
            return rprContextSetAOVindicesLookup(context, keyOffset, keyCount, ptr1);
        }
    }

    public static Status ContextSetUserTexture(Context context, int index, string gpuCode, void* cpuCode)
    {
        char* ptr1 = (char*)SilkMarshal.StringToPtr(gpuCode);

        Status status = rprContextSetUserTexture(context, index, ptr1, cpuCode);

        SilkMarshal.Free((nint)ptr1);

        return status;
    }

    public static Status ContextGetUserTexture(Context context, int index, long bufferSizeByte, void* buffer, out long sizeRet)
    {
        fixed (long* ptr1 = &sizeRet)
        {
            return rprContextGetUserTexture(context, index, bufferSizeByte, buffer, ptr1);
        }
    }

    public static Status ContextSetScene(Context context, Scene scene)
    {
        return rprContextSetScene(context, scene);
    }

    public static Status ContextGetScene(Context context, out Scene scene)
    {
        fixed (Scene* ptr1 = &scene)
        {
            return rprContextGetScene(context, ptr1);
        }
    }

    public static Status ContextSetParameterByKey1u(Context context, ContextInfo inInput, uint x)
    {
        return rprContextSetParameterByKey1u(context, inInput, x);
    }

    public static Status ContextSetParameterByKeyPtr(Context context, ContextInfo inInput, void* x)
    {
        return rprContextSetParameterByKeyPtr(context, inInput, x);
    }

    public static Status ContextSetParameterByKey1f(Context context, ContextInfo inInput, float x)
    {
        return rprContextSetParameterByKey1f(context, inInput, x);
    }

    public static Status ContextSetParameterByKey3f(Context context, ContextInfo inInput, float x, float y, float z)
    {
        return rprContextSetParameterByKey3f(context, inInput, x, y, z);
    }

    public static Status ContextSetParameterByKey4f(Context context, ContextInfo inInput, float x, float y, float z, float w)
    {
        return rprContextSetParameterByKey4f(context, inInput, x, y, z, w);
    }

    public static Status ContextSetParameterByKeyString(Context context, ContextInfo inInput, string value)
    {
        char* ptr1 = (char*)SilkMarshal.StringToPtr(value);

        Status status = rprContextSetParameterByKeyString(context, inInput, ptr1);

        SilkMarshal.Free((nint)ptr1);

        return status;
    }

    public static Status ContextSetInternalParameter4f(Context context, uint pluginIndex, string paramName, float x, float y, float z, float w)
    {
        char* ptr1 = (char*)SilkMarshal.StringToPtr(paramName);

        Status status = rprContextSetInternalParameter4f(context, pluginIndex, ptr1, x, y, z, w);

        SilkMarshal.Free((nint)ptr1);

        return status;
    }

    public static Status ContextSetInternalParameter1u(Context context, uint pluginIndex, string paramName, uint x)
    {
        char* ptr1 = (char*)SilkMarshal.StringToPtr(paramName);

        Status status = rprContextSetInternalParameter1u(context, pluginIndex, ptr1, x);

        SilkMarshal.Free((nint)ptr1);

        return status;
    }

    public static Status ContextSetInternalParameterBuffer(Context context, uint pluginIndex, string paramName, void* buffer, long bufferSizeByte)
    {
        char* ptr1 = (char*)SilkMarshal.StringToPtr(paramName);

        Status status = rprContextSetInternalParameterBuffer(context, pluginIndex, ptr1, buffer, bufferSizeByte);

        SilkMarshal.Free((nint)ptr1);

        return status;
    }

    public static Status ContextGetInternalParameter4f(Context context, uint pluginIndex, string paramName, float* x, float* y, float* z, float* w)
    {
        char* ptr1 = (char*)SilkMarshal.StringToPtr(paramName);

        Status status = rprContextGetInternalParameter4f(context, pluginIndex, ptr1, x, y, z, w);

        SilkMarshal.Free((nint)ptr1);

        return status;
    }

    public static Status ContextGetInternalParameter1u(Context context, uint pluginIndex, string paramName, uint* x)
    {
        char* ptr1 = (char*)SilkMarshal.StringToPtr(paramName);

        Status status = rprContextGetInternalParameter1u(context, pluginIndex, ptr1, x);

        SilkMarshal.Free((nint)ptr1);

        return status;
    }

    public static Status ContextGetInternalParameterBuffer(Context context, uint pluginIndex, string paramName, long bufferSizeByte, void* buffer, out long sizeRet)
    {
        char* ptr1 = (char*)SilkMarshal.StringToPtr(paramName);
        fixed (long* ptr2 = &sizeRet)
        {
            Status status = rprContextGetInternalParameterBuffer(context, pluginIndex, ptr1, bufferSizeByte, buffer, ptr2);

            SilkMarshal.Free((nint)ptr1);

            return status;
        }
    }

    public static Status ContextRender(Context context)
    {
        return rprContextRender(context);
    }

    public static Status ContextAbortRender(Context context)
    {
        return rprContextAbortRender(context);
    }

    public static Status ContextRenderTile(Context context, uint xmin, uint xmax, uint ymin, uint ymax)
    {
        return rprContextRenderTile(context, xmin, xmax, ymin, ymax);
    }

    public static Status ContextClearMemory(Context context)
    {
        return rprContextClearMemory(context);
    }

    public static Status ContextCreateImage(Context context, ImageFormat format, ImageDesc imageDesc, void* data, out Image image)
    {
        fixed (Image* ptr1 = &image)
        {
            return rprContextCreateImage(context, format, &imageDesc, data, ptr1);
        }
    }

    public static Status ContextCreateBuffer(Context context, BufferDesc bufferDesc, void* data, out Buffer buffer)
    {
        fixed (Buffer* ptr1 = &buffer)
        {
            return rprContextCreateBuffer(context, &bufferDesc, data, ptr1);
        }
    }

    public static Status ContextCreateImageFromFile(Context context, string path, out Image image)
    {
        char* ptr1 = (char*)SilkMarshal.StringToPtr(path);
        fixed (Image* ptr2 = &image)
        {
            Status status = rprContextCreateImageFromFile(context, ptr1, ptr2);

            SilkMarshal.Free((nint)ptr1);

            return status;
        }
    }

    public static Status ContextCreateImageFromFileMemory(Context context, string extension, void* data, long dataSizeByte, out Image image)
    {
        char* ptr1 = (char*)SilkMarshal.StringToPtr(extension);
        fixed (Image* ptr2 = &image)
        {
            Status status = rprContextCreateImageFromFileMemory(context, ptr1, data, dataSizeByte, ptr2);

            SilkMarshal.Free((nint)ptr1);

            return status;
        }
    }

    public static Status ContextCreateScene(Context context, out Scene scene)
    {
        fixed (Scene* ptr1 = &scene)
        {
            return rprContextCreateScene(context, ptr1);
        }
    }

    public static Status ContextCreateInstance(Context context, Shape shape, out Shape instance)
    {
        fixed (Shape* ptr1 = &instance)
        {
            return rprContextCreateInstance(context, shape, ptr1);
        }
    }

    public static Status ContextCreateMesh(Context context, float* vertices, long numVertices, int vertexStride, float* normals, long numNormals, int normalStride, float* texcoords, long numTexcoords, int texcoordStride, int* vertexIndices, int vidxStride, int* normalIndices, int nidxStride, int* texcoordIndices, int tidxStride, int* numFaceVertices, long numFaces, out Shape mesh)
    {
        fixed (Shape* ptr1 = &mesh)
        {
            return rprContextCreateMesh(context, vertices, numVertices, vertexStride, normals, numNormals, normalStride, texcoords, numTexcoords, texcoordStride, vertexIndices, vidxStride, normalIndices, nidxStride, texcoordIndices, tidxStride, numFaceVertices, numFaces, ptr1);
        }
    }

    public static Status ContextCreateMeshEx(Context context, float* vertices, long numVertices, int vertexStride, float* normals, long numNormals, int normalStride, int* perVertexFlag, long numPerVertexFlags, int perVertexFlagStride, int numberOfTexCoordLayers, float** texcoords, long* numTexcoords, int* texcoordStride, int* vertexIndices, int vidxStride, int* normalIndices, int nidxStride, int** texcoordIndices, int* tidxStride, int* numFaceVertices, long numFaces, out Shape mesh)
    {
        fixed (Shape* ptr1 = &mesh)
        {
            return rprContextCreateMeshEx(context, vertices, numVertices, vertexStride, normals, numNormals, normalStride, perVertexFlag, numPerVertexFlags, perVertexFlagStride, numberOfTexCoordLayers, texcoords, numTexcoords, texcoordStride, vertexIndices, vidxStride, normalIndices, nidxStride, texcoordIndices, tidxStride, numFaceVertices, numFaces, ptr1);
        }
    }

    public static Status ContextCreateMeshEx2(Context context, float* vertices, long numVertices, int vertexStride, float* normals, long numNormals, int normalStride, int* perVertexFlag, long numPerVertexFlags, int perVertexFlagStride, int numberOfTexCoordLayers, float** texcoords, long* numTexcoords, int* texcoordStride, int* vertexIndices, int vidxStride, int* normalIndices, int nidxStride, int** texcoordIndices, int* tidxStride, int* numFaceVertices, long numFaces, MeshInfo meshProperties, out Shape mesh)
    {
        fixed (Shape* ptr1 = &mesh)
        {
            return rprContextCreateMeshEx2(context, vertices, numVertices, vertexStride, normals, numNormals, normalStride, perVertexFlag, numPerVertexFlags, perVertexFlagStride, numberOfTexCoordLayers, texcoords, numTexcoords, texcoordStride, vertexIndices, vidxStride, normalIndices, nidxStride, texcoordIndices, tidxStride, numFaceVertices, numFaces, &meshProperties, ptr1);
        }
    }

    public static Status ContextCreateCamera(Context context, out Camera camera)
    {
        fixed (Camera* ptr1 = &camera)
        {
            return rprContextCreateCamera(context, ptr1);
        }
    }

    public static Status ContextCreateFrameBuffer(Context context, FramebufferFormat fbFormat, FramebufferDesc fbDesc, out Framebuffer frameBuffer)
    {
        fixed (Framebuffer* ptr1 = &frameBuffer)
        {
            return rprContextCreateFrameBuffer(context, fbFormat, &fbDesc, ptr1);
        }
    }

    public static Status ContextGetFunctionPtr(Context context, string functionName, out nint outFunctionPtr)
    {
        char* ptr1 = (char*)SilkMarshal.StringToPtr(functionName);
        fixed (nint* ptr2 = &outFunctionPtr)
        {
            Status status = rprContextGetFunctionPtr(context, ptr1, (void**)ptr2);

            SilkMarshal.Free((nint)ptr1);

            return status;
        }
    }

    public static Status CameraGetInfo(Camera camera, CameraInfo cameraInfo, long size, void* data, out long sizeRet)
    {
        fixed (long* ptr1 = &sizeRet)
        {
            return rprCameraGetInfo(camera, cameraInfo, size, data, ptr1);
        }
    }

    public static Status CameraSetFocalLength(Camera camera, float flength)
    {
        return rprCameraSetFocalLength(camera, flength);
    }

    public static Status CameraSetMotionTransformCount(Camera camera, uint transformCount)
    {
        return rprCameraSetMotionTransformCount(camera, transformCount);
    }

    public static Status CameraSetMotionTransform(Camera camera, bool transpose, float[] transform, uint timeIndex)
    {
        fixed (float* ptr1 = transform)
        {
            return rprCameraSetMotionTransform(camera, transpose, ptr1, timeIndex);
        }
    }

    public static Status CameraSetFocusDistance(Camera camera, float fdist)
    {
        return rprCameraSetFocusDistance(camera, fdist);
    }

    public static Status CameraSetTransform(Camera camera, bool transpose, float[] transform)
    {
        fixed (float* ptr1 = transform)
        {
            return rprCameraSetTransform(camera, transpose, ptr1);
        }
    }

    public static Status CameraSetSensorSize(Camera camera, float width, float height)
    {
        return rprCameraSetSensorSize(camera, width, height);
    }

    public static Status CameraLookAt(Camera camera, float posx, float posy, float posz, float atx, float aty, float atz, float upx, float upy, float upz)
    {
        return rprCameraLookAt(camera, posx, posy, posz, atx, aty, atz, upx, upy, upz);
    }

    public static Status CameraSetFStop(Camera camera, float fstop)
    {
        return rprCameraSetFStop(camera, fstop);
    }

    public static Status CameraSetApertureBlades(Camera camera, uint numBlades)
    {
        return rprCameraSetApertureBlades(camera, numBlades);
    }

    public static Status CameraSetExposure(Camera camera, float exposure)
    {
        return rprCameraSetExposure(camera, exposure);
    }

    public static Status CameraSetMode(Camera camera, CameraMode mode)
    {
        return rprCameraSetMode(camera, mode);
    }

    public static Status CameraSetOrthoWidth(Camera camera, float width)
    {
        return rprCameraSetOrthoWidth(camera, width);
    }

    public static Status CameraSetFocalTilt(Camera camera, float tilt)
    {
        return rprCameraSetFocalTilt(camera, tilt);
    }

    public static Status CameraSetIPD(Camera camera, float ipd)
    {
        return rprCameraSetIPD(camera, ipd);
    }

    public static Status CameraSetLensShift(Camera camera, float shiftx, float shifty)
    {
        return rprCameraSetLensShift(camera, shiftx, shifty);
    }

    public static Status CameraSetTiltCorrection(Camera camera, float tiltX, float tiltY)
    {
        return rprCameraSetTiltCorrection(camera, tiltX, tiltY);
    }

    public static Status CameraSetOrthoHeight(Camera camera, float height)
    {
        return rprCameraSetOrthoHeight(camera, height);
    }

    public static Status CameraSetNearPlane(Camera camera, float near)
    {
        return rprCameraSetNearPlane(camera, near);
    }

    public static Status CameraSetPostScale(Camera camera, float scale)
    {
        return rprCameraSetPostScale(camera, scale);
    }

    public static Status CameraSetFarPlane(Camera camera, float far)
    {
        return rprCameraSetFarPlane(camera, far);
    }

    public static Status CameraSetUVDistortion(Camera camera, Image distortionMap)
    {
        return rprCameraSetUVDistortion(camera, distortionMap);
    }

    public static Status ImageGetInfo(Image image, ImageInfo image_info, long size, void* data, out long sizeRet)
    {
        fixed (long* ptr1 = &sizeRet)
        {
            return rprImageGetInfo(image, image_info, size, data, ptr1);
        }
    }

    public static Status ImageSetWrap(Image image, ImageWrapType type)
    {
        return rprImageSetWrap(image, type);
    }

    public static Status ImageSetInternalCompression(Image image, uint compressionEnabled)
    {
        return rprImageSetInternalCompression(image, compressionEnabled);
    }

    public static Status ImageSetOcioColorspace(Image image, string ocioColorspace)
    {
        char* ptr1 = (char*)SilkMarshal.StringToPtr(ocioColorspace);

        Status status = rprImageSetOcioColorspace(image, ptr1);

        SilkMarshal.Free((nint)ptr1);

        return status;
    }

    public static Status ImageSetUDIM(Image imageUdimRoot, uint tileIndex, Image imageTile)
    {
        return rprImageSetUDIM(imageUdimRoot, tileIndex, imageTile);
    }

    public static Status ImageSetFilter(Image image, ImageFilterType type)
    {
        return rprImageSetFilter(image, type);
    }

    public static Status ImageSetGamma(Image image, float type)
    {
        return rprImageSetGamma(image, type);
    }

    public static Status ImageSetMipmapEnabled(Image image, bool enabled)
    {
        return rprImageSetMipmapEnabled(image, enabled);
    }

    public static Status ShapeSetTransform(Shape shape, bool transpose, float[] transform)
    {
        fixed (float* ptr1 = transform)
        {
            return rprShapeSetTransform(shape, transpose, ptr1);
        }
    }

    public static Status ShapeSetVertexValue(Shape in_shape, int setIndex, int[] indices, float[] values, int indicesCount)
    {
        fixed (int* ptr1 = indices)
        fixed (float* ptr2 = values)
        {
            return rprShapeSetVertexValue(in_shape, setIndex, ptr1, ptr2, indicesCount);
        }
    }

    public static Status ShapeSetPrimvar(Shape in_shape, uint key, float[] data, uint floatCount, uint componentCount, PrimvarInterpolationType interop)
    {
        fixed (float* ptr1 = data)
        {
            return rprShapeSetPrimvar(in_shape, key, ptr1, floatCount, componentCount, interop);
        }
    }

    public static Status ShapeSetSubdivisionFactor(Shape shape, uint factor)
    {
        return rprShapeSetSubdivisionFactor(shape, factor);
    }

    public static Status ShapeSetSubdivisionAutoRatioCap(Shape shape, float autoRatioCap)
    {
        return rprShapeSetSubdivisionAutoRatioCap(shape, autoRatioCap);
    }

    public static Status ShapeSetSubdivisionCreaseWeight(Shape shape, float factor)
    {
        return rprShapeSetSubdivisionCreaseWeight(shape, factor);
    }

    public static Status ShapeAttachRenderLayer(Shape shape, string renderLayerString)
    {
        char* ptr1 = (char*)SilkMarshal.StringToPtr(renderLayerString);

        Status status = rprShapeAttachRenderLayer(shape, ptr1);

        SilkMarshal.Free((nint)ptr1);

        return status;
    }

    public static Status ShapeDetachRenderLayer(Shape shape, string renderLayerString)
    {
        char* ptr1 = (char*)SilkMarshal.StringToPtr(renderLayerString);

        Status status = rprShapeDetachRenderLayer(shape, ptr1);

        SilkMarshal.Free((nint)ptr1);

        return status;
    }

    public static Status LightAttachRenderLayer(Light light, string renderLayerString)
    {
        char* ptr1 = (char*)SilkMarshal.StringToPtr(renderLayerString);

        Status status = rprLightAttachRenderLayer(light, ptr1);

        SilkMarshal.Free((nint)ptr1);

        return status;
    }

    public static Status LightDetachRenderLayer(Light light, string renderLayerString)
    {
        char* ptr1 = (char*)SilkMarshal.StringToPtr(renderLayerString);

        Status status = rprLightDetachRenderLayer(light, ptr1);

        SilkMarshal.Free((nint)ptr1);

        return status;
    }

    public static Status ShapeSetSubdivisionBoundaryInterop(Shape shape, SubdivBoundaryInterfopType type)
    {
        return rprShapeSetSubdivisionBoundaryInterop(shape, type);
    }

    public static Status ShapeAutoAdaptSubdivisionFactor(Shape shape, Framebuffer framebuffer, Camera camera, int factor)
    {
        return rprShapeAutoAdaptSubdivisionFactor(shape, framebuffer, camera, factor);
    }

    public static Status ShapeSetDisplacementScale(Shape shape, float minscale, float maxscale)
    {
        return rprShapeSetDisplacementScale(shape, minscale, maxscale);
    }

    public static Status ShapeSetObjectGroupID(Shape shape, uint objectGroupID)
    {
        return rprShapeSetObjectGroupID(shape, objectGroupID);
    }

    public static Status ShapeSetObjectID(Shape shape, uint objectID)
    {
        return rprShapeSetObjectID(shape, objectID);
    }

    public static Status ShapeSetLightGroupID(Shape shape, uint lightGroupID)
    {
        return rprShapeSetLightGroupID(shape, lightGroupID);
    }

    public static Status ShapeSetLayerMask(Shape shape, uint layerMask)
    {
        return rprShapeSetLayerMask(shape, layerMask);
    }

    public static Status ShapeSetDisplacementMaterial(Shape shape, MaterialNode materialNode)
    {
        return rprShapeSetDisplacementMaterial(shape, materialNode);
    }

    public static Status ShapeSetMaterial(Shape shape, MaterialNode node)
    {
        return rprShapeSetMaterial(shape, node);
    }

    public static Status ShapeSetMaterialFaces(Shape shape, MaterialNode node, int[] faceIndices, long numFaces)
    {
        fixed (int* ptr1 = faceIndices)
        {
            return rprShapeSetMaterialFaces(shape, node, ptr1, numFaces);
        }
    }

    public static Status ShapeSetVolumeMaterial(Shape shape, MaterialNode node)
    {
        return rprShapeSetVolumeMaterial(shape, node);
    }

    public static Status ShapeSetMotionTransformCount(Shape shape, uint transformCount)
    {
        return rprShapeSetMotionTransformCount(shape, transformCount);
    }

    public static Status ShapeSetMotionTransform(Shape shape, bool transpose, float[] transform, uint timeIndex)
    {
        fixed (float* ptr1 = transform)
        {
            return rprShapeSetMotionTransform(shape, transpose, ptr1, timeIndex);
        }
    }

    public static Status ShapeSetVisibilityFlag(Shape shape, ShapeInfo visibilityFlag, bool visible)
    {
        return rprShapeSetVisibilityFlag(shape, visibilityFlag, visible);
    }

    public static Status CurveSetVisibilityFlag(Curve curve, CurveParameter visibilityFlag, bool visible)
    {
        return rprCurveSetVisibilityFlag(curve, visibilityFlag, visible);
    }

    public static Status ShapeSetVisibility(Shape shape, bool visible)
    {
        return rprShapeSetVisibility(shape, visible);
    }

    public static Status LightSetVisibilityFlag(Light light, LightInfo visibilityFlag, bool visible)
    {
        return rprLightSetVisibilityFlag(light, visibilityFlag, visible);
    }

    public static Status CurveSetVisibility(Curve curve, bool visible)
    {
        return rprCurveSetVisibility(curve, visible);
    }

    public static Status ShapeSetVisibilityInSpecular(Shape shape, bool visible)
    {
        return rprShapeSetVisibilityInSpecular(shape, visible);
    }

    public static Status ShapeSetShadowCatcher(Shape shape, bool shadowCatcher)
    {
        return rprShapeSetShadowCatcher(shape, shadowCatcher);
    }

    public static Status ShapeSetShadowColor(Shape shape, float r, float g, float b)
    {
        return rprShapeSetShadowColor(shape, r, g, b);
    }

    public static Status ShapeSetReflectionCatcher(Shape shape, bool reflectionCatcher)
    {
        return rprShapeSetReflectionCatcher(shape, reflectionCatcher);
    }

    public static Status ShapeSetContourIgnore(Shape shape, bool ignoreInContour)
    {
        return rprShapeSetContourIgnore(shape, ignoreInContour);
    }

    public static Status ShapeSetEnvironmentLight(Shape shape, bool envLight)
    {
        return rprShapeSetEnvironmentLight(shape, envLight);
    }

    public static Status ShapeMarkStatic(Shape shape, bool isStatic)
    {
        return rprShapeMarkStatic(shape, isStatic);
    }

    public static Status LightSetTransform(Light light, bool transpose, float[] transform)
    {
        fixed (float* ptr1 = transform)
        {
            return rprLightSetTransform(light, transpose, ptr1);
        }
    }

    public static Status LightSetGroupId(Light light, uint groupId)
    {
        return rprLightSetGroupId(light, groupId);
    }

    public static Status ShapeGetInfo(Shape arg0, ShapeInfo arg1, long arg2, void* arg3, long* arg4)
    {
        return rprShapeGetInfo(arg0, arg1, arg2, arg3, arg4);
    }

    public static Status MeshGetInfo(Shape mesh, MeshInfo meshInfo, long size, void* data, out long sizeRet)
    {
        fixed (long* ptr1 = &sizeRet)
        {
            return rprMeshGetInfo(mesh, meshInfo, size, data, ptr1);
        }
    }

    public static Status CurveGetInfo(Curve curve, CurveParameter curveInfo, long size, void* data, out long sizeRet)
    {
        fixed (long* ptr1 = &sizeRet)
        {
            return rprCurveGetInfo(curve, curveInfo, size, data, ptr1);
        }
    }

    public static Status HeteroVolumeGetInfo(HeteroVolume heteroVol, HeteroVolumeParameter heteroVolInfo, long size, void* data, out long sizeRet)
    {
        fixed (long* ptr1 = &sizeRet)
        {
            return rprHeteroVolumeGetInfo(heteroVol, heteroVolInfo, size, data, ptr1);
        }
    }

    public static Status GridGetInfo(Grid grid, GridParameter gridInfo, long size, void* data, out long sizeRet)
    {
        fixed (long* ptr1 = &sizeRet)
        {
            return rprGridGetInfo(grid, gridInfo, size, data, ptr1);
        }
    }

    public static Status InstanceGetBaseShape(Shape shape, out Shape outShape)
    {
        fixed (Shape* ptr1 = &outShape)
        {
            return rprInstanceGetBaseShape(shape, ptr1);
        }
    }

    public static Status ContextCreatePointLight(Context context, out Light light)
    {
        fixed (Light* ptr1 = &light)
        {
            return rprContextCreatePointLight(context, ptr1);
        }
    }

    public static Status PointLightSetRadiantPower3f(Light light, float r, float g, float b)
    {
        return rprPointLightSetRadiantPower3f(light, r, g, b);
    }

    public static Status ContextCreateSpotLight(Context context, out Light light)
    {
        fixed (Light* ptr1 = &light)
        {
            return rprContextCreateSpotLight(context, ptr1);
        }
    }

    public static Status ContextCreateSphereLight(Context context, out Light light)
    {
        fixed (Light* ptr1 = &light)
        {
            return rprContextCreateSphereLight(context, ptr1);
        }
    }

    public static Status ContextCreateDiskLight(Context context, out Light light)
    {
        fixed (Light* ptr1 = &light)
        {
            return rprContextCreateDiskLight(context, ptr1);
        }
    }

    public static Status SpotLightSetRadiantPower3f(Light light, float r, float g, float b)
    {
        return rprSpotLightSetRadiantPower3f(light, r, g, b);
    }

    public static Status SpotLightSetImage(Light light, Image img)
    {
        return rprSpotLightSetImage(light, img);
    }

    public static Status SphereLightSetRadiantPower3f(Light light, float r, float g, float b)
    {
        return rprSphereLightSetRadiantPower3f(light, r, g, b);
    }

    public static Status SphereLightSetRadius(Light light, float radius)
    {
        return rprSphereLightSetRadius(light, radius);
    }

    public static Status DiskLightSetRadiantPower3f(Light light, float r, float g, float b)
    {
        return rprDiskLightSetRadiantPower3f(light, r, g, b);
    }

    public static Status DiskLightSetRadius(Light light, float radius)
    {
        return rprDiskLightSetRadius(light, radius);
    }

    public static Status DiskLightSetAngle(Light light, float angle)
    {
        return rprDiskLightSetAngle(light, angle);
    }

    public static Status DiskLightSetInnerAngle(Light light, float innerAngle)
    {
        return rprDiskLightSetInnerAngle(light, innerAngle);
    }

    public static Status SpotLightSetConeShape(Light light, float iangle, float oangle)
    {
        return rprSpotLightSetConeShape(light, iangle, oangle);
    }

    public static Status ContextCreateDirectionalLight(Context context, out Light light)
    {
        fixed (Light* ptr1 = &light)
        {
            return rprContextCreateDirectionalLight(context, ptr1);
        }
    }

    public static Status DirectionalLightSetRadiantPower3f(Light light, float r, float g, float b)
    {
        return rprDirectionalLightSetRadiantPower3f(light, r, g, b);
    }

    public static Status DirectionalLightSetShadowSoftnessAngle(Light light, float softnessAngle)
    {
        return rprDirectionalLightSetShadowSoftnessAngle(light, softnessAngle);
    }

    public static Status ContextCreateEnvironmentLight(Context context, out Light light)
    {
        fixed (Light* ptr1 = &light)
        {
            return rprContextCreateEnvironmentLight(context, ptr1);
        }
    }

    public static Status EnvironmentLightSetImage(Light envLight, Image image)
    {
        return rprEnvironmentLightSetImage(envLight, image);
    }

    public static Status EnvironmentLightSetIntensityScale(Light envLight, float intensityScale)
    {
        return rprEnvironmentLightSetIntensityScale(envLight, intensityScale);
    }

    public static Status EnvironmentLightAttachPortal(Scene scene, Light envLight, Shape portal)
    {
        return rprEnvironmentLightAttachPortal(scene, envLight, portal);
    }

    public static Status EnvironmentLightDetachPortal(Scene scene, Light envLight, Shape portal)
    {
        return rprEnvironmentLightDetachPortal(scene, envLight, portal);
    }

    public static Status EnvironmentLightSetEnvironmentLightOverride(Light inIbl, uint overrideType, Light iblOverride)
    {
        return rprEnvironmentLightSetEnvironmentLightOverride(inIbl, overrideType, iblOverride);
    }

    public static Status EnvironmentLightGetEnvironmentLightOverride(Light inIbl, uint overrideType, out Light iblOverride)
    {
        fixed (Light* ptr1 = &iblOverride)
        {
            return rprEnvironmentLightGetEnvironmentLightOverride(inIbl, overrideType, ptr1);
        }
    }

    public static Status ContextCreateSkyLight(Context context, out Light light)
    {
        fixed (Light* ptr1 = &light)
        {
            return rprContextCreateSkyLight(context, ptr1);
        }
    }

    public static Status SkyLightSetTurbidity(Light skylight, float turbidity)
    {
        return rprSkyLightSetTurbidity(skylight, turbidity);
    }

    public static Status SkyLightSetAlbedo(Light skylight, float albedo)
    {
        return rprSkyLightSetAlbedo(skylight, albedo);
    }

    public static Status SkyLightSetScale(Light skylight, float scale)
    {
        return rprSkyLightSetScale(skylight, scale);
    }

    public static Status SkyLightSetDirection(Light skylight, float x, float y, float z)
    {
        return rprSkyLightSetDirection(skylight, x, y, z);
    }

    public static Status SkyLightAttachPortal(Scene scene, Light skylight, Shape portal)
    {
        return rprSkyLightAttachPortal(scene, skylight, portal);
    }

    public static Status SkyLightDetachPortal(Scene scene, Light skylight, Shape portal)
    {
        return rprSkyLightDetachPortal(scene, skylight, portal);
    }

    public static Status ContextCreateIESLight(Context context, out Light light)
    {
        fixed (Light* ptr1 = &light)
        {
            return rprContextCreateIESLight(context, ptr1);
        }
    }

    public static Status IESLightSetRadiantPower3f(Light light, float r, float g, float b)
    {
        return rprIESLightSetRadiantPower3f(light, r, g, b);
    }

    public static Status IESLightSetImageFromFile(Light env_light, string imagePath, int nx, int ny)
    {
        char* ptr1 = (char*)SilkMarshal.StringToPtr(imagePath);

        Status status = rprIESLightSetImageFromFile(env_light, ptr1, nx, ny);

        SilkMarshal.Free((nint)ptr1);

        return status;
    }

    public static Status IESLightSetImageFromIESdata(Light env_light, string iesData, int nx, int ny)
    {
        char* ptr1 = (char*)SilkMarshal.StringToPtr(iesData);

        Status status = rprIESLightSetImageFromIESdata(env_light, ptr1, nx, ny);

        SilkMarshal.Free((nint)ptr1);

        return status;
    }

    public static Status LightGetInfo(Light light, LightInfo info, long size, void* data, out long sizeRet)
    {
        fixed (long* ptr1 = &sizeRet)
        {
            return rprLightGetInfo(light, info, size, data, ptr1);
        }
    }

    public static Status SceneClear(Scene scene)
    {
        return rprSceneClear(scene);
    }

    public static Status SceneAttachShape(Scene scene, Shape shape)
    {
        return rprSceneAttachShape(scene, shape);
    }

    public static Status SceneDetachShape(Scene scene, Shape shape)
    {
        return rprSceneDetachShape(scene, shape);
    }

    public static Status SceneAttachHeteroVolume(Scene scene, HeteroVolume heteroVolume)
    {
        return rprSceneAttachHeteroVolume(scene, heteroVolume);
    }

    public static Status SceneDetachHeteroVolume(Scene scene, HeteroVolume heteroVolume)
    {
        return rprSceneDetachHeteroVolume(scene, heteroVolume);
    }

    public static Status SceneAttachCurve(Scene scene, Curve curve)
    {
        return rprSceneAttachCurve(scene, curve);
    }

    public static Status SceneDetachCurve(Scene scene, Curve curve)
    {
        return rprSceneDetachCurve(scene, curve);
    }

    public static Status CurveSetMaterial(Curve curve, MaterialNode material)
    {
        return rprCurveSetMaterial(curve, material);
    }

    public static Status CurveSetTransform(Curve curve, bool transpose, float[] transform)
    {
        fixed (float* ptr1 = transform)
        {
            return rprCurveSetTransform(curve, transpose, ptr1);
        }
    }

    public static Status ContextCreateCurve(Context context, out Curve curve, long numControlPoints, float[] controlPointsData, int controlPointsStride, long numIndices, uint curveCount, uint[] indicesData, float[] radius, float[] textureUV, int[] segmentPerCurve, uint creationFlagTapered)
    {
        fixed (Curve* ptr1 = &curve)
        fixed (float* ptr2 = controlPointsData)
        fixed (uint* ptr3 = indicesData)
        fixed (float* ptr4 = radius)
        fixed (float* ptr5 = textureUV)
        fixed (int* ptr6 = segmentPerCurve)
        {
            return rprContextCreateCurve(context, ptr1, numControlPoints, ptr2, controlPointsStride, numIndices, curveCount, ptr3, ptr4, ptr5, ptr6, creationFlagTapered);
        }
    }

    public static Status SceneAttachLight(Scene scene, Light light)
    {
        return rprSceneAttachLight(scene, light);
    }

    public static Status SceneDetachLight(Scene scene, Light light)
    {
        return rprSceneDetachLight(scene, light);
    }

    public static Status SceneSetEnvironmentLight(Scene scene, Light light)
    {
        return rprSceneSetEnvironmentLight(scene, light);
    }

    public static Status SceneGetEnvironmentLight(Scene scene, out Light light)
    {
        fixed (Light* ptr1 = &light)
        {
            return rprSceneGetEnvironmentLight(scene, ptr1);
        }
    }

    public static Status SceneGetInfo(Scene scene, SceneInfo info, long size, void* data, out long sizeRet)
    {
        fixed (long* ptr1 = &sizeRet)
        {
            return rprSceneGetInfo(scene, info, size, data, ptr1);
        }
    }

    public static Status SceneSetBackgroundImage(Scene scene, Image image)
    {
        return rprSceneSetBackgroundImage(scene, image);
    }

    public static Status SceneGetBackgroundImage(Scene scene, out Image image)
    {
        fixed (Image* ptr1 = &image)
        {
            return rprSceneGetBackgroundImage(scene, ptr1);
        }
    }

    public static Status SceneSetCameraRight(Scene scene, Camera camera)
    {
        return rprSceneSetCameraRight(scene, camera);
    }

    public static Status SceneGetCameraRight(Scene scene, out Camera camera)
    {
        fixed (Camera* ptr1 = &camera)
        {
            return rprSceneGetCameraRight(scene, ptr1);
        }
    }

    public static Status SceneSetCamera(Scene scene, Camera camera)
    {
        return rprSceneSetCamera(scene, camera);
    }

    public static Status SceneGetCamera(Scene scene, out Camera camera)
    {
        fixed (Camera* ptr1 = &camera)
        {
            return rprSceneGetCamera(scene, ptr1);
        }
    }

    public static Status FrameBufferGetInfo(Framebuffer framebuffer, FramebufferInfo info, long size, void* data, out long sizeRet)
    {
        fixed (long* ptr1 = &sizeRet)
        {
            return rprFrameBufferGetInfo(framebuffer, info, size, data, ptr1);
        }
    }

    public static Status FrameBufferClear(Framebuffer framebuffer)
    {
        return rprFrameBufferClear(framebuffer);
    }

    public static Status FrameBufferFillWithColor(Framebuffer framebuffer, float r, float g, float b, float a)
    {
        return rprFrameBufferFillWithColor(framebuffer, r, g, b, a);
    }

    public static Status FrameBufferSaveToFile(Framebuffer framebuffer, string filePath)
    {
        char* ptr1 = (char*)SilkMarshal.StringToPtr(filePath);

        Status status = rprFrameBufferSaveToFile(framebuffer, ptr1);

        SilkMarshal.Free((nint)ptr1);

        return status;
    }

    public static Status FrameBufferSaveToFileEx(Framebuffer* framebufferList, uint framebufferCount, string filePath, void* extraOptions)
    {
        char* ptr1 = (char*)SilkMarshal.StringToPtr(filePath);

        Status status = rprFrameBufferSaveToFileEx(framebufferList, framebufferCount, ptr1, extraOptions);

        SilkMarshal.Free((nint)ptr1);

        return status;
    }

    public static Status ContextResolveFrameBuffer(Context context, Framebuffer srcFb, Framebuffer dstFb, bool noDisplayGamma)
    {
        return rprContextResolveFrameBuffer(context, srcFb, dstFb, noDisplayGamma);
    }

    public static Status MaterialSystemGetInfo(MaterialSystem materialSystem, MaterialSystemInfo materialSystemInfo, long size, void* data, out long sizeRet)
    {
        fixed (long* ptr1 = &sizeRet)
        {
            return rprMaterialSystemGetInfo(materialSystem, materialSystemInfo, size, data, ptr1);
        }
    }

    public static Status ContextCreateMaterialSystem(Context context, uint type, out MaterialSystem matsys)
    {
        fixed (MaterialSystem* ptr1 = &matsys)
        {
            return rprContextCreateMaterialSystem(context, type, ptr1);
        }
    }

    public static Status MaterialSystemGetSize(Context context, out uint size)
    {
        fixed (uint* ptr1 = &size)
        {
            return rprMaterialSystemGetSize(context, ptr1);
        }
    }

    public static Status MaterialSystemCreateNode(MaterialSystem materialSystem, MaterialNodeType materialNodeType, out MaterialNode node)
    {
        fixed (MaterialNode* ptr1 = &node)
        {
            return rprMaterialSystemCreateNode(materialSystem, materialNodeType, ptr1);
        }
    }

    public static Status MaterialNodeSetID(MaterialNode materialNode, uint id)
    {
        return rprMaterialNodeSetID(materialNode, id);
    }

    public static Status MaterialNodeSetInputNByKey(MaterialNode materialNode, MaterialNodeInput materialNodeInput, MaterialNode inputNode)
    {
        return rprMaterialNodeSetInputNByKey(materialNode, materialNodeInput, inputNode);
    }

    public static Status MaterialNodeSetInputFByKey(MaterialNode materialNode, MaterialNodeInput materialNodeInput, float x, float y, float z, float w)
    {
        return rprMaterialNodeSetInputFByKey(materialNode, materialNodeInput, x, y, z, w);
    }

    public static Status MaterialNodeSetInputDataByKey(MaterialNode materialNode, MaterialNodeInput materialNodeInput, void* data, long dataSizeByte)
    {
        return rprMaterialNodeSetInputDataByKey(materialNode, materialNodeInput, data, dataSizeByte);
    }

    public static Status MaterialNodeSetInputUByKey(MaterialNode materialNode, MaterialNodeInput materialNodeInput, uint value)
    {
        return rprMaterialNodeSetInputUByKey(materialNode, materialNodeInput, value);
    }

    public static Status MaterialNodeSetInputImageDataByKey(MaterialNode materialNode, MaterialNodeInput materialNodeInput, Image image)
    {
        return rprMaterialNodeSetInputImageDataByKey(materialNode, materialNodeInput, image);
    }

    public static Status MaterialNodeSetInputLightDataByKey(MaterialNode materialNode, MaterialNodeInput materialNodeInput, Light light)
    {
        return rprMaterialNodeSetInputLightDataByKey(materialNode, materialNodeInput, light);
    }

    public static Status MaterialNodeSetInputBufferDataByKey(MaterialNode materialNode, MaterialNodeInput materialNodeInput, Buffer buffer)
    {
        return rprMaterialNodeSetInputBufferDataByKey(materialNode, materialNodeInput, buffer);
    }

    public static Status MaterialNodeSetInputGridDataByKey(MaterialNode materialNode, MaterialNodeInput materialNodeInput, Grid grid)
    {
        return rprMaterialNodeSetInputGridDataByKey(materialNode, materialNodeInput, grid);
    }

    public static Status MaterialNodeGetInfo(MaterialNode materialNode, MaterialNodeInfo materialNodeInfo, long size, void* data, out long sizeRet)
    {
        fixed (long* ptr1 = &sizeRet)
        {
            return rprMaterialNodeGetInfo(materialNode, materialNodeInfo, size, data, ptr1);
        }
    }

    public static Status MaterialNodeGetInputInfo(MaterialNode materialNode, int idx, MaterialNodeInputInfo info, long size, void* data, out long sizeRet)
    {
        fixed (long* ptr1 = &sizeRet)
        {
            return rprMaterialNodeGetInputInfo(materialNode, idx, info, size, data, ptr1);
        }
    }

    public static Status ContextCreateComposite(Context context, CompositeType type, out Composite composite)
    {
        fixed (Composite* ptr1 = &composite)
        {
            return rprContextCreateComposite(context, type, ptr1);
        }
    }

    public static Status ContextCreateLUTFromFile(Context context, string fileLutPath, out Lut lut)
    {
        char* ptr1 = (char*)SilkMarshal.StringToPtr(fileLutPath);
        fixed (Lut* ptr2 = &lut)
        {
            Status status = rprContextCreateLUTFromFile(context, ptr1, ptr2);

            SilkMarshal.Free((nint)ptr1);

            return status;
        }
    }

    public static Status ContextCreateLUTFromData(Context context, string lutData, out Lut lut)
    {
        char* ptr1 = (char*)SilkMarshal.StringToPtr(lutData);
        fixed (Lut* ptr2 = &lut)
        {
            Status status = rprContextCreateLUTFromData(context, ptr1, ptr2);

            SilkMarshal.Free((nint)ptr1);

            return status;
        }
    }

    public static Status CompositeSetInputFb(Composite composite, string inputName, Framebuffer input)
    {
        char* ptr1 = (char*)SilkMarshal.StringToPtr(inputName);

        Status status = rprCompositeSetInputFb(composite, ptr1, input);

        SilkMarshal.Free((nint)ptr1);

        return status;
    }

    public static Status CompositeSetInputC(Composite composite, string inputName, Composite input)
    {
        char* ptr1 = (char*)SilkMarshal.StringToPtr(inputName);

        Status status = rprCompositeSetInputC(composite, ptr1, input);

        SilkMarshal.Free((nint)ptr1);

        return status;
    }

    public static Status CompositeSetInputLUT(Composite composite, string inputName, Lut input)
    {
        char* ptr1 = (char*)SilkMarshal.StringToPtr(inputName);

        Status status = rprCompositeSetInputLUT(composite, ptr1, input);

        SilkMarshal.Free((nint)ptr1);

        return status;
    }

    public static Status CompositeSetInput4f(Composite composite, string inputName, float x, float y, float z, float w)
    {
        char* ptr1 = (char*)SilkMarshal.StringToPtr(inputName);

        Status status = rprCompositeSetInput4f(composite, ptr1, x, y, z, w);

        SilkMarshal.Free((nint)ptr1);

        return status;
    }

    public static Status CompositeSetInput1u(Composite composite, string inputName, uint value)
    {
        char* ptr1 = (char*)SilkMarshal.StringToPtr(inputName);

        Status status = rprCompositeSetInput1u(composite, ptr1, value);

        SilkMarshal.Free((nint)ptr1);

        return status;
    }

    public static Status CompositeSetInputOp(Composite composite, string inputName, MaterialNodeArithmeticOperation op)
    {
        char* ptr1 = (char*)SilkMarshal.StringToPtr(inputName);

        Status status = rprCompositeSetInputOp(composite, ptr1, op);

        SilkMarshal.Free((nint)ptr1);

        return status;
    }

    public static Status CompositeCompute(Composite composite, Framebuffer fb)
    {
        return rprCompositeCompute(composite, fb);
    }

    public static Status CompositeGetInfo(Composite composite, CompositeInfo compositeInfo, long size, void* data, out long sizeRet)
    {
        fixed (long* ptr1 = &sizeRet)
        {
            return rprCompositeGetInfo(composite, compositeInfo, size, data, ptr1);
        }
    }

    public static Status ObjectDelete(object obj)
    {
        Type type = obj.GetType();

        if (type == typeof(nint))
        {
            return rprObjectDelete((void*)(nint)obj);
        }
        else if (type.IsValueType && type.GetFields().FirstOrDefault(item => item.FieldType == typeof(void*)) is FieldInfo fieldInfo)
        {
            return rprObjectDelete(Pointer.Unbox(fieldInfo.GetValue(obj)!));
        }
        else
        {
            return Status.ErrorInvalidParameterType;
        }
    }

    public static Status ObjectSetName(void* node, string name)
    {
        char* ptr1 = (char*)SilkMarshal.StringToPtr(name);

        Status status = rprObjectSetName(node, ptr1);

        SilkMarshal.Free((nint)ptr1);

        return status;
    }

    public static Status ObjectSetCustomPointer(void* node, void* customPtr)
    {
        return rprObjectSetCustomPointer(node, customPtr);
    }

    public static Status ObjectGetCustomPointer(void* node, out nint customPtr)
    {
        fixed (nint* ptr1 = &customPtr)
        {
            return rprObjectGetCustomPointer(node, (void**)ptr1);
        }
    }

    public static Status ContextCreatePostEffect(Context context, PostEffectType type, out PostEffect effect)
    {
        fixed (PostEffect* ptr1 = &effect)
        {
            return rprContextCreatePostEffect(context, type, ptr1);
        }
    }

    public static Status ContextAttachPostEffect(Context context, PostEffect effect)
    {
        return rprContextAttachPostEffect(context, effect);
    }

    public static Status ContextDetachPostEffect(Context context, PostEffect effect)
    {
        return rprContextDetachPostEffect(context, effect);
    }

    public static Status PostEffectSetParameter1u(PostEffect effect, string name, uint x)
    {
        char* ptr1 = (char*)SilkMarshal.StringToPtr(name);

        Status status = rprPostEffectSetParameter1u(effect, ptr1, x);

        SilkMarshal.Free((nint)ptr1);

        return status;
    }

    public static Status PostEffectSetParameter1f(PostEffect effect, string name, float x)
    {
        char* ptr1 = (char*)SilkMarshal.StringToPtr(name);

        Status status = rprPostEffectSetParameter1f(effect, ptr1, x);

        SilkMarshal.Free((nint)ptr1);

        return status;
    }

    public static Status PostEffectSetParameter3f(PostEffect effect, string name, float x, float y, float z)
    {
        char* ptr1 = (char*)SilkMarshal.StringToPtr(name);

        Status status = rprPostEffectSetParameter3f(effect, ptr1, x, y, z);

        SilkMarshal.Free((nint)ptr1);

        return status;
    }

    public static Status PostEffectSetParameter4f(PostEffect effect, string name, float x, float y, float z, float w)
    {
        char* ptr1 = (char*)SilkMarshal.StringToPtr(name);

        Status status = rprPostEffectSetParameter4f(effect, ptr1, x, y, z, w);

        SilkMarshal.Free((nint)ptr1);

        return status;
    }

    public static Status ContextGetAttachedPostEffectCount(Context context, uint* nb)
    {
        return rprContextGetAttachedPostEffectCount(context, nb);
    }

    public static Status ContextGetAttachedPostEffect(Context context, uint i, out PostEffect effect)
    {
        fixed (PostEffect* ptr1 = &effect)
        {
            return rprContextGetAttachedPostEffect(context, i, ptr1);
        }
    }

    public static Status PostEffectGetInfo(PostEffect effect, PostEffectInfo info, long size, void* data, out long sizeRet)
    {
        fixed (long* ptr1 = &sizeRet)
        {
            return rprPostEffectGetInfo(effect, info, size, data, ptr1);
        }
    }

    public static Status ContextCreateGrid(Context context, out Grid grid, long gridSizeX, long gridSizeY, long gridSizeZ, void* indicesList, long numberOfIndices, GridIndicesTopology indicesListTopology, void* gridData, long gridDataSizeByte, uint gridDataTopologyUnused)
    {
        fixed (Grid* ptr1 = &grid)
        {
            return rprContextCreateGrid(context, ptr1, gridSizeX, gridSizeY, gridSizeZ, indicesList, numberOfIndices, indicesListTopology, gridData, gridDataSizeByte, gridDataTopologyUnused);
        }
    }

    public static Status ContextCreateHeteroVolume(Context context, out HeteroVolume heteroVolume)
    {
        fixed (HeteroVolume* ptr1 = &heteroVolume)
        {
            return rprContextCreateHeteroVolume(context, ptr1);
        }
    }

    public static Status ShapeSetHeteroVolume(Shape shape, HeteroVolume heteroVolume)
    {
        return rprShapeSetHeteroVolume(shape, heteroVolume);
    }

    public static Status HeteroVolumeSetTransform(HeteroVolume heteroVolume, bool transpose, float[] transform)
    {
        fixed (float* ptr1 = transform)
        {
            return rprHeteroVolumeSetTransform(heteroVolume, transpose, ptr1);
        }
    }

    public static Status HeteroVolumeSetEmissionGrid(HeteroVolume heteroVolume, Grid grid)
    {
        return rprHeteroVolumeSetEmissionGrid(heteroVolume, grid);
    }

    public static Status HeteroVolumeSetDensityGrid(HeteroVolume heteroVolume, Grid grid)
    {
        return rprHeteroVolumeSetDensityGrid(heteroVolume, grid);
    }

    public static Status HeteroVolumeSetAlbedoGrid(HeteroVolume heteroVolume, Grid grid)
    {
        return rprHeteroVolumeSetAlbedoGrid(heteroVolume, grid);
    }

    public static Status HeteroVolumeSetEmissionLookup(HeteroVolume heteroVolume, float[] floats, uint n)
    {
        fixed (float* ptr1 = floats)
        {
            return rprHeteroVolumeSetEmissionLookup(heteroVolume, ptr1, n);
        }
    }

    public static Status HeteroVolumeSetDensityLookup(HeteroVolume heteroVolume, float[] floats, uint n)
    {
        fixed (float* ptr1 = floats)
        {
            return rprHeteroVolumeSetDensityLookup(heteroVolume, ptr1, n);
        }
    }

    public static Status HeteroVolumeSetAlbedoLookup(HeteroVolume heteroVolume, float[] floats, uint n)
    {
        fixed (float* ptr1 = floats)
        {
            return rprHeteroVolumeSetAlbedoLookup(heteroVolume, ptr1, n);
        }
    }

    public static Status HeteroVolumeSetAlbedoScale(HeteroVolume heteroVolume, float scale)
    {
        return rprHeteroVolumeSetAlbedoScale(heteroVolume, scale);
    }

    public static Status HeteroVolumeSetEmissionScale(HeteroVolume heteroVolume, float scale)
    {
        return rprHeteroVolumeSetEmissionScale(heteroVolume, scale);
    }

    public static Status HeteroVolumeSetDensityScale(HeteroVolume heteroVolume, float scale)
    {
        return rprHeteroVolumeSetDensityScale(heteroVolume, scale);
    }
}

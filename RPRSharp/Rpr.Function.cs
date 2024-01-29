using System.Runtime.InteropServices;

namespace RPRSharp;

public partial class Rpr
{
    [LibraryImport("RadeonProRender64")]
    private static unsafe partial int rprRegisterPlugin(byte* path);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprCreateContext(uint api_version, int* pluginIDs, long pluginCount, CreationFlags creation_flags, ContextProperties* props, byte* cache_path, Context* out_context);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextSetActivePlugin(Context context, int pluginID);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextGetInfo(Context context, ContextInfo ContextInfo, long size, void* data, long* size_ret);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextGetParameterInfo(Context context, int param_idx, ParameterInfo parameter_info, long size, void* data, long* size_ret);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextGetAOV(Context context, Aov aov, FrameBuffer* out_fb);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextSetAOV(Context context, Aov aov, FrameBuffer frame_buffer);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextAttachRenderLayer(Context context, byte* renderLayerString);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextDetachRenderLayer(Context context, byte* renderLayerString);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprFrameBufferSetLPE(FrameBuffer frame_buffer, byte* lpe);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextSetAOVindexLookup(Context context, int key, float colorR, float colorG, float colorB, float colorA);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextSetCuttingPlane(Context context, int index, float a, float b, float c, float d);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextSetAOVindicesLookup(Context context, int keyOffset, int keyCount, float* colorRGBA);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextSetUserTexture(Context context, int index, byte* gpuCode, void* cpuCode);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextGetUserTexture(Context context, int index, long bufferSizeByte, void* buffer, long* size_ret);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextSetScene(Context context, Scene scene);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextGetScene(Context context, Scene* out_scene);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextSetParameterByKey1u(Context context, ContextInfo in_input, uint x);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextSetParameterByKeyPtr(Context context, ContextInfo in_input, void* x);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextSetParameterByKey1f(Context context, ContextInfo in_input, float x);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextSetParameterByKey3f(Context context, ContextInfo in_input, float x, float y, float z);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextSetParameterByKey4f(Context context, ContextInfo in_input, float x, float y, float z, float w);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextSetParameterByKeyString(Context context, ContextInfo in_input, byte* value);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextSetInternalParameter4f(Context context, uint pluginIndex, byte* paramName, float x, float y, float z, float w);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextSetInternalParameter1u(Context context, uint pluginIndex, byte* paramName, uint x);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextSetInternalParameterBuffer(Context context, uint pluginIndex, byte* paramName, void* buffer, long bufferSizeByte);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextGetInternalParameter4f(Context context, uint pluginIndex, byte* paramName, float* x, float* y, float* z, float* w);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextGetInternalParameter1u(Context context, uint pluginIndex, byte* paramName, uint* x);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextGetInternalParameterBuffer(Context context, uint pluginIndex, byte* paramName, long bufferSizeByte, void* buffer, long* size_ret);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextRender(Context context);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextAbortRender(Context context);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextRenderTile(Context context, uint xmin, uint xmax, uint ymin, uint ymax);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextClearMemory(Context context);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextCreateImage(Context context, ImageFormat format, ImageDesc* image_desc, void* data, Image* out_image);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextCreateBuffer(Context context, BufferDesc* buffer_desc, void* data, Buffer* out_buffer);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextCreateImageFromFile(Context context, byte* path, Image* out_image);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextCreateImageFromFileMemory(Context context, byte* extension, void* data, long dataSizeByte, Image* out_image);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextCreateScene(Context context, Scene* out_scene);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextCreateInstance(Context context, Shape shape, Shape* out_instance);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextCreateMesh(Context context, float* vertices, long num_vertices, int vertex_stride, float* normals, long num_normals, int normal_stride, float* texcoords, long num_texcoords, int texcoord_stride, int* vertex_indices, int vidx_stride, int* normal_indices, int nidx_stride, int* texcoord_indices, int tidx_stride, int* num_face_vertices, long num_faces, Shape* out_mesh);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextCreateMeshEx(Context context, float* vertices, long num_vertices, int vertex_stride, float* normals, long num_normals, int normal_stride, int* perVertexFlag, long num_perVertexFlags, int perVertexFlag_stride, int numberOfTexCoordLayers, float** texcoords, long* num_texcoords, int* texcoord_stride, int* vertex_indices, int vidx_stride, int* normal_indices, int nidx_stride, int** texcoord_indices, int* tidx_stride, int* num_face_vertices, long num_faces, Shape* out_mesh);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextCreateMeshEx2(Context context, float* vertices, long num_vertices, int vertex_stride, float* normals, long num_normals, int normal_stride, int* perVertexFlag, long num_perVertexFlags, int perVertexFlag_stride, int numberOfTexCoordLayers, float** texcoords, long* num_texcoords, int* texcoord_stride, int* vertex_indices, int vidx_stride, int* normal_indices, int nidx_stride, int** texcoord_indices, int* tidx_stride, int* num_face_vertices, long num_faces, MeshInfo* mesh_properties, Shape* out_mesh);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextCreateCamera(Context context, Camera* out_camera);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextCreateFrameBuffer(Context context, FrameBufferFormat format, FrameBufferDesc* fb_desc, FrameBuffer* out_fb);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextGetFunctionPtr(Context context, byte* function_name, void** out_function_ptr);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprCameraGetInfo(Camera camera, CameraInfo camera_info, long size, void* data, long* size_ret);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprCameraSetFocalLength(Camera camera, float flength);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprCameraSetMotionTransformCount(Camera camera, uint transformCount);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprCameraSetMotionTransform(Camera camera, [MarshalAs(UnmanagedType.Bool)] bool transpose, float* transform, uint timeIndex);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprCameraSetFocusDistance(Camera camera, float fdist);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprCameraSetTransform(Camera camera, [MarshalAs(UnmanagedType.Bool)] bool transpose, float* transform);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprCameraSetSensorSize(Camera camera, float width, float height);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprCameraLookAt(Camera camera, float posx, float posy, float posz, float atx, float aty, float atz, float upx, float upy, float upz);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprCameraSetFStop(Camera camera, float fstop);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprCameraSetApertureBlades(Camera camera, uint num_blades);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprCameraSetExposure(Camera camera, float exposure);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprCameraSetMode(Camera camera, CameraMode mode);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprCameraSetOrthoWidth(Camera camera, float width);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprCameraSetFocalTilt(Camera camera, float tilt);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprCameraSetIPD(Camera camera, float ipd);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprCameraSetLensShift(Camera camera, float shiftx, float shifty);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprCameraSetTiltCorrection(Camera camera, float tiltX, float tiltY);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprCameraSetOrthoHeight(Camera camera, float height);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprCameraSetNearPlane(Camera camera, float near);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprCameraSetPostScale(Camera camera, float scale);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprCameraSetFarPlane(Camera camera, float far);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprCameraSetUVDistortion(Camera camera, Image distortionMap);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprImageGetInfo(Image image, ImageInfo image_info, long size, void* data, long* size_ret);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprImageSetWrap(Image image, ImageWrapType type);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprImageSetInternalCompression(Image image, uint compressionEnabled);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprImageSetOcioColorspace(Image image, byte* ocioColorspace);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprImageSetUDIM(Image imageUdimRoot, uint tileIndex, Image imageTile);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprImageSetFilter(Image image, ImageFilterType type);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprImageSetGamma(Image image, float type);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprImageSetMipmapEnabled(Image image, [MarshalAs(UnmanagedType.Bool)] bool enabled);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprShapeSetTransform(Shape shape, [MarshalAs(UnmanagedType.Bool)] bool transpose, float* transform);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprShapeSetVertexValue(Shape in_shape, int setIndex, int* indices, float* values, int indicesCount);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprShapeSetPrimvar(Shape in_shape, uint key, float* data, uint floatCount, uint componentCount, PrimvarInterpolationType interop);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprShapeSetSubdivisionFactor(Shape shape, uint factor);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprShapeSetSubdivisionAutoRatioCap(Shape shape, float autoRatioCap);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprShapeSetSubdivisionCreaseWeight(Shape shape, float factor);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprShapeAttachRenderLayer(Shape shape, byte* renderLayerString);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprShapeDetachRenderLayer(Shape shape, byte* renderLayerString);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprLightAttachRenderLayer(Light light, byte* renderLayerString);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprLightDetachRenderLayer(Light light, byte* renderLayerString);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprShapeSetSubdivisionBoundaryInterop(Shape shape, SubdivBoundaryInteropType type);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprShapeAutoAdaptSubdivisionFactor(Shape shape, FrameBuffer framebuffer, Camera camera, int factor);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprShapeSetDisplacementScale(Shape shape, float minscale, float maxscale);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprShapeSetObjectGroupID(Shape shape, uint objectGroupID);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprShapeSetObjectID(Shape shape, uint objectID);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprShapeSetLightGroupID(Shape shape, uint lightGroupID);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprShapeSetLayerMask(Shape shape, uint layerMask);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprShapeSetDisplacementMaterial(Shape shape, MaterialNode materialNode);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprShapeSetMaterial(Shape shape, MaterialNode node);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprShapeSetMaterialFaces(Shape shape, MaterialNode node, int* face_indices, long num_faces);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprShapeSetVolumeMaterial(Shape shape, MaterialNode node);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprShapeSetMotionTransformCount(Shape shape, uint transformCount);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprShapeSetMotionTransform(Shape shape, [MarshalAs(UnmanagedType.Bool)] bool transpose, float* transform, uint timeIndex);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprShapeSetVisibilityFlag(Shape shape, ShapeInfo visibilityFlag, [MarshalAs(UnmanagedType.Bool)] bool visible);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprCurveSetVisibilityFlag(Curve curve, CurveParameter visibilityFlag, [MarshalAs(UnmanagedType.Bool)] bool visible);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprShapeSetVisibility(Shape shape, [MarshalAs(UnmanagedType.Bool)] bool visible);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprLightSetVisibilityFlag(Light light, LightInfo visibilityFlag, [MarshalAs(UnmanagedType.Bool)] bool visible);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprCurveSetVisibility(Curve curve, [MarshalAs(UnmanagedType.Bool)] bool visible);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprShapeSetVisibilityInSpecular(Shape shape, [MarshalAs(UnmanagedType.Bool)] bool visible);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprShapeSetShadowCatcher(Shape shape, [MarshalAs(UnmanagedType.Bool)] bool shadowCatcher);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprShapeSetShadowColor(Shape shape, float r, float g, float b);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprShapeSetReflectionCatcher(Shape shape, [MarshalAs(UnmanagedType.Bool)] bool reflectionCatcher);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprShapeSetContourIgnore(Shape shape, [MarshalAs(UnmanagedType.Bool)] bool ignoreInContour);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprShapeSetEnvironmentLight(Shape shape, [MarshalAs(UnmanagedType.Bool)] bool envLight);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprShapeMarkStatic(Shape in_shape, [MarshalAs(UnmanagedType.Bool)] bool in_is_static);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprLightSetTransform(Light light, [MarshalAs(UnmanagedType.Bool)] bool transpose, float* transform);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprLightSetGroupId(Light light, uint groupId);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprShapeGetInfo(Shape arg0, ShapeInfo arg1, long arg2, void* arg3, long* arg4);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprMeshGetInfo(Shape mesh, MeshInfo mesh_info, long size, void* data, long* size_ret);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprCurveGetInfo(Curve curve, CurveParameter curve_info, long size, void* data, long* size_ret);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprHeteroVolumeGetInfo(HeteroVolume heteroVol, HeteroVolumeParameter heteroVol_info, long size, void* data, long* size_ret);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprGridGetInfo(Grid grid, GridParameter grid_info, long size, void* data, long* size_ret);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprInstanceGetBaseShape(Shape shape, Shape* out_shape);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextCreatePointLight(Context context, Light* out_light);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprPointLightSetRadiantPower3f(Light light, float r, float g, float b);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextCreateSpotLight(Context context, Light* light);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextCreateSphereLight(Context context, Light* light);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextCreateDiskLight(Context context, Light* light);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprSpotLightSetRadiantPower3f(Light light, float r, float g, float b);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprSpotLightSetImage(Light light, Image img);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprSphereLightSetRadiantPower3f(Light light, float r, float g, float b);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprSphereLightSetRadius(Light light, float radius);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprDiskLightSetRadiantPower3f(Light light, float r, float g, float b);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprDiskLightSetRadius(Light light, float radius);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprDiskLightSetAngle(Light light, float angle);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprDiskLightSetInnerAngle(Light light, float innerAngle);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprSpotLightSetConeShape(Light light, float iangle, float oangle);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextCreateDirectionalLight(Context context, Light* out_light);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprDirectionalLightSetRadiantPower3f(Light light, float r, float g, float b);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprDirectionalLightSetShadowSoftnessAngle(Light light, float softnessAngle);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextCreateEnvironmentLight(Context context, Light* out_light);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprEnvironmentLightSetImage(Light env_light, Image image);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprEnvironmentLightSetIntensityScale(Light env_light, float intensity_scale);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprEnvironmentLightAttachPortal(Scene scene, Light env_light, Shape portal);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprEnvironmentLightDetachPortal(Scene scene, Light env_light, Shape portal);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprEnvironmentLightSetEnvironmentLightOverride(Light in_ibl, uint overrideType, Light in_iblOverride);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprEnvironmentLightGetEnvironmentLightOverride(Light in_ibl, uint overrideType, Light* out_iblOverride);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextCreateSkyLight(Context context, Light* out_light);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprSkyLightSetTurbidity(Light skylight, float turbidity);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprSkyLightSetAlbedo(Light skylight, float albedo);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprSkyLightSetScale(Light skylight, float scale);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprSkyLightSetDirection(Light skylight, float x, float y, float z);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprSkyLightAttachPortal(Scene scene, Light skylight, Shape portal);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprSkyLightDetachPortal(Scene scene, Light skylight, Shape portal);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextCreateIESLight(Context context, Light* light);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprIESLightSetRadiantPower3f(Light light, float r, float g, float b);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprIESLightSetImageFromFile(Light env_light, byte* imagePath, int nx, int ny);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprIESLightSetImageFromIESdata(Light env_light, byte* iesData, int nx, int ny);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprLightGetInfo(Light light, LightInfo info, long size, void* data, long* size_ret);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprSceneClear(Scene scene);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprSceneAttachShape(Scene scene, Shape shape);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprSceneDetachShape(Scene scene, Shape shape);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprSceneAttachHeteroVolume(Scene scene, HeteroVolume heteroVolume);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprSceneDetachHeteroVolume(Scene scene, HeteroVolume heteroVolume);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprSceneAttachCurve(Scene scene, Curve curve);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprSceneDetachCurve(Scene scene, Curve curve);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprCurveSetMaterial(Curve curve, MaterialNode material);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprCurveSetTransform(Curve curve, [MarshalAs(UnmanagedType.Bool)] bool transpose, float* transform);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextCreateCurve(Context context, Curve* out_curve, long num_controlPoints, float* controlPointsData, int controlPointsStride, long num_indices, uint curveCount, uint* indicesData, float* radius, float* textureUV, int* segmentPerCurve, uint creationFlag_tapered);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprSceneAttachLight(Scene scene, Light light);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprSceneDetachLight(Scene scene, Light light);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprSceneSetEnvironmentLight(Scene in_scene, Light in_light);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprSceneGetEnvironmentLight(Scene in_scene, Light* out_light);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprSceneGetInfo(Scene scene, SceneInfo info, long size, void* data, long* size_ret);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprSceneSetBackgroundImage(Scene scene, Image image);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprSceneGetBackgroundImage(Scene scene, Image* out_image);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprSceneSetCameraRight(Scene scene, Camera camera);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprSceneGetCameraRight(Scene scene, Camera* out_camera);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprSceneSetCamera(Scene scene, Camera camera);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprSceneGetCamera(Scene scene, Camera* out_camera);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprFrameBufferGetInfo(FrameBuffer framebuffer, FrameBufferInfo info, long size, void* data, long* size_ret);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprFrameBufferClear(FrameBuffer frame_buffer);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprFrameBufferFillWithColor(FrameBuffer frame_buffer, float r, float g, float b, float a);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprFrameBufferSaveToFile(FrameBuffer frame_buffer, byte* file_path);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprFrameBufferSaveToFileEx(FrameBuffer* framebufferList, uint framebufferCount, byte* filePath, void* extraOptions);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextResolveFrameBuffer(Context context, FrameBuffer src_frame_buffer, FrameBuffer dst_frame_buffer, [MarshalAs(UnmanagedType.Bool)] bool noDisplayGamma);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprMaterialSystemGetInfo(MaterialSystem in_material_system, MaterialSystemInfo type, long in_size, void* in_data, long* out_size);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextCreateMaterialSystem(Context in_context, uint type, MaterialSystem* out_matsys);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprMaterialSystemGetSize(Context in_context, uint* out_size);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprMaterialSystemCreateNode(MaterialSystem in_matsys, MaterialNodeType in_type, MaterialNode* out_node);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprMaterialNodeSetID(MaterialNode in_node, uint id);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprMaterialNodeSetInputNByKey(MaterialNode in_node, MaterialNodeInput in_input, MaterialNode in_input_node);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprMaterialNodeSetInputFByKey(MaterialNode in_node, MaterialNodeInput in_input, float in_value_x, float in_value_y, float in_value_z, float in_value_w);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprMaterialNodeSetInputDataByKey(MaterialNode in_node, MaterialNodeInput in_input, void* data, long dataSizeByte);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprMaterialNodeSetInputUByKey(MaterialNode in_node, MaterialNodeInput in_input, uint in_value);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprMaterialNodeSetInputImageDataByKey(MaterialNode in_node, MaterialNodeInput in_input, Image image);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprMaterialNodeSetInputLightDataByKey(MaterialNode in_node, MaterialNodeInput in_input, Light light);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprMaterialNodeSetInputBufferDataByKey(MaterialNode in_node, MaterialNodeInput in_input, Buffer buffer);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprMaterialNodeSetInputGridDataByKey(MaterialNode in_node, MaterialNodeInput in_input, Grid grid);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprMaterialNodeGetInfo(MaterialNode in_node, MaterialNodeInfo in_info, long in_size, void* in_data, long* out_size);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprMaterialNodeGetInputInfo(MaterialNode in_node, int in_input_idx, MaterialNodeInputInfo in_info, long in_size, void* in_data, long* out_size);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextCreateComposite(Context context, CompositeType in_type, Composite* out_composite);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextCreateLUTFromFile(Context context, byte* fileLutPath, Lut* out_lut);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextCreateLUTFromData(Context context, byte* lutData, Lut* out_lut);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprCompositeSetInputFb(Composite composite, byte* inputName, FrameBuffer input);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprCompositeSetInputC(Composite composite, byte* inputName, Composite input);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprCompositeSetInputLUT(Composite composite, byte* inputName, Lut input);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprCompositeSetInput4f(Composite composite, byte* inputName, float x, float y, float z, float w);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprCompositeSetInput1u(Composite composite, byte* inputName, uint value);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprCompositeSetInputOp(Composite composite, byte* inputName, MaterialNodeOp op);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprCompositeCompute(Composite composite, FrameBuffer fb);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprCompositeGetInfo(Composite composite, CompositeInfo composite_info, long size, void* data, long* size_ret);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprObjectDelete(void* obj);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprObjectSetName(void* node, byte* name);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprObjectSetCustomPointer(void* node, void* customPtr);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprObjectGetCustomPointer(void* node, void** customPtr_out);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextCreatePostEffect(Context context, PostEffectType type, PostEffect* out_effect);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextAttachPostEffect(Context context, PostEffect effect);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextDetachPostEffect(Context context, PostEffect effect);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprPostEffectSetParameter1u(PostEffect effect, byte* name, uint x);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprPostEffectSetParameter1f(PostEffect effect, byte* name, float x);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprPostEffectSetParameter3f(PostEffect effect, byte* name, float x, float y, float z);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprPostEffectSetParameter4f(PostEffect effect, byte* name, float x, float y, float z, float w);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextGetAttachedPostEffectCount(Context context, uint* nb);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextGetAttachedPostEffect(Context context, uint i, PostEffect* out_effect);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprPostEffectGetInfo(PostEffect effect, PostEffectInfo info, long size, void* data, long* size_ret);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextCreateGrid(Context context, Grid* out_grid, long gridSizeX, long gridSizeY, long gridSizeZ, void* indicesList, long numberOfIndices, GridIndicesTopology indicesListTopology, void* gridData, long gridDataSizeByte, uint gridDataTopology___unused);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprContextCreateHeteroVolume(Context context, HeteroVolume* out_heteroVolume);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprShapeSetHeteroVolume(Shape shape, HeteroVolume heteroVolume);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprHeteroVolumeSetTransform(HeteroVolume heteroVolume, [MarshalAs(UnmanagedType.Bool)] bool transpose, float* transform);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprHeteroVolumeSetEmissionGrid(HeteroVolume heteroVolume, Grid grid);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprHeteroVolumeSetDensityGrid(HeteroVolume heteroVolume, Grid grid);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprHeteroVolumeSetAlbedoGrid(HeteroVolume heteroVolume, Grid grid);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprHeteroVolumeSetEmissionLookup(HeteroVolume heteroVolume, float* ptr, uint n);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprHeteroVolumeSetDensityLookup(HeteroVolume heteroVolume, float* ptr, uint n);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprHeteroVolumeSetAlbedoLookup(HeteroVolume heteroVolume, float* ptr, uint n);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprHeteroVolumeSetAlbedoScale(HeteroVolume heteroVolume, float scale);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprHeteroVolumeSetEmissionScale(HeteroVolume heteroVolume, float scale);

    [LibraryImport("RadeonProRender64")]
    private static unsafe partial Status rprHeteroVolumeSetDensityScale(HeteroVolume heteroVolume, float scale);
}

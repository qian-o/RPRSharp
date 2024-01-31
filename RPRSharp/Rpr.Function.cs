using System.Runtime.InteropServices;

namespace RPRSharp;

public partial class Rpr
{
    [LibraryImport(Core.Rpr)]
    private static unsafe partial int rprRegisterPlugin(char* path);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprCreateContext(uint apiVersion, int* pluginIDs, long pluginCount, uint creationFlags, ContextProperties* props, char* cachePath, Context* outContext);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextSetActivePlugin(Context context, int pluginID);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextGetInfo(Context context, ContextInfo contextInfo, long size, void* data, long* sizeRet);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextGetParameterInfo(Context context, int paramIdx, ParameterInfo parameterInfo, long size, void* data, long* sizeRet);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextGetAOV(Context context, Aov aov, Framebuffer* outFb);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextSetAOV(Context context, Aov aov, Framebuffer frameBuffer);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextAttachRenderLayer(Context context, char* renderLayerString);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextDetachRenderLayer(Context context, char* renderLayerString);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprFrameBufferSetLPE(Framebuffer frameBuffer, char* lpe);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextSetAOVindexLookup(Context context, int key, float colorR, float colorG, float colorB, float colorA);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextSetCuttingPlane(Context context, int index, float a, float b, float c, float d);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextSetAOVindicesLookup(Context context, int keyOffset, int keyCount, float* colorRGBA);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextSetUserTexture(Context context, int index, char* gpuCode, void* cpuCode);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextGetUserTexture(Context context, int index, long bufferSizeByte, void* buffer, long* sizeRet);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextSetScene(Context context, Scene scene);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextGetScene(Context arg0, Scene* outScene);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextSetParameterByKey1u(Context context, ContextInfo inInput, uint x);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextSetParameterByKeyPtr(Context context, ContextInfo inInput, void* x);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextSetParameterByKey1f(Context context, ContextInfo inInput, float x);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextSetParameterByKey3f(Context context, ContextInfo inInput, float x, float y, float z);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextSetParameterByKey4f(Context context, ContextInfo inInput, float x, float y, float z, float w);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextSetParameterByKeyString(Context context, ContextInfo inInput, char* value);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextSetInternalParameter4f(Context context, uint pluginIndex, char* paramName, float x, float y, float z, float w);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextSetInternalParameter1u(Context context, uint pluginIndex, char* paramName, uint x);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextSetInternalParameterBuffer(Context context, uint pluginIndex, char* paramName, void* buffer, long bufferSizeByte);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextGetInternalParameter4f(Context context, uint pluginIndex, char* paramName, float* x, float* y, float* z, float* w);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextGetInternalParameter1u(Context context, uint pluginIndex, char* paramName, uint* x);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextGetInternalParameterBuffer(Context context, uint pluginIndex, char* paramName, long bufferSizeByte, void* buffer, long* sizeRet);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextRender(Context context);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextAbortRender(Context context);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextRenderTile(Context context, uint xmin, uint xmax, uint ymin, uint ymax);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextClearMemory(Context context);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextCreateImage(Context context, ImageFormat format, ImageDesc* imageDesc, void* data, Image* outImage);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextCreateBuffer(Context context, BufferDesc* bufferDesc, void* data, Buffer* outBuffer);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextCreateImageFromFile(Context context, char* path, Image* outImage);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextCreateImageFromFileMemory(Context context, char* extension, void* data, long dataSizeByte, Image* outImage);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextCreateScene(Context context, Scene* outScene);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextCreateInstance(Context context, Shape shape, Shape* outInstance);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextCreateMesh(Context context, float* vertices, long numVertices, int vertexStride, float* normals, long numNormals, int normalStride, float* texcoords, long numTexcoords, int texcoordStride, int* vertexIndices, int vidxStride, int* normalIndices, int nidxStride, int* texcoordIndices, int tidxStride, int* numFaceVertices, long numFaces, Shape* outMesh);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextCreateMeshEx(Context context, float* vertices, long numVertices, int vertexStride, float* normals, long numNormals, int normalStride, int* perVertexFlag, long numPerVertexFlags, int perVertexFlagStride, int numberOfTexCoordLayers, float** texcoords, long* numTexcoords, int* texcoordStride, int* vertexIndices, int vidxStride, int* normalIndices, int nidxStride, int** texcoordIndices, int* tidxStride, int* numFaceVertices, long numFaces, Shape* outMesh);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextCreateMeshEx2(Context context, float* vertices, long numVertices, int vertexStride, float* normals, long numNormals, int normalStride, int* perVertexFlag, long numPerVertexFlags, int perVertexFlagStride, int numberOfTexCoordLayers, float** texcoords, long* numTexcoords, int* texcoordStride, int* vertexIndices, int vidxStride, int* normalIndices, int nidxStride, int** texcoordIndices, int* tidxStride, int* numFaceVertices, long numFaces, MeshInfo* meshProperties, Shape* outMesh);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextCreateCamera(Context context, Camera* outCamera);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextCreateFrameBuffer(Context context, FramebufferFormat format, FramebufferDesc* fbDesc, Framebuffer* outFb);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextGetFunctionPtr(Context context, char* functionName, void** outFunctionPtr);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprCameraGetInfo(Camera camera, CameraInfo cameraInfo, long size, void* data, long* sizeRet);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprCameraSetFocalLength(Camera camera, float flength);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprCameraSetMotionTransformCount(Camera camera, uint transformCount);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprCameraSetMotionTransform(Camera camera, [MarshalAs(UnmanagedType.Bool)] bool transpose, float* transform, uint timeIndex);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprCameraSetFocusDistance(Camera camera, float fdist);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprCameraSetTransform(Camera camera, [MarshalAs(UnmanagedType.Bool)] bool transpose, float* transform);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprCameraSetSensorSize(Camera camera, float width, float height);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprCameraLookAt(Camera camera, float posx, float posy, float posz, float atx, float aty, float atz, float upx, float upy, float upz);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprCameraSetFStop(Camera camera, float fstop);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprCameraSetApertureBlades(Camera camera, uint numBlades);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprCameraSetExposure(Camera camera, float exposure);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprCameraSetMode(Camera camera, CameraMode mode);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprCameraSetOrthoWidth(Camera camera, float width);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprCameraSetFocalTilt(Camera camera, float tilt);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprCameraSetIPD(Camera camera, float ipd);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprCameraSetLensShift(Camera camera, float shiftx, float shifty);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprCameraSetTiltCorrection(Camera camera, float tiltX, float tiltY);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprCameraSetOrthoHeight(Camera camera, float height);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprCameraSetNearPlane(Camera camera, float near);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprCameraSetPostScale(Camera camera, float scale);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprCameraSetFarPlane(Camera camera, float far);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprCameraSetUVDistortion(Camera camera, Image distortionMap);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprImageGetInfo(Image image, ImageInfo imageInfo, long size, void* data, long* sizeRet);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprImageSetWrap(Image image, ImageWrapType type);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprImageSetInternalCompression(Image image, uint compressionEnabled);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprImageSetOcioColorspace(Image image, char* ocioColorspace);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprImageSetUDIM(Image imageUdimRoot, uint tileIndex, Image imageTile);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprImageSetFilter(Image image, ImageFilterType type);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprImageSetGamma(Image image, float type);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprImageSetMipmapEnabled(Image image, [MarshalAs(UnmanagedType.Bool)] bool enabled);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprShapeSetTransform(Shape shape, [MarshalAs(UnmanagedType.Bool)] bool transpose, float* transform);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprShapeSetVertexValue(Shape inShape, int setIndex, int* indices, float* values, int indicesCount);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprShapeSetPrimvar(Shape inShape, uint key, float* data, uint floatCount, uint componentCount, PrimvarInterpolationType interop);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprShapeSetSubdivisionFactor(Shape shape, uint factor);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprShapeSetSubdivisionAutoRatioCap(Shape shape, float autoRatioCap);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprShapeSetSubdivisionCreaseWeight(Shape shape, float factor);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprShapeAttachRenderLayer(Shape shape, char* renderLayerString);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprShapeDetachRenderLayer(Shape shape, char* renderLayerString);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprLightAttachRenderLayer(Light light, char* renderLayerString);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprLightDetachRenderLayer(Light light, char* renderLayerString);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprShapeSetSubdivisionBoundaryInterop(Shape shape, SubdivBoundaryInterfopType type);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprShapeAutoAdaptSubdivisionFactor(Shape shape, Framebuffer framebuffer, Camera camera, int factor);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprShapeSetDisplacementScale(Shape shape, float minscale, float maxscale);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprShapeSetObjectGroupID(Shape shape, uint objectGroupID);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprShapeSetObjectID(Shape shape, uint objectID);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprShapeSetLightGroupID(Shape shape, uint lightGroupID);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprShapeSetLayerMask(Shape shape, uint layerMask);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprShapeSetDisplacementMaterial(Shape shape, MaterialNode materialNode);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprShapeSetMaterial(Shape shape, MaterialNode node);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprShapeSetMaterialFaces(Shape shape, MaterialNode node, int* faceIndices, long numFaces);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprShapeSetVolumeMaterial(Shape shape, MaterialNode node);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprShapeSetMotionTransformCount(Shape shape, uint transformCount);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprShapeSetMotionTransform(Shape shape, [MarshalAs(UnmanagedType.Bool)] bool transpose, float* transform, uint timeIndex);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprShapeSetVisibilityFlag(Shape shape, ShapeInfo visibilityFlag, [MarshalAs(UnmanagedType.Bool)] bool visible);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprCurveSetVisibilityFlag(Curve curve, CurveParameter visibilityFlag, [MarshalAs(UnmanagedType.Bool)] bool visible);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprShapeSetVisibility(Shape shape, [MarshalAs(UnmanagedType.Bool)] bool visible);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprLightSetVisibilityFlag(Light light, LightInfo visibilityFlag, [MarshalAs(UnmanagedType.Bool)] bool visible);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprCurveSetVisibility(Curve curve, [MarshalAs(UnmanagedType.Bool)] bool visible);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprShapeSetVisibilityInSpecular(Shape shape, [MarshalAs(UnmanagedType.Bool)] bool visible);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprShapeSetShadowCatcher(Shape shape, [MarshalAs(UnmanagedType.Bool)] bool shadowCatcher);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprShapeSetShadowColor(Shape shape, float r, float g, float b);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprShapeSetReflectionCatcher(Shape shape, [MarshalAs(UnmanagedType.Bool)] bool reflectionCatcher);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprShapeSetContourIgnore(Shape shape, [MarshalAs(UnmanagedType.Bool)] bool ignoreInContour);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprShapeSetEnvironmentLight(Shape shape, [MarshalAs(UnmanagedType.Bool)] bool envLight);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprShapeMarkStatic(Shape inShape, [MarshalAs(UnmanagedType.Bool)] bool inIsStatic);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprLightSetTransform(Light light, [MarshalAs(UnmanagedType.Bool)] bool transpose, float* transform);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprLightSetGroupId(Light light, uint groupId);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprShapeGetInfo(Shape arg0, ShapeInfo arg1, long arg2, void* arg3, long* arg4);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprMeshGetInfo(Shape mesh, MeshInfo meshInfo, long size, void* data, long* sizeRet);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprCurveGetInfo(Curve curve, CurveParameter curveInfo, long size, void* data, long* sizeRet);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprHeteroVolumeGetInfo(HeteroVolume heteroVol, HeteroVolumeParameter heteroVolInfo, long size, void* data, long* sizeRet);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprGridGetInfo(Grid grid, GridParameter gridInfo, long size, void* data, long* sizeRet);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprBufferGetInfo(Buffer buffer, BufferInfo bufferInfo, long size, void* data, long* sizeRet);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprInstanceGetBaseShape(Shape shape, Shape* outShape);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextCreatePointLight(Context context, Light* outLight);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprPointLightSetRadiantPower3f(Light light, float r, float g, float b);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextCreateSpotLight(Context context, Light* light);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextCreateSphereLight(Context context, Light* light);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextCreateDiskLight(Context context, Light* light);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprSpotLightSetRadiantPower3f(Light light, float r, float g, float b);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprSpotLightSetImage(Light light, Image img);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprSphereLightSetRadiantPower3f(Light light, float r, float g, float b);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprSphereLightSetRadius(Light light, float radius);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprDiskLightSetRadiantPower3f(Light light, float r, float g, float b);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprDiskLightSetRadius(Light light, float radius);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprDiskLightSetAngle(Light light, float angle);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprDiskLightSetInnerAngle(Light light, float innerAngle);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprSpotLightSetConeShape(Light light, float iangle, float oangle);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextCreateDirectionalLight(Context context, Light* outLight);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprDirectionalLightSetRadiantPower3f(Light light, float r, float g, float b);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprDirectionalLightSetShadowSoftnessAngle(Light light, float softnessAngle);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextCreateEnvironmentLight(Context context, Light* outLight);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprEnvironmentLightSetImage(Light envLight, Image image);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprEnvironmentLightSetIntensityScale(Light envLight, float intensityScale);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprEnvironmentLightAttachPortal(Scene scene, Light envLight, Shape portal);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprEnvironmentLightDetachPortal(Scene scene, Light envLight, Shape portal);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprEnvironmentLightSetEnvironmentLightOverride(Light inIbl, uint overrideType, Light inIblOverride);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprEnvironmentLightGetEnvironmentLightOverride(Light inIbl, uint overrideType, Light* outIblOverride);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextCreateSkyLight(Context context, Light* outLight);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprSkyLightSetTurbidity(Light skylight, float turbidity);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprSkyLightSetAlbedo(Light skylight, float albedo);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprSkyLightSetScale(Light skylight, float scale);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprSkyLightSetDirection(Light skylight, float x, float y, float z);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprSkyLightAttachPortal(Scene scene, Light skylight, Shape portal);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprSkyLightDetachPortal(Scene scene, Light skylight, Shape portal);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextCreateIESLight(Context context, Light* light);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprIESLightSetRadiantPower3f(Light light, float r, float g, float b);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprIESLightSetImageFromFile(Light envLight, char* imagePath, int nx, int ny);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprIESLightSetImageFromIESdata(Light envLight, char* iesData, int nx, int ny);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprLightGetInfo(Light light, LightInfo info, long size, void* data, long* sizeRet);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprSceneClear(Scene scene);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprSceneAttachShape(Scene scene, Shape shape);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprSceneDetachShape(Scene scene, Shape shape);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprSceneAttachHeteroVolume(Scene scene, HeteroVolume heteroVolume);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprSceneDetachHeteroVolume(Scene scene, HeteroVolume heteroVolume);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprSceneAttachCurve(Scene scene, Curve curve);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprSceneDetachCurve(Scene scene, Curve curve);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprCurveSetMaterial(Curve curve, MaterialNode material);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprCurveSetTransform(Curve curve, [MarshalAs(UnmanagedType.Bool)] bool transpose, float* transform);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextCreateCurve(Context context, Curve* outCurve, long numControlPoints, float* controlPointsData, int controlPointsStride, long numIndices, uint curveCount, uint* indicesData, float* radius, float* textureUV, int* segmentPerCurve, uint creationFlagTapered);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprSceneAttachLight(Scene scene, Light light);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprSceneDetachLight(Scene scene, Light light);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprSceneSetEnvironmentLight(Scene inScene, Light inLight);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprSceneGetEnvironmentLight(Scene inScene, Light* outLight);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprSceneGetInfo(Scene scene, SceneInfo info, long size, void* data, long* sizeRet);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprSceneSetBackgroundImage(Scene scene, Image image);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprSceneGetBackgroundImage(Scene scene, Image* outImage);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprSceneSetCameraRight(Scene scene, Camera camera);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprSceneGetCameraRight(Scene scene, Camera* outCamera);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprSceneSetCamera(Scene scene, Camera camera);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprSceneGetCamera(Scene scene, Camera* outCamera);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprFrameBufferGetInfo(Framebuffer framebuffer, FramebufferInfo info, long size, void* data, long* sizeRet);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprFrameBufferClear(Framebuffer frameBuffer);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprFrameBufferFillWithColor(Framebuffer frameBuffer, float r, float g, float b, float a);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprFrameBufferSaveToFile(Framebuffer frameBuffer, char* filePath);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprFrameBufferSaveToFileEx(Framebuffer* framebufferList, uint framebufferCount, char* filePath, void* extraOptions);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextResolveFrameBuffer(Context context, Framebuffer srcFrameBuffer, Framebuffer dstFrameBuffer, [MarshalAs(UnmanagedType.Bool)] bool noDisplayGamma);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprMaterialSystemGetInfo(MaterialSystem inMaterialSystem, MaterialSystemInfo type, long inSize, void* inData, long* outSize);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextCreateMaterialSystem(Context inContext, uint type, MaterialSystem* outMatsys);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprMaterialSystemGetSize(Context inContext, uint* outSize);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprMaterialSystemCreateNode(MaterialSystem inMatsys, MaterialNodeType inType, MaterialNode* outNode);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprMaterialNodeSetID(MaterialNode inNode, uint id);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprMaterialNodeSetInputNByKey(MaterialNode inNode, MaterialNodeInput inInput, MaterialNode inInputNode);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprMaterialNodeSetInputFByKey(MaterialNode inNode, MaterialNodeInput inInput, float inValueX, float inValueY, float inValueZ, float inValueW);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprMaterialNodeSetInputDataByKey(MaterialNode inNode, MaterialNodeInput inInput, void* data, long dataSizeByte);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprMaterialNodeSetInputUByKey(MaterialNode inNode, MaterialNodeInput inInput, uint inValue);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprMaterialNodeSetInputImageDataByKey(MaterialNode inNode, MaterialNodeInput inInput, Image image);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprMaterialNodeSetInputLightDataByKey(MaterialNode inNode, MaterialNodeInput inInput, Light light);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprMaterialNodeSetInputBufferDataByKey(MaterialNode inNode, MaterialNodeInput inInput, Buffer buffer);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprMaterialNodeSetInputGridDataByKey(MaterialNode inNode, MaterialNodeInput inInput, Grid grid);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprMaterialNodeGetInfo(MaterialNode inNode, MaterialNodeInfo inInfo, long inSize, void* inData, long* outSize);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprMaterialNodeGetInputInfo(MaterialNode inNode, int inInputIdx, MaterialNodeInputInfo inInfo, long inSize, void* inData, long* outSize);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextCreateComposite(Context context, CompositeType inType, Composite* outComposite);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextCreateLUTFromFile(Context context, char* fileLutPath, Lut* outLut);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextCreateLUTFromData(Context context, char* lutData, Lut* outLut);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprCompositeSetInputFb(Composite composite, char* inputName, Framebuffer input);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprCompositeSetInputC(Composite composite, char* inputName, Composite input);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprCompositeSetInputLUT(Composite composite, char* inputName, Lut input);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprCompositeSetInput4f(Composite composite, char* inputName, float x, float y, float z, float w);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprCompositeSetInput1u(Composite composite, char* inputName, uint value);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprCompositeSetInputOp(Composite composite, char* inputName, MaterialNodeArithmeticOperation op);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprCompositeCompute(Composite composite, Framebuffer fb);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprCompositeGetInfo(Composite composite, CompositeInfo compositeInfo, long size, void* data, long* sizeRet);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprObjectDelete(void* obj);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprObjectSetName(void* node, char* name);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprObjectSetCustomPointer(void* node, void* customPtr);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprObjectGetCustomPointer(void* node, void** customPtrOut);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextCreatePostEffect(Context context, PostEffectType type, PostEffect* outEffect);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextAttachPostEffect(Context context, PostEffect effect);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextDetachPostEffect(Context context, PostEffect effect);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprPostEffectSetParameter1u(PostEffect effect, char* name, uint x);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprPostEffectSetParameter1f(PostEffect effect, char* name, float x);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprPostEffectSetParameter3f(PostEffect effect, char* name, float x, float y, float z);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprPostEffectSetParameter4f(PostEffect effect, char* name, float x, float y, float z, float w);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextGetAttachedPostEffectCount(Context context, uint* nb);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextGetAttachedPostEffect(Context context, uint i, PostEffect* outEffect);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprPostEffectGetInfo(PostEffect effect, PostEffectInfo info, long size, void* data, long* sizeRet);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextCreateGrid(Context context, Grid* outGrid, long gridSizeX, long gridSizeY, long gridSizeZ, void* indicesList, long numberOfIndices, GridIndicesTopology indicesListTopology, void* gridData, long gridDataSizeByte, uint gridDataTopology_Unused);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprContextCreateHeteroVolume(Context context, HeteroVolume* outHeteroVolume);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprShapeSetHeteroVolume(Shape shape, HeteroVolume heteroVolume);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprHeteroVolumeSetTransform(HeteroVolume heteroVolume, [MarshalAs(UnmanagedType.Bool)] bool transpose, float* transform);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprHeteroVolumeSetEmissionGrid(HeteroVolume heteroVolume, Grid grid);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprHeteroVolumeSetDensityGrid(HeteroVolume heteroVolume, Grid grid);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprHeteroVolumeSetAlbedoGrid(HeteroVolume heteroVolume, Grid grid);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprHeteroVolumeSetEmissionLookup(HeteroVolume heteroVolume, float* ptr, uint n);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprHeteroVolumeSetDensityLookup(HeteroVolume heteroVolume, float* ptr, uint n);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprHeteroVolumeSetAlbedoLookup(HeteroVolume heteroVolume, float* ptr, uint n);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprHeteroVolumeSetAlbedoScale(HeteroVolume heteroVolume, float scale);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprHeteroVolumeSetEmissionScale(HeteroVolume heteroVolume, float scale);

    [LibraryImport(Core.Rpr)]
    private static unsafe partial Status rprHeteroVolumeSetDensityScale(HeteroVolume heteroVolume, float scale);
}

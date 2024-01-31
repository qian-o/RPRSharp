using System.ComponentModel;

namespace RPRSharp;

public enum Platform
{
    [Description("Windows")]
    Windows = 0,
    [Description("CentOS")]
    CentOS = 1,
    [Description("Ubuntu")]
    Ubuntu = 2,
    [Description("MacOS")]
    MacOS = 3,
    [Description("Unknown")]
    Unknown = -1
}

public enum Status
{
    [Description("RPR_SUCCESS")]
    Success = 0,

    [Description("RPR_ERROR_COMPUTE_API_NOT_SUPPORTED")]
    ErrorComputeApiNotSupported = -1,

    [Description("RPR_ERROR_OUT_OF_SYSTEM_MEMORY")]
    ErrorOutOfSystemMemory = -2,

    [Description("RPR_ERROR_OUT_OF_VIDEO_MEMORY")]
    ErrorOutOfVideoMemory = -3,

    [Description("RPR_ERROR_SHADER_COMPILATION")]
    ErrorShaderCompilation = -4,

    [Description("RPR_ERROR_INVALID_LIGHTPATH_EXPR")]
    ErrorInvalidLightpathExpr = -5,

    [Description("RPR_ERROR_INVALID_IMAGE")]
    ErrorInvalidImage = -6,

    [Description("RPR_ERROR_INVALID_AA_METHOD")]
    ErrorInvalidAaMethod = -7,

    [Description("RPR_ERROR_UNSUPPORTED_IMAGE_FORMAT")]
    ErrorUnsupportedImageFormat = -8,

    [Description("RPR_ERROR_INVALID_GL_TEXTURE")]
    ErrorInvalidGlTexture = -9,

    [Description("RPR_ERROR_INVALID_CL_IMAGE")]
    ErrorInvalidClImage = -10,

    [Description("RPR_ERROR_INVALID_OBJECT")]
    ErrorInvalidObject = -11,

    [Description("RPR_ERROR_INVALID_PARAMETER")]
    ErrorInvalidParameter = -12,

    [Description("RPR_ERROR_INVALID_TAG")]
    ErrorInvalidTag = -13,

    [Description("RPR_ERROR_INVALID_LIGHT")]
    ErrorInvalidLight = -14,

    [Description("RPR_ERROR_INVALID_CONTEXT")]
    ErrorInvalidContext = -15,

    [Description("RPR_ERROR_UNIMPLEMENTED")]
    ErrorUnimplemented = -16,

    [Description("RPR_ERROR_INVALID_API_VERSION")]
    ErrorInvalidApiVersion = -17,

    [Description("RPR_ERROR_INTERNAL_ERROR")]
    ErrorInternalError = -18,

    [Description("RPR_ERROR_IO_ERROR")]
    ErrorIoError = -19,

    [Description("RPR_ERROR_UNSUPPORTED_SHADER_PARAMETER_TYPE")]
    ErrorUnsupportedShaderParameterType = -20,

    [Description("RPR_ERROR_MATERIAL_STACK_OVERFLOW")]
    ErrorMaterialStackOverflow = -21,

    [Description("RPR_ERROR_INVALID_PARAMETER_TYPE")]
    ErrorInvalidParameterType = -22,

    [Description("RPR_ERROR_UNSUPPORTED")]
    ErrorUnsupported = -23,

    [Description("RPR_ERROR_OPENCL_OUT_OF_HOST_MEMORY")]
    ErrorOpenclOutOfHostMemory = -24,

    [Description("RPR_ERROR_OPENGL")]
    ErrorOpengl = -25,

    [Description("RPR_ERROR_OPENCL")]
    ErrorOpencl = -26,

    [Description("RPR_ERROR_NULLPTR")]
    ErrorNullptr = -27,

    [Description("RPR_ERROR_NODETYPE")]
    ErrorNodetype = -28,

    [Description("RPR_ERROR_ABORTED")]
    ErrorAborted = -29
}

public enum ParameterType
{
    [Description("RPR_PARAMETER_TYPE_UNDEF")]
    Undef = 0,

    [Description("RPR_PARAMETER_TYPE_FLOAT")]
    Float = 1,

    [Description("RPR_PARAMETER_TYPE_FLOAT2")]
    Float2 = 2,

    [Description("RPR_PARAMETER_TYPE_FLOAT3")]
    Float3 = 3,

    [Description("RPR_PARAMETER_TYPE_FLOAT4")]
    Float4 = 4,

    [Description("RPR_PARAMETER_TYPE_IMAGE")]
    Image = 5,

    [Description("RPR_PARAMETER_TYPE_STRING")]
    String = 6,

    [Description("RPR_PARAMETER_TYPE_SHADER")]
    Shader = 7,

    [Description("RPR_PARAMETER_TYPE_UINT")]
    Uint = 8,

    [Description("RPR_PARAMETER_TYPE_ULONG")]
    Ulong = 9,

    [Description("RPR_PARAMETER_TYPE_LONGLONG")]
    Longlong = 10
}

public enum CreationFlags
{
    [Description("RPR_CREATION_FLAGS_ENABLE_GPU0")]
    EnableGpu0 = 1,

    [Description("RPR_CREATION_FLAGS_ENABLE_GPU1")]
    EnableGpu1 = 2,

    [Description("RPR_CREATION_FLAGS_ENABLE_GPU2")]
    EnableGpu2 = 4,

    [Description("RPR_CREATION_FLAGS_ENABLE_GPU3")]
    EnableGpu3 = 8,

    [Description("RPR_CREATION_FLAGS_ENABLE_CPU")]
    EnableCpu = 16,

    [Description("RPR_CREATION_FLAGS_ENABLE_GL_INTEROP")]
    EnableGlInterop = 32,

    [Description("RPR_CREATION_FLAGS_ENABLE_GPU4")]
    EnableGpu4 = 64,

    [Description("RPR_CREATION_FLAGS_ENABLE_GPU5")]
    EnableGpu5 = 128,

    [Description("RPR_CREATION_FLAGS_ENABLE_GPU6")]
    EnableGpu6 = 256,

    [Description("RPR_CREATION_FLAGS_ENABLE_GPU7")]
    EnableGpu7 = 512,

    [Description("RPR_CREATION_FLAGS_ENABLE_METAL")]
    EnableMetal = 1024,

    [Description("RPR_CREATION_FLAGS_ENABLE_GPU8")]
    EnableGpu8 = 2048,

    [Description("RPR_CREATION_FLAGS_ENABLE_GPU9")]
    EnableGpu9 = 4096,

    [Description("RPR_CREATION_FLAGS_ENABLE_GPU10")]
    EnableGpu10 = 8192,

    [Description("RPR_CREATION_FLAGS_ENABLE_GPU11")]
    EnableGpu11 = 16384,

    [Description("RPR_CREATION_FLAGS_ENABLE_GPU12")]
    EnableGpu12 = 32768,

    [Description("RPR_CREATION_FLAGS_ENABLE_GPU13")]
    EnableGpu13 = 65536,

    [Description("RPR_CREATION_FLAGS_ENABLE_GPU14")]
    EnableGpu14 = 131072,

    [Description("RPR_CREATION_FLAGS_ENABLE_GPU15")]
    EnableGpu15 = 262144,

    [Description("RPR_CREATION_FLAGS_ENABLE_HIP")]
    EnableHip = 524288,

    [Description("RPR_CREATION_FLAGS_ENABLE_OPENCL")]
    EnableOpencl = 1048576,

    [Description("RPR_CREATION_FLAGS_ENABLE_DEBUG")]
    EnableDebug = -2147483648
}

public enum AaFilter
{
    [Description("RPR_FILTER_NONE")]
    FilterNone = 0,

    [Description("RPR_FILTER_BOX")]
    FilterBox = 1,

    [Description("RPR_FILTER_TRIANGLE")]
    FilterTriangle = 2,

    [Description("RPR_FILTER_GAUSSIAN")]
    FilterGaussian = 3,

    [Description("RPR_FILTER_MITCHELL")]
    FilterMitchell = 4,

    [Description("RPR_FILTER_LANCZOS")]
    FilterLanczos = 5,

    [Description("RPR_FILTER_BLACKMANHARRIS")]
    FilterBlackmanharris = 6
}

public enum ContextSamplerType
{
    [Description("RPR_CONTEXT_SAMPLER_TYPE_SOBOL")]
    Sobol = 1,

    [Description("RPR_CONTEXT_SAMPLER_TYPE_RANDOM")]
    Random = 2,

    [Description("RPR_CONTEXT_SAMPLER_TYPE_CMJ")]
    Cmj = 3
}

public enum PrimvarInterpolationType
{
    [Description("RPR_PRIMVAR_INTERPOLATION_CONSTANT")]
    Constant = 1,

    [Description("RPR_PRIMVAR_INTERPOLATION_UNIFORM")]
    Uniform = 2,

    [Description("RPR_PRIMVAR_INTERPOLATION_VERTEX")]
    Vertex = 3,

    [Description("RPR_PRIMVAR_INTERPOLATION_FACEVARYING_NORMAL")]
    FacevaryingNormal = 4,

    [Description("RPR_PRIMVAR_INTERPOLATION_FACEVARYING_UV")]
    FacevaryingUv = 5
}

public enum ShapeType
{
    [Description("RPR_SHAPE_TYPE_MESH")]
    Mesh = 1,

    [Description("RPR_SHAPE_TYPE_INSTANCE")]
    Instance = 2
}

public enum LightType
{
    [Description("RPR_LIGHT_TYPE_POINT")]
    Point = 1,

    [Description("RPR_LIGHT_TYPE_DIRECTIONAL")]
    Directional = 2,

    [Description("RPR_LIGHT_TYPE_SPOT")]
    Spot = 3,

    [Description("RPR_LIGHT_TYPE_ENVIRONMENT")]
    Environment = 4,

    [Description("RPR_LIGHT_TYPE_SKY")]
    Sky = 5,

    [Description("RPR_LIGHT_TYPE_IES")]
    Ies = 6,

    [Description("RPR_LIGHT_TYPE_SPHERE")]
    Sphere = 7,

    [Description("RPR_LIGHT_TYPE_DISK")]
    Disk = 8
}

public enum ContextInfo
{
    [Description("RPR_CONTEXT_CREATION_FLAGS")]
    CreationFlags = 258,

    [Description("RPR_CONTEXT_CACHE_PATH")]
    CachePath = 259,

    [Description("RPR_CONTEXT_RENDER_STATUS")]
    RenderStatus = 260,

    [Description("RPR_CONTEXT_RENDER_STATISTICS")]
    RenderStatistics = 261,

    [Description("RPR_CONTEXT_DEVICE_COUNT")]
    DeviceCount = 262,

    [Description("RPR_CONTEXT_PARAMETER_COUNT")]
    ParameterCount = 263,

    [Description("RPR_CONTEXT_ACTIVE_PLUGIN")]
    ActivePlugin = 264,

    [Description("RPR_CONTEXT_SCENE")]
    Scene = 265,

    [Description("RPR_CONTEXT_ITERATIONS")]
    Iterations = 267,

    [Description("RPR_CONTEXT_IMAGE_FILTER_TYPE")]
    ImageFilterType = 268,

    [Description("RPR_CONTEXT_TONE_MAPPING_TYPE")]
    ToneMappingType = 275,

    [Description("RPR_CONTEXT_TONE_MAPPING_LINEAR_SCALE")]
    ToneMappingLinearScale = 276,

    [Description("RPR_CONTEXT_TONE_MAPPING_PHOTO_LINEAR_SENSITIVITY")]
    ToneMappingPhotoLinearSensitivity = 277,

    [Description("RPR_CONTEXT_TONE_MAPPING_PHOTO_LINEAR_EXPOSURE")]
    ToneMappingPhotoLinearExposure = 278,

    [Description("RPR_CONTEXT_TONE_MAPPING_PHOTO_LINEAR_FSTOP")]
    ToneMappingPhotoLinearFstop = 279,

    [Description("RPR_CONTEXT_TONE_MAPPING_REINHARD02_PRE_SCALE")]
    ToneMappingReinhard02PreScale = 280,

    [Description("RPR_CONTEXT_TONE_MAPPING_REINHARD02_POST_SCALE")]
    ToneMappingReinhard02PostScale = 281,

    [Description("RPR_CONTEXT_TONE_MAPPING_REINHARD02_BURN")]
    ToneMappingReinhard02Burn = 282,

    [Description("RPR_CONTEXT_MAX_RECURSION")]
    MaxRecursion = 283,

    [Description("RPR_CONTEXT_RAY_CAST_EPSILON")]
    RayCastEpsilon = 284,

    [Description("RPR_CONTEXT_RADIANCE_CLAMP")]
    RadianceClamp = 285,

    [Description("RPR_CONTEXT_X_FLIP")]
    XFlip = 286,

    [Description("RPR_CONTEXT_Y_FLIP")]
    YFlip = 287,

    [Description("RPR_CONTEXT_TEXTURE_GAMMA")]
    TextureGamma = 288,

    [Description("RPR_CONTEXT_PDF_THRESHOLD")]
    PdfThreshold = 289,

    [Description("RPR_CONTEXT_RENDER_MODE")]
    RenderMode = 290,

    [Description("RPR_CONTEXT_ROUGHNESS_CAP")]
    RoughnessCap = 291,

    [Description("RPR_CONTEXT_DISPLAY_GAMMA")]
    DisplayGamma = 292,

    [Description("RPR_CONTEXT_MATERIAL_STACK_SIZE")]
    MaterialStackSize = 293,

    [Description("RPR_CONTEXT_CUTTING_PLANES")]
    CuttingPlanes = 294,

    [Description("RPR_CONTEXT_GPU0_NAME")]
    Gpu0Name = 295,

    [Description("RPR_CONTEXT_GPU1_NAME")]
    Gpu1Name = 296,

    [Description("RPR_CONTEXT_GPU2_NAME")]
    Gpu2Name = 297,

    [Description("RPR_CONTEXT_GPU3_NAME")]
    Gpu3Name = 298,

    [Description("RPR_CONTEXT_CPU_NAME")]
    CpuName = 299,

    [Description("RPR_CONTEXT_GPU4_NAME")]
    Gpu4Name = 300,

    [Description("RPR_CONTEXT_GPU5_NAME")]
    Gpu5Name = 301,

    [Description("RPR_CONTEXT_GPU6_NAME")]
    Gpu6Name = 302,

    [Description("RPR_CONTEXT_GPU7_NAME")]
    Gpu7Name = 303,

    [Description("RPR_CONTEXT_TONE_MAPPING_EXPONENTIAL_INTENSITY")]
    ToneMappingExponentialIntensity = 304,

    [Description("RPR_CONTEXT_FRAMECOUNT")]
    Framecount = 305,

    [Description("RPR_CONTEXT_TEXTURE_COMPRESSION")]
    TextureCompression = 306,

    [Description("RPR_CONTEXT_AO_RAY_LENGTH")]
    AoRayLength = 307,

    [Description("RPR_CONTEXT_OOC_TEXTURE_CACHE")]
    OocTextureCache = 308,

    [Description("RPR_CONTEXT_PREVIEW")]
    Preview = 309,

    [Description("RPR_CONTEXT_CPU_THREAD_LIMIT")]
    CpuThreadLimit = 310,

    [Description("RPR_CONTEXT_LAST_ERROR_MESSAGE")]
    LastErrorMessage = 311,

    [Description("RPR_CONTEXT_MAX_DEPTH_DIFFUSE")]
    MaxDepthDiffuse = 312,

    [Description("RPR_CONTEXT_MAX_DEPTH_GLOSSY")]
    MaxDepthGlossy = 313,

    [Description("RPR_CONTEXT_OOC_CACHE_PATH")]
    OocCachePath = 314,

    [Description("RPR_CONTEXT_MAX_DEPTH_REFRACTION")]
    MaxDepthRefraction = 315,

    [Description("RPR_CONTEXT_MAX_DEPTH_GLOSSY_REFRACTION")]
    MaxDepthGlossyRefraction = 316,

    [Description("RPR_CONTEXT_RENDER_LAYER_MASK")]
    RenderLayerMask = 317,

    [Description("RPR_CONTEXT_SINGLE_LEVEL_BVH_ENABLED")]
    SingleLevelBvhEnabled = 318,

    [Description("RPR_CONTEXT_TRANSPARENT_BACKGROUND")]
    TransparentBackground = 319,

    [Description("RPR_CONTEXT_MAX_DEPTH_SHADOW")]
    MaxDepthShadow = 320,

    [Description("RPR_CONTEXT_API_VERSION")]
    ApiVersion = 321,

    [Description("RPR_CONTEXT_GPU8_NAME")]
    Gpu8Name = 322,

    [Description("RPR_CONTEXT_GPU9_NAME")]
    Gpu9Name = 323,

    [Description("RPR_CONTEXT_GPU10_NAME")]
    Gpu10Name = 324,

    [Description("RPR_CONTEXT_GPU11_NAME")]
    Gpu11Name = 325,

    [Description("RPR_CONTEXT_GPU12_NAME")]
    Gpu12Name = 326,

    [Description("RPR_CONTEXT_GPU13_NAME")]
    Gpu13Name = 327,

    [Description("RPR_CONTEXT_GPU14_NAME")]
    Gpu14Name = 328,

    [Description("RPR_CONTEXT_GPU15_NAME")]
    Gpu15Name = 329,

    [Description("RPR_CONTEXT_API_VERSION_MINOR")]
    ApiVersionMinor = 330,

    [Description("RPR_CONTEXT_METAL_PERFORMANCE_SHADER")]
    MetalPerformanceShader = 331,

    [Description("RPR_CONTEXT_USER_TEXTURE_0")]
    UserTexture0 = 332,

    [Description("RPR_CONTEXT_USER_TEXTURE_1")]
    UserTexture1 = 333,

    [Description("RPR_CONTEXT_USER_TEXTURE_2")]
    UserTexture2 = 334,

    [Description("RPR_CONTEXT_USER_TEXTURE_3")]
    UserTexture3 = 335,

    [Description("RPR_CONTEXT_MIPMAP_LOD_OFFSET")]
    MipmapLodOffset = 336,

    [Description("RPR_CONTEXT_AO_RAY_COUNT")]
    AoRayCount = 337,

    [Description("RPR_CONTEXT_SAMPLER_TYPE")]
    SamplerType = 338,

    [Description("RPR_CONTEXT_ADAPTIVE_SAMPLING_TILE_SIZE")]
    AdaptiveSamplingTileSize = 339,

    [Description("RPR_CONTEXT_ADAPTIVE_SAMPLING_MIN_SPP")]
    AdaptiveSamplingMinSpp = 340,

    [Description("RPR_CONTEXT_ADAPTIVE_SAMPLING_THRESHOLD")]
    AdaptiveSamplingThreshold = 341,

    [Description("RPR_CONTEXT_TILE_SIZE")]
    TileSize = 342,

    [Description("RPR_CONTEXT_LIST_CREATED_CAMERAS")]
    ListCreatedCameras = 343,

    [Description("RPR_CONTEXT_LIST_CREATED_MATERIALNODES")]
    ListCreatedMaterialnodes = 344,

    [Description("RPR_CONTEXT_LIST_CREATED_LIGHTS")]
    ListCreatedLights = 345,

    [Description("RPR_CONTEXT_LIST_CREATED_SHAPES")]
    ListCreatedShapes = 346,

    [Description("RPR_CONTEXT_LIST_CREATED_POSTEFFECTS")]
    ListCreatedPosteffects = 347,

    [Description("RPR_CONTEXT_LIST_CREATED_HETEROVOLUMES")]
    ListCreatedHeterovolumes = 348,

    [Description("RPR_CONTEXT_LIST_CREATED_GRIDS")]
    ListCreatedGrids = 349,

    [Description("RPR_CONTEXT_LIST_CREATED_BUFFERS")]
    ListCreatedBuffers = 350,

    [Description("RPR_CONTEXT_LIST_CREATED_IMAGES")]
    ListCreatedImages = 351,

    [Description("RPR_CONTEXT_LIST_CREATED_FRAMEBUFFERS")]
    ListCreatedFramebuffers = 352,

    [Description("RPR_CONTEXT_LIST_CREATED_SCENES")]
    ListCreatedScenes = 353,

    [Description("RPR_CONTEXT_LIST_CREATED_CURVES")]
    ListCreatedCurves = 354,

    [Description("RPR_CONTEXT_LIST_CREATED_MATERIALSYSTEM")]
    ListCreatedMaterialsystem = 355,

    [Description("RPR_CONTEXT_LIST_CREATED_COMPOSITE")]
    ListCreatedComposite = 356,

    [Description("RPR_CONTEXT_LIST_CREATED_LUT")]
    ListCreatedLut = 357,

    [Description("RPR_CONTEXT_AA_ENABLED")]
    AaEnabled = 358,

    [Description("RPR_CONTEXT_ACTIVE_PIXEL_COUNT")]
    ActivePixelCount = 359,

    [Description("RPR_CONTEXT_TRACING_ENABLED")]
    TracingEnabled = 360,

    [Description("RPR_CONTEXT_TRACING_PATH")]
    TracingPath = 361,

    [Description("RPR_CONTEXT_TILE_RECT")]
    TileRect = 362,

    [Description("RPR_CONTEXT_PLUGIN_VERSION")]
    PluginVersion = 363,

    [Description("RPR_CONTEXT_RUSSIAN_ROULETTE_DEPTH")]
    RussianRouletteDepth = 364,

    [Description("RPR_CONTEXT_SHADOW_CATCHER_BAKING")]
    ShadowCatcherBaking = 365,

    [Description("RPR_CONTEXT_RENDER_UPDATE_CALLBACK_FUNC")]
    RenderUpdateCallbackFunc = 366,

    [Description("RPR_CONTEXT_RENDER_UPDATE_CALLBACK_DATA")]
    RenderUpdateCallbackData = 367,

    [Description("RPR_CONTEXT_COMPILE_CALLBACK_FUNC")]
    CompileCallbackFunc = 1537,

    [Description("RPR_CONTEXT_COMPILE_CALLBACK_DATA")]
    CompileCallbackData = 1538,

    [Description("RPR_CONTEXT_TEXTURE_CACHE_PATH")]
    TextureCachePath = 368,

    [Description("RPR_CONTEXT_OCIO_CONFIG_PATH")]
    OcioConfigPath = 369,

    [Description("RPR_CONTEXT_OCIO_RENDERING_COLOR_SPACE")]
    OcioRenderingColorSpace = 370,

    [Description("RPR_CONTEXT_CONTOUR_USE_OBJECTID")]
    ContourUseObjectid = 371,

    [Description("RPR_CONTEXT_CONTOUR_USE_MATERIALID")]
    ContourUseMaterialid = 372,

    [Description("RPR_CONTEXT_CONTOUR_USE_NORMAL")]
    ContourUseNormal = 373,

    [Description("RPR_CONTEXT_CONTOUR_USE_UV")]
    ContourUseUv = 390,

    [Description("RPR_CONTEXT_CONTOUR_NORMAL_THRESHOLD")]
    ContourNormalThreshold = 374,

    [Description("RPR_CONTEXT_CONTOUR_UV_THRESHOLD")]
    ContourUvThreshold = 391,

    [Description("RPR_CONTEXT_CONTOUR_UV_SECONDARY")]
    ContourUvSecondary = 404,

    [Description("RPR_CONTEXT_CONTOUR_LINEWIDTH_OBJECTID")]
    ContourLinewidthObjectid = 375,

    [Description("RPR_CONTEXT_CONTOUR_LINEWIDTH_MATERIALID")]
    ContourLinewidthMaterialid = 376,

    [Description("RPR_CONTEXT_CONTOUR_LINEWIDTH_NORMAL")]
    ContourLinewidthNormal = 377,

    [Description("RPR_CONTEXT_CONTOUR_LINEWIDTH_UV")]
    ContourLinewidthUv = 392,

    [Description("RPR_CONTEXT_CONTOUR_ANTIALIASING")]
    ContourAntialiasing = 378,

    [Description("RPR_CONTEXT_CONTOUR_DEBUG_ENABLED")]
    ContourDebugEnabled = 383,

    [Description("RPR_CONTEXT_GPUINTEGRATOR")]
    Gpuintegrator = 379,

    [Description("RPR_CONTEXT_CPUINTEGRATOR")]
    Cpuintegrator = 380,

    [Description("RPR_CONTEXT_BEAUTY_MOTION_BLUR")]
    BeautyMotionBlur = 381,

    [Description("RPR_CONTEXT_CAUSTICS_REDUCTION")]
    CausticsReduction = 382,

    [Description("RPR_CONTEXT_GPU_MEMORY_LIMIT")]
    GpuMemoryLimit = 384,

    [Description("RPR_CONTEXT_RENDER_LAYER_LIST")]
    RenderLayerList = 385,

    [Description("RPR_CONTEXT_WINDING_ORDER_CORRECTION")]
    WindingOrderCorrection = 386,

    [Description("RPR_CONTEXT_DEEP_SUBPIXEL_MERGE_Z_THRESHOLD")]
    DeepSubpixelMergeZThreshold = 387,

    [Description("RPR_CONTEXT_DEEP_GPU_ALLOCATION_LEVEL")]
    DeepGpuAllocationLevel = 388,

    [Description("RPR_CONTEXT_DEEP_COLOR_ENABLED")]
    DeepColorEnabled = 389,

    [Description("RPR_CONTEXT_FOG_COLOR")]
    FogColor = 393,

    [Description("RPR_CONTEXT_FOG_DISTANCE")]
    FogDistance = 394,

    [Description("RPR_CONTEXT_FOG_HEIGHT")]
    FogHeight = 395,

    [Description("RPR_CONTEXT_ATMOSPHERE_VOLUME_COLOR")]
    AtmosphereVolumeColor = 396,

    [Description("RPR_CONTEXT_ATMOSPHERE_VOLUME_DENSITY")]
    AtmosphereVolumeDensity = 397,

    [Description("RPR_CONTEXT_ATMOSPHERE_VOLUME_RADIANCE_CLAMP")]
    AtmosphereVolumeRadianceClamp = 399,

    [Description("RPR_CONTEXT_FOG_HEIGHT_OFFSET")]
    FogHeightOffset = 398,

    [Description("RPR_CONTEXT_INDIRECT_DOWNSAMPLE")]
    IndirectDownsample = 400,

    [Description("RPR_CONTEXT_CRYPTOMATTE_EXTENDED")]
    CryptomatteExtended = 401,

    [Description("RPR_CONTEXT_CRYPTOMATTE_SPLIT_INDIRECT")]
    CryptomatteSplitIndirect = 402,

    [Description("RPR_CONTEXT_FOG_DIRECTION")]
    FogDirection = 403,

    [Description("RPR_CONTEXT_RANDOM_SEED")]
    RandomSeed = 4096,

    [Description("RPR_CONTEXT_IBL_DISPLAY")]
    IblDisplay = 405,

    [Description("RPR_CONTEXT_FRAMEBUFFER_SAVE_FLOAT32")]
    FramebufferSaveFloat32 = 406,

    [Description("RPR_CONTEXT_UPDATE_TIME_CALLBACK_FUNC")]
    UpdateTimeCallbackFunc = 407,

    [Description("RPR_CONTEXT_UPDATE_TIME_CALLBACK_DATA")]
    UpdateTimeCallbackData = 408,

    [Description("RPR_CONTEXT_RENDER_TIME_CALLBACK_FUNC")]
    RenderTimeCallbackFunc = 409,

    [Description("RPR_CONTEXT_RENDER_TIME_CALLBACK_DATA")]
    RenderTimeCallbackData = 410,

    [Description("RPR_CONTEXT_FIRST_ITERATION_TIME_CALLBACK_FUNC")]
    FirstIterationTimeCallbackFunc = 411,

    [Description("RPR_CONTEXT_FIRST_ITERATION_TIME_CALLBACK_DATA")]
    FirstIterationTimeCallbackData = 412,

    [Description("RPR_CONTEXT_IMAGE_FILTER_RADIUS")]
    ImageFilterRadius = 413,

    [Description("RPR_CONTEXT_PRECOMPILED_BINARY_PATH")]
    PrecompiledBinaryPath = 414,

    [Description("RPR_CONTEXT_REFLECTION_ENERGY_COMPENSATION_ENABLED")]
    ReflectionEnergyCompensationEnabled = 415,

    [Description("RPR_CONTEXT_NORMALIZE_LIGHT_INTENSITY_ENABLED")]
    NormalizeLightIntensityEnabled = 416,

    [Description("RPR_CONTEXT_NAME")]
    Name = 7829367,

    [Description("RPR_CONTEXT_UNIQUE_ID")]
    UniqueId = 7829368,

    [Description("RPR_CONTEXT_CUSTOM_PTR")]
    CustomPtr = 7829369
}

public enum CameraInfo
{
    [Description("RPR_CAMERA_TRANSFORM")]
    Transform = 513,

    [Description("RPR_CAMERA_FSTOP")]
    Fstop = 514,

    [Description("RPR_CAMERA_APERTURE_BLADES")]
    ApertureBlades = 515,

    [Description("RPR_CAMERA_RESPONSE")]
    Response = 516,

    [Description("RPR_CAMERA_EXPOSURE")]
    Exposure = 517,

    [Description("RPR_CAMERA_FOCAL_LENGTH")]
    FocalLength = 518,

    [Description("RPR_CAMERA_SENSOR_SIZE")]
    SensorSize = 519,

    [Description("RPR_CAMERA_MODE")]
    Mode = 520,

    [Description("RPR_CAMERA_ORTHO_WIDTH")]
    OrthoWidth = 521,

    [Description("RPR_CAMERA_ORTHO_HEIGHT")]
    OrthoHeight = 522,

    [Description("RPR_CAMERA_FOCUS_DISTANCE")]
    FocusDistance = 523,

    [Description("RPR_CAMERA_POSITION")]
    Position = 524,

    [Description("RPR_CAMERA_LOOKAT")]
    Lookat = 525,

    [Description("RPR_CAMERA_UP")]
    Up = 526,

    [Description("RPR_CAMERA_FOCAL_TILT")]
    FocalTilt = 527,

    [Description("RPR_CAMERA_LENS_SHIFT")]
    LensShift = 528,

    [Description("RPR_CAMERA_IPD")]
    Ipd = 529,

    [Description("RPR_CAMERA_TILT_CORRECTION")]
    TiltCorrection = 530,

    [Description("RPR_CAMERA_NEAR_PLANE")]
    NearPlane = 531,

    [Description("RPR_CAMERA_FAR_PLANE")]
    FarPlane = 532,

    [Description("RPR_CAMERA_LINEAR_MOTION")]
    LinearMotion = 533,

    [Description("RPR_CAMERA_ANGULAR_MOTION")]
    AngularMotion = 534,

    [Description("RPR_CAMERA_MOTION_TRANSFORMS_COUNT")]
    MotionTransformsCount = 535,

    [Description("RPR_CAMERA_MOTION_TRANSFORMS")]
    MotionTransforms = 536,

    [Description("RPR_CAMERA_POST_SCALE")]
    PostScale = 537,

    [Description("RPR_CAMERA_UV_DISTORTION")]
    UvDistortion = 538,

    [Description("RPR_CAMERA_NAME")]
    Name = 7829367,

    [Description("RPR_CAMERA_UNIQUE_ID")]
    UniqueId = 7829368,

    [Description("RPR_CAMERA_CUSTOM_PTR")]
    CustomPtr = 7829369
}

public enum ImageInfo
{
    [Description("RPR_IMAGE_FORMAT")]
    Format = 769,

    [Description("RPR_IMAGE_DESC")]
    Desc = 770,

    [Description("RPR_IMAGE_DATA")]
    Data = 771,

    [Description("RPR_IMAGE_DATA_SIZEBYTE")]
    DataSizebyte = 772,

    [Description("RPR_IMAGE_WRAP")]
    Wrap = 773,

    [Description("RPR_IMAGE_FILTER")]
    Filter = 774,

    [Description("RPR_IMAGE_GAMMA")]
    Gamma = 775,

    [Description("RPR_IMAGE_MIPMAP_ENABLED")]
    MipmapEnabled = 776,

    [Description("RPR_IMAGE_MIP_COUNT")]
    MipCount = 777,

    [Description("RPR_IMAGE_GAMMA_FROM_FILE")]
    GammaFromFile = 778,

    [Description("RPR_IMAGE_UDIM")]
    Udim = 779,

    [Description("RPR_IMAGE_OCIO_COLORSPACE")]
    OcioColorspace = 780,

    [Description("RPR_IMAGE_INTERNAL_COMPRESSION")]
    InternalCompression = 781,

    [Description("RPR_IMAGE_NAME")]
    Name = 7829367,

    [Description("RPR_IMAGE_UNIQUE_ID")]
    UniqueId = 7829368,

    [Description("RPR_IMAGE_CUSTOM_PTR")]
    CustomPtr = 7829369
}

public enum BufferInfo
{
    [Description("RPR_BUFFER_DESC")]
    Desc = 848,

    [Description("RPR_BUFFER_DATA")]
    Data = 849,

    [Description("RPR_BUFFER_NAME")]
    Name = 7829367,

    [Description("RPR_BUFFER_UNIQUE_ID")]
    UniqueId = 7829368,

    [Description("RPR_BUFFER_CUSTOM_PTR")]
    CustomPtr = 7829369
}

public enum ShapeInfo
{
    [Description("RPR_SHAPE_TYPE")]
    Type = 1025,

    [Description("RPR_SHAPE_VIDMEM_USAGE")]
    VidmemUsage = 1026,

    [Description("RPR_SHAPE_TRANSFORM")]
    Transform = 1027,

    [Description("RPR_SHAPE_MATERIAL")]
    Material = 1028,

    [Description("RPR_SHAPE_LINEAR_MOTION")]
    LinearMotion = 1029,

    [Description("RPR_SHAPE_ANGULAR_MOTION")]
    AngularMotion = 1030,

    [Description("RPR_SHAPE_SHADOW_FLAG")]
    ShadowFlag = 1032,

    [Description("RPR_SHAPE_SUBDIVISION_FACTOR")]
    SubdivisionFactor = 1033,

    [Description("RPR_SHAPE_DISPLACEMENT_SCALE")]
    DisplacementScale = 1034,

    [Description("RPR_SHAPE_SHADOW_CATCHER_FLAG")]
    ShadowCatcherFlag = 1038,

    [Description("RPR_SHAPE_VOLUME_MATERIAL")]
    VolumeMaterial = 1039,

    [Description("RPR_SHAPE_OBJECT_GROUP_ID")]
    ObjectGroupId = 1040,

    [Description("RPR_SHAPE_SUBDIVISION_CREASEWEIGHT")]
    SubdivisionCreaseweight = 1041,

    [Description("RPR_SHAPE_SUBDIVISION_BOUNDARYINTEROP")]
    SubdivisionBoundaryinterop = 1042,

    [Description("RPR_SHAPE_DISPLACEMENT_MATERIAL")]
    DisplacementMaterial = 1043,

    [Description("RPR_SHAPE_MATERIALS_PER_FACE")]
    MaterialsPerFace = 1045,

    [Description("RPR_SHAPE_SCALE_MOTION")]
    ScaleMotion = 1046,

    [Description("RPR_SHAPE_HETERO_VOLUME")]
    HeteroVolume = 1047,

    [Description("RPR_SHAPE_LAYER_MASK")]
    LayerMask = 1048,

    [Description("RPR_SHAPE_VISIBILITY_PRIMARY_ONLY_FLAG")]
    VisibilityPrimaryOnlyFlag = 1036,

    [Description("RPR_SHAPE_VISIBILITY_SHADOW")]
    VisibilityShadow = 1050,

    [Description("RPR_SHAPE_VISIBILITY_REFLECTION")]
    VisibilityReflection = 1051,

    [Description("RPR_SHAPE_VISIBILITY_REFRACTION")]
    VisibilityRefraction = 1052,

    [Description("RPR_SHAPE_VISIBILITY_TRANSPARENT")]
    VisibilityTransparent = 1053,

    [Description("RPR_SHAPE_VISIBILITY_DIFFUSE")]
    VisibilityDiffuse = 1054,

    [Description("RPR_SHAPE_VISIBILITY_GLOSSY_REFLECTION")]
    VisibilityGlossyReflection = 1055,

    [Description("RPR_SHAPE_VISIBILITY_GLOSSY_REFRACTION")]
    VisibilityGlossyRefraction = 1056,

    [Description("RPR_SHAPE_VISIBILITY_LIGHT")]
    VisibilityLight = 1057,

    [Description("RPR_SHAPE_LIGHT_GROUP_ID")]
    LightGroupId = 1058,

    [Description("RPR_SHAPE_STATIC")]
    Static = 1059,

    [Description("RPR_SHAPE_PER_VERTEX_VALUE0")]
    PerVertexValue0 = 1060,

    [Description("RPR_SHAPE_PER_VERTEX_VALUE1")]
    PerVertexValue1 = 1061,

    [Description("RPR_SHAPE_PER_VERTEX_VALUE2")]
    PerVertexValue2 = 1062,

    [Description("RPR_SHAPE_PER_VERTEX_VALUE3")]
    PerVertexValue3 = 1063,

    [Description("RPR_SHAPE_REFLECTION_CATCHER_FLAG")]
    ReflectionCatcherFlag = 1064,

    [Description("RPR_SHAPE_OBJECT_ID")]
    ObjectId = 1065,

    [Description("RPR_SHAPE_SUBDIVISION_AUTO_RATIO_CAP")]
    SubdivisionAutoRatioCap = 1066,

    [Description("RPR_SHAPE_MOTION_TRANSFORMS_COUNT")]
    MotionTransformsCount = 1067,

    [Description("RPR_SHAPE_MOTION_TRANSFORMS")]
    MotionTransforms = 1068,

    [Description("RPR_SHAPE_CONTOUR_IGNORE")]
    ContourIgnore = 1069,

    [Description("RPR_SHAPE_RENDER_LAYER_LIST")]
    RenderLayerList = 1070,

    [Description("RPR_SHAPE_SHADOW_COLOR")]
    ShadowColor = 1071,

    [Description("RPR_SHAPE_VISIBILITY_RECEIVE_SHADOW")]
    VisibilityReceiveShadow = 1072,

    [Description("RPR_SHAPE_PRIMVARS")]
    Primvars = 1073,

    [Description("RPR_SHAPE_ENVIRONMENT_LIGHT")]
    EnvironmentLight = 1074,

    [Description("RPR_SHAPE_NAME")]
    Name = 7829367,

    [Description("RPR_SHAPE_UNIQUE_ID")]
    UniqueId = 7829368,

    [Description("RPR_SHAPE_CUSTOM_PTR")]
    CustomPtr = 7829369
}

public enum MeshInfo
{
    [Description("RPR_MESH_POLYGON_COUNT")]
    PolygonCount = 1281,

    [Description("RPR_MESH_VERTEX_COUNT")]
    VertexCount = 1282,

    [Description("RPR_MESH_NORMAL_COUNT")]
    NormalCount = 1283,

    [Description("RPR_MESH_UV_COUNT")]
    UvCount = 1284,

    [Description("RPR_MESH_VERTEX_ARRAY")]
    VertexArray = 1285,

    [Description("RPR_MESH_NORMAL_ARRAY")]
    NormalArray = 1286,

    [Description("RPR_MESH_UV_ARRAY")]
    UvArray = 1287,

    [Description("RPR_MESH_VERTEX_INDEX_ARRAY")]
    VertexIndexArray = 1288,

    [Description("RPR_MESH_NORMAL_INDEX_ARRAY")]
    NormalIndexArray = 1289,

    [Description("RPR_MESH_UV_INDEX_ARRAY")]
    UvIndexArray = 1290,

    [Description("RPR_MESH_VERTEX_STRIDE")]
    VertexStride = 1292,

    [Description("RPR_MESH_NORMAL_STRIDE")]
    NormalStride = 1293,

    [Description("RPR_MESH_UV_STRIDE")]
    UvStride = 1294,

    [Description("RPR_MESH_VERTEX_INDEX_STRIDE")]
    VertexIndexStride = 1295,

    [Description("RPR_MESH_NORMAL_INDEX_STRIDE")]
    NormalIndexStride = 1296,

    [Description("RPR_MESH_UV_INDEX_STRIDE")]
    UvIndexStride = 1297,

    [Description("RPR_MESH_NUM_FACE_VERTICES_ARRAY")]
    NumFaceVerticesArray = 1298,

    [Description("RPR_MESH_UV2_COUNT")]
    Uv2Count = 1299,

    [Description("RPR_MESH_UV2_ARRAY")]
    Uv2Array = 1300,

    [Description("RPR_MESH_UV2_INDEX_ARRAY")]
    Uv2IndexArray = 1301,

    [Description("RPR_MESH_UV2_STRIDE")]
    Uv2Stride = 1302,

    [Description("RPR_MESH_UV2_INDEX_STRIDE")]
    Uv2IndexStride = 1303,

    [Description("RPR_MESH_UV_DIM")]
    UvDim = 1304,

    [Description("RPR_MESH_MOTION_DIMENSION")]
    MotionDimension = 1305,

    [Description("RPR_MESH_VOLUME_FLAG")]
    VolumeFlag = 1306
}

public enum SceneInfo
{
    [Description("RPR_SCENE_SHAPE_COUNT")]
    ShapeCount = 1793,

    [Description("RPR_SCENE_LIGHT_COUNT")]
    LightCount = 1794,

    [Description("RPR_SCENE_SHAPE_LIST")]
    ShapeList = 1796,

    [Description("RPR_SCENE_LIGHT_LIST")]
    LightList = 1797,

    [Description("RPR_SCENE_CAMERA")]
    Camera = 1798,

    [Description("RPR_SCENE_CAMERA_RIGHT")]
    CameraRight = 1799,

    [Description("RPR_SCENE_BACKGROUND_IMAGE")]
    BackgroundImage = 1800,

    [Description("RPR_SCENE_AABB")]
    Aabb = 1805,

    [Description("RPR_SCENE_HETEROVOLUME_LIST")]
    HeterovolumeList = 1806,

    [Description("RPR_SCENE_HETEROVOLUME_COUNT")]
    HeterovolumeCount = 1807,

    [Description("RPR_SCENE_CURVE_LIST")]
    CurveList = 1808,

    [Description("RPR_SCENE_CURVE_COUNT")]
    CurveCount = 1809,

    [Description("RPR_SCENE_ENVIRONMENT_LIGHT")]
    EnvironmentLight = 1810,

    [Description("RPR_SCENE_NAME")]
    Name = 7829367,

    [Description("RPR_SCENE_UNIQUE_ID")]
    UniqueId = 7829368,

    [Description("RPR_SCENE_CUSTOM_PTR")]
    CustomPtr = 7829369
}

public enum LutInfo
{
    [Description("RPR_LUT_FILENAME")]
    Filename = 2128,

    [Description("RPR_LUT_DATA")]
    Data = 2129
}

public enum LightInfo
{
    [Description("RPR_LIGHT_TYPE")]
    Type = 2049,

    [Description("RPR_LIGHT_TRANSFORM")]
    Transform = 2051,

    [Description("RPR_LIGHT_GROUP_ID")]
    GroupId = 2053,

    [Description("RPR_LIGHT_RENDER_LAYER_LIST")]
    RenderLayerList = 2054,

    [Description("RPR_LIGHT_VISIBILITY_LIGHT")]
    Visibility = 2055,

    [Description("RPR_LIGHT_NAME")]
    Name = 7829367,

    [Description("RPR_LIGHT_UNIQUE_ID")]
    UniqueId = 7829368,

    [Description("RPR_LIGHT_CUSTOM_PTR")]
    CustomPtr = 7829369,

    [Description("RPR_POINT_LIGHT_RADIANT_POWER")]
    PointLightRadiantPower = 2052,

    [Description("RPR_DIRECTIONAL_LIGHT_RADIANT_POWER")]
    DirectionalLightRadiantPower = 2056,

    [Description("RPR_DIRECTIONAL_LIGHT_SHADOW_SOFTNESS_ANGLE")]
    DirectionalLightShadowSoftnessAngle = 2058,

    [Description("RPR_SPOT_LIGHT_RADIANT_POWER")]
    SpotLightRadiantPower = 2059,

    [Description("RPR_SPOT_LIGHT_CONE_SHAPE")]
    SpotLightConeShape = 2060,

    [Description("RPR_SPOT_LIGHT_IMAGE")]
    SpotLightImage = 2061,

    [Description("RPR_ENVIRONMENT_LIGHT_IMAGE")]
    EnvironmentLightImage = 2063,

    [Description("RPR_ENVIRONMENT_LIGHT_INTENSITY_SCALE")]
    EnvironmentLightIntensityScale = 2064,

    [Description("RPR_ENVIRONMENT_LIGHT_PORTAL_LIST")]
    EnvironmentLightPortalList = 2072,

    [Description("RPR_ENVIRONMENT_LIGHT_PORTAL_COUNT")]
    EnvironmentLightPortalCount = 2073,

    [Description("RPR_ENVIRONMENT_LIGHT_OVERRIDE_REFLECTION")]
    EnvironmentLightOverrideReflection = 2074,

    [Description("RPR_ENVIRONMENT_LIGHT_OVERRIDE_REFRACTION")]
    EnvironmentLightOverrideRefraction = 2075,

    [Description("RPR_ENVIRONMENT_LIGHT_OVERRIDE_TRANSPARENCY")]
    EnvironmentLightOverrideTransparency = 2076,

    [Description("RPR_ENVIRONMENT_LIGHT_OVERRIDE_BACKGROUND")]
    EnvironmentLightOverrideBackground = 2077,

    [Description("RPR_ENVIRONMENT_LIGHT_OVERRIDE_IRRADIANCE")]
    EnvironmentLightOverrideIrradiance = 2078,

    [Description("RPR_SKY_LIGHT_TURBIDITY")]
    SkyLightTurbidity = 2066,

    [Description("RPR_SKY_LIGHT_ALBEDO")]
    SkyLightAlbedo = 2067,

    [Description("RPR_SKY_LIGHT_SCALE")]
    SkyLightScale = 2068,

    [Description("RPR_SKY_LIGHT_DIRECTION")]
    SkyLightDirection = 2069,

    [Description("RPR_SKY_LIGHT_PORTAL_LIST")]
    SkyLightPortalList = 2080,

    [Description("RPR_SKY_LIGHT_PORTAL_COUNT")]
    SkyLightPortalCount = 2081,

    [Description("RPR_IES_LIGHT_RADIANT_POWER")]
    IesLightRadiantPower = 2070,

    [Description("RPR_IES_LIGHT_IMAGE_DESC")]
    IesLightImageDesc = 2071,

    [Description("RPR_SPHERE_LIGHT_RADIANT_POWER")]
    SphereLightRadiantPower = 2082,

    [Description("RPR_SPHERE_LIGHT_RADIUS")]
    SphereLightRadius = 2084,

    [Description("RPR_DISK_LIGHT_RADIANT_POWER")]
    DiskLightRadiantPower = 2083,

    [Description("RPR_DISK_LIGHT_RADIUS")]
    DiskLightRadius = 2085,

    [Description("RPR_DISK_LIGHT_ANGLE")]
    DiskLightAngle = 2086,

    [Description("RPR_DISK_LIGHT_INNER_ANGLE")]
    DiskLightInnerAngle = 2087
}

public enum ParameterInfo
{
    [Description("RPR_PARAMETER_NAME")]
    Name = 4609,

    [Description("RPR_PARAMETER_TYPE")]
    Type = 4611,

    [Description("RPR_PARAMETER_DESCRIPTION")]
    Description = 4612,

    [Description("RPR_PARAMETER_VALUE")]
    Value = 4613
}

public enum FramebufferInfo
{
    [Description("RPR_FRAMEBUFFER_FORMAT")]
    Format = 4865,

    [Description("RPR_FRAMEBUFFER_DESC")]
    Desc = 4866,

    [Description("RPR_FRAMEBUFFER_DATA")]
    Data = 4867,

    [Description("RPR_FRAMEBUFFER_GL_TARGET")]
    GlTarget = 4868,

    [Description("RPR_FRAMEBUFFER_GL_MIPLEVEL")]
    GlMiplevel = 4869,

    [Description("RPR_FRAMEBUFFER_GL_TEXTURE")]
    GlTexture = 4870,

    [Description("RPR_FRAMEBUFFER_LPE")]
    Lpe = 4871,

    [Description("RPR_FRAMEBUFFER_NAME")]
    Name = 7829367,

    [Description("RPR_FRAMEBUFFER_UNIQUE_ID")]
    UniqueId = 7829368,

    [Description("RPR_FRAMEBUFFER_CUSTOM_PTR")]
    CustomPtr = 7829369
}

public enum ComponentType
{
    [Description("RPR_COMPONENT_TYPE_UINT8")]
    Uint8 = 1,

    [Description("RPR_COMPONENT_TYPE_FLOAT16")]
    Float16 = 2,

    [Description("RPR_COMPONENT_TYPE_FLOAT32")]
    Float32 = 3,

    [Description("RPR_COMPONENT_TYPE_UNKNOWN")]
    Unknown = 4,

    [Description("RPR_COMPONENT_TYPE_DEEP")]
    Deep = 5,

    [Description("RPR_COMPONENT_TYPE_UINT32")]
    Uint32 = 6
}

public enum BufferElementType
{
    [Description("RPR_BUFFER_ELEMENT_TYPE_INT32")]
    Int32 = 1,

    [Description("RPR_BUFFER_ELEMENT_TYPE_FLOAT32")]
    Float32 = 2
}

public enum RenderMode
{
    [Description("RPR_RENDER_MODE_GLOBAL_ILLUMINATION")]
    GlobalIllumination = 1,

    [Description("RPR_RENDER_MODE_DIRECT_ILLUMINATION")]
    DirectIllumination = 2,

    [Description("RPR_RENDER_MODE_DIRECT_ILLUMINATION_NO_SHADOW")]
    DirectIlluminationNoShadow = 3,

    [Description("RPR_RENDER_MODE_WIREFRAME")]
    Wireframe = 4,

    [Description("RPR_RENDER_MODE_MATERIAL_INDEX")]
    MaterialIndex = 5,

    [Description("RPR_RENDER_MODE_POSITION")]
    Position = 6,

    [Description("RPR_RENDER_MODE_NORMAL")]
    Normal = 7,

    [Description("RPR_RENDER_MODE_TEXCOORD")]
    Texcoord = 8,

    [Description("RPR_RENDER_MODE_AMBIENT_OCCLUSION")]
    AmbientOcclusion = 9,

    [Description("RPR_RENDER_MODE_DIFFUSE")]
    Diffuse = 10
}

public enum CameraMode
{
    [Description("RPR_CAMERA_MODE_PERSPECTIVE")]
    Perspective = 1,

    [Description("RPR_CAMERA_MODE_ORTHOGRAPHIC")]
    Orthographic = 2,

    [Description("RPR_CAMERA_MODE_LATITUDE_LONGITUDE_360")]
    LatitudeLongitude360 = 3,

    [Description("RPR_CAMERA_MODE_LATITUDE_LONGITUDE_STEREO")]
    LatitudeLongitudeStereo = 4,

    [Description("RPR_CAMERA_MODE_CUBEMAP")]
    Cubemap = 5,

    [Description("RPR_CAMERA_MODE_CUBEMAP_STEREO")]
    CubemapStereo = 6,

    [Description("RPR_CAMERA_MODE_FISHEYE")]
    Fisheye = 7
}

public enum TonemappingOperator
{
    [Description("RPR_TONEMAPPING_OPERATOR_NONE")]
    None = 0,

    [Description("RPR_TONEMAPPING_OPERATOR_LINEAR")]
    Linear = 1,

    [Description("RPR_TONEMAPPING_OPERATOR_PHOTOLINEAR")]
    Photolinear = 2,

    [Description("RPR_TONEMAPPING_OPERATOR_AUTOLINEAR")]
    Autolinear = 3,

    [Description("RPR_TONEMAPPING_OPERATOR_MAXWHITE")]
    Maxwhite = 4,

    [Description("RPR_TONEMAPPING_OPERATOR_REINHARD02")]
    Reinhard02 = 5,

    [Description("RPR_TONEMAPPING_OPERATOR_EXPONENTIAL")]
    Exponential = 6
}

public enum VolumeType
{
    [Description("RPR_VOLUME_TYPE_NONE")]
    None = 65535,

    [Description("RPR_VOLUME_TYPE_HOMOGENEOUS")]
    Homogeneous = 0,

    [Description("RPR_VOLUME_TYPE_HETEROGENEOUS")]
    Heterogeneous = 1
}

public enum MaterialSystemInfo
{
    [Description("RPR_MATERIAL_SYSTEM_NODE_LIST")]
    NodeList = 4352
}

public enum MaterialNodeInfo
{
    [Description("RPR_MATERIAL_NODE_TYPE")]
    Type = 4353,

    [Description("RPR_MATERIAL_NODE_SYSTEM")]
    System = 4354,

    [Description("RPR_MATERIAL_NODE_INPUT_COUNT")]
    InputCount = 4355,

    [Description("RPR_MATERIAL_NODE_ID")]
    Id = 4356,

    [Description("RPR_MATERIAL_NODE_NAME")]
    Name = 7829367,

    [Description("RPR_MATERIAL_NODE_UNIQUE_ID")]
    UniqueId = 7829368,

    [Description("RPR_MATERIAL_CUSTOM_PTR")]
    CustomPtr = 7829369
}

public enum MaterialNodeInputInfo
{
    [Description("RPR_MATERIAL_NODE_INPUT_NAME")]
    Name = 4355,

    [Description("RPR_MATERIAL_NODE_INPUT_DESCRIPTION")]
    Description = 4357,

    [Description("RPR_MATERIAL_NODE_INPUT_VALUE")]
    Value = 4358,

    [Description("RPR_MATERIAL_NODE_INPUT_TYPE")]
    Type = 4359
}

public enum MaterialNodeType
{
    [Description("RPR_MATERIAL_NODE_DIFFUSE")]
    Diffuse = 1,

    [Description("RPR_MATERIAL_NODE_MICROFACET")]
    Microfacet = 2,

    [Description("RPR_MATERIAL_NODE_REFLECTION")]
    Reflection = 3,

    [Description("RPR_MATERIAL_NODE_REFRACTION")]
    Refraction = 4,

    [Description("RPR_MATERIAL_NODE_MICROFACET_REFRACTION")]
    MicrofacetRefraction = 5,

    [Description("RPR_MATERIAL_NODE_TRANSPARENT")]
    Ransparent = 6,

    [Description("RPR_MATERIAL_NODE_EMISSIVE")]
    Emissive = 7,

    [Description("RPR_MATERIAL_NODE_WARD")]
    Ward = 8,

    [Description("RPR_MATERIAL_NODE_ADD")]
    Add = 9,

    [Description("RPR_MATERIAL_NODE_BLEND")]
    Blend = 10,

    [Description("RPR_MATERIAL_NODE_ARITHMETIC")]
    Arithmetic = 11,

    [Description("RPR_MATERIAL_NODE_FRESNEL")]
    Fresnel = 12,

    [Description("RPR_MATERIAL_NODE_NORMAL_MAP")]
    NormalMap = 13,

    [Description("RPR_MATERIAL_NODE_IMAGE_TEXTURE")]
    ImageTexture = 14,

    [Description("RPR_MATERIAL_NODE_NOISE2D_TEXTURE")]
    Noise2dTexture = 15,

    [Description("RPR_MATERIAL_NODE_DOT_TEXTURE")]
    DotTexture = 16,

    [Description("RPR_MATERIAL_NODE_GRADIENT_TEXTURE")]
    GradientTexture = 17,

    [Description("RPR_MATERIAL_NODE_CHECKER_TEXTURE")]
    CheckerTexture = 18,

    [Description("RPR_MATERIAL_NODE_CONSTANT_TEXTURE")]
    ConstantTexture = 19,

    [Description("RPR_MATERIAL_NODE_INPUT_LOOKUP")]
    InputLookup = 20,

    [Description("RPR_MATERIAL_NODE_BLEND_VALUE")]
    BlendValue = 22,

    [Description("RPR_MATERIAL_NODE_PASSTHROUGH")]
    Passthrough = 23,

    [Description("RPR_MATERIAL_NODE_ORENNAYAR")]
    Orennayar = 24,

    [Description("RPR_MATERIAL_NODE_FRESNEL_SCHLICK")]
    FresnelSchlick = 25,

    [Description("RPR_MATERIAL_NODE_DIFFUSE_REFRACTION")]
    DiffuseRefraction = 27,

    [Description("RPR_MATERIAL_NODE_BUMP_MAP")]
    BumpMap = 28,

    [Description("RPR_MATERIAL_NODE_VOLUME")]
    Volume = 29,

    [Description("RPR_MATERIAL_NODE_MICROFACET_ANISOTROPIC_REFLECTION")]
    MicrofacetAnisotropicReflection = 30,

    [Description("RPR_MATERIAL_NODE_MICROFACET_ANISOTROPIC_REFRACTION")]
    MicrofacetAnisotropicRefraction = 31,

    [Description("RPR_MATERIAL_NODE_TWOSIDED")]
    Wosided = 32,

    [Description("RPR_MATERIAL_NODE_UV_PROCEDURAL")]
    UvProcedural = 33,

    [Description("RPR_MATERIAL_NODE_MICROFACET_BECKMANN")]
    MicrofacetBeckmann = 34,

    [Description("RPR_MATERIAL_NODE_PHONG")]
    Phong = 35,

    [Description("RPR_MATERIAL_NODE_BUFFER_SAMPLER")]
    BufferSampler = 36,

    [Description("RPR_MATERIAL_NODE_UV_TRIPLANAR")]
    UvTriplanar = 37,

    [Description("RPR_MATERIAL_NODE_AO_MAP")]
    AoMap = 38,

    [Description("RPR_MATERIAL_NODE_USER_TEXTURE_0")]
    UserTexture0 = 39,

    [Description("RPR_MATERIAL_NODE_USER_TEXTURE_1")]
    UserTexture1 = 40,

    [Description("RPR_MATERIAL_NODE_USER_TEXTURE_2")]
    UserTexture2 = 41,

    [Description("RPR_MATERIAL_NODE_USER_TEXTURE_3")]
    UserTexture3 = 42,

    [Description("RPR_MATERIAL_NODE_UBERV2")]
    Uberv2 = 43,

    [Description("RPR_MATERIAL_NODE_TRANSFORM")]
    Ransform = 44,

    [Description("RPR_MATERIAL_NODE_RGB_TO_HSV")]
    RgbToHsv = 45,

    [Description("RPR_MATERIAL_NODE_HSV_TO_RGB")]
    HsvToRgb = 46,

    [Description("RPR_MATERIAL_NODE_USER_TEXTURE")]
    UserTexture = 47,

    [Description("RPR_MATERIAL_NODE_TOON_CLOSURE")]
    OonClosure = 48,

    [Description("RPR_MATERIAL_NODE_TOON_RAMP")]
    OonRamp = 49,

    [Description("RPR_MATERIAL_NODE_VORONOI_TEXTURE")]
    VoronoiTexture = 50,

    [Description("RPR_MATERIAL_NODE_GRID_SAMPLER")]
    GridSampler = 51,

    [Description("RPR_MATERIAL_NODE_BLACKBODY")]
    Blackbody = 52,

    [Description("RPR_MATERIAL_NODE_RAMP")]
    Ramp = 53,

    [Description("RPR_MATERIAL_NODE_PRIMVAR_LOOKUP")]
    PrimvarLookup = 54,

    [Description("RPR_MATERIAL_NODE_ROUNDED_CORNER")]
    RoundedCorner = 55,

    [Description("RPR_MATERIAL_NODE_MATX_DIFFUSE_BRDF")]
    MatxDiffuseBrdf = 4096,

    [Description("RPR_MATERIAL_NODE_MATX_DIELECTRIC_BRDF")]
    MatxDielectricBrdf = 4097,

    [Description("RPR_MATERIAL_NODE_MATX_GENERALIZED_SCHLICK_BRDF")]
    MatxGeneralizedSchlickBrdf = 4098,

    [Description("RPR_MATERIAL_NODE_MATX_NOISE3D")]
    MatxNoise3d = 4099,

    [Description("RPR_MATERIAL_NODE_MATX_TANGENT")]
    MatxTangent = 4100,

    [Description("RPR_MATERIAL_NODE_MATX_NORMAL")]
    MatxNormal = 4101,

    [Description("RPR_MATERIAL_NODE_MATX_POSITION")]
    MatxPosition = 4102,

    [Description("RPR_MATERIAL_NODE_MATX_ROUGHNESS_ANISOTROPY")]
    MatxRoughnessAnisotropy = 4103,

    [Description("RPR_MATERIAL_NODE_MATX_ROTATE3D")]
    MatxRotate3d = 4104,

    [Description("RPR_MATERIAL_NODE_MATX_NORMALIZE")]
    MatxNormalize = 4105,

    [Description("RPR_MATERIAL_NODE_MATX_IFGREATER")]
    MatxIfgreater = 4106,

    [Description("RPR_MATERIAL_NODE_MATX_SHEEN_BRDF")]
    MatxSheenBrdf = 4107,

    [Description("RPR_MATERIAL_NODE_MATX_DIFFUSE_BTDF")]
    MatxDiffuseBtdf = 4108,

    [Description("RPR_MATERIAL_NODE_MATX_CONVERT")]
    MatxConvert = 4109,

    [Description("RPR_MATERIAL_NODE_MATX_SUBSURFACE_BRDF")]
    MatxSubsurfaceBrdf = 4110,

    [Description("RPR_MATERIAL_NODE_MATX_DIELECTRIC_BTDF")]
    MatxDielectricBtdf = 4111,

    [Description("RPR_MATERIAL_NODE_MATX_CONDUCTOR_BRDF")]
    MatxConductorBrdf = 4112,

    [Description("RPR_MATERIAL_NODE_MATX_FRESNEL")]
    MatxFresnel = 4113,

    [Description("RPR_MATERIAL_NODE_MATX_LUMINANCE")]
    MatxLuminance = 4114,

    [Description("RPR_MATERIAL_NODE_MATX_FRACTAL3D")]
    MatxFractal3d = 4115,

    [Description("RPR_MATERIAL_NODE_MATX_MIX")]
    MatxMix = 4116,

    [Description("RPR_MATERIAL_NODE_MATX")]
    Matx = 4117,

    [Description("RPR_MATERIAL_NODE_MATX_ARTISTIC_IOR")]
    MatxArtisticIor = 4118,

    [Description("RPR_MATERIAL_NODE_MATX_GENERALIZED_SCHLICK_BTDF")]
    MatxGeneralizedSchlickBtdf = 4119,

    [Description("RPR_MATERIAL_NODE_MATX_LAYER")]
    MatxLayer = 4120,

    [Description("RPR_MATERIAL_NODE_MATX_THIN_FILM")]
    MatxThinFilm = 4121,

    [Description("RPR_MATERIAL_NODE_MATX_BITANGENT")]
    MatxBitangent = 4122,

    [Description("RPR_MATERIAL_NODE_MATX_TEXCOORD")]
    MatxTexcoord = 4123,

    [Description("RPR_MATERIAL_NODE_MATX_MODULO")]
    MatxModulo = 4124,

    [Description("RPR_MATERIAL_NODE_MATX_ABSVAL")]
    MatxAbsval = 4125,

    [Description("RPR_MATERIAL_NODE_MATX_SIGN")]
    MatxSign = 4126,

    [Description("RPR_MATERIAL_NODE_MATX_FLOOR")]
    MatxFloor = 4127,

    [Description("RPR_MATERIAL_NODE_MATX_CEIL")]
    MatxCeil = 4128,

    [Description("RPR_MATERIAL_NODE_MATX_ATAN2")]
    MatxAtan2 = 4129,

    [Description("RPR_MATERIAL_NODE_MATX_SQRT")]
    MatxSqrt = 4130,

    [Description("RPR_MATERIAL_NODE_MATX_LN")]
    MatxLn = 4131,

    [Description("RPR_MATERIAL_NODE_MATX_EXP")]
    MatxExp = 4132,

    [Description("RPR_MATERIAL_NODE_MATX_CLAMP")]
    MatxClamp = 4133,

    [Description("RPR_MATERIAL_NODE_MATX_MIN")]
    MatxMin = 4134,

    [Description("RPR_MATERIAL_NODE_MATX_MAX")]
    MatxMax = 4135,

    [Description("RPR_MATERIAL_NODE_MATX_MAGNITUDE")]
    MatxMagnitude = 4136,

    [Description("RPR_MATERIAL_NODE_MATX_CROSSPRODUCT")]
    MatxCrossproduct = 4137,

    [Description("RPR_MATERIAL_NODE_MATX_REMAP")]
    MatxRemap = 4138,

    [Description("RPR_MATERIAL_NODE_MATX_SMOOTHSTEP")]
    MatxSmoothstep = 4139,

    [Description("RPR_MATERIAL_NODE_MATX_RGBTOHSV")]
    MatxRgbtohsv = 4140,

    [Description("RPR_MATERIAL_NODE_MATX_HSVTORGB")]
    MatxHsvtorgb = 4141,

    [Description("RPR_MATERIAL_NODE_MATX_IFGREATEREQ")]
    MatxIfgreatereq = 4142,

    [Description("RPR_MATERIAL_NODE_MATX_IFEQUAL")]
    MatxIfequal = 4143,

    [Description("RPR_MATERIAL_NODE_MATX_SWIZZLE")]
    MatxSwizzle = 4144,

    [Description("RPR_MATERIAL_NODE_MATX_NOISE2D")]
    MatxNoise2d = 4145,

    [Description("RPR_MATERIAL_NODE_MATX_PLUS")]
    MatxPlus = 4146,

    [Description("RPR_MATERIAL_NODE_MATX_MINUS")]
    MatxMinus = 4147,

    [Description("RPR_MATERIAL_NODE_MATX_DIFFERENCE")]
    MatxDifference = 4148,

    [Description("RPR_MATERIAL_NODE_MATX_BURN")]
    MatxBurn = 4149,

    [Description("RPR_MATERIAL_NODE_MATX_DODGE")]
    MatxDodge = 4150,

    [Description("RPR_MATERIAL_NODE_MATX_SCREEN")]
    MatxScreen = 4151,

    [Description("RPR_MATERIAL_NODE_MATX_OVERLAY")]
    MatxOverlay = 4152,

    [Description("RPR_MATERIAL_NODE_MATX_INSIDE")]
    MatxInside = 4153,

    [Description("RPR_MATERIAL_NODE_MATX_OUTSIDE")]
    MatxOutside = 4154,

    [Description("RPR_MATERIAL_NODE_MATX_RAMPLR")]
    MatxRamplr = 4155,

    [Description("RPR_MATERIAL_NODE_MATX_RAMPTB")]
    MatxRamptb = 4156,

    [Description("RPR_MATERIAL_NODE_MATX_SPLITLR")]
    MatxSplitlr = 4157,

    [Description("RPR_MATERIAL_NODE_MATX_SPLITTB")]
    MatxSplittb = 4158,

    [Description("RPR_MATERIAL_NODE_MATX_CELLNOISE2D")]
    MatxCellnoise2d = 4159,

    [Description("RPR_MATERIAL_NODE_MATX_CELLNOISE3D")]
    MatxCellnoise3d = 4160,

    [Description("RPR_MATERIAL_NODE_MATX_ROTATE2D")]
    MatxRotate2d = 4161,

    [Description("RPR_MATERIAL_NODE_MATX_DOT")]
    MatxDot = 4162,

    [Description("RPR_MATERIAL_NODE_MATX_RANGE")]
    MatxRange = 4163,

    [Description("RPR_MATERIAL_NODE_MATX_SWITCH")]
    MatxSwitch = 4164,

    [Description("RPR_MATERIAL_NODE_MATX_EXTRACT")]
    MatxExtract = 4165,

    [Description("RPR_MATERIAL_NODE_MATX_COMBINE2")]
    MatxCombine2 = 4166,

    [Description("RPR_MATERIAL_NODE_MATX_COMBINE3")]
    MatxCombine3 = 4167,

    [Description("RPR_MATERIAL_NODE_MATX_COMBINE4")]
    MatxCombine4 = 4168,

    [Description("RPR_MATERIAL_NODE_MATX_TRIPLANARPROJECTION")]
    MatxTriplanarprojection = 4169,

    [Description("RPR_MATERIAL_NODE_MATX_MULTIPLY")]
    MatxMultiply = 4170
}

public enum MaterialNodeInput
{
    [Description("RPR_MATERIAL_INPUT_COLOR")]
    InputColor = 0,

    [Description("RPR_MATERIAL_INPUT_COLOR0")]
    InputColor0 = 1,

    [Description("RPR_MATERIAL_INPUT_COLOR1")]
    InputColor1 = 2,

    [Description("RPR_MATERIAL_INPUT_NORMAL")]
    InputNormal = 3,

    [Description("RPR_MATERIAL_INPUT_UV")]
    InputUv = 4,

    [Description("RPR_MATERIAL_INPUT_DATA")]
    InputData = 5,

    [Description("RPR_MATERIAL_INPUT_ROUGHNESS")]
    InputRoughness = 6,

    [Description("RPR_MATERIAL_INPUT_IOR")]
    InputIor = 7,

    [Description("RPR_MATERIAL_INPUT_ROUGHNESS_X")]
    InputRoughnessX = 8,

    [Description("RPR_MATERIAL_INPUT_ROUGHNESS_Y")]
    InputRoughnessY = 9,

    [Description("RPR_MATERIAL_INPUT_ROTATION")]
    InputRotation = 10,

    [Description("RPR_MATERIAL_INPUT_WEIGHT")]
    InputWeight = 11,

    [Description("RPR_MATERIAL_INPUT_OP")]
    InputOp = 12,

    [Description("RPR_MATERIAL_INPUT_INVEC")]
    InputInvec = 13,

    [Description("RPR_MATERIAL_INPUT_UV_SCALE")]
    InputUvScale = 14,

    [Description("RPR_MATERIAL_INPUT_VALUE")]
    InputValue = 15,

    [Description("RPR_MATERIAL_INPUT_REFLECTANCE")]
    InputReflectance = 16,

    [Description("RPR_MATERIAL_INPUT_SCALE")]
    InputScale = 17,

    [Description("RPR_MATERIAL_INPUT_SCATTERING")]
    InputScattering = 18,

    [Description("RPR_MATERIAL_INPUT_ABSORBTION")]
    InputAbsorbtion = 19,

    [Description("RPR_MATERIAL_INPUT_EMISSION")]
    InputEmission = 20,

    [Description("RPR_MATERIAL_INPUT_G")]
    InputG = 21,

    [Description("RPR_MATERIAL_INPUT_MULTISCATTER")]
    InputMultiscatter = 22,

    [Description("RPR_MATERIAL_INPUT_COLOR2")]
    InputColor2 = 23,

    [Description("RPR_MATERIAL_INPUT_COLOR3")]
    InputColor3 = 24,

    [Description("RPR_MATERIAL_INPUT_ANISOTROPIC")]
    InputAnisotropic = 25,

    [Description("RPR_MATERIAL_INPUT_FRONTFACE")]
    InputFrontface = 26,

    [Description("RPR_MATERIAL_INPUT_BACKFACE")]
    InputBackface = 27,

    [Description("RPR_MATERIAL_INPUT_ORIGIN")]
    InputOrigin = 28,

    [Description("RPR_MATERIAL_INPUT_ZAXIS")]
    InputZaxis = 29,

    [Description("RPR_MATERIAL_INPUT_XAXIS")]
    InputXaxis = 30,

    [Description("RPR_MATERIAL_INPUT_THRESHOLD")]
    InputThreshold = 31,

    [Description("RPR_MATERIAL_INPUT_OFFSET")]
    InputOffset = 32,

    [Description("RPR_MATERIAL_INPUT_UV_TYPE")]
    InputUvType = 33,

    [Description("RPR_MATERIAL_INPUT_RADIUS")]
    InputRadius = 34,

    [Description("RPR_MATERIAL_INPUT_SIDE")]
    InputSide = 35,

    [Description("RPR_MATERIAL_INPUT_CAUSTICS")]
    InputCaustics = 36,

    [Description("RPR_MATERIAL_INPUT_TRANSMISSION_COLOR")]
    InputTransmissionColor = 37,

    [Description("RPR_MATERIAL_INPUT_THICKNESS")]
    InputThickness = 38,

    [Description("RPR_MATERIAL_INPUT_0")]
    Input0 = 39,

    [Description("RPR_MATERIAL_INPUT_1")]
    Input1 = 40,

    [Description("RPR_MATERIAL_INPUT_2")]
    Input2 = 41,

    [Description("RPR_MATERIAL_INPUT_3")]
    Input3 = 42,

    [Description("RPR_MATERIAL_INPUT_4")]
    Input4 = 43,

    [Description("RPR_MATERIAL_INPUT_SCHLICK_APPROXIMATION")]
    InputSchlickApproximation = 44,

    [Description("RPR_MATERIAL_INPUT_APPLYSURFACE")]
    InputApplysurface = 45,

    [Description("RPR_MATERIAL_INPUT_TANGENT")]
    InputTangent = 46,

    [Description("RPR_MATERIAL_INPUT_DISTRIBUTION")]
    InputDistribution = 47,

    [Description("RPR_MATERIAL_INPUT_BASE")]
    InputBase = 48,

    [Description("RPR_MATERIAL_INPUT_TINT")]
    InputTint = 49,

    [Description("RPR_MATERIAL_INPUT_EXPONENT")]
    InputExponent = 50,

    [Description("RPR_MATERIAL_INPUT_AMPLITUDE")]
    InputAmplitude = 51,

    [Description("RPR_MATERIAL_INPUT_PIVOT")]
    InputPivot = 52,

    [Description("RPR_MATERIAL_INPUT_POSITION")]
    InputPosition = 53,

    [Description("RPR_MATERIAL_INPUT_AMOUNT")]
    InputAmount = 54,

    [Description("RPR_MATERIAL_INPUT_AXIS")]
    InputAxis = 55,

    [Description("RPR_MATERIAL_INPUT_LUMACOEFF")]
    InputLumacoeff = 56,

    [Description("RPR_MATERIAL_INPUT_REFLECTIVITY")]
    InputReflectivity = 57,

    [Description("RPR_MATERIAL_INPUT_EDGE_COLOR")]
    InputEdgeColor = 58,

    [Description("RPR_MATERIAL_INPUT_VIEW_DIRECTION")]
    InputViewDirection = 59,

    [Description("RPR_MATERIAL_INPUT_INTERIOR")]
    InputInterior = 60,

    [Description("RPR_MATERIAL_INPUT_OCTAVES")]
    InputOctaves = 61,

    [Description("RPR_MATERIAL_INPUT_LACUNARITY")]
    InputLacunarity = 62,

    [Description("RPR_MATERIAL_INPUT_DIMINISH")]
    InputDiminish = 63,

    [Description("RPR_MATERIAL_INPUT_WRAP_U")]
    InputWrapU = 64,

    [Description("RPR_MATERIAL_INPUT_WRAP_V")]
    InputWrapV = 65,

    [Description("RPR_MATERIAL_INPUT_WRAP_W")]
    InputWrapW = 66,

    [Description("RPR_MATERIAL_INPUT_5")]
    Input5 = 67,

    [Description("RPR_MATERIAL_INPUT_6")]
    Input6 = 68,

    [Description("RPR_MATERIAL_INPUT_7")]
    Input7 = 69,

    [Description("RPR_MATERIAL_INPUT_8")]
    Input8 = 70,

    [Description("RPR_MATERIAL_INPUT_9")]
    Input9 = 71,

    [Description("RPR_MATERIAL_INPUT_10")]
    Input10 = 72,

    [Description("RPR_MATERIAL_INPUT_11")]
    Input11 = 73,

    [Description("RPR_MATERIAL_INPUT_12")]
    Input12 = 74,

    [Description("RPR_MATERIAL_INPUT_13")]
    Input13 = 75,

    [Description("RPR_MATERIAL_INPUT_14")]
    Input14 = 76,

    [Description("RPR_MATERIAL_INPUT_15")]
    Input15 = 77,

    [Description("RPR_MATERIAL_INPUT_DIFFUSE_RAMP")]
    InputDiffuseRamp = 78,

    [Description("RPR_MATERIAL_INPUT_SHADOW")]
    InputShadow = 79,

    [Description("RPR_MATERIAL_INPUT_MID")]
    InputMid = 80,

    [Description("RPR_MATERIAL_INPUT_HIGHLIGHT")]
    InputHighlight = 81,

    [Description("RPR_MATERIAL_INPUT_POSITION1")]
    InputPosition1 = 82,

    [Description("RPR_MATERIAL_INPUT_POSITION2")]
    InputPosition2 = 83,

    [Description("RPR_MATERIAL_INPUT_RANGE1")]
    InputRange1 = 84,

    [Description("RPR_MATERIAL_INPUT_RANGE2")]
    InputRange2 = 85,

    [Description("RPR_MATERIAL_INPUT_INTERPOLATION")]
    InputInterpolation = 86,

    [Description("RPR_MATERIAL_INPUT_RANDOMNESS")]
    InputRandomness = 87,

    [Description("RPR_MATERIAL_INPUT_DIMENSION")]
    InputDimension = 88,

    [Description("RPR_MATERIAL_INPUT_OUTTYPE")]
    InputOuttype = 89,

    [Description("RPR_MATERIAL_INPUT_DENSITY")]
    InputDensity = 90,

    [Description("RPR_MATERIAL_INPUT_DENSITYGRID")]
    InputDensitygrid = 91,

    [Description("RPR_MATERIAL_INPUT_DISPLACEMENT")]
    InputDisplacement = 92,

    [Description("RPR_MATERIAL_INPUT_TEMPERATURE")]
    InputTemperature = 93,

    [Description("RPR_MATERIAL_INPUT_KELVIN")]
    InputKelvin = 94,

    [Description("RPR_MATERIAL_INPUT_EXTINCTION")]
    InputExtinction = 95,

    [Description("RPR_MATERIAL_INPUT_THIN_FILM")]
    InputThinFilm = 96,

    [Description("RPR_MATERIAL_INPUT_TOP")]
    InputTop = 97,

    [Description("RPR_MATERIAL_INPUT_HIGHLIGHT2")]
    InputHighlight2 = 98,

    [Description("RPR_MATERIAL_INPUT_SHADOW2")]
    InputShadow2 = 99,

    [Description("RPR_MATERIAL_INPUT_POSITION_SHADOW")]
    InputPositionShadow = 100,

    [Description("RPR_MATERIAL_INPUT_POSITION_HIGHLIGHT")]
    InputPositionHighlight = 101,

    [Description("RPR_MATERIAL_INPUT_RANGE_SHADOW")]
    InputRangeShadow = 102,

    [Description("RPR_MATERIAL_INPUT_RANGE_HIGHLIGHT")]
    InputRangeHighlight = 103,

    [Description("RPR_MATERIAL_INPUT_TOON_5_COLORS")]
    InputToon5Colors = 104,

    [Description("RPR_MATERIAL_INPUT_X")]
    InputX = 105,

    [Description("RPR_MATERIAL_INPUT_Y")]
    InputY = 106,

    [Description("RPR_MATERIAL_INPUT_Z")]
    InputZ = 107,

    [Description("RPR_MATERIAL_INPUT_W")]
    InputW = 108,

    [Description("RPR_MATERIAL_INPUT_LIGHT")]
    InputLight = 109,

    [Description("RPR_MATERIAL_INPUT_MID_IS_ALBEDO")]
    InputMidIsAlbedo = 110,

    [Description("RPR_MATERIAL_INPUT_SAMPLES")]
    InputSamples = 111,

    [Description("RPR_MATERIAL_INPUT_BASE_NORMAL")]
    InputBaseNormal = 112,

    [Description("RPR_MATERIAL_INPUT_UBER_DIFFUSE_COLOR")]
    InputUberDiffuseColor = 2320,

    [Description("RPR_MATERIAL_INPUT_UBER_DIFFUSE_WEIGHT")]
    InputUberDiffuseWeight = 2343,

    [Description("RPR_MATERIAL_INPUT_UBER_DIFFUSE_ROUGHNESS")]
    InputUberDiffuseRoughness = 2321,

    [Description("RPR_MATERIAL_INPUT_UBER_DIFFUSE_NORMAL")]
    InputUberDiffuseNormal = 2322,

    [Description("RPR_MATERIAL_INPUT_UBER_REFLECTION_COLOR")]
    InputUberReflectionColor = 2323,

    [Description("RPR_MATERIAL_INPUT_UBER_REFLECTION_WEIGHT")]
    InputUberReflectionWeight = 2344,

    [Description("RPR_MATERIAL_INPUT_UBER_REFLECTION_ROUGHNESS")]
    InputUberReflectionRoughness = 2324,

    [Description("RPR_MATERIAL_INPUT_UBER_REFLECTION_ANISOTROPY")]
    InputUberReflectionAnisotropy = 2325,

    [Description("RPR_MATERIAL_INPUT_UBER_REFLECTION_ANISOTROPY_ROTATION")]
    InputUberReflectionAnisotropyRotation = 2326,

    [Description("RPR_MATERIAL_INPUT_UBER_REFLECTION_MODE")]
    InputUberReflectionMode = 2327,

    [Description("RPR_MATERIAL_INPUT_UBER_REFLECTION_IOR")]
    InputUberReflectionIor = 2328,

    [Description("RPR_MATERIAL_INPUT_UBER_REFLECTION_METALNESS")]
    InputUberReflectionMetalness = 2329,

    [Description("RPR_MATERIAL_INPUT_UBER_REFLECTION_NORMAL")]
    InputUberReflectionNormal = 2345,

    [Description("RPR_MATERIAL_INPUT_UBER_REFLECTION_DIELECTRIC_REFLECTANCE")]
    InputUberReflectionDielectricReflectance = 2366,

    [Description("RPR_MATERIAL_INPUT_UBER_REFRACTION_COLOR")]
    InputUberRefractionColor = 2330,

    [Description("RPR_MATERIAL_INPUT_UBER_REFRACTION_WEIGHT")]
    InputUberRefractionWeight = 2346,

    [Description("RPR_MATERIAL_INPUT_UBER_REFRACTION_ROUGHNESS")]
    InputUberRefractionRoughness = 2331,

    [Description("RPR_MATERIAL_INPUT_UBER_REFRACTION_IOR")]
    InputUberRefractionIor = 2332,

    [Description("RPR_MATERIAL_INPUT_UBER_REFRACTION_NORMAL")]
    InputUberRefractionNormal = 2347,

    [Description("RPR_MATERIAL_INPUT_UBER_REFRACTION_THIN_SURFACE")]
    InputUberRefractionThinSurface = 2333,

    [Description("RPR_MATERIAL_INPUT_UBER_REFRACTION_ABSORPTION_COLOR")]
    InputUberRefractionAbsorptionColor = 2348,

    [Description("RPR_MATERIAL_INPUT_UBER_REFRACTION_ABSORPTION_DISTANCE")]
    InputUberRefractionAbsorptionDistance = 2349,

    [Description("RPR_MATERIAL_INPUT_UBER_REFRACTION_CAUSTICS")]
    InputUberRefractionCaustics = 2350,

    [Description("RPR_MATERIAL_INPUT_UBER_COATING_COLOR")]
    InputUberCoatingColor = 2334,

    [Description("RPR_MATERIAL_INPUT_UBER_COATING_WEIGHT")]
    InputUberCoatingWeight = 2351,

    [Description("RPR_MATERIAL_INPUT_UBER_COATING_ROUGHNESS")]
    InputUberCoatingRoughness = 2335,

    [Description("RPR_MATERIAL_INPUT_UBER_COATING_MODE")]
    InputUberCoatingMode = 2336,

    [Description("RPR_MATERIAL_INPUT_UBER_COATING_IOR")]
    InputUberCoatingIor = 2337,

    [Description("RPR_MATERIAL_INPUT_UBER_COATING_METALNESS")]
    InputUberCoatingMetalness = 2338,

    [Description("RPR_MATERIAL_INPUT_UBER_COATING_NORMAL")]
    InputUberCoatingNormal = 2339,

    [Description("RPR_MATERIAL_INPUT_UBER_COATING_TRANSMISSION_COLOR")]
    InputUberCoatingTransmissionColor = 2352,

    [Description("RPR_MATERIAL_INPUT_UBER_COATING_THICKNESS")]
    InputUberCoatingThickness = 2353,

    [Description("RPR_MATERIAL_INPUT_UBER_SHEEN")]
    InputUberSheen = 2354,

    [Description("RPR_MATERIAL_INPUT_UBER_SHEEN_TINT")]
    InputUberSheenTint = 2355,

    [Description("RPR_MATERIAL_INPUT_UBER_SHEEN_WEIGHT")]
    InputUberSheenWeight = 2356,

    [Description("RPR_MATERIAL_INPUT_UBER_EMISSION_COLOR")]
    InputUberEmissionColor = 2340,

    [Description("RPR_MATERIAL_INPUT_UBER_EMISSION_WEIGHT")]
    InputUberEmissionWeight = 2341,

    [Description("RPR_MATERIAL_INPUT_UBER_EMISSION_MODE")]
    InputUberEmissionMode = 2357,

    [Description("RPR_MATERIAL_INPUT_UBER_TRANSPARENCY")]
    InputUberTransparency = 2342,

    [Description("RPR_MATERIAL_INPUT_UBER_SSS_SCATTER_COLOR")]
    InputUberSssScatterColor = 2359,

    [Description("RPR_MATERIAL_INPUT_UBER_SSS_SCATTER_DISTANCE")]
    InputUberSssScatterDistance = 2360,

    [Description("RPR_MATERIAL_INPUT_UBER_SSS_SCATTER_DIRECTION")]
    InputUberSssScatterDirection = 2361,

    [Description("RPR_MATERIAL_INPUT_UBER_SSS_WEIGHT")]
    InputUberSssWeight = 2362,

    [Description("RPR_MATERIAL_INPUT_UBER_SSS_MULTISCATTER")]
    InputUberSssMultiscatter = 2363,

    [Description("RPR_MATERIAL_INPUT_UBER_BACKSCATTER_WEIGHT")]
    InputUberBackscatterWeight = 2364,

    [Description("RPR_MATERIAL_INPUT_UBER_BACKSCATTER_COLOR")]
    InputUberBackscatterColor = 2365,

    [Description("RPR_MATERIAL_INPUT_ADDRESS")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1069:不应复制枚举值", Justification = "<挂起>")]
    InputAddress = 2366,

    [Description("RPR_MATERIAL_INPUT_TYPE")]
    InputType = 2367,

    [Description("RPR_MATERIAL_INPUT_UBER_FRESNEL_SCHLICK_APPROXIMATION")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1069:不应复制枚举值", Justification = "<挂起>")]
    InputUberFresnelSchlickApproximation = 44
}

public enum MaterialInputRaster
{
    [Description("RPR_MATERIAL_INPUT_RASTER_METALLIC")]
    Metallic = 2305,

    [Description("RPR_MATERIAL_INPUT_RASTER_ROUGHNESS")]
    Roughness = 2306,

    [Description("RPR_MATERIAL_INPUT_RASTER_SUBSURFACE")]
    Subsurface = 2307,

    [Description("RPR_MATERIAL_INPUT_RASTER_ANISOTROPIC")]
    Anisotropic = 2308,

    [Description("RPR_MATERIAL_INPUT_RASTER_SPECULAR")]
    Specular = 2309,

    [Description("RPR_MATERIAL_INPUT_RASTER_SPECULARTINT")]
    Speculartint = 2310,

    [Description("RPR_MATERIAL_INPUT_RASTER_SHEEN")]
    Sheen = 2311,

    [Description("RPR_MATERIAL_INPUT_RASTER_SHEENTINT")]
    Sheentint = 2312,

    [Description("RPR_MATERIAL_INPUT_RASTER_CLEARCOAT")]
    Clearcoat = 2314,

    [Description("RPR_MATERIAL_INPUT_RASTER_CLEARCOATGLOSS")]
    Clearcoatgloss = 2315,

    [Description("RPR_MATERIAL_INPUT_RASTER_COLOR")]
    Color = 2316,

    [Description("RPR_MATERIAL_INPUT_RASTER_NORMAL")]
    Normal = 2317
}

public enum InterpolationMode
{
    [Description("RPR_INTERPOLATION_MODE_NONE")]
    None = 0,

    [Description("RPR_INTERPOLATION_MODE_LINEAR")]
    Linear = 1,

    [Description("RPR_INTERPOLATION_MODE_EXPONENTIAL_UP")]
    ExponentialUp = 2,

    [Description("RPR_INTERPOLATION_MODE_EXPONENTIAL_DOWN")]
    ExponentialDown = 3,

    [Description("RPR_INTERPOLATION_MODE_SMOOTH")]
    Smooth = 4,

    [Description("RPR_INTERPOLATION_MODE_BUMP")]
    Bump = 5,

    [Description("RPR_INTERPOLATION_MODE_SPIKE")]
    Spike = 6
}

public enum UbermaterialIorMode
{
    [Description("RPR_UBER_MATERIAL_IOR_MODE_PBR")]
    MaterialIorModePbr = 1,

    [Description("RPR_UBER_MATERIAL_IOR_MODE_METALNESS")]
    MaterialIorModeMetalness = 2
}

public enum UbermaterialEmissionMode
{
    [Description("RPR_UBER_MATERIAL_EMISSION_MODE_SINGLESIDED")]
    MaterialEmissionModeSinglesided = 1,

    [Description("RPR_UBER_MATERIAL_EMISSION_MODE_DOUBLESIDED")]
    MaterialEmissionModeDoublesided = 2
}

public enum MaterialNodeArithmeticOperation
{
    [Description("RPR_MATERIAL_NODE_OP_ADD")]
    OpAdd = 0,

    [Description("RPR_MATERIAL_NODE_OP_SUB")]
    OpSub = 1,

    [Description("RPR_MATERIAL_NODE_OP_MUL")]
    OpMul = 2,

    [Description("RPR_MATERIAL_NODE_OP_DIV")]
    OpDiv = 3,

    [Description("RPR_MATERIAL_NODE_OP_SIN")]
    OpSin = 4,

    [Description("RPR_MATERIAL_NODE_OP_COS")]
    OpCos = 5,

    [Description("RPR_MATERIAL_NODE_OP_TAN")]
    OpTan = 6,

    [Description("RPR_MATERIAL_NODE_OP_SELECT_X")]
    OpSelectX = 7,

    [Description("RPR_MATERIAL_NODE_OP_SELECT_Y")]
    OpSelectY = 8,

    [Description("RPR_MATERIAL_NODE_OP_SELECT_Z")]
    OpSelectZ = 9,

    [Description("RPR_MATERIAL_NODE_OP_COMBINE")]
    OpCombine = 10,

    [Description("RPR_MATERIAL_NODE_OP_DOT3")]
    OpDot3 = 11,

    [Description("RPR_MATERIAL_NODE_OP_CROSS3")]
    OpCross3 = 12,

    [Description("RPR_MATERIAL_NODE_OP_LENGTH3")]
    OpLength3 = 13,

    [Description("RPR_MATERIAL_NODE_OP_NORMALIZE3")]
    OpNormalize3 = 14,

    [Description("RPR_MATERIAL_NODE_OP_POW")]
    OpPow = 15,

    [Description("RPR_MATERIAL_NODE_OP_ACOS")]
    OpAcos = 16,

    [Description("RPR_MATERIAL_NODE_OP_ASIN")]
    OpAsin = 17,

    [Description("RPR_MATERIAL_NODE_OP_ATAN")]
    OpAtan = 18,

    [Description("RPR_MATERIAL_NODE_OP_AVERAGE_XYZ")]
    OpAverageXyz = 19,

    [Description("RPR_MATERIAL_NODE_OP_AVERAGE")]
    OpAverage = 20,

    [Description("RPR_MATERIAL_NODE_OP_MIN")]
    OpMin = 21,

    [Description("RPR_MATERIAL_NODE_OP_MAX")]
    OpMax = 22,

    [Description("RPR_MATERIAL_NODE_OP_FLOOR")]
    OpFloor = 23,

    [Description("RPR_MATERIAL_NODE_OP_MOD")]
    OpMod = 24,

    [Description("RPR_MATERIAL_NODE_OP_ABS")]
    OpAbs = 25,

    [Description("RPR_MATERIAL_NODE_OP_SHUFFLE_YZWX")]
    OpShuffleYzwx = 26,

    [Description("RPR_MATERIAL_NODE_OP_SHUFFLE_ZWXY")]
    OpShuffleZwxy = 27,

    [Description("RPR_MATERIAL_NODE_OP_SHUFFLE_WXYZ")]
    OpShuffleWxyz = 28,

    [Description("RPR_MATERIAL_NODE_OP_MAT_MUL")]
    OpMatMul = 29,

    [Description("RPR_MATERIAL_NODE_OP_SELECT_W")]
    OpSelectW = 30,

    [Description("RPR_MATERIAL_NODE_OP_DOT4")]
    OpDot4 = 31,

    [Description("RPR_MATERIAL_NODE_OP_LOG")]
    OpLog = 32,

    [Description("RPR_MATERIAL_NODE_OP_LOWER_OR_EQUAL")]
    OpLowerOrEqual = 33,

    [Description("RPR_MATERIAL_NODE_OP_LOWER")]
    OpLower = 34,

    [Description("RPR_MATERIAL_NODE_OP_GREATER_OR_EQUAL")]
    OpGreaterOrEqual = 35,

    [Description("RPR_MATERIAL_NODE_OP_GREATER")]
    OpGreater = 36,

    [Description("RPR_MATERIAL_NODE_OP_EQUAL")]
    OpEqual = 37,

    [Description("RPR_MATERIAL_NODE_OP_NOT_EQUAL")]
    OpNotEqual = 38,

    [Description("RPR_MATERIAL_NODE_OP_AND")]
    OpAnd = 39,

    [Description("RPR_MATERIAL_NODE_OP_OR")]
    OpOr = 40,

    [Description("RPR_MATERIAL_NODE_OP_TERNARY")]
    OpTernary = 41,

    [Description("RPR_MATERIAL_NODE_OP_EXP")]
    OpExp = 42,

    [Description("RPR_MATERIAL_NODE_OP_ROTATE2D")]
    OpRotate2d = 43,

    [Description("RPR_MATERIAL_NODE_OP_ROTATE3D")]
    OpRotate3d = 44,

    [Description("RPR_MATERIAL_NODE_OP_NOP")]
    OpNop = 45,

    [Description("RPR_MATERIAL_NODE_OP_CEIL")]
    OpCeil = 4138,

    [Description("RPR_MATERIAL_NODE_OP_ROUND")]
    OpRound = 4139,

    [Description("RPR_MATERIAL_NODE_OP_SIGN")]
    OpSign = 4140,

    [Description("RPR_MATERIAL_NODE_OP_SQRT")]
    OpSqrt = 4143,

    [Description("RPR_MATERIAL_NODE_OP_CLAMP")]
    OpClamp = 4149
}

public enum MaterialNodeLookupValue
{
    [Description("RPR_MATERIAL_NODE_LOOKUP_UV")]
    Uv = 0,

    [Description("RPR_MATERIAL_NODE_LOOKUP_N")]
    N = 1,

    [Description("RPR_MATERIAL_NODE_LOOKUP_P")]
    P = 2,

    [Description("RPR_MATERIAL_NODE_LOOKUP_INVEC")]
    Invec = 3,

    [Description("RPR_MATERIAL_NODE_LOOKUP_OUTVEC")]
    Outvec = 4,

    [Description("RPR_MATERIAL_NODE_LOOKUP_UV1")]
    Uv1 = 5,

    [Description("RPR_MATERIAL_NODE_LOOKUP_P_LOCAL")]
    PLocal = 6,

    [Description("RPR_MATERIAL_NODE_LOOKUP_VERTEX_VALUE0")]
    ErtexValue0 = 7,

    [Description("RPR_MATERIAL_NODE_LOOKUP_VERTEX_VALUE1")]
    ErtexValue1 = 8,

    [Description("RPR_MATERIAL_NODE_LOOKUP_VERTEX_VALUE2")]
    ErtexValue2 = 9,

    [Description("RPR_MATERIAL_NODE_LOOKUP_VERTEX_VALUE3")]
    ErtexValue3 = 10,

    [Description("RPR_MATERIAL_NODE_LOOKUP_SHAPE_RANDOM_COLOR")]
    ShapeRandomColor = 11,

    [Description("RPR_MATERIAL_NODE_LOOKUP_OBJECT_ID")]
    ObjectId = 12,

    [Description("RPR_MATERIAL_NODE_LOOKUP_PRIMITIVE_RANDOM_COLOR")]
    PrimitiveRandomColor = 13
}

public enum MaterialGradientProceduralType
{
    [Description("RPR_MATERIAL_GRADIENT_PROCEDURAL_TYPE_LINEAR")]
    Linear = 1,

    [Description("RPR_MATERIAL_GRADIENT_PROCEDURAL_TYPE_QUADRATIC")]
    Quadratic = 2,

    [Description("RPR_MATERIAL_GRADIENT_PROCEDURAL_TYPE_EASING")]
    Easing = 3,

    [Description("RPR_MATERIAL_GRADIENT_PROCEDURAL_TYPE_DIAGONAL")]
    Diagonal = 4,

    [Description("RPR_MATERIAL_GRADIENT_PROCEDURAL_TYPE_SPHERICAL")]
    Spherical = 5,

    [Description("RPR_MATERIAL_GRADIENT_PROCEDURAL_TYPE_QUAD_SPHERE")]
    QuadSphere = 6,

    [Description("RPR_MATERIAL_GRADIENT_PROCEDURAL_TYPE_RADIAL")]
    Radial = 7
}

public enum MaterialNodeUvtypeValue
{
    [Description("RPR_MATERIAL_NODE_UVTYPE_PLANAR")]
    Planar = 0,

    [Description("RPR_MATERIAL_NODE_UVTYPE_CYLINDICAL")]
    Cylindical = 1,

    [Description("RPR_MATERIAL_NODE_UVTYPE_SPHERICAL")]
    Spherical = 2,

    [Description("RPR_MATERIAL_NODE_UVTYPE_PROJECT")]
    Project = 3
}

public enum MaterialNodeTransformOp
{
    [Description("RPR_MATERIAL_NODE_TRANSFORM_ROTATE_LOCAL_TO_WORLD")]
    RotateLocalToWorld = 1
}

public enum PostEffectInfo
{
    [Description("RPR_POST_EFFECT_TYPE")]
    Type = 0,

    [Description("RPR_POST_EFFECT_WHITE_BALANCE_COLOR_SPACE")]
    WhiteBalanceColorSpace = 4,

    [Description("RPR_POST_EFFECT_WHITE_BALANCE_COLOR_TEMPERATURE")]
    WhiteBalanceColorTemperature = 5,

    [Description("RPR_POST_EFFECT_SIMPLE_TONEMAP_EXPOSURE")]
    SimpleTonemapExposure = 6,

    [Description("RPR_POST_EFFECT_SIMPLE_TONEMAP_CONTRAST")]
    SimpleTonemapContrast = 7,

    [Description("RPR_POST_EFFECT_SIMPLE_TONEMAP_ENABLE_TONEMAP")]
    SimpleTonemapEnableTonemap = 8,

    [Description("RPR_POST_EFFECT_BLOOM_RADIUS")]
    BloomRadius = 9,

    [Description("RPR_POST_EFFECT_BLOOM_THRESHOLD")]
    BloomThreshold = 10,

    [Description("RPR_POST_EFFECT_BLOOM_WEIGHT")]
    BloomWeight = 11,

    [Description("RPR_POST_EFFECT_NAME")]
    Name = 7829367,

    [Description("RPR_POST_EFFECT_UNIQUE_ID")]
    UniqueId = 7829368,

    [Description("RPR_POST_EFFECT_CUSTOM_PTR")]
    CustomPtr = 7829369
}

public enum Aov
{
    [Description("RPR_AOV_COLOR")]
    Color = 0,

    [Description("RPR_AOV_OPACITY")]
    Opacity = 1,

    [Description("RPR_AOV_WORLD_COORDINATE")]
    WorldCoordinate = 2,

    [Description("RPR_AOV_UV")]
    Uv = 3,

    [Description("RPR_AOV_MATERIAL_ID")]
    MaterialId = 4,

    [Description("RPR_AOV_GEOMETRIC_NORMAL")]
    GeometricNormal = 5,

    [Description("RPR_AOV_SHADING_NORMAL")]
    ShadingNormal = 6,

    [Description("RPR_AOV_DEPTH")]
    Depth = 7,

    [Description("RPR_AOV_OBJECT_ID")]
    ObjectId = 8,

    [Description("RPR_AOV_OBJECT_GROUP_ID")]
    ObjectGroupId = 9,

    [Description("RPR_AOV_SHADOW_CATCHER")]
    ShadowCatcher = 10,

    [Description("RPR_AOV_BACKGROUND")]
    Background = 11,

    [Description("RPR_AOV_EMISSION")]
    Emission = 12,

    [Description("RPR_AOV_VELOCITY")]
    Velocity = 13,

    [Description("RPR_AOV_DIRECT_ILLUMINATION")]
    DirectIllumination = 14,

    [Description("RPR_AOV_INDIRECT_ILLUMINATION")]
    IndirectIllumination = 15,

    [Description("RPR_AOV_AO")]
    Ao = 16,

    [Description("RPR_AOV_DIRECT_DIFFUSE")]
    DirectDiffuse = 17,

    [Description("RPR_AOV_DIRECT_REFLECT")]
    DirectReflect = 18,

    [Description("RPR_AOV_INDIRECT_DIFFUSE")]
    IndirectDiffuse = 19,

    [Description("RPR_AOV_INDIRECT_REFLECT")]
    IndirectReflect = 20,

    [Description("RPR_AOV_REFRACT")]
    Refract = 21,

    [Description("RPR_AOV_VOLUME")]
    Volume = 22,

    [Description("RPR_AOV_LIGHT_GROUP0")]
    LightGroup0 = 23,

    [Description("RPR_AOV_LIGHT_GROUP1")]
    LightGroup1 = 24,

    [Description("RPR_AOV_LIGHT_GROUP2")]
    LightGroup2 = 25,

    [Description("RPR_AOV_LIGHT_GROUP3")]
    LightGroup3 = 26,

    [Description("RPR_AOV_DIFFUSE_ALBEDO")]
    DiffuseAlbedo = 27,

    [Description("RPR_AOV_VARIANCE")]
    Variance = 28,

    [Description("RPR_AOV_VIEW_SHADING_NORMAL")]
    ViewShadingNormal = 29,

    [Description("RPR_AOV_REFLECTION_CATCHER")]
    ReflectionCatcher = 30,

    [Description("RPR_AOV_COLOR_RIGHT")]
    ColorRight = 31,

    [Description("RPR_AOV_LPE_0")]
    Lpe0 = 32,

    [Description("RPR_AOV_LPE_1")]
    Lpe1 = 33,

    [Description("RPR_AOV_LPE_2")]
    Lpe2 = 34,

    [Description("RPR_AOV_LPE_3")]
    Lpe3 = 35,

    [Description("RPR_AOV_LPE_4")]
    Lpe4 = 36,

    [Description("RPR_AOV_LPE_5")]
    Lpe5 = 37,

    [Description("RPR_AOV_LPE_6")]
    Lpe6 = 38,

    [Description("RPR_AOV_LPE_7")]
    Lpe7 = 39,

    [Description("RPR_AOV_LPE_8")]
    Lpe8 = 40,

    [Description("RPR_AOV_CAMERA_NORMAL")]
    CameraNormal = 41,

    [Description("RPR_AOV_MATTE_PASS")]
    MattePass = 42,

    [Description("RPR_AOV_SSS")]
    Sss = 43,

    [Description("RPR_AOV_CRYPTOMATTE_MAT0")]
    CryptomatteMat0 = 48,

    [Description("RPR_AOV_CRYPTOMATTE_MAT1")]
    CryptomatteMat1 = 49,

    [Description("RPR_AOV_CRYPTOMATTE_MAT2")]
    CryptomatteMat2 = 50,

    [Description("RPR_AOV_CRYPTOMATTE_MAT3")]
    CryptomatteMat3 = 51,

    [Description("RPR_AOV_CRYPTOMATTE_MAT4")]
    CryptomatteMat4 = 52,

    [Description("RPR_AOV_CRYPTOMATTE_MAT5")]
    CryptomatteMat5 = 53,

    [Description("RPR_AOV_CRYPTOMATTE_OBJ0")]
    CryptomatteObj0 = 56,

    [Description("RPR_AOV_CRYPTOMATTE_OBJ1")]
    CryptomatteObj1 = 57,

    [Description("RPR_AOV_CRYPTOMATTE_OBJ2")]
    CryptomatteObj2 = 58,

    [Description("RPR_AOV_CRYPTOMATTE_OBJ3")]
    CryptomatteObj3 = 59,

    [Description("RPR_AOV_CRYPTOMATTE_OBJ4")]
    CryptomatteObj4 = 60,

    [Description("RPR_AOV_CRYPTOMATTE_OBJ5")]
    CryptomatteObj5 = 61,

    [Description("RPR_AOV_DEEP_COLOR")]
    DeepColor = 64,

    [Description("RPR_AOV_LIGHT_GROUP4")]
    LightGroup4 = 80,

    [Description("RPR_AOV_LIGHT_GROUP5")]
    LightGroup5 = 81,

    [Description("RPR_AOV_LIGHT_GROUP6")]
    LightGroup6 = 82,

    [Description("RPR_AOV_LIGHT_GROUP7")]
    LightGroup7 = 83,

    [Description("RPR_AOV_LIGHT_GROUP8")]
    LightGroup8 = 84,

    [Description("RPR_AOV_LIGHT_GROUP9")]
    LightGroup9 = 85,

    [Description("RPR_AOV_LIGHT_GROUP10")]
    LightGroup10 = 86,

    [Description("RPR_AOV_LIGHT_GROUP11")]
    LightGroup11 = 87,

    [Description("RPR_AOV_LIGHT_GROUP12")]
    LightGroup12 = 88,

    [Description("RPR_AOV_LIGHT_GROUP13")]
    LightGroup13 = 89,

    [Description("RPR_AOV_LIGHT_GROUP14")]
    LightGroup14 = 90,

    [Description("RPR_AOV_LIGHT_GROUP15")]
    LightGroup15 = 91,

    [Description("RPR_AOV_MESH_ID")]
    MeshId = 96
}

public enum PostEffectType
{
    [Description("RPR_POST_EFFECT_TONE_MAP")]
    OneMap = 0,

    [Description("RPR_POST_EFFECT_WHITE_BALANCE")]
    WhiteBalance = 1,

    [Description("RPR_POST_EFFECT_SIMPLE_TONEMAP")]
    SimpleTonemap = 2,

    [Description("RPR_POST_EFFECT_NORMALIZATION")]
    Normalization = 3,

    [Description("RPR_POST_EFFECT_GAMMA_CORRECTION")]
    GammaCorrection = 4,

    [Description("RPR_POST_EFFECT_BLOOM")]
    Bloom = 5
}

public enum ColorSpace
{
    [Description("RPR_COLOR_SPACE_SRGB")]
    Srgb = 1,

    [Description("RPR_COLOR_SPACE_ADOBE_RGB")]
    AdobeRgb = 2,

    [Description("RPR_COLOR_SPACE_REC2020")]
    Rec2020 = 3,

    [Description("RPR_COLOR_SPACE_DCIP3")]
    Dcip3 = 4
}

public enum MaterialNodeInputType
{
    [Description("RPR_MATERIAL_NODE_INPUT_TYPE_FLOAT4")]
    Float4 = 1,

    [Description("RPR_MATERIAL_NODE_INPUT_TYPE_UINT")]
    Uint = 2,

    [Description("RPR_MATERIAL_NODE_INPUT_TYPE_NODE")]
    Node = 3,

    [Description("RPR_MATERIAL_NODE_INPUT_TYPE_IMAGE")]
    Image = 4,

    [Description("RPR_MATERIAL_NODE_INPUT_TYPE_BUFFER")]
    Buffer = 5,

    [Description("RPR_MATERIAL_NODE_INPUT_TYPE_GRID")]
    Grid = 6,

    [Description("RPR_MATERIAL_NODE_INPUT_TYPE_DATA")]
    Data = 7,

    [Description("RPR_MATERIAL_NODE_INPUT_TYPE_LIGHT")]
    Light = 8
}

public enum SubdivBoundaryInterfopType
{
    [Description("RPR_SUBDIV_BOUNDARY_INTERFOP_TYPE_EDGE_AND_CORNER")]
    EdgeAndCorner = 1,

    [Description("RPR_SUBDIV_BOUNDARY_INTERFOP_TYPE_EDGE_ONLY")]
    EdgeOnly = 2
}

public enum ImageWrapType
{
    [Description("RPR_IMAGE_WRAP_TYPE_REPEAT")]
    Repeat = 1,

    [Description("RPR_IMAGE_WRAP_TYPE_MIRRORED_REPEAT")]
    MirroredRepeat = 2,

    [Description("RPR_IMAGE_WRAP_TYPE_CLAMP_TO_EDGE")]
    ClampToEdge = 3,

    [Description("RPR_IMAGE_WRAP_TYPE_CLAMP_ZERO")]
    ClampZero = 5,

    [Description("RPR_IMAGE_WRAP_TYPE_CLAMP_ONE")]
    ClampOne = 6
}

public enum VoronoiOutType
{
    [Description("RPR_VORONOI_OUT_TYPE_DISTANCE")]
    Distance = 1,

    [Description("RPR_VORONOI_OUT_TYPE_COLOR")]
    Color = 2,

    [Description("RPR_VORONOI_OUT_TYPE_POSITION")]
    Position = 3
}

public enum ImageFilterType
{
    [Description("RPR_IMAGE_FILTER_TYPE_NEAREST")]
    Nearest = 1,

    [Description("RPR_IMAGE_FILTER_TYPE_LINEAR")]
    Linear = 2
}

public enum CompositeInfo
{
    [Description("RPR_COMPOSITE_TYPE")]
    Type = 1,

    [Description("RPR_COMPOSITE_FRAMEBUFFER_INPUT_FB")]
    FramebufferInputFb = 2,

    [Description("RPR_COMPOSITE_NORMALIZE_INPUT_COLOR")]
    NormalizeInputColor = 3,

    [Description("RPR_COMPOSITE_NORMALIZE_INPUT_AOVTYPE")]
    NormalizeInputAovtype = 4,

    [Description("RPR_COMPOSITE_CONSTANT_INPUT_VALUE")]
    ConstantInputValue = 5,

    [Description("RPR_COMPOSITE_LERP_VALUE_INPUT_COLOR0")]
    LerpValueInputColor0 = 6,

    [Description("RPR_COMPOSITE_LERP_VALUE_INPUT_COLOR1")]
    LerpValueInputColor1 = 7,

    [Description("RPR_COMPOSITE_LERP_VALUE_INPUT_WEIGHT")]
    LerpValueInputWeight = 8,

    [Description("RPR_COMPOSITE_ARITHMETIC_INPUT_COLOR0")]
    ArithmeticInputColor0 = 9,

    [Description("RPR_COMPOSITE_ARITHMETIC_INPUT_COLOR1")]
    ArithmeticInputColor1 = 10,

    [Description("RPR_COMPOSITE_ARITHMETIC_INPUT_OP")]
    ArithmeticInputOp = 11,

    [Description("RPR_COMPOSITE_GAMMA_CORRECTION_INPUT_COLOR")]
    GammaCorrectionInputColor = 12,

    [Description("RPR_COMPOSITE_LUT_INPUT_LUT")]
    LutInputLut = 13,

    [Description("RPR_COMPOSITE_LUT_INPUT_COLOR")]
    LutInputColor = 14,

    [Description("RPR_COMPOSITE_NAME")]
    Name = 7829367,

    [Description("RPR_COMPOSITE_UNIQUE_ID")]
    UniqueId = 7829368,

    [Description("RPR_COMPOSITE_CUSTOM_PTR")]
    CustomPtr = 7829369
}

public enum CompositeType
{
    [Description("RPR_COMPOSITE_ARITHMETIC")]
    Arithmetic = 1,

    [Description("RPR_COMPOSITE_LERP_VALUE")]
    LerpValue = 2,

    [Description("RPR_COMPOSITE_INVERSE")]
    Inverse = 3,

    [Description("RPR_COMPOSITE_NORMALIZE")]
    Normalize = 4,

    [Description("RPR_COMPOSITE_GAMMA_CORRECTION")]
    GammaCorrection = 5,

    [Description("RPR_COMPOSITE_EXPOSURE")]
    Exposure = 6,

    [Description("RPR_COMPOSITE_CONTRAST")]
    Contrast = 7,

    [Description("RPR_COMPOSITE_SIDE_BY_SIDE")]
    SideBySide = 8,

    [Description("RPR_COMPOSITE_TONEMAP_ACES")]
    OnemapAces = 9,

    [Description("RPR_COMPOSITE_TONEMAP_REINHARD")]
    OnemapReinhard = 10,

    [Description("RPR_COMPOSITE_TONEMAP_LINEAR")]
    OnemapLinear = 11,

    [Description("RPR_COMPOSITE_FRAMEBUFFER")]
    Framebuffer = 12,

    [Description("RPR_COMPOSITE_CONSTANT")]
    Constant = 13,

    [Description("RPR_COMPOSITE_LUT")]
    Lut = 14
}

public enum GridParameter
{
    [Description("RPR_GRID_SIZE_X")]
    SizeX = 2352,

    [Description("RPR_GRID_SIZE_Y")]
    SizeY = 2353,

    [Description("RPR_GRID_SIZE_Z")]
    SizeZ = 2354,

    [Description("RPR_GRID_DATA")]
    Data = 2355,

    [Description("RPR_GRID_DATA_SIZEBYTE")]
    DataSizebyte = 2356,

    [Description("RPR_GRID_INDICES")]
    Indices = 2358,

    [Description("RPR_GRID_INDICES_NUMBER")]
    IndicesNumber = 2359,

    [Description("RPR_GRID_INDICES_TOPOLOGY")]
    IndicesTopology = 2360,

    [Description("RPR_GRID_NAME")]
    Name = 7829367,

    [Description("RPR_GRID_UNIQUE_ID")]
    UniqueId = 7829368,

    [Description("RPR_GRID_CUSTOM_PTR")]
    CustomPtr = 7829369
}

public enum HeteroVolumeParameter
{
    [Description("RPR_HETEROVOLUME_TRANSFORM")]
    VolumeTransform = 1845,

    [Description("RPR_HETEROVOLUME_ALBEDO_V2")]
    VolumeAlbedoV2 = 1852,

    [Description("RPR_HETEROVOLUME_DENSITY_V2")]
    VolumeDensityV2 = 1853,

    [Description("RPR_HETEROVOLUME_EMISSION_V2")]
    VolumeEmissionV2 = 1854,

    [Description("RPR_HETEROVOLUME_ALBEDO_LOOKUP_VALUES")]
    VolumeAlbedoLookupValues = 1855,

    [Description("RPR_HETEROVOLUME_ALBEDO_LOOKUP_VALUES_COUNT")]
    VolumeAlbedoLookupValuesCount = 1856,

    [Description("RPR_HETEROVOLUME_DENSITY_LOOKUP_VALUES")]
    VolumeDensityLookupValues = 1857,

    [Description("RPR_HETEROVOLUME_DENSITY_LOOKUP_VALUES_COUNT")]
    VolumeDensityLookupValuesCount = 1858,

    [Description("RPR_HETEROVOLUME_EMISSION_LOOKUP_VALUES")]
    VolumeEmissionLookupValues = 1859,

    [Description("RPR_HETEROVOLUME_EMISSION_LOOKUP_VALUES_COUNT")]
    VolumeEmissionLookupValuesCount = 1860,

    [Description("RPR_HETEROVOLUME_ALBEDO_SCALE")]
    VolumeAlbedoScale = 1861,

    [Description("RPR_HETEROVOLUME_DENSITY_SCALE")]
    VolumeDensityScale = 1862,

    [Description("RPR_HETEROVOLUME_EMISSION_SCALE")]
    VolumeEmissionScale = 1863,

    [Description("RPR_HETEROVOLUME_NAME")]
    VolumeName = 7829367,

    [Description("RPR_HETEROVOLUME_UNIQUE_ID")]
    VolumeUniqueId = 7829368,

    [Description("RPR_HETEROVOLUME_CUSTOM_PTR")]
    VolumeCustomPtr = 7829369
}

public enum GridIndicesTopology
{
    [Description("RPR_GRID_INDICES_TOPOLOGY_I_U64")]
    IU64 = 2384,

    [Description("RPR_GRID_INDICES_TOPOLOGY_XYZ_U32")]
    XyzU32 = 2385,

    [Description("RPR_GRID_INDICES_TOPOLOGY_I_S64")]
    IS64 = 2386,

    [Description("RPR_GRID_INDICES_TOPOLOGY_XYZ_S32")]
    XyzS32 = 2387
}

public enum CurveParameter
{
    [Description("RPR_CURVE_CONTROLPOINTS_COUNT")]
    ControlpointsCount = 2096,

    [Description("RPR_CURVE_CONTROLPOINTS_DATA")]
    ControlpointsData = 2097,

    [Description("RPR_CURVE_CONTROLPOINTS_STRIDE")]
    ControlpointsStride = 2098,

    [Description("RPR_CURVE_INDICES_COUNT")]
    IndicesCount = 2099,

    [Description("RPR_CURVE_INDICES_DATA")]
    IndicesData = 2100,

    [Description("RPR_CURVE_RADIUS")]
    Radius = 2101,

    [Description("RPR_CURVE_UV")]
    Uv = 2102,

    [Description("RPR_CURVE_COUNT_CURVE")]
    Count = 2103,

    [Description("RPR_CURVE_SEGMENTS_PER_CURVE")]
    SegmentsPer = 2104,

    [Description("RPR_CURVE_CREATION_FLAG")]
    CreationFlag = 2105,

    [Description("RPR_CURVE_NAME")]
    Name = 7829367,

    [Description("RPR_CURVE_UNIQUE_ID")]
    UniqueId = 7829368,

    [Description("RPR_CURVE_CUSTOM_PTR")]
    CustomPtr = 7829369,

    [Description("RPR_CURVE_TRANSFORM")]
    Transform = 1027,

    [Description("RPR_CURVE_MATERIAL")]
    Material = 1028,

    [Description("RPR_CURVE_VISIBILITY_PRIMARY_ONLY_FLAG")]
    VisibilityPrimaryOnlyFlag = 1036,

    [Description("RPR_CURVE_VISIBILITY_SHADOW")]
    VisibilityShadow = 1050,

    [Description("RPR_CURVE_VISIBILITY_REFLECTION")]
    VisibilityReflection = 1051,

    [Description("RPR_CURVE_VISIBILITY_REFRACTION")]
    VisibilityRefraction = 1052,

    [Description("RPR_CURVE_VISIBILITY_TRANSPARENT")]
    VisibilityTransparent = 1053,

    [Description("RPR_CURVE_VISIBILITY_DIFFUSE")]
    VisibilityDiffuse = 1054,

    [Description("RPR_CURVE_VISIBILITY_GLOSSY_REFLECTION")]
    VisibilityGlossyReflection = 1055,

    [Description("RPR_CURVE_VISIBILITY_GLOSSY_REFRACTION")]
    VisibilityGlossyRefraction = 1056,

    [Description("RPR_CURVE_VISIBILITY_LIGHT")]
    VisibilityLight = 1057,

    [Description("RPR_CURVE_VISIBILITY_RECEIVE_SHADOW")]
    VisibilityReceiveShadow = 1072
}

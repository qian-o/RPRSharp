﻿namespace RPRSharp;

/// <summary>
/// rpr_context_info
/// </summary>
public enum ContextInfo : int
{
    CREATION_FLAGS = 0x102,
    CACHE_PATH = 0x103,
    RENDER_STATUS = 0x104,
    RENDER_STATISTICS = 0x105,
    DEVICE_COUNT = 0x106,
    PARAMETER_COUNT = 0x107,
    ACTIVE_PLUGIN = 0x108,
    SCENE = 0x109,
    ITERATIONS = 0x10B,
    IMAGE_FILTER_TYPE = 0x10C,
    TONE_MAPPING_TYPE = 0x113,
    TONE_MAPPING_LINEAR_SCALE = 0x114,
    TONE_MAPPING_PHOTO_LINEAR_SENSITIVITY = 0x115,
    TONE_MAPPING_PHOTO_LINEAR_EXPOSURE = 0x116,
    TONE_MAPPING_PHOTO_LINEAR_FSTOP = 0x117,
    TONE_MAPPING_REINHARD02_PRE_SCALE = 0x118,
    TONE_MAPPING_REINHARD02_POST_SCALE = 0x119,
    TONE_MAPPING_REINHARD02_BURN = 0x11A,
    MAX_RECURSION = 0x11B,
    RAY_CAST_EPSILON = 0x11C,
    RADIANCE_CLAMP = 0x11D,
    X_FLIP = 0x11E,
    Y_FLIP = 0x11F,
    TEXTURE_GAMMA = 0x120,
    PDF_THRESHOLD = 0x121,
    RENDER_MODE = 0x122,
    ROUGHNESS_CAP = 0x123,
    DISPLAY_GAMMA = 0x124,
    MATERIAL_STACK_SIZE = 0x125,
    CUTTING_PLANES = 0x126,
    GPU0_NAME = 0x127,
    GPU1_NAME = 0x128,
    GPU2_NAME = 0x129,
    GPU3_NAME = 0x12A,
    CPU_NAME = 0x12B,
    GPU4_NAME = 0x12C,
    GPU5_NAME = 0x12D,
    GPU6_NAME = 0x12E,
    GPU7_NAME = 0x12F,
    TONE_MAPPING_EXPONENTIAL_INTENSITY = 0x130,
    FRAMECOUNT = 0x131,
    TEXTURE_COMPRESSION = 0x132,
    AO_RAY_LENGTH = 0x133,
    OOC_TEXTURE_CACHE = 0x134,
    PREVIEW = 0x135,
    CPU_THREAD_LIMIT = 0x136,
    LAST_ERROR_MESSAGE = 0x137,
    MAX_DEPTH_DIFFUSE = 0x138,
    MAX_DEPTH_GLOSSY = 0x139,
    OOC_CACHE_PATH = 0x13a,
    MAX_DEPTH_REFRACTION = 0x13B,
    MAX_DEPTH_GLOSSY_REFRACTION = 0x13C,
    RENDER_LAYER_MASK = 0x13D,
    SINGLE_LEVEL_BVH_ENABLED = 0x13E,
    TRANSPARENT_BACKGROUND = 0x13F,
    MAX_DEPTH_SHADOW = 0x140,
    API_VERSION = 0x141,
    GPU8_NAME = 0x142,
    GPU9_NAME = 0x143,
    GPU10_NAME = 0x144,
    GPU11_NAME = 0x145,
    GPU12_NAME = 0x146,
    GPU13_NAME = 0x147,
    GPU14_NAME = 0x148,
    GPU15_NAME = 0x149,
    API_VERSION_MINOR = 0x14A,
    METAL_PERFORMANCE_SHADER = 0x14B,
    USER_TEXTURE_0 = 0x14C,
    USER_TEXTURE_1 = 0x14D,
    USER_TEXTURE_2 = 0x14E,
    USER_TEXTURE_3 = 0x14F,
    MIPMAP_LOD_OFFSET = 0x150,
    AO_RAY_COUNT = 0x151,
    SAMPLER_TYPE = 0x152,
    ADAPTIVE_SAMPLING_TILE_SIZE = 0x153,
    ADAPTIVE_SAMPLING_MIN_SPP = 0x154,
    ADAPTIVE_SAMPLING_THRESHOLD = 0x155,
    TILE_SIZE = 0x156,
    LIST_CREATED_CAMERAS = 0x157,
    LIST_CREATED_MATERIALNODES = 0x158,
    LIST_CREATED_LIGHTS = 0x159,
    LIST_CREATED_SHAPES = 0x15A,
    LIST_CREATED_POSTEFFECTS = 0x15B,
    LIST_CREATED_HETEROVOLUMES = 0x15C,
    LIST_CREATED_GRIDS = 0x15D,
    LIST_CREATED_BUFFERS = 0x15E,
    LIST_CREATED_IMAGES = 0x15F,
    LIST_CREATED_FRAMEBUFFERS = 0x160,
    LIST_CREATED_SCENES = 0x161,
    LIST_CREATED_CURVES = 0x162,
    LIST_CREATED_MATERIALSYSTEM = 0x163,
    LIST_CREATED_COMPOSITE = 0x164,
    LIST_CREATED_LUT = 0x165,
    AA_ENABLED = 0x166,
    ACTIVE_PIXEL_COUNT = 0x167,
    TRACING_ENABLED = 0x168,
    TRACING_PATH = 0x169,
    TILE_RECT = 0x16A,
    PLUGIN_VERSION = 0x16B,
    RUSSIAN_ROULETTE_DEPTH = 0x16C,
    SHADOW_CATCHER_BAKING = 0x16D,
    RENDER_UPDATE_CALLBACK_FUNC = 0x16E,
    RENDER_UPDATE_CALLBACK_DATA = 0x16F,
    COMPILE_CALLBACK_FUNC = 0x601,
    COMPILE_CALLBACK_DATA = 0x602,
    TEXTURE_CACHE_PATH = 0x170,
    OCIO_CONFIG_PATH = 0x171,
    OCIO_RENDERING_COLOR_SPACE = 0x172,
    CONTOUR_USE_OBJECTID = 0x173,
    CONTOUR_USE_MATERIALID = 0x174,
    CONTOUR_USE_NORMAL = 0x175,
    CONTOUR_USE_UV = 0x186,
    CONTOUR_NORMAL_THRESHOLD = 0x176,
    CONTOUR_UV_THRESHOLD = 0x187,
    CONTOUR_UV_SECONDARY = 0x194,
    CONTOUR_LINEWIDTH_OBJECTID = 0x177,
    CONTOUR_LINEWIDTH_MATERIALID = 0x178,
    CONTOUR_LINEWIDTH_NORMAL = 0x179,
    CONTOUR_LINEWIDTH_UV = 0x188,
    CONTOUR_ANTIALIASING = 0x17A,
    CONTOUR_DEBUG_ENABLED = 0x17F,
    GPUINTEGRATOR = 0x17B,
    CPUINTEGRATOR = 0x17C,
    BEAUTY_MOTION_BLUR = 0x17D,
    CAUSTICS_REDUCTION = 0x17E,
    GPU_MEMORY_LIMIT = 0x180,
    RENDER_LAYER_LIST = 0x181,
    WINDING_ORDER_CORRECTION = 0x182,
    DEEP_SUBPIXEL_MERGE_Z_THRESHOLD = 0x183,
    DEEP_GPU_ALLOCATION_LEVEL = 0x184,
    DEEP_COLOR_ENABLED = 0x185,
    FOG_COLOR = 0x189,
    FOG_DISTANCE = 0x18A,
    FOG_HEIGHT = 0x18B,
    ATMOSPHERE_VOLUME_COLOR = 0x18C,
    ATMOSPHERE_VOLUME_DENSITY = 0x18D,
    ATMOSPHERE_VOLUME_RADIANCE_CLAMP = 0x18F,
    FOG_HEIGHT_OFFSET = 0x18E,
    INDIRECT_DOWNSAMPLE = 0x190,
    CRYPTOMATTE_EXTENDED = 0x191,
    CRYPTOMATTE_SPLIT_INDIRECT = 0x192,
    FOG_DIRECTION = 0x193,
    RANDOM_SEED = 0x1000,
    IBL_DISPLAY = 0x195,
    FRAMEBUFFER_SAVE_FLOAT32 = 0x196,
    UPDATE_TIME_CALLBACK_FUNC = 0x197,
    UPDATE_TIME_CALLBACK_DATA = 0x198,
    RENDER_TIME_CALLBACK_FUNC = 0x199,
    RENDER_TIME_CALLBACK_DATA = 0x19A,
    FIRST_ITERATION_TIME_CALLBACK_FUNC = 0x19B,
    FIRST_ITERATION_TIME_CALLBACK_DATA = 0x19C,
    IMAGE_FILTER_RADIUS = 0x19D,
    PRECOMPILED_BINARY_PATH = 0x19E,
    REFLECTION_ENERGY_COMPENSATION_ENABLED = 0x19F,
    NORMALIZE_LIGHT_INTENSITY_ENABLED = 0x1A0,
    NAME = Rpr.OBJECT_NAME,
    UNIQUE_ID = Rpr.OBJECT_UNIQUE_ID,
    CUSTOM_PTR = Rpr.OBJECT_CUSTOM_PTR
}

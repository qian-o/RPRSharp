﻿namespace RPRSharp;

/// <summary>
/// rpr_shape_info
/// </summary>
public enum ShapeInfo : int
{
    TYPE = 0x401,
    VIDMEM_USAGE = 0x402,
    TRANSFORM = 0x403,
    MATERIAL = 0x404,
    LINEAR_MOTION = 0x405,
    ANGULAR_MOTION = 0x406,
    SHADOW_FLAG = 0x408,
    SUBDIVISION_FACTOR = 0x409,
    DISPLACEMENT_SCALE = 0x40A,
    SHADOW_CATCHER_FLAG = 0x40E,
    VOLUME_MATERIAL = 0x40F,
    OBJECT_GROUP_ID = 0x410,
    SUBDIVISION_CREASEWEIGHT = 0x411,
    SUBDIVISION_BOUNDARYINTEROP = 0x412,
    DISPLACEMENT_MATERIAL = 0x413,
    MATERIALS_PER_FACE = 0x415,
    SCALE_MOTION = 0x416,
    HETERO_VOLUME = 0x417,
    LAYER_MASK = 0x418,
    VISIBILITY_PRIMARY_ONLY_FLAG = 0x40C,
    VISIBILITY_SHADOW = 0x41A,
    VISIBILITY_REFLECTION = 0x41B,
    VISIBILITY_REFRACTION = 0x41C,
    VISIBILITY_TRANSPARENT = 0x41D,
    VISIBILITY_DIFFUSE = 0x41E,
    VISIBILITY_GLOSSY_REFLECTION = 0x41F,
    VISIBILITY_GLOSSY_REFRACTION = 0x420,
    VISIBILITY_LIGHT = 0x421,
    LIGHT_GROUP_ID = 0x422,
    STATIC = 0x423,
    PER_VERTEX_VALUE0 = 0x424,
    PER_VERTEX_VALUE1 = 0x425,
    PER_VERTEX_VALUE2 = 0x426,
    PER_VERTEX_VALUE3 = 0x427,
    REFLECTION_CATCHER_FLAG = 0x428,
    OBJECT_ID = 0x429,
    SUBDIVISION_AUTO_RATIO_CAP = 0x42A,
    MOTION_TRANSFORMS_COUNT = 0x42B,
    MOTION_TRANSFORMS = 0x42C,
    CONTOUR_IGNORE = 0x42D,
    RENDER_LAYER_LIST = 0x42E,
    SHADOW_COLOR = 0x42F,
    VISIBILITY_RECEIVE_SHADOW = 0x430,
    PRIMVARS = 0x431,
    ENVIRONMENT_LIGHT = 0x432,
    NAME = Rpr.OBJECT_NAME,
    UNIQUE_ID = Rpr.OBJECT_UNIQUE_ID,
    CUSTOM_PTR = Rpr.OBJECT_CUSTOM_PTR
}

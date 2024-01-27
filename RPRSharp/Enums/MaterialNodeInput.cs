﻿namespace RPRSharp.Enums;

/// <summary>
/// rpr_material_node_input
/// </summary>
public enum MaterialNodeInput : int
{
    COLOR = 0x0,
    COLOR0 = 0x1,
    COLOR1 = 0x2,
    NORMAL = 0x3,
    UV = 0x4,
    DATA = 0x5,
    ROUGHNESS = 0x6,
    IOR = 0x7,
    ROUGHNESS_X = 0x8,
    ROUGHNESS_Y = 0x9,
    ROTATION = 0xA,
    WEIGHT = 0xB,
    OP = 0xC,
    INVEC = 0xD,
    UV_SCALE = 0xE,
    VALUE = 0xF,
    REFLECTANCE = 0x10,
    SCALE = 0x11,
    SCATTERING = 0x12,
    ABSORBTION = 0x13,
    EMISSION = 0x14,
    G = 0x15,
    MULTISCATTER = 0x16,
    COLOR2 = 0x17,
    COLOR3 = 0x18,
    ANISOTROPIC = 0x19,
    FRONTFACE = 0x1a,
    BACKFACE = 0x1b,
    ORIGIN = 0x1c,
    ZAXIS = 0x1d,
    XAXIS = 0x1e,
    THRESHOLD = 0x1f,
    OFFSET = 0x20,
    UV_TYPE = 0x21,
    RADIUS = 0x22,
    SIDE = 0x23,
    CAUSTICS = 0x24,
    TRANSMISSION_COLOR = 0x25,
    THICKNESS = 0x26,
    INPUT_0 = 0x27,
    INPUT_1 = 0x28,
    INPUT_2 = 0x29,
    INPUT_3 = 0x2a,
    INPUT_4 = 0x2b,
    SCHLICK_APPROXIMATION = 0x2c,
    APPLYSURFACE = 0x2d,
    TANGENT = 0x2e,
    DISTRIBUTION = 0x2f,
    BASE = 0x30,
    TINT = 0x31,
    EXPONENT = 0x32,
    AMPLITUDE = 0x33,
    PIVOT = 0x34,
    POSITION = 0x35,
    AMOUNT = 0x36,
    AXIS = 0x37,
    LUMACOEFF = 0x38,
    REFLECTIVITY = 0x39,
    EDGE_COLOR = 0x3a,
    VIEW_DIRECTION = 0x3b,
    INTERIOR = 0x3c,
    OCTAVES = 0x3d,
    LACUNARITY = 0x3e,
    DIMINISH = 0x3f,
    WRAP_U = 0x40,
    WRAP_V = 0x41,
    WRAP_W = 0x42,
    INPUT_5 = 0x43,
    INPUT_6 = 0x44,
    INPUT_7 = 0x45,
    INPUT_8 = 0x46,
    INPUT_9 = 0x47,
    INPUT_10 = 0x48,
    INPUT_11 = 0x49,
    INPUT_12 = 0x4a,
    INPUT_13 = 0x4b,
    INPUT_14 = 0x4c,
    INPUT_15 = 0x4d,
    DIFFUSE_RAMP = 0x4e,
    SHADOW = 0x4f,
    MID = 0x50,
    HIGHLIGHT = 0x51,
    POSITION1 = 0x52,
    POSITION2 = 0x53,
    RANGE1 = 0x54,
    RANGE2 = 0x55,
    INTERPOLATION = 0x56,
    RANDOMNESS = 0x57,
    DIMENSION = 0x58,
    OUTTYPE = 0x59,
    DENSITY = 0x5a,
    DENSITYGRID = 0x5b,
    DISPLACEMENT = 0x5c,
    TEMPERATURE = 0x5d,
    KELVIN = 0x5e,
    EXTINCTION = 0x5f,
    THIN_FILM = 0x60,
    TOP = 0x61,
    HIGHLIGHT2 = 0x62,
    SHADOW2 = 0x63,
    POSITION_SHADOW = 0x64,
    POSITION_HIGHLIGHT = 0x65,
    RANGE_SHADOW = 0x66,
    RANGE_HIGHLIGHT = 0x67,
    TOON_5_COLORS = 0x68,
    X = 0x69,
    Y = 0x6a,
    Z = 0x6b,
    W = 0x6c,
    LIGHT = 0x6d,
    MID_IS_ALBEDO = 0x6e,
    SAMPLES = 0x6f,
    BASE_NORMAL = 0x70,
    UBER_DIFFUSE_COLOR = 0x910,
    UBER_DIFFUSE_WEIGHT = 0x927,
    UBER_DIFFUSE_ROUGHNESS = 0x911,
    UBER_DIFFUSE_NORMAL = 0x912,
    UBER_REFLECTION_COLOR = 0x913,
    UBER_REFLECTION_WEIGHT = 0x928,
    UBER_REFLECTION_ROUGHNESS = 0x914,
    UBER_REFLECTION_ANISOTROPY = 0x915,
    UBER_REFLECTION_ANISOTROPY_ROTATION = 0x916,
    UBER_REFLECTION_MODE = 0x917,
    UBER_REFLECTION_IOR = 0x918,
    UBER_REFLECTION_METALNESS = 0x919,
    UBER_REFLECTION_NORMAL = 0x929,
    UBER_REFLECTION_DIELECTRIC_REFLECTANCE = 0x93e,
    UBER_REFRACTION_COLOR = 0x91A,
    UBER_REFRACTION_WEIGHT = 0x92a,
    UBER_REFRACTION_ROUGHNESS = 0x91B,
    UBER_REFRACTION_IOR = 0x91C,
    UBER_REFRACTION_NORMAL = 0x92b,
    UBER_REFRACTION_THIN_SURFACE = 0x91D,
    UBER_REFRACTION_ABSORPTION_COLOR = 0x92c,
    UBER_REFRACTION_ABSORPTION_DISTANCE = 0x92d,
    UBER_REFRACTION_CAUSTICS = 0x92e,
    UBER_COATING_COLOR = 0x91E,
    UBER_COATING_WEIGHT = 0x92f,
    UBER_COATING_ROUGHNESS = 0x91F,
    UBER_COATING_MODE = 0x920,
    UBER_COATING_IOR = 0x921,
    UBER_COATING_METALNESS = 0x922,
    UBER_COATING_NORMAL = 0x923,
    UBER_COATING_TRANSMISSION_COLOR = 0x930,
    UBER_COATING_THICKNESS = 0x931,
    UBER_SHEEN = 0x932,
    UBER_SHEEN_TINT = 0x933,
    UBER_SHEEN_WEIGHT = 0x934,
    UBER_EMISSION_COLOR = 0x924,
    UBER_EMISSION_WEIGHT = 0x925,
    UBER_EMISSION_MODE = 0x935,
    UBER_TRANSPARENCY = 0x926,
    UBER_SSS_SCATTER_COLOR = 0x937,
    UBER_SSS_SCATTER_DISTANCE = 0x938,
    UBER_SSS_SCATTER_DIRECTION = 0x939,
    UBER_SSS_WEIGHT = 0x93a,
    UBER_SSS_MULTISCATTER = 0x93b,
    UBER_BACKSCATTER_WEIGHT = 0x93c,
    UBER_BACKSCATTER_COLOR = 0x93d,
    ADDRESS = UBER_REFLECTION_DIELECTRIC_REFLECTANCE,
    TYPE = 0x93f,
    UBER_FRESNEL_SCHLICK_APPROXIMATION = SCHLICK_APPROXIMATION
}

﻿namespace RPRSharp;

/// <summary>
/// rpr_composite_info
/// </summary>
public enum CompositeInfo : int
{
    TYPE = 0x1,
    FRAMEBUFFER_INPUT_FB = 0x2,
    NORMALIZE_INPUT_COLOR = 0x3,
    NORMALIZE_INPUT_AOVTYPE = 0x4,
    CONSTANT_INPUT_VALUE = 0x5,
    LERP_VALUE_INPUT_COLOR0 = 0x6,
    LERP_VALUE_INPUT_COLOR1 = 0x7,
    LERP_VALUE_INPUT_WEIGHT = 0x8,
    ARITHMETIC_INPUT_COLOR0 = 0x9,
    ARITHMETIC_INPUT_COLOR1 = 0x0a,
    ARITHMETIC_INPUT_OP = 0x0b,
    GAMMA_CORRECTION_INPUT_COLOR = 0x0c,
    LUT_INPUT_LUT = 0x0d,
    LUT_INPUT_COLOR = 0x0e,
    NAME = Rpr.ObjectName,
    UNIQUE_ID = Rpr.ObjectUniqueId,
    CUSTOM_PTR = Rpr.ObjectCustomPtr
}

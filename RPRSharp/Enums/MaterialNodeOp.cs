﻿namespace RPRSharp.Enums;

/// <summary>
/// rpr_material_node_arithmetic_operation
/// </summary>
public enum MaterialNodeOp : int
{
    ADD = 0x00,
    SUB = 0x01,
    MUL = 0x02,
    DIV = 0x03,
    SIN = 0x04,
    COS = 0x05,
    TAN = 0x06,
    SELECT_X = 0x07,
    SELECT_Y = 0x08,
    SELECT_Z = 0x09,
    COMBINE = 0x0A,
    DOT3 = 0x0B,
    CROSS3 = 0x0C,
    LENGTH3 = 0x0D,
    NORMALIZE3 = 0x0E,
    POW = 0x0F,
    ACOS = 0x10,
    ASIN = 0x11,
    ATAN = 0x12,
    AVERAGE_XYZ = 0x13,
    AVERAGE = 0x14,
    MIN = 0x15,
    MAX = 0x16,
    FLOOR = 0x17,
    MOD = 0x18,
    ABS = 0x19,
    SHUFFLE_YZWX = 0x1a,
    SHUFFLE_ZWXY = 0x1b,
    SHUFFLE_WXYZ = 0x1c,
    MAT_MUL = 0x1d,
    SELECT_W = 0x1e,
    DOT4 = 0x1f,
    LOG = 0x20,
    LOWER_OR_EQUAL = 0x21,
    LOWER = 0x22,
    GREATER_OR_EQUAL = 0x23,
    GREATER = 0x24,
    EQUAL = 0x25,
    NOT_EQUAL = 0x26,
    AND = 0x27,
    OR = 0x28,
    TERNARY = 0x29,
    EXP = 0x2a,
    ROTATE2D = 0x2b,
    ROTATE3D = 0x2c,
    NOP = 0x2d,
    CEIL = 0x102a,
    ROUND = 0x102b,
    SIGN = 0x102c,
    SQRT = 0x102f,
    CLAMP = 0x1035
}

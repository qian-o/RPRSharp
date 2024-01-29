namespace RPRSharp;

/// <summary>
/// rpr_composite_type
/// </summary>
public enum CompositeType : int
{
    ARITHMETIC = 0x1,
    LERP_VALUE = 0x2,
    INVERSE = 0x3,
    NORMALIZE = 0x4,
    GAMMA_CORRECTION = 0x5,
    EXPOSURE = 0x6,
    CONTRAST = 0x7,
    SIDE_BY_SIDE = 0x8,
    TONEMAP_ACES = 0x9,
    TONEMAP_REINHARD = 0xa,
    TONEMAP_LINEAR = 0xb,
    FRAMEBUFFER = 0xc,
    CONSTANT = 0xd,
    LUT = 0xe
}

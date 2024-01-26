namespace RPRSharp.Enums;

/// <summary>
/// rpr_image_wrap_type
/// </summary>
public enum ImageWrapType : int
{
    REPEAT = 0x1,
    MIRRORED_REPEAT = 0x2,
    CLAMP_TO_EDGE = 0x3,
    CLAMP_ZERO = 0x5,
    CLAMP_ONE = 0x6
}

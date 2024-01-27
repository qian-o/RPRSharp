namespace RPRSharp.Enums;

/// <summary>
/// rpr_post_effect_info
/// </summary>
public enum PostEffectInfo : int
{
    TYPE = 0x0,
    WHITE_BALANCE_COLOR_SPACE = 0x4,
    WHITE_BALANCE_COLOR_TEMPERATURE = 0x5,
    SIMPLE_TONEMAP_EXPOSURE = 0x6,
    SIMPLE_TONEMAP_CONTRAST = 0x7,
    SIMPLE_TONEMAP_ENABLE_TONEMAP = 0x8,
    BLOOM_RADIUS = 0x9,
    BLOOM_THRESHOLD = 0x0a,
    BLOOM_WEIGHT = 0x0b,
    NAME = Rpr.OBJECT_NAME,
    UNIQUE_ID = Rpr.OBJECT_UNIQUE_ID,
    CUSTOM_PTR = Rpr.OBJECT_CUSTOM_PTR
}

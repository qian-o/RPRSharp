namespace RPRSharp.Enums;

/// <summary>
/// rpr_post_effect_type
/// </summary>
public enum PostEffectType : int
{
    TONE_MAP = 0x0,
    WHITE_BALANCE = 0x1,
    SIMPLE_TONEMAP = 0x2,
    NORMALIZATION = 0x3,
    GAMMA_CORRECTION = 0x4,
    BLOOM = 0x5
}

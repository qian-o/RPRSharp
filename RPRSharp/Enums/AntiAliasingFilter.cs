namespace RPRSharp.Enums;

/// <summary>
/// rpr_aa_filter
/// </summary>
public enum AntiAliasingFilter : int
{
    NONE = 0x0,
    BOX = 0x1,
    TRIANGLE = 0x2,
    GAUSSIAN = 0x3,
    MITCHELL = 0x4,
    LANCZOS = 0x5,
    BLACKMANHARRIS = 0x6
}
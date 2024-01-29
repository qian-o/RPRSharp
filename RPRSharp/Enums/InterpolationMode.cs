namespace RPRSharp;

/// <summary>
/// rpr_interpolation_mode
/// </summary>
public enum InterpolationMode : int
{
    NONE = 0x0,
    LINEAR = 0x1,
    EXPONENTIAL_UP = 0x2,
    EXPONENTIAL_DOWN = 0x3,
    SMOOTH = 0x4,
    BUMP = 0x5,
    SPIKE = 0x6
}

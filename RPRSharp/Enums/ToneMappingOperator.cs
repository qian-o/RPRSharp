namespace RPRSharp;

/// <summary>
/// rpr_tonemapping_operator
/// </summary>
public enum ToneMappingOperator : int
{
    NONE = 0x0,
    LINEAR = 0x1,
    PHOTOLINEAR = 0x2,
    AUTOLINEAR = 0x3,
    MAXWHITE = 0x4,
    REINHARD02 = 0x5,
    EXPONENTIAL = 0x6
}

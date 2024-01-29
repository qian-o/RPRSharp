namespace RPRSharp;

/// <summary>
/// rpr_primvar_interpolation_type
/// </summary>
public enum PrimvarInterpolationType : int
{
    CONSTANT = 0x1,
    UNIFORM = 0x2,
    VERTEX = 0x3,
    FACEVARYING_NORMAL = 0x4,
    FACEVARYING_UV = 0x5
}

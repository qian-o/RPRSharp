namespace RPRSharp;

/// <summary>
/// rpr_light_type
/// </summary>
public enum LightType : int
{
    POINT = 0x1,
    DIRECTIONAL = 0x2,
    SPOT = 0x3,
    ENVIRONMENT = 0x4,
    SKY = 0x5,
    IES = 0x6,
    SPHERE = 0x7,
    DISK = 0x8
}

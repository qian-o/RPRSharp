namespace RPRSharp.Enums;

/// <summary>
/// rpr_parameter_type
/// </summary>
public enum ParameterType : int
{
    UNDEF = 0x0,
    FLOAT = 0x1,
    FLOAT2 = 0x2,
    FLOAT3 = 0x3,
    FLOAT4 = 0x4,
    IMAGE = 0x5,
    STRING = 0x6,
    SHADER = 0x7,
    UINT = 0x8,
    ULONG = 0x9,
    LONGLONG = 0xa
}

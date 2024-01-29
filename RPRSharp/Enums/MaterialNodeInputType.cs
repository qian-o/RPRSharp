namespace RPRSharp;

/// <summary>
/// rpr_material_node_input_type
/// </summary>
public enum MaterialNodeInputType : int
{
    FLOAT4 = 0x1,
    UINT = 0x2,
    NODE = 0x3,
    IMAGE = 0x4,
    BUFFER = 0x5,
    GRID = 0x6,
    DATA = 0x7,
    LIGHT = 0x8
}

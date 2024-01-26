namespace RPRSharp.Enums;

/// <summary>
/// rpr_material_node_lookup_value
/// </summary>
public enum MaterialNodeLookup : int
{
    UV = 0x0,
    N = 0x1,
    P = 0x2,
    INVEC = 0x3,
    OUTVEC = 0x4,
    UV1 = 0x5,
    P_LOCAL = 0x6,
    VERTEX_VALUE0 = 0x7,
    VERTEX_VALUE1 = 0x8,
    VERTEX_VALUE2 = 0x9,
    VERTEX_VALUE3 = 0xa,
    SHAPE_RANDOM_COLOR = 0xb,
    OBJECT_ID = 0xc,
    PRIMITIVE_RANDOM_COLOR = 0xd
}

namespace RPRSharp.Enums;

/// <summary>
/// rpr_material_node_info
/// </summary>
public enum MaterialNodeInfo : int
{
    TYPE = 0x1101,
    SYSTEM = 0x1102,
    INPUT_COUNT = 0x1103,
    ID = 0x1104,
    NAME = Rpr.OBJECT_NAME,
    UNIQUE_ID = Rpr.OBJECT_UNIQUE_ID,
    CUSTOM_PTR = Rpr.OBJECT_CUSTOM_PTR
}

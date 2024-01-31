namespace RPRSharp;

/// <summary>
/// rpr_material_node_info
/// </summary>
public enum MaterialNodeInfo : int
{
    TYPE = 0x1101,
    SYSTEM = 0x1102,
    INPUT_COUNT = 0x1103,
    ID = 0x1104,
    NAME = Rpr.ObjectName,
    UNIQUE_ID = Rpr.ObjectUniqueId,
    CUSTOM_PTR = Rpr.ObjectCustomPtr
}

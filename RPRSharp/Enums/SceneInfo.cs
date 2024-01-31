namespace RPRSharp;

/// <summary>
/// rpr_scene_info
/// </summary>
public enum SceneInfo : int
{
    SHAPE_COUNT = 0x701,
    LIGHT_COUNT = 0x702,
    SHAPE_LIST = 0x704,
    LIGHT_LIST = 0x705,
    CAMERA = 0x706,
    CAMERA_RIGHT = 0x707,
    BACKGROUND_IMAGE = 0x708,
    AABB = 0x70D,
    HETEROVOLUME_LIST = 0x70E,
    HETEROVOLUME_COUNT = 0x70F,
    CURVE_LIST = 0x710,
    CURVE_COUNT = 0x711,
    ENVIRONMENT_LIGHT = 0x712,
    NAME = Rpr.ObjectName,
    UNIQUE_ID = Rpr.ObjectUniqueId,
    CUSTOM_PTR = Rpr.ObjectCustomPtr
}

namespace RPRSharp.Enums;

/// <summary>
/// rpr_render_mode
/// </summary>
public enum RenderMode : int
{
    GLOBAL_ILLUMINATION = 0x1,
    DIRECT_ILLUMINATION = 0x2,
    DIRECT_ILLUMINATION_NO_SHADOW = 0x3,
    WIREFRAME = 0x4,
    MATERIAL_INDEX = 0x5,
    POSITION = 0x6,
    NORMAL = 0x7,
    TEXCOORD = 0x8,
    AMBIENT_OCCLUSION = 0x9,
    DIFFUSE = 0x0a
}
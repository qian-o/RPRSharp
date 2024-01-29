namespace RPRSharp;

/// <summary>
/// rpr_camera_mode
/// </summary>
public enum CameraMode : int
{
    PERSPECTIVE = 0x1,
    ORTHOGRAPHIC = 0x2,
    LATITUDE_LONGITUDE_360 = 0x3,
    LATITUDE_LONGITUDE_STEREO = 0x4,
    CUBEMAP = 0x5,
    CUBEMAP_STEREO = 0x6,
    FISHEYE = 0x7
}

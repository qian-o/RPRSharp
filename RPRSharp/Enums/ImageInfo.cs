namespace RPRSharp;

/// <summary>
/// rpr_image_info
/// </summary>
public enum ImageInfo : int
{
    FORMAT = 0x301,
    DESC = 0x302,
    DATA = 0x303,
    DATA_SIZEBYTE = 0x304,
    WRAP = 0x305,
    FILTER = 0x306,
    GAMMA = 0x307,
    MIPMAP_ENABLED = 0x308,
    MIP_COUNT = 0x309,
    GAMMA_FROM_FILE = 0x30A,
    UDIM = 0x30B,
    OCIO_COLORSPACE = 0x30C,
    INTERNAL_COMPRESSION = 0x30D,
    NAME = Rpr.ObjectName,
    UNIQUE_ID = Rpr.ObjectUniqueId,
    CUSTOM_PTR = Rpr.ObjectCustomPtr
}

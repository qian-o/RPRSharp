namespace RPRSharp.Enums;

/// <summary>
/// rpr_buffer_info
/// </summary>
public enum BufferInfo : int
{
    DESC = 0x350,
    DATA = 0x351,
    NAME = Rpr.OBJECT_NAME,
    UNIQUE_ID = Rpr.OBJECT_UNIQUE_ID,
    CUSTOM_PTR = Rpr.OBJECT_CUSTOM_PTR
}
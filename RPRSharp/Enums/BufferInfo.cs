namespace RPRSharp;

/// <summary>
/// rpr_buffer_info
/// </summary>
public enum BufferInfo : int
{
    DESC = 0x350,
    DATA = 0x351,
    NAME = Rpr.ObjectName,
    UNIQUE_ID = Rpr.ObjectUniqueId,
    CUSTOM_PTR = Rpr.ObjectCustomPtr
}
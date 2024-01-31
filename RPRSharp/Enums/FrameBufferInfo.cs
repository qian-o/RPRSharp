namespace RPRSharp;

/// <summary>
/// rpr_framebuffer_info
/// </summary>
public enum FrameBufferInfo : int
{
    FORMAT = 0x1301,
    DESC = 0x1302,
    DATA = 0x1303,
    GL_TARGET = 0x1304,
    GL_MIPLEVEL = 0x1305,
    GL_TEXTURE = 0x1306,
    LPE = 0x1307,
    NAME = Rpr.ObjectName,
    UNIQUE_ID = Rpr.ObjectUniqueId,
    CUSTOM_PTR = Rpr.ObjectCustomPtr
}

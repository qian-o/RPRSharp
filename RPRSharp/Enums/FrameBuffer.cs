namespace RPRSharp.Enums;

/// <summary>
/// rpr_framebuffer_info
/// </summary>
public enum FrameBuffer : int
{
    FORMAT = 0x1301,
    DESC = 0x1302,
    DATA = 0x1303,
    GL_TARGET = 0x1304,
    GL_MIPLEVEL = 0x1305,
    GL_TEXTURE = 0x1306,
    LPE = 0x1307,
    NAME = Rpr.OBJECT_NAME,
    UNIQUE_ID = Rpr.OBJECT_UNIQUE_ID,
    CUSTOM_PTR = Rpr.OBJECT_CUSTOM_PTR
}

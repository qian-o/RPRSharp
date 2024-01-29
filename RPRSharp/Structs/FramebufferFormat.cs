using System.Runtime.InteropServices;

namespace RPRSharp;

/// <summary>
/// rpr_framebuffer_format
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct FrameBufferFormat
{
    public uint NumComponents;

    public ComponentType Type;
}

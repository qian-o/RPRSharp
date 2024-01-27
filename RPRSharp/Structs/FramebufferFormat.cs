using System.Runtime.InteropServices;
using RPRSharp.Enums;

namespace RPRSharp.Structs;

/// <summary>
/// rpr_framebuffer_format
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct FrameBufferFormat
{
    public uint NumComponents;

    public ComponentType Type;
}

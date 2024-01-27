using System.Runtime.InteropServices;

namespace RPRSharp.Structs;

/// <summary>
/// rpr_framebuffer
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct FrameBuffer
{
    public nint Handle;
}

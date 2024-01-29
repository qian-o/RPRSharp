using System.Runtime.InteropServices;

namespace RPRSharp;

/// <summary>
/// rpr_framebuffer
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct FrameBuffer
{
    public nint Handle;
}

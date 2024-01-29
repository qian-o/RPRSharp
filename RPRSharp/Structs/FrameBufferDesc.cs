using System.Runtime.InteropServices;

namespace RPRSharp;

/// <summary>
/// rpr_framebuffer_desc
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct FrameBufferDesc
{
    public uint FbWidth;

    public uint FbHeight;
}
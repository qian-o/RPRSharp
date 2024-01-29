using System.Runtime.InteropServices;

namespace RPRSharp;

/// <summary>
/// rpr_image_desc
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct ImageDesc
{
    public uint Width;

    public uint Height;

    public uint Depth;

    public uint RowPitch;

    public uint SlicePitch;
}

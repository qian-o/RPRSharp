using System.Runtime.InteropServices;

namespace RPRSharp.Structs;

/// <summary>
/// rpr_ies_image_desc
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct IesImageDesc
{
    public int W;

    public int H;

    public nint Data;

    public nint Filename;
}

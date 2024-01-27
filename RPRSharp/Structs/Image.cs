using System.Runtime.InteropServices;

namespace RPRSharp.Structs;

/// <summary>
/// rpr_image
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Image
{
    public nint Handle;
}

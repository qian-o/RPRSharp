using System.Runtime.InteropServices;

namespace RPRSharp;

/// <summary>
/// rpr_image
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Image
{
    public nint Handle;
}

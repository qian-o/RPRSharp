using System.Runtime.InteropServices;

namespace RPRSharp.Structs;

/// <summary>
/// rpr_shape
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Shape
{
    public nint Handle;
}

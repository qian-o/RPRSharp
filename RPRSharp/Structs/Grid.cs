using System.Runtime.InteropServices;

namespace RPRSharp.Structs;

/// <summary>
/// rpr_grid
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Grid
{
    public nint Handle;
}

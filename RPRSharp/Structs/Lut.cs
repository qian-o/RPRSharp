using System.Runtime.InteropServices;

namespace RPRSharp.Structs;

/// <summary>
/// rpr_lut
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Lut
{
    public nint Handle;
}

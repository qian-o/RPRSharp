using System.Runtime.InteropServices;

namespace RPRSharp.Structs;

/// <summary>
/// rpr_curve
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Curve
{
    public nint Handle;
}

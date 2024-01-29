using System.Runtime.InteropServices;

namespace RPRSharp;

/// <summary>
/// rpr_curve
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Curve
{
    public nint Handle;
}

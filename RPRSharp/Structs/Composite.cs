using System.Runtime.InteropServices;

namespace RPRSharp;

/// <summary>
/// rpr_composite
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Composite
{
    public nint Handle;
}

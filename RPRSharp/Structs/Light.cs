using System.Runtime.InteropServices;

namespace RPRSharp;

/// <summary>
/// rpr_light
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Light
{
    public nint Handle;
}

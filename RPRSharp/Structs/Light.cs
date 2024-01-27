using System.Runtime.InteropServices;

namespace RPRSharp.Structs;

/// <summary>
/// rpr_light
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Light
{
    public nint Handle;
}

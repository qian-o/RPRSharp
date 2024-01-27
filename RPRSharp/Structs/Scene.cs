using System.Runtime.InteropServices;

namespace RPRSharp.Structs;

/// <summary>
/// rpr_scene
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Scene
{
    public nint Handle;
}

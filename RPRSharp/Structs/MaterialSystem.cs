using System.Runtime.InteropServices;

namespace RPRSharp;

/// <summary>
/// rpr_material_system
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct MaterialSystem
{
    public nint Handle;
}

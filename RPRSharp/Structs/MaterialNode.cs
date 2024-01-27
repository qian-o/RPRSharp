using System.Runtime.InteropServices;

namespace RPRSharp.Structs;

/// <summary>
/// rpr_material_node
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct MaterialNode
{
    public nint Handle;
}

using System.Runtime.InteropServices;

namespace RPRSharp;

/// <summary>
/// rpr_hetero_volume
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct HeteroVolume
{
    public nint Handle;
}

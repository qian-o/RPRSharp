using System.Runtime.InteropServices;

namespace RPRSharp;

/// <summary>
/// rpr_camera
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Camera
{
    public nint Handle;
}

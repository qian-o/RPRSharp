using System.Runtime.InteropServices;

namespace RPRSharp;

/// <summary>
/// rpr_image_format
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct ImageFormat
{
    public uint NumComponents;

    public ComponentType Type;
}

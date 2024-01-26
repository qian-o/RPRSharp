using System.Runtime.InteropServices;
using RPRSharp.Enums;

namespace RPRSharp.Structs;

/// <summary>
/// rpr_image_format
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct ImageFormat
{
    public uint NumComponents;

    public ComponentType Type;
}

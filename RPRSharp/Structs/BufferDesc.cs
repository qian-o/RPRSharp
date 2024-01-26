using System.Runtime.InteropServices;
using RPRSharp.Enums;

namespace RPRSharp.Structs;

/// <summary>
/// rpr_buffer_desc
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct BufferDesc
{
    public uint NbElement;

    public BufferElementType ElementType;

    public uint ElementChannelSize;
}

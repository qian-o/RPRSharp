using System.Runtime.InteropServices;

namespace RPRSharp;

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

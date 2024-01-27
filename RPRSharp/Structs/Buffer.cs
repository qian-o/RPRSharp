using System.Runtime.InteropServices;

namespace RPRSharp.Structs;

/// <summary>
/// rpr_buffer
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Buffer
{
    public nint Handle;
}

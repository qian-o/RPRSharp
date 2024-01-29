using System.Runtime.InteropServices;

namespace RPRSharp;

/// <summary>
/// rpr_buffer
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Buffer
{
    public nint Handle;
}

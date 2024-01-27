using System.Runtime.InteropServices;

namespace RPRSharp.Structs;

/// <summary>
/// rpr_context
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Context
{
    public nint Handle;
}

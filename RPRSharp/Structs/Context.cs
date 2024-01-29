using System.Runtime.InteropServices;

namespace RPRSharp;

/// <summary>
/// rpr_context
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Context
{
    public nint Handle;
}

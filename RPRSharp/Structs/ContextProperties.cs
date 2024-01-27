using System.Runtime.InteropServices;

namespace RPRSharp.Structs;

/// <summary>
/// rpr_context_properties
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct ContextProperties
{
    public nint Handle;
}

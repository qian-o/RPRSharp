using System.Runtime.InteropServices;

namespace RPRSharp;

/// <summary>
/// rpr_context_properties
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct ContextProperties
{
    public nint Handle;

    public ContextProperties(int prop)
    {
        Handle = prop;
    }

    public ContextProperties(string prop)
    {
        Handle = Marshal.StringToHGlobalAnsi(prop);
    }
}
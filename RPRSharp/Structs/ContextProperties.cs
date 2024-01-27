using System.Runtime.InteropServices;
using Silk.NET.Core.Native;

namespace RPRSharp.Structs;

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
        Handle = SilkMarshal.StringToPtr(prop);
    }
}
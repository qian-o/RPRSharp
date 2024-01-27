using System.Runtime.InteropServices;

namespace RPRSharp.Structs;

/// <summary>
/// rpr_post_effect
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct PostEffect
{
    public nint Handle;
}

using System.Runtime.InteropServices;

namespace RPRSharp;

/// <summary>
/// rpr_post_effect
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct PostEffect
{
    public nint Handle;
}

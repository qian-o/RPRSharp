﻿using System.Runtime.InteropServices;

namespace RPRSharp;

/// <summary>
/// rpr_lut
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Lut
{
    public nint Handle;
}

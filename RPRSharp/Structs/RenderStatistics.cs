using System.Runtime.InteropServices;

namespace RPRSharp.Structs;

/// <summary>
/// rpr_render_statistics
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct RenderStatistics
{
    public long GpumemUsage;

    public long GpumemTotal;

    public long GpumemMaxAllocation;

    public long SysmemUsage;
}

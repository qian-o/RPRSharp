using System.Runtime.InteropServices;
using RPRSharp.Enums;
using RPRSharp.Structs;

namespace RPRSharp;

public partial class Rpr
{
    [LibraryImport("rpr")]
    private static unsafe partial Status rprCreateContext(uint api_version, int* pluginIDs, long pluginCount, CreationFlags creation_flags, byte** props, byte* cache_path, RprContext* context);
}

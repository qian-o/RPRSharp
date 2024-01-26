using System.Reflection;
using System.Runtime.InteropServices;
using RPRSharp.Enums;
using RPRSharp.Structs;

namespace RPRSharp;

public static partial class Rpr
{
    public const int VERSION_MAJOR = 3;
    public const int VERSION_MINOR = 1;
    public const int VERSION_REVISION = 5;
    public const uint VERSION_BUILD = 0x92dd2edd;
    public const int VERSION_MAJOR_MINOR_REVISION = 0x00300105;
    public const int API_VERSION = VERSION_MAJOR_MINOR_REVISION;
    public const uint API_VERSION_MINOR = VERSION_BUILD;
    public const int OBJECT_NAME = 0x777777;
    public const int OBJECT_UNIQUE_ID = 0x777778;
    public const int OBJECT_CUSTOM_PTR = 0x777779;
    public const int INSTANCE_PARENT_SHAPE = 0x1601;
    public const uint FALSE = 0u;
    public const uint TRUE = 1u;

    static Rpr()
    {
        NativeLibrary.SetDllImportResolver(Assembly.GetExecutingAssembly(), DllImportResolver);

        static nint DllImportResolver(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
        {
            if (libraryName == "rpr")
            {
                return NativeLibrary.Load(Common.RadeonProRender64);
            }

            return 0;
        }
    }

    public static unsafe Status CreateContext(uint api_version, int* pluginIDs, long pluginCount, CreationFlags creation_flags, byte** props, byte* cache_path, RprContext* context)
    {
        return rprCreateContext(api_version, pluginIDs, pluginCount, creation_flags, props, cache_path, context);
    }
}

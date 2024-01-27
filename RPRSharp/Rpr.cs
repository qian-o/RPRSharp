using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using RPRSharp.Enums;
using RPRSharp.Structs;
using Silk.NET.Core.Native;

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

    public static unsafe Status RegisterPlugin(string path)
    {
        byte* ptr1 = (byte*)SilkMarshal.StringToPtr(path);
        Status status = rprRegisterPlugin(ptr1);
        SilkMarshal.Free((nint)ptr1);

        return status;
    }

    public static unsafe Status CreateContext(uint api_version, int[] pluginIDs, long pluginCount, CreationFlags creation_flags, string[] props, string cache_path, out Context context)
    {
        context = new Context();

        int* ptr1 = (int*)Unsafe.AsPointer(ref pluginIDs);
        ContextProperties* ptr2 = (ContextProperties*)SilkMarshal.StringArrayToPtr(props);
        byte* ptr3 = (byte*)SilkMarshal.StringToPtr(cache_path);
        Context* ptr4 = (Context*)Unsafe.AsPointer(ref context);
        Status status = rprCreateContext(api_version, ptr1, pluginCount, creation_flags, ptr2, ptr3, ptr4);
        SilkMarshal.Free((nint)ptr3);
        SilkMarshal.Free((nint)ptr2);

        return status;
    }
}

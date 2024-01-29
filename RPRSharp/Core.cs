using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace RPRSharp;

public static class Core
{
    public const string AMD_Radeon_ProRender_SDK = "AMD Radeon ProRender SDK";

    private static readonly string _libraryDirectory;

    static Core()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            _libraryDirectory = Path.Combine(AMD_Radeon_ProRender_SDK, "binCentOS7");
            _libraryDirectory = Path.Combine(AMD_Radeon_ProRender_SDK, "binUbuntu20");
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            _libraryDirectory = Path.Combine(AMD_Radeon_ProRender_SDK, "binMacOS");
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            _libraryDirectory = Path.Combine(AMD_Radeon_ProRender_SDK, "binWin64");
        }
        else
        {
            _libraryDirectory = string.Empty;
        }
    }

    public static bool IsInitialized { get; private set; }

    public static string Northstar64 => GetLibraryPath("Northstar64");

    public static string ProRenderGLTF => GetLibraryPath("ProRenderGLTF");

    public static string RadeonProRender64 => GetLibraryPath("RadeonProRender64");

    public static string RprLoadStore64 => GetLibraryPath("RprLoadStore64");

    public static string Tahoe64 => GetLibraryPath("Tahoe64");

    public static string RprsRender64 => Path.Combine(_libraryDirectory, "RprsRender64");

    public static string RprTextureCompiler64 => Path.Combine(_libraryDirectory, "RprTextureCompiler64");

    public static string HipBin => Path.Combine(AMD_Radeon_ProRender_SDK, "hipbin");

    public static ContextProperties[] HipProperties => [new((int)ContextInfo.PRECOMPILED_BINARY_PATH), new(HipBin)];

    public static void Init()
    {
        if (!IsInitialized)
        {
            NativeLibrary.SetDllImportResolver(Assembly.GetExecutingAssembly(), (libraryName, _, _) => NativeLibrary.Load(GetLibraryPath(libraryName)));

            IsInitialized = true;
        }
    }

    public static string GetLibraryPath(string libraryName)
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            return Path.Combine(_libraryDirectory, $"lib{libraryName}.so");
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            return Path.Combine(_libraryDirectory, $"lib{libraryName}.dylib");
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            return Path.Combine(_libraryDirectory, $"{libraryName}.dll");
        }
        else
        {
            return string.Empty;
        }
    }

    public static void CheckStatus(this Status status, bool @throw = true)
    {
        if (status != Status.SUCCESS)
        {
            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine($"RPRSharp: {status}");

            if (status == Status.ERROR_SHADER_COMPILATION)
            {
                stringBuilder.AppendLine("==== KERNEL ERROR ====");
                stringBuilder.AppendLine("Since Northstar 3.01.00, precompiled kernels must be downloaded from a separate link and inluded in projects.");
                stringBuilder.AppendLine("Check the readme of this SDK for more information.");
            }

            if (@throw)
            {
                throw new Exception(stringBuilder.ToString());
            }
            else
            {
                Console.WriteLine(stringBuilder.ToString());
            }
        }
    }
}

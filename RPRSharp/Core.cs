using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using RPRSharp.Enums;
using RPRSharp.Structs;

namespace RPRSharp;

public static class Core
{
    public static readonly string LibraryDirectory;

    public static bool IsInitialized { get; private set; }

    public static string Northstar64 => GetLibraryPath("Northstar64");

    public static string ProRenderGLTF => GetLibraryPath("ProRenderGLTF");

    public static string RadeonProRender64 => GetLibraryPath("RadeonProRender64");

    public static string RprLoadStore64 => GetLibraryPath("RprLoadStore64");

    public static string Tahoe64 => GetLibraryPath("Tahoe64");

    public static string HipBin => GetLibraryPath("RprLoadStore64");

    public static string RprsRender64 => Path.Combine(LibraryDirectory, "RprsRender64");

    public static string RprTextureCompiler64 => Path.Combine(LibraryDirectory, "RprTextureCompiler64");

    public static ContextProperties[] HipProperties => [new((int)ContextInfo.PRECOMPILED_BINARY_PATH), new(HipBin)];

    static Core()
    {
        if (OperatingSystem.IsLinux())
        {
            LibraryDirectory = Path.Combine("AMD Radeon ProRender", "binCentOS7");
            LibraryDirectory = Path.Combine("AMD Radeon ProRender", "binUbuntu20");
        }
        else if (OperatingSystem.IsMacOS())
        {
            LibraryDirectory = Path.Combine("AMD Radeon ProRender", "binMacOS");
        }
        else if (OperatingSystem.IsWindows())
        {
            LibraryDirectory = Path.Combine("AMD Radeon ProRender", "binWin64");
        }
        else
        {
            LibraryDirectory = string.Empty;
        }
    }

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
        if (OperatingSystem.IsLinux())
        {
            return Path.Combine(LibraryDirectory, $"lib{libraryName}.so");
        }
        else if (OperatingSystem.IsMacOS())
        {
            return Path.Combine(LibraryDirectory, $"lib{libraryName}.dylib");
        }
        else if (OperatingSystem.IsWindows())
        {
            return Path.Combine(LibraryDirectory, $"{libraryName}.dll");
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

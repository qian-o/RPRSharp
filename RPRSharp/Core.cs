using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace RPRSharp;

public static class Core
{
    public const string AMD_Radeon_ProRender_SDK = "AMD Radeon ProRender SDK";

    private static readonly string _libraryDirectory;
    private static readonly Dictionary<string, string> _libraryNameAndPath;
    private static readonly string _hipBin;
    private static readonly ContextProperties[] _hipProperties;

    static Core()
    {
        _libraryDirectory = Path.Combine(AppContext.BaseDirectory, AMD_Radeon_ProRender_SDK);
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            if (RuntimeInformation.OSDescription.Contains("CentOS"))
            {
                _libraryDirectory = Path.Combine(_libraryDirectory, "binCentOS7");
            }
            else if (RuntimeInformation.OSDescription.Contains("Ubuntu"))
            {
                _libraryDirectory = Path.Combine(_libraryDirectory, "binUbuntu20");
            }
            else
            {
                _libraryDirectory = string.Empty;
            }
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            _libraryDirectory = Path.Combine(_libraryDirectory, "binMacOS");
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            _libraryDirectory = Path.Combine(_libraryDirectory, "binWin64");
        }
        else
        {
            _libraryDirectory = string.Empty;
        }

        _libraryNameAndPath = new()
        {
            { nameof(Northstar64), GetLibraryPath("Northstar64") },
            { nameof(ProRenderGLTF), GetLibraryPath("ProRenderGLTF") },
            { nameof(RadeonProRender64), GetLibraryPath("RadeonProRender64") },
            { nameof(RprLoadStore64), GetLibraryPath("RprLoadStore64") },
            { nameof(Tahoe64), GetLibraryPath("Tahoe64") },
            { nameof(RprsRender64), Path.Combine(_libraryDirectory, "RprsRender64") },
            { nameof(RprTextureCompiler64), Path.Combine(_libraryDirectory, "RprTextureCompiler64") }
        };

        _hipBin = Path.Combine(AppContext.BaseDirectory, AMD_Radeon_ProRender_SDK, "hipbin");
        _hipProperties = [new((int)ContextInfo.PRECOMPILED_BINARY_PATH), new(_hipBin), new()];
    }

    public static bool IsInitialized { get; private set; }

    public static string Northstar64 => _libraryNameAndPath[nameof(Northstar64)];

    public static string ProRenderGLTF => _libraryNameAndPath[nameof(ProRenderGLTF)];

    public static string RadeonProRender64 => _libraryNameAndPath[nameof(RadeonProRender64)];

    public static string RprLoadStore64 => _libraryNameAndPath[nameof(RprLoadStore64)];

    public static string Tahoe64 => _libraryNameAndPath[nameof(Tahoe64)];

    public static string RprsRender64 => _libraryNameAndPath[nameof(RprsRender64)];

    public static string RprTextureCompiler64 => _libraryNameAndPath[nameof(RprTextureCompiler64)];

    public static string HipBin => _hipBin;

    public static ContextProperties[] HipProperties => _hipProperties;

    public static void Init()
    {
        if (!IsInitialized)
        {
            NativeLibrary.SetDllImportResolver(Assembly.GetExecutingAssembly(), (libraryName, _, _) => NativeLibrary.Load(_libraryNameAndPath[libraryName]));

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

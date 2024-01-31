using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace RPRSharp;

public delegate void RegisterLibraryHandler(Platform platform, out string rprPath);

public static class Core
{
    public const string Rpr = "RadeonProRender64";

    private static readonly Dictionary<string, string> _libraryNameToPath = [];

    public static bool IsInitialized { get; private set; }

    public static void Init(RegisterLibraryHandler registerLibraryHandler)
    {
        if (!IsInitialized)
        {
            Platform platform = GetPlatform();

            if (platform == Platform.Unknown)
            {
                throw new Exception("RPRSharp: Unsupported platform.");
            }

            registerLibraryHandler.Invoke(GetPlatform(), out string rprPath);

            _libraryNameToPath.Add(Rpr, rprPath);

            NativeLibrary.SetDllImportResolver(Assembly.GetExecutingAssembly(), (libraryName, _, _) =>
            {
                return NativeLibrary.Load(_libraryNameToPath[libraryName]);
            });

            IsInitialized = true;
        }
    }

    public static Platform GetPlatform()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            if (RuntimeInformation.OSDescription.Contains("centos", StringComparison.CurrentCultureIgnoreCase))
            {
                return Platform.CentOS;
            }
            else if (RuntimeInformation.OSDescription.Contains("ubuntu", StringComparison.CurrentCultureIgnoreCase))
            {
                return Platform.Ubuntu;
            }
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            return Platform.MacOS;
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            return Platform.Windows;
        }

        return Platform.Unknown;
    }

    public static void CheckStatus(this Status status, bool @throw = true)
    {
        if (status != Status.Success)
        {
            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine($"RPRSharp: {status}");

            if (status == Status.ErrorShaderCompilation)
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

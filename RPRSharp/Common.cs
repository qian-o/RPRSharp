using RPRSharp.Enums;
using RPRSharp.Structs;

namespace RPRSharp;

public static class Common
{
    public static readonly string LibraryDirectory;
    public static readonly string Northstar64;
    public static readonly string ProRenderGLTF;
    public static readonly string RadeonProRender64;
    public static readonly string RprLoadStore64;
    public static readonly string Tahoe64;
    public static readonly string RprsRender64;
    public static readonly string RprTextureCompiler64;
    public static readonly string HipBin;

    public static readonly ContextProperties[] HipProperties;

    static Common()
    {
        if (OperatingSystem.IsLinux())
        {
            LibraryDirectory = Path.Combine("Dependencies", "binCentOS7");
            LibraryDirectory = Path.Combine("Dependencies", "binUbuntu20");

            Northstar64 = Path.Combine(LibraryDirectory, "libNorthstar64.so");
            ProRenderGLTF = Path.Combine(LibraryDirectory, "libProRenderGLTF.so");
            RadeonProRender64 = Path.Combine(LibraryDirectory, "libRadeonProRender64.so");
            RprLoadStore64 = Path.Combine(LibraryDirectory, "libRprLoadStore64.so");
            Tahoe64 = Path.Combine(LibraryDirectory, "libTahoe64.so");
            RprsRender64 = Path.Combine(LibraryDirectory, "RprsRender64");
            RprTextureCompiler64 = Path.Combine(LibraryDirectory, "RprTextureCompiler64");
        }
        else if (OperatingSystem.IsMacOS())
        {
            LibraryDirectory = Path.Combine("Dependencies", "binMacOS");

            Northstar64 = Path.Combine(LibraryDirectory, "libNorthstar64.dylib");
            ProRenderGLTF = Path.Combine(LibraryDirectory, "libProRenderGLTF.dylib");
            RadeonProRender64 = Path.Combine(LibraryDirectory, "libRadeonProRender64.dylib");
            RprLoadStore64 = Path.Combine(LibraryDirectory, "libRprLoadStore64.dylib");
            Tahoe64 = Path.Combine(LibraryDirectory, "libTahoe64.dylib");
            RprsRender64 = Path.Combine(LibraryDirectory, "RprsRender64");
            RprTextureCompiler64 = Path.Combine(LibraryDirectory, "RprTextureCompiler64");
        }
        else
        {
            LibraryDirectory = Path.Combine("Dependencies", "binWin64");

            Northstar64 = Path.Combine(LibraryDirectory, "Northstar64.dll");
            ProRenderGLTF = Path.Combine(LibraryDirectory, "ProRenderGLTF.dll");
            RadeonProRender64 = Path.Combine(LibraryDirectory, "RadeonProRender64.dll");
            RprLoadStore64 = Path.Combine(LibraryDirectory, "RprLoadStore64.dll");
            Tahoe64 = Path.Combine(LibraryDirectory, "Tahoe64.dll");
            RprsRender64 = Path.Combine(LibraryDirectory, "RprsRender64.exe");
            RprTextureCompiler64 = Path.Combine(LibraryDirectory, "RprTextureCompiler64.exe");
        }

        HipBin = Path.Combine("Dependencies", "hipbin");
        HipProperties = [new((int)ContextInfo.PRECOMPILED_BINARY_PATH), new(HipBin)];
    }

    public static void CheckStatus(this Status status)
    {
        if (status != Status.SUCCESS)
        {
            Console.WriteLine($"RPRSharp: {status}");

            if (status == Status.ERROR_SHADER_COMPILATION)
            {
                Console.WriteLine("==== KERNEL ERROR ====");
                Console.WriteLine("Since Northstar 3.01.00, precompiled kernels must be downloaded from a separate link and inluded in projects.");
                Console.WriteLine("Check the readme of this SDK for more information.");
            }
        }
    }
}

﻿namespace RPRSharp;

public class Common
{
    public static readonly string LibraryDirectory;
    public static readonly string Northstar64;
    public static readonly string ProRenderGLTF;
    public static readonly string RadeonProRender64;
    public static readonly string RprLoadStore64;
    public static readonly string Tahoe64;
    public static readonly string RprsRender64;
    public static readonly string RprTextureCompiler64;

    static Common()
    {
#if Win64
        LibraryDirectory = Path.Combine("Dependencies", "binWin64");
#elif MacOS
        LibraryDirectory = Path.Combine("Dependencies", "binMacOS");
#elif CentOS7
        LibraryDirectory = Path.Combine("Dependencies", "binCentOS7");
#elif Ubuntu20
        LibraryDirectory = Path.Combine("Dependencies", "binUbuntu20");
#endif

        if (OperatingSystem.IsLinux())
        {
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
            Northstar64 = Path.Combine(LibraryDirectory, "Northstar64.dll");
            ProRenderGLTF = Path.Combine(LibraryDirectory, "ProRenderGLTF.dll");
            RadeonProRender64 = Path.Combine(LibraryDirectory, "RadeonProRender64.dll");
            RprLoadStore64 = Path.Combine(LibraryDirectory, "RprLoadStore64.dll");
            Tahoe64 = Path.Combine(LibraryDirectory, "Tahoe64.dll");
            RprsRender64 = Path.Combine(LibraryDirectory, "RprsRender64.exe");
            RprTextureCompiler64 = Path.Combine(LibraryDirectory, "RprTextureCompiler64.exe");
        }
    }
}
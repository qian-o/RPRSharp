using System.ComponentModel;

namespace RPRSharp;

public struct ApiVersion
{
    public uint Major;
    public uint Minor;
    public uint Revision;
    public uint Build;

    public ApiVersion(uint major, uint minor, uint revision)
    {
        Major = major;
        Minor = minor;
        Revision = revision;
        Build = 0;
    }

    public ApiVersion(uint major, uint minor, uint revision, uint build)
    {
        Major = major;
        Minor = minor;
        Revision = revision;
        Build = build;
    }

    public ApiVersion(string version)
    {
        string[] versions = version.Split('.');
        Major = uint.Parse(versions[0]);
        Minor = uint.Parse(versions[1]);
        Revision = versions.Length == 2 ? 0 : uint.Parse(versions[2]);
        Build = versions.Length == 3 ? 0 : uint.Parse(versions[3]);
    }
}

public unsafe struct Context
{
    [Description("_")]
    public void* Handle;
}

public unsafe struct Camera
{
    [Description("_")]
    public void* Handle;
}

public unsafe struct Shape
{
    [Description("_")]
    public void* Handle;
}

public unsafe struct Light
{
    [Description("_")]
    public void* Handle;
}

public unsafe struct Scene
{
    [Description("_")]
    public void* Handle;
}

public unsafe struct Image
{
    [Description("_")]
    public void* Handle;
}

public unsafe struct Buffer
{
    [Description("_")]
    public void* Handle;
}

public unsafe struct HeteroVolume
{
    [Description("_")]
    public void* Handle;
}

public unsafe struct Grid
{
    [Description("_")]
    public void* Handle;
}

public unsafe struct Curve
{
    [Description("_")]
    public void* Handle;
}

public unsafe struct Framebuffer
{
    [Description("_")]
    public void* Handle;
}

public unsafe struct MaterialSystem
{
    [Description("_")]
    public void* Handle;
}

public unsafe struct MaterialNode
{
    [Description("_")]
    public void* Handle;
}

public unsafe struct PostEffect
{
    [Description("_")]
    public void* Handle;
}

public unsafe struct ContextProperties
{
    [Description("_")]
    public void* Handle;
}

public unsafe struct Composite
{
    [Description("_")]
    public void* Handle;
}

public unsafe struct Lut
{
    [Description("_")]
    public void* Handle;
}

public unsafe struct ImageDesc
{
    [Description("image_width")]
    public uint ImageWidth;

    [Description("image_height")]
    public uint ImageHeight;

    [Description("image_depth")]
    public uint ImageDepth;

    [Description("image_row_pitch")]
    public uint ImageRowPitch;

    [Description("image_slice_pitch")]
    public uint ImageSlicePitch;
}

public unsafe struct BufferDesc
{
    [Description("nb_element")]
    public uint NbElement;

    [Description("element_type")]
    public BufferElementType ElementType;

    [Description("element_channel_size")]
    public uint ElementChannelSize;
}

public unsafe struct FramebufferDesc
{
    [Description("fb_width")]
    public uint FbWidth;

    [Description("fb_height")]
    public uint FbHeight;
}

public unsafe struct RenderStatistics
{
    [Description("gpumem_usage")]
    public long GpumemUsage;

    [Description("gpumem_total")]
    public long GpumemTotal;

    [Description("gpumem_max_allocation")]
    public long GpumemMaxAllocation;

    [Description("sysmem_usage")]
    public long SysmemUsage;
}

public unsafe struct ImageFormat
{
    [Description("num_components")]
    public uint NumComponents;

    [Description("type")]
    public ComponentType Type;
}

public unsafe struct FramebufferFormat
{
    [Description("num_components")]
    public uint NumComponents;

    [Description("type")]
    public ComponentType Type;
}

public unsafe struct IesImageDesc
{
    [Description("w")]
    public int W;

    [Description("h")]
    public int H;

    [Description("data")]
    public char* Data;

    [Description("filename")]
    public char* Filename;
}

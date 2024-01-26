namespace RPRSharp.Enums;

/// <summary>
/// rpr_creation_flags
/// </summary>
public enum CreationFlags : int
{
    ENABLE_GPU0 = 1 << 0,
    ENABLE_GPU1 = 1 << 1,
    ENABLE_GPU2 = 1 << 2,
    ENABLE_GPU3 = 1 << 3,
    ENABLE_CPU = 1 << 4,
    ENABLE_GL_INTEROP = 1 << 5,
    ENABLE_GPU4 = 1 << 6,
    ENABLE_GPU5 = 1 << 7,
    ENABLE_GPU6 = 1 << 8,
    ENABLE_GPU7 = 1 << 9,
    ENABLE_METAL = 1 << 10,
    ENABLE_GPU8 = 1 << 11,
    ENABLE_GPU9 = 1 << 12,
    ENABLE_GPU10 = 1 << 13,
    ENABLE_GPU11 = 1 << 14,
    ENABLE_GPU12 = 1 << 15,
    ENABLE_GPU13 = 1 << 16,
    ENABLE_GPU14 = 1 << 17,
    ENABLE_GPU15 = 1 << 18,
    ENABLE_HIP = 1 << 19,
    ENABLE_OPENCL = 1 << 20,
    ENABLE_DEBUG = 1 << 31
}

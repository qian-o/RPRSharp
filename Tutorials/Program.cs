using RPRSharp;

namespace Tutorials;

internal class Program
{
    static void Main(string[] _)
    {
        Core.Init(RegisterLibrary);

        new CameraDof().Run();
    }

    private static void RegisterLibrary(Platform platform, out string rprPath)
    {
        string dir = Path.Combine(AppContext.BaseDirectory, "AMD Radeon ProRender SDK");

        rprPath = platform switch
        {
            Platform.CentOS => Path.Combine(dir, "binCentOS7", "libRadeonProRender64.so"),
            Platform.Ubuntu => Path.Combine(dir, "binUbuntu20", "libRadeonProRender64.so"),
            Platform.MacOS => Path.Combine(dir, "binMacOS", "libRadeonProRender64.dylib"),
            Platform.Windows => Path.Combine(dir, "binWin64", "RadeonProRender64.dll"),
            _ => string.Empty,
        };
    }
}

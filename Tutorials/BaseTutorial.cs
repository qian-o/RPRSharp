using RPRSharp;

namespace Tutorials;

public abstract class BaseTutorial : IDisposable
{
    static BaseTutorial()
    {
        ContextProperties =
        [
            new ContextProperties((int)ContextInfo.PRECOMPILED_BINARY_PATH),
            new ContextProperties(Path.Combine("AMD Radeon ProRender SDK", "hipbin")),
            new ContextProperties(0)
        ];

        Northstar64 = Core.GetPlatform() switch
        {
            Platform.CentOS => Path.Combine("AMD Radeon ProRender SDK", "binCentOS7", "libNorthstar64.so"),
            Platform.Ubuntu => Path.Combine("AMD Radeon ProRender SDK", "binUbuntu20", "libNorthstar64.so"),
            Platform.MacOS => Path.Combine("AMD Radeon ProRender SDK", "binMacOS", "libNorthstar64.dylib"),
            Platform.Windows => Path.Combine("AMD Radeon ProRender SDK", "binWin64", "Northstar64.dll"),
            _ => string.Empty,
        };
    }

    public static CreationFlags ContextCreationFlags => CreationFlags.ENABLE_GPU1;

    public static ContextProperties[] ContextProperties { get; }

    public static string Northstar64 { get; }

    public abstract void Run();

    public virtual void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}

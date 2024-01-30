using RPRSharp;

namespace Tutorials;

public abstract class BaseTutorial : IDisposable
{
    public static CreationFlags ContextCreationFlags => CreationFlags.ENABLE_GPU0;

    public static ContextProperties[] ContextProperties => Core.HipProperties;

    public abstract void Run();

    public virtual void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}

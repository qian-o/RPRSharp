namespace Tutorials;

public abstract class BaseTutorial : IDisposable
{
    public abstract void Run();

    public virtual void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}

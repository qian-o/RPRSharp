using RPRSharp;

namespace Tutorials;

public unsafe class ContextCreation : ITutorial
{
    public void Run()
    {
        Console.WriteLine(Common.RprTextureCompiler64);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}

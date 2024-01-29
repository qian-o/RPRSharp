using RPRSharp;

namespace Tutorials;

internal class Program
{
    static void Main(string[] _)
    {
        Core.Init();

        new BasicScene().Run();
    }
}

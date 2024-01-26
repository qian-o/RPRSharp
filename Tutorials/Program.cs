namespace Tutorials;

internal class Program
{
    static void Main(string[] args)
    {
        ITutorial tutorial = new ContextCreation();

        tutorial.Run();
    }
}

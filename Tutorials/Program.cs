namespace Tutorials;

internal class Program
{
    static void Main(string[] args)
    {
        using ITutorial tutorial = new ContextCreation();

        tutorial.Run();

        Console.ReadKey();
    }
}

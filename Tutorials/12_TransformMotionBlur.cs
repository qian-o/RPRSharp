using RPRSharp;
using RPRSharp.Structs;

namespace Tutorials;

public class TransformMotionBlur : BaseTutorial
{
    public override void Run()
    {
        // Create the RPR context
        int pluginID = Rpr.RegisterPlugin(Common.Northstar64);

        if (pluginID == -1)
        {
            Console.WriteLine("Failed to register plugin");
            return;
        }

        int[] plugins = [pluginID];
        Rpr.CreateContext(Rpr.API_VERSION, plugins, plugins.Length, ContextCreationFlags, ContextProperties, "", out Context context).CheckStatus();
        Rpr.ContextSetActivePlugin(context, plugins[0]).CheckStatus();

        Console.WriteLine("Context successfully created.");

        // Create a scene. A scene is a container of nodes we want to render.
        // RPR can manage multiple scenes per context.
        Rpr.ContextCreateScene(context, out Scene scene).CheckStatus();
        Rpr.ContextSetScene(context, scene).CheckStatus();
    }
}

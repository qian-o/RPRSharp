using RPRSharp;
using Silk.NET.Core.Native;
using Tutorials.Helpers;

namespace Tutorials;

public unsafe class ContextCreation : BaseTutorial
{
    public override void Run()
    {
        Console.WriteLine("Radeon ProRender SDK simple context creation tutorial.");

        int pluginID = Rpr.RegisterPlugin(RprHelper.Northstar64);

        if (pluginID == -1)
        {
            Console.WriteLine("Failed to register plugin");
            return;
        }

        int[] plugins = [pluginID];

        // Create context using a single GPU
        // note that multiple GPUs can be enabled for example with creation_flags = RPR_CREATION_FLAGS_ENABLE_GPU0 | RPR_CREATION_FLAGS_ENABLE_GPU1
        Rpr.CreateContext(RprHelper.ApiVersion, plugins, plugins.Length, RprHelper.ContextCreationFlags, RprHelper.ContextProperties, "", out Context context).CheckStatus();

        // Set the active plugin.
        Rpr.ContextSetActivePlugin(context, plugins[0]).CheckStatus();

        Console.WriteLine("RPR Context creation succeeded.");

        char* deviceNameGpu0 = stackalloc char[1024];
        Rpr.ContextGetInfo(context, ContextInfo.GPU0_NAME, 1024, deviceNameGpu0, out _).CheckStatus();

        // Output the name of the GPU
        Console.WriteLine($"GPU0: {SilkMarshal.PtrToString((nint)deviceNameGpu0)}");

        // Release the context
        Rpr.ObjectDelete(context).CheckStatus();
    }
}

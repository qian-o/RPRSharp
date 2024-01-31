using System.Numerics;
using RPRSharp;
using Tutorials.Helpers;

namespace Tutorials;

public unsafe class ParametersEnumeration : BaseTutorial
{
    public override void Run()
    {
        Console.WriteLine("Radeon ProRender SDK parameters enumeration tutorial.");

        // Create the RPR context
        int pluginID = Rpr.RegisterPlugin(RprHelper.Northstar64);

        if (pluginID == -1)
        {
            Console.WriteLine("Failed to register plugin");
            return;
        }

        int[] plugins = [pluginID];
        Rpr.CreateContext(RprHelper.ApiVersion, plugins, plugins.Length, RprHelper.ContextCreationFlags, RprHelper.ContextProperties, "", out Context context).CheckStatus();
        Rpr.ContextSetActivePlugin(context, plugins[0]).CheckStatus();

        Console.WriteLine("Context successfully created.");

        // List parameters from rpr_context
        {
            Console.WriteLine("=== CONTEXT PARAMETERS ===");

            long parameterCount = 0;
            Rpr.ContextGetInfo(context, ContextInfo.ParameterCount, sizeof(long), &parameterCount, out _).CheckStatus();

            Console.WriteLine($"    Parameter Count: {parameterCount}");

            for (int i = 0; i < parameterCount; i++)
            {
                ContextInfo paramID;
                Rpr.ContextGetParameterInfo(context, i, ParameterInfo.Name, sizeof(ContextInfo), &paramID, out _).CheckStatus();

                ParameterType paramType;
                Rpr.ContextGetParameterInfo(context, i, ParameterInfo.Type, sizeof(ParameterType), &paramType, out _).CheckStatus();

                Rpr.ContextGetParameterInfo(context, i, ParameterInfo.Value, 0, null, out long paramValueSize).CheckStatus();

                byte[] value = new byte[paramValueSize];
                fixed (byte* valuePtr = value)
                {
                    Rpr.ContextGetParameterInfo(context, i, ParameterInfo.Value, paramValueSize, valuePtr, out _).CheckStatus();
                }

                Console.WriteLine($"        {paramID} ({paramType}) = ".ToLower() + RprHelper.GetValue(paramType, value));
            }
        }

        // create the material system
        Rpr.ContextCreateMaterialSystem(context, 0, out MaterialSystem materialSystem).CheckStatus();

        // Create a MICROFACET material
        Rpr.MaterialSystemCreateNode(materialSystem, MaterialNodeType.Microfacet, out MaterialNode materialNode).CheckStatus();

        // List parameters from rpr_material
        {
            Console.WriteLine("=== MATERIAL PARAMETERS ===");

            // Get the number of parameters for the material
            long parameterCount = 0;
            Rpr.MaterialNodeGetInfo(materialNode, MaterialNodeInfo.InputCount, sizeof(long), &parameterCount, out _).CheckStatus();

            Console.WriteLine($"    Parameter Count: {parameterCount}");

            // get the material type.
            MaterialNodeType materialType;
            Rpr.MaterialNodeGetInfo(materialNode, MaterialNodeInfo.Type, sizeof(MaterialNodeType), &materialType, out _).CheckStatus();

            // For each parameter
            for (int i = 0; i < parameterCount; i++)
            {
                MaterialNodeInput paramID;
                Rpr.MaterialNodeGetInputInfo(materialNode, i, MaterialNodeInputInfo.Name, sizeof(MaterialNodeInput), &paramID, out _).CheckStatus();

                MaterialNodeInputType nodeInputType;
                Rpr.MaterialNodeGetInputInfo(materialNode, i, MaterialNodeInputInfo.Type, sizeof(MaterialNodeInputType), &nodeInputType, out _).CheckStatus();

                Rpr.MaterialNodeGetInputInfo(materialNode, i, MaterialNodeInputInfo.Value, 0, null, out long paramValueSize).CheckStatus();

                byte[] value = new byte[paramValueSize];
                fixed (byte* valuePtr = value)
                {
                    Rpr.MaterialNodeGetInputInfo(materialNode, i, MaterialNodeInputInfo.Value, paramValueSize, valuePtr, out _).CheckStatus();

                    if (nodeInputType == MaterialNodeInputType.Node)
                    {
                        MaterialNode* node = (MaterialNode*)valuePtr;

                        if ((*node).Handle != null)
                        {
                            Console.WriteLine($"        {paramID} = ".ToLower() + $"material:{*node}");
                        }
                        else
                        {
                            Console.WriteLine($"        {paramID} = ".ToLower() + "null-material");
                        }
                    }
                    else if (nodeInputType == MaterialNodeInputType.Float4)
                    {
                        Console.WriteLine($"        {paramID} = ".ToLower() + new Vector4(BitConverter.ToSingle(value), BitConverter.ToSingle(value, 4), BitConverter.ToSingle(value, 8), BitConverter.ToSingle(value, 12)));
                    }
                    else
                    {
                        Console.WriteLine($"        {paramID} = ".ToLower() + "???");
                    }
                }
            }
        }

        Rpr.ObjectDelete(materialSystem).CheckStatus();
        Rpr.ObjectDelete(materialNode).CheckStatus();
        Rpr.ObjectDelete(context).CheckStatus();
    }
}

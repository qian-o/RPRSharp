﻿using System.Numerics;
using RPRSharp;
using RPRSharp.Enums;
using RPRSharp.Structs;
using Silk.NET.Core.Native;

namespace Tutorials;

public unsafe class ParametersEnumeration : ITutorial
{
    public void Run()
    {
        Console.WriteLine("Radeon ProRender SDK parameters enumeration tutorial.");

        // Create the RPR context
        int pluginID = Rpr.RegisterPlugin(Common.Northstar64);

        if (pluginID == -1)
        {
            Console.WriteLine("Failed to register plugin");
            return;
        }

        int[] plugins = [pluginID];
        Rpr.CreateContext(Rpr.API_VERSION, plugins, plugins.Length, CreationFlags.ENABLE_GPU0, Common.HipProperties, "", out Context context).CheckStatus();
        Rpr.ContextSetActivePlugin(context, plugins[0]).CheckStatus();

        Console.WriteLine("Context successfully created.");

        // List parameters from rpr_context
        {
            Console.WriteLine("=== CONTEXT PARAMETERS ===");

            long parameterCount = 0;
            Rpr.ContextGetInfo(context, ContextInfo.PARAMETER_COUNT, sizeof(long), &parameterCount, out _).CheckStatus();

            Console.WriteLine($"    Parameter Count: {parameterCount}");

            for (int i = 0; i < parameterCount; i++)
            {
                ContextInfo paramID;
                Rpr.ContextGetParameterInfo(context, i, ParameterInfo.NAME, sizeof(ContextInfo), &paramID, out _).CheckStatus();

                ParameterType paramType;
                Rpr.ContextGetParameterInfo(context, i, ParameterInfo.TYPE, sizeof(ParameterType), &paramType, out _).CheckStatus();

                Rpr.ContextGetParameterInfo(context, i, ParameterInfo.VALUE, 0, null, out long paramValueSize).CheckStatus();

                byte[] value = new byte[paramValueSize];
                fixed (byte* valuePtr = value)
                {
                    Rpr.ContextGetParameterInfo(context, i, ParameterInfo.VALUE, paramValueSize, valuePtr, out _).CheckStatus();
                }

                Console.WriteLine($"        {paramID} ({paramType}) = ".ToLower() + GetValue(paramType, value));
            }
        }

        // create the material system
        Rpr.ContextCreateMaterialSystem(context, 0, out MaterialSystem materialSystem).CheckStatus();

        // Create a MICROFACET material
        Rpr.MaterialSystemCreateNode(materialSystem, MaterialNodeType.MICROFACET, out MaterialNode materialNode).CheckStatus();

        // List parameters from rpr_material
        {
            Console.WriteLine("=== MATERIAL PARAMETERS ===");

            // Get the number of parameters for the material
            long parameterCount = 0;
            Rpr.MaterialNodeGetInfo(materialNode, MaterialNodeInfo.INPUT_COUNT, sizeof(long), &parameterCount, out _).CheckStatus();

            Console.WriteLine($"    Parameter Count: {parameterCount}");

            // get the material type.
            MaterialNodeType materialType;
            Rpr.MaterialNodeGetInfo(materialNode, MaterialNodeInfo.TYPE, sizeof(MaterialNodeType), &materialType, out _).CheckStatus();

            // For each parameter
            for (int i = 0; i < parameterCount; i++)
            {
                MaterialNodeInput paramID;
                Rpr.MaterialNodeGetInputInfo(materialNode, i, MaterialNodeInputInfo.NAME, sizeof(MaterialNodeInput), &paramID, out _).CheckStatus();

                MaterialNodeInputType nodeInputType;
                Rpr.MaterialNodeGetInputInfo(materialNode, i, MaterialNodeInputInfo.TYPE, sizeof(MaterialNodeInputType), &nodeInputType, out _).CheckStatus();

                Rpr.MaterialNodeGetInputInfo(materialNode, i, MaterialNodeInputInfo.VALUE, 0, null, out long paramValueSize).CheckStatus();

                byte[] value = new byte[paramValueSize];
                fixed (byte* valuePtr = value)
                {
                    Rpr.MaterialNodeGetInputInfo(materialNode, i, MaterialNodeInputInfo.VALUE, paramValueSize, valuePtr, out _).CheckStatus();

                    if (nodeInputType == MaterialNodeInputType.NODE)
                    {
                        MaterialNode* node = (MaterialNode*)valuePtr;

                        if ((*node).Handle != 0)
                        {
                            Console.WriteLine($"        {paramID} = ".ToLower() + $"material:{*node}");
                        }
                        else
                        {
                            Console.WriteLine($"        {paramID} = ".ToLower() + "null-material");
                        }
                    }
                    else if (nodeInputType == MaterialNodeInputType.FLOAT4)
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

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public static object? GetValue(ParameterType parameterType, byte[] bytes)
    {
        fixed (byte* bytesPtr = bytes)
        {
            return parameterType switch
            {
                ParameterType.FLOAT => BitConverter.ToSingle(bytes),
                ParameterType.FLOAT2 => new Vector2(BitConverter.ToSingle(bytes), BitConverter.ToSingle(bytes, 4)),
                ParameterType.FLOAT3 => new Vector3(BitConverter.ToSingle(bytes), BitConverter.ToSingle(bytes, 4), BitConverter.ToSingle(bytes, 8)),
                ParameterType.FLOAT4 => new Vector4(BitConverter.ToSingle(bytes), BitConverter.ToSingle(bytes, 4), BitConverter.ToSingle(bytes, 8), BitConverter.ToSingle(bytes, 12)),
                ParameterType.STRING => SilkMarshal.PtrToString((nint)bytesPtr),
                ParameterType.UINT => BitConverter.ToUInt32(bytes),
                ParameterType.ULONG => BitConverter.ToUInt64(bytes),
                ParameterType.LONGLONG => BitConverter.ToInt64(bytes),
                _ => bytes,
            };
        }
    }
}
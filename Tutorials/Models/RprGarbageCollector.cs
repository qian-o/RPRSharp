using RPRSharp;

namespace Tutorials.Models;

public unsafe class RprGarbageCollector
{
    private readonly List<nint> _rprNodesCollector = [];

    public void Add(MaterialNode materialNode)
    {
        _rprNodesCollector.Add((nint)materialNode.Handle);
    }

    public void Add(Image image)
    {
        _rprNodesCollector.Add((nint)image.Handle);
    }

    public void Add(Shape shape)
    {
        _rprNodesCollector.Add((nint)shape.Handle);
    }

    public void Add(Light light)
    {
        _rprNodesCollector.Add((nint)light.Handle);
    }

    public void Add(Framebuffer frameBuffer)
    {
        _rprNodesCollector.Add((nint)frameBuffer.Handle);
    }

    public void Add(Camera camera)
    {
        _rprNodesCollector.Add((nint)camera.Handle);
    }

    public void Clear()
    {
        foreach (nint handle in _rprNodesCollector)
        {
            Rpr.ObjectDelete(handle).CheckStatus();
        }

        _rprNodesCollector.Clear();
    }
}

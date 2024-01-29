using RPRSharp;
using RPRSharp.Structs;

namespace Tutorials.Models;

public class RprGarbageCollector
{
    private readonly List<nint> _rprNodesCollector = [];

    public void Add(MaterialNode materialNode)
    {
        _rprNodesCollector.Add(materialNode.Handle);
    }

    public void Add(Image image)
    {
        _rprNodesCollector.Add(image.Handle);
    }

    public void Add(Shape shape)
    {
        _rprNodesCollector.Add(shape.Handle);
    }

    public void Add(Light light)
    {
        _rprNodesCollector.Add(light.Handle);
    }

    public void Add(FrameBuffer frameBuffer)
    {
        _rprNodesCollector.Add(frameBuffer.Handle);
    }

    public void Add(Camera camera)
    {
        _rprNodesCollector.Add(camera.Handle);
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

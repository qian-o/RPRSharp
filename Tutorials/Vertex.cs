using System.Numerics;

namespace Tutorials;

public struct Vertex
{
    public Vector3 Pos;

    public Vector3 Norm;

    public Vector2 Tex;

    public static Vertex[] Cube()
    {
        return
        [
            new Vertex { Pos = new Vector3(-1.0f, 1.0f, -1.0f), Norm = new Vector3(0.0f, 1.0f, 0.0f), Tex = new Vector2(0.0f, 0.0f) },
            new Vertex { Pos = new Vector3(1.0f, 1.0f, -1.0f), Norm = new Vector3(0.0f, 1.0f, 0.0f), Tex = new Vector2(1.0f, 0.0f) },
            new Vertex { Pos = new Vector3(1.0f, 1.0f, 1.0f), Norm = new Vector3(0.0f, 1.0f, 0.0f), Tex = new Vector2(1.0f, 1.0f) },
            new Vertex { Pos = new Vector3(-1.0f, 1.0f, 1.0f), Norm = new Vector3(0.0f, 1.0f, 0.0f), Tex = new Vector2(0.0f, 1.0f) },

            new Vertex { Pos = new Vector3(-1.0f, -1.0f, -1.0f), Norm = new Vector3(0.0f, -1.0f, 0.0f), Tex = new Vector2(0.0f, 0.0f) },
            new Vertex { Pos = new Vector3(1.0f, -1.0f, -1.0f), Norm = new Vector3(0.0f, -1.0f, 0.0f), Tex = new Vector2(1.0f, 0.0f) },
            new Vertex { Pos = new Vector3(1.0f, -1.0f, 1.0f), Norm = new Vector3(0.0f, -1.0f, 0.0f), Tex = new Vector2(1.0f, 1.0f) },
            new Vertex { Pos = new Vector3(-1.0f, -1.0f, 1.0f), Norm = new Vector3(0.0f, -1.0f, 0.0f), Tex = new Vector2(0.0f, 1.0f) },

            new Vertex { Pos = new Vector3(-1.0f, -1.0f, 1.0f), Norm = new Vector3(-1.0f, 0.0f, 0.0f), Tex = new Vector2(0.0f, 0.0f) },
            new Vertex { Pos = new Vector3(-1.0f, -1.0f, -1.0f), Norm = new Vector3(-1.0f, 0.0f, 0.0f), Tex = new Vector2(1.0f, 0.0f) },
            new Vertex { Pos = new Vector3(-1.0f, 1.0f, -1.0f), Norm = new Vector3(-1.0f, 0.0f, 0.0f), Tex = new Vector2(1.0f, 1.0f) },
            new Vertex { Pos = new Vector3(-1.0f, 1.0f, 1.0f), Norm = new Vector3(-1.0f, 0.0f, 0.0f), Tex = new Vector2(0.0f, 1.0f) },

            new Vertex { Pos = new Vector3(1.0f, -1.0f, 1.0f), Norm = new Vector3(1.0f, 0.0f, 0.0f), Tex = new Vector2(0.0f, 0.0f) },
            new Vertex { Pos = new Vector3(1.0f, -1.0f, -1.0f), Norm = new Vector3(1.0f, 0.0f, 0.0f), Tex = new Vector2(1.0f, 0.0f) },
            new Vertex { Pos = new Vector3(1.0f, 1.0f, -1.0f), Norm = new Vector3(1.0f, 0.0f, 0.0f), Tex = new Vector2(1.0f, 1.0f) },
            new Vertex { Pos = new Vector3(1.0f, 1.0f, 1.0f), Norm = new Vector3(1.0f, 0.0f, 0.0f), Tex = new Vector2(0.0f, 1.0f) },

            new Vertex { Pos = new Vector3(-1.0f, -1.0f, -1.0f), Norm = new Vector3(0.0f, 0.0f, -1.0f), Tex = new Vector2(0.0f, 0.0f) },
            new Vertex { Pos = new Vector3(1.0f, -1.0f, -1.0f), Norm = new Vector3(0.0f, 0.0f, -1.0f), Tex = new Vector2(1.0f, 0.0f) },
            new Vertex { Pos = new Vector3(1.0f, 1.0f, -1.0f), Norm = new Vector3(0.0f, 0.0f, -1.0f), Tex = new Vector2(1.0f, 1.0f) },
            new Vertex { Pos = new Vector3(-1.0f, 1.0f, -1.0f), Norm = new Vector3(0.0f, 0.0f, -1.0f), Tex = new Vector2(0.0f, 1.0f) },

            new Vertex { Pos = new Vector3(-1.0f, -1.0f, 1.0f), Norm = new Vector3(0.0f, 0.0f, 1.0f), Tex = new Vector2(0.0f, 0.0f) },
            new Vertex { Pos = new Vector3(1.0f, -1.0f, 1.0f), Norm = new Vector3(0.0f, 0.0f, 1.0f), Tex = new Vector2(1.0f, 0.0f) },
            new Vertex { Pos = new Vector3(1.0f, 1.0f, 1.0f), Norm = new Vector3(0.0f, 0.0f, 1.0f), Tex = new Vector2(1.0f, 1.0f) },
            new Vertex { Pos = new Vector3(-1.0f, 1.0f, 1.0f), Norm = new Vector3(0.0f, 0.0f, 1.0f), Tex = new Vector2(0.0f, 1.0f) }
        ];
    }

    public static Vertex[] Plane()
    {
        return
        [
            new Vertex { Pos = new Vector3(-15.0f, 0.0f, -15.0f), Norm = new Vector3(0.0f, 1.0f, 0.0f), Tex = new Vector2(0.0f, 1.0f) },
            new Vertex { Pos = new Vector3(-15.0f, 0.0f, 15.0f), Norm = new Vector3(0.0f, 1.0f, 0.0f), Tex = new Vector2(0.0f, 0.0f) },
            new Vertex { Pos = new Vector3(15.0f, 0.0f, 15.0f), Norm = new Vector3(0.0f, 1.0f, 0.0f), Tex = new Vector2(1.0f, 0.0f) },
            new Vertex { Pos = new Vector3(15.0f, 0.0f, -15.0f), Norm = new Vector3(0.0f, 1.0f, 0.0f), Tex = new Vector2(1.0f, 1.0f) }
        ];
    }

    public static int[] Indices()
    {
        List<int> indices =
        [
            .. new int[] { 3, 1, 0 },
            .. new int[] { 2, 1, 3 },

            .. new int[] { 6, 4, 5 },
            .. new int[] { 7, 4, 6 },

            .. new int[] { 11, 9, 8 },
            .. new int[] { 10, 9, 11 },

            .. new int[] { 14, 12, 13 },
            .. new int[] { 15, 12, 14 },

            .. new int[] { 19, 17, 16 },
            .. new int[] { 18, 17, 19 },

            .. new int[] { 22, 20, 21 },
            .. new int[] { 23, 20, 22 }
        ];

        return [.. indices];
    }

    public static int[] NumFaceVertices()
    {
        return [3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3];
    }
}

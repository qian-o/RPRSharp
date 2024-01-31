namespace RPRSharp;

public readonly struct ApiVersion
{
    public int Major { get; init; }

    public int Minor { get; init; }

    public int Revision { get; init; }

    public int Build { get; init; }

    public ApiVersion(int major, int minor, int revision)
    {
        Major = major;
        Minor = minor;
        Revision = revision;
        Build = 0;
    }

    public ApiVersion(int major, int minor, int revision, int build)
    {
        Major = major;
        Minor = minor;
        Revision = revision;
        Build = build;
    }

    public ApiVersion(string version)
    {
        string[] parts = version.Split('.');

        Major = int.Parse(parts[0]);
        Minor = int.Parse(parts[1]);
        Revision = parts.Length == 2 ? 0 : int.Parse(parts[2]);
        Build = parts.Length == 3 ? 0 : int.Parse(parts[3]);
    }

    public override readonly string ToString()
    {
        return $"{Major}.{Minor}.{Revision}.{Build}";
    }
}

# RPRSharp

This repository is developed based on the C# bindings provided by [RadeonProRenderSDK](https://github.com/GPUOpen-LibrariesAndSDKs/RadeonProRenderSDK), improving its enums and structs to make the calling method more suitable for C# developers.

The repository code uses [ClangSharp](https://github.com/dotnet/ClangSharp) to perform semantic analysis and generation on the [RadeonProRender_v2.h](https://github.com/GPUOpen-LibrariesAndSDKs/RadeonProRenderSDK/blob/master/RadeonProRender/inc/RadeonProRender_v2.h) file, and refactors it using the Camel-Case naming convention.\
**Note: Some enumerations and structures may have names that do not match their original meanings.**

The interface code has been double-checked on the [RadeonProRender_v2.h](https://github.com/GPUOpen-LibrariesAndSDKs/RadeonProRenderSDK/blob/master/RadeonProRender/inc/RadeonProRender_v2.h) file provided by the [RadeonProRenderSDK](https://github.com/GPUOpen-LibrariesAndSDKs/RadeonProRenderSDK) repository, and all the interfaces have been implemented. The current code version is 3.1.5.

The code is currently in the early stages of development, and it cannot be guaranteed that all interfaces are functional. I will continue to improve the code based on the tutorial examples provided by RadeonProRenderSDK, and I also welcome contributions from the community.

## Usage:
Call the Core.Init() function in the program entry point and provide a callback function for registering dependency libraries.
```csharp
static void Main(string[] _)
{
    Core.Init(RegisterLibrary);

    // code
    Rpr.Create....;
}

private static void RegisterLibrary(Platform platform, out string rprPath)
{
    string dir = Path.Combine(AppContext.BaseDirectory, "AMD Radeon ProRender SDK");

    rprPath = platform switch
    {
        Platform.CentOS => Path.Combine(dir, "binCentOS7", "libRadeonProRender64.so"),
        Platform.Ubuntu => Path.Combine(dir, "binUbuntu20", "libRadeonProRender64.so"),
        Platform.MacOS => Path.Combine(dir, "binMacOS", "libRadeonProRender64.dylib"),
        Platform.Windows => Path.Combine(dir, "binWin64", "RadeonProRender64.dll"),
        _ => string.Empty,
    };
}
```


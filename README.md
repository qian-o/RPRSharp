# RPRSharp

This repository is developed based on the C# bindings provided by [RadeonProRenderSDK](https://github.com/GPUOpen-LibrariesAndSDKs/RadeonProRenderSDK), improving its enums and structs to make the calling method more suitable for C# developers.

The repository code uses [ClangSharp](https://github.com/dotnet/ClangSharp) to perform semantic analysis and generation on the [RadeonProRender_v2.h](https://github.com/GPUOpen-LibrariesAndSDKs/RadeonProRenderSDK/blob/master/RadeonProRender/inc/RadeonProRender_v2.h) file, and refactors it using the Camel-Case naming convention.\
**Note: Some enumerations and structures may have names that do not match their original meanings.**

The interface code has been double-checked on the [RadeonProRender_v2.h](https://github.com/GPUOpen-LibrariesAndSDKs/RadeonProRenderSDK/blob/master/RadeonProRender/inc/RadeonProRender_v2.h) file provided by the [RadeonProRenderSDK](https://github.com/GPUOpen-LibrariesAndSDKs/RadeonProRenderSDK) repository, and all the interfaces have been implemented. The current code version is 3.1.5.

The code is currently in the early stages of development, and it cannot be guaranteed that all interfaces are functional. I will continue to improve the code based on the tutorial examples provided by RadeonProRenderSDK, and I also welcome contributions from the community.

00_context_creation
![image](https://github.com/qian-o/RPRSharp/assets/84434846/b0ba6bca-a2ba-479e-9052-5a9f8372a4cb)

03_parameters_enumeration
![image](https://github.com/qian-o/RPRSharp/assets/84434846/1de4ebff-80d2-40f5-8c4a-c22655958e5e)

05_basic_scene
![image](https://github.com/qian-o/RPRSharp/assets/84434846/4dfd3749-de1e-49e2-9f7f-1eafaf17bec1)

12_transform_motion_blur
![image](https://github.com/qian-o/RPRSharp/assets/84434846/366f9571-2fc0-42c7-aea3-de2aefeaf1a6)

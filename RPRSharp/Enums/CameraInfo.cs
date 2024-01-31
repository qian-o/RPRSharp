﻿namespace RPRSharp;

/// <summary>
/// rpr_camera_info
/// </summary>
public enum CameraInfo : int
{
    TRANSFORM = 0x201,
    FSTOP = 0x202,
    APERTURE_BLADES = 0x203,
    RESPONSE = 0x204,
    EXPOSURE = 0x205,
    FOCAL_LENGTH = 0x206,
    SENSOR_SIZE = 0x207,
    MODE = 0x208,
    ORTHO_WIDTH = 0x209,
    ORTHO_HEIGHT = 0x20A,
    FOCUS_DISTANCE = 0x20B,
    POSITION = 0x20C,
    LOOKAT = 0x20D,
    UP = 0x20E,
    FOCAL_TILT = 0x20F,
    LENS_SHIFT = 0x210,
    IPD = 0x211,
    TILT_CORRECTION = 0x212,
    NEAR_PLANE = 0x213,
    FAR_PLANE = 0x214,
    LINEAR_MOTION = 0x215,
    ANGULAR_MOTION = 0x216,
    MOTION_TRANSFORMS_COUNT = 0x217,
    MOTION_TRANSFORMS = 0x218,
    POST_SCALE = 0x219,
    UV_DISTORTION = 0x21A,
    NAME = Rpr.ObjectName,
    UNIQUE_ID = Rpr.ObjectUniqueId,
    CUSTOM_PTR = Rpr.ObjectCustomPtr
}

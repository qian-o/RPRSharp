﻿namespace RPRSharp;

/// <summary>
/// rpr_hetero_volume_parameter
/// </summary>
public enum HeteroVolumeParameter : int
{
    TRANSFORM = 0x735,
    ALBEDO_V2 = 0x73c,
    DENSITY_V2 = 0x73d,
    EMISSION_V2 = 0x73e,
    ALBEDO_LOOKUP_VALUES = 0x73f,
    ALBEDO_LOOKUP_VALUES_COUNT = 0x740,
    DENSITY_LOOKUP_VALUES = 0x741,
    DENSITY_LOOKUP_VALUES_COUNT = 0x742,
    EMISSION_LOOKUP_VALUES = 0x743,
    EMISSION_LOOKUP_VALUES_COUNT = 0x744,
    ALBEDO_SCALE = 0x745,
    DENSITY_SCALE = 0x746,
    EMISSION_SCALE = 0x747,
    NAME = Rpr.ObjectName,
    UNIQUE_ID = Rpr.ObjectUniqueId,
    CUSTOM_PTR = Rpr.ObjectCustomPtr
}

namespace RPRSharp.Enums;

/// <summary>
/// rpr_grid_parameter
/// </summary>
public enum GridParameter : int
{
    SIZE_X = 0x930,
    SIZE_Y = 0x931,
    SIZE_Z = 0x932,
    DATA = 0x933,
    DATA_SIZEBYTE = 0x934,
    INDICES = 0x936,
    INDICES_NUMBER = 0x937,
    INDICES_TOPOLOGY = 0x938,
    NAME = Rpr.OBJECT_NAME,
    UNIQUE_ID = Rpr.OBJECT_UNIQUE_ID,
    CUSTOM_PTR = Rpr.OBJECT_CUSTOM_PTR
}

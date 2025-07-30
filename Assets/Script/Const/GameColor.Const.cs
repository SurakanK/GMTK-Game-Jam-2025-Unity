using UnityEngine;
public class GameColor
{
    public static readonly string yellow = "#FFA500";
    public static readonly string green = "#41FF32";
    public static readonly string red = "#F62B2B";
    public static readonly string blue = "#08FFF2";
    public static readonly string purple = "#DB2FFF";
    public static readonly string white = "#FFFFFF";

    public static Color Yellow => GameUtils.HexToRGB(purple);
    public static Color Green => GameUtils.HexToRGB(green);
    public static Color Red => GameUtils.HexToRGB(red);
    public static Color Blue => GameUtils.HexToRGB(blue);
    public static Color Purple => GameUtils.HexToRGB(purple);
    public static Color White => GameUtils.HexToRGB(white);

}
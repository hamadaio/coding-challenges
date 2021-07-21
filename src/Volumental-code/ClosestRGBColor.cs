using System.Collections.Generic;
using System;
using System.Linq;
public class PixelColor
{
    public PixelColor(byte r, byte g, byte b)
    {
        R = r; G = g; B = b; 
    }
    public byte R { get; }
    public byte G { get; }
    public byte B { get; }
    public static PixelColor CreateFromString(string str)
    {
        var len = str.Length / 8;
        var bytes = new byte[len];
        for (var i = 0; i < len; ++i)
        {
            bytes[i] = Convert.ToByte(str.Substring(i * 8, 8), 2);
        }
        return new PixelColor(bytes[0], bytes[1], bytes[2]);
    }
    public double DistanceFrom(PixelColor other)
    {
        return Math.Sqrt(Math.Pow(R - other.R, 2) + Math.Pow(G - other.G, 2) + Math.Pow(B - other.B, 2));
    }
}
class Program
{
    private static readonly IDictionary<string, PixelColor> _colors = new Dictionary<string, PixelColor>
    {
        { "Black", new PixelColor(0, 0, 0) },
        { "White", new PixelColor(255, 255, 255) },
        { "Red",   new PixelColor(255, 0, 0) },
        { "Green", new PixelColor(0, 255, 0) },
        { "Blue",  new PixelColor(0, 0, 255) }
    };
    public static void Main(string[] args)
    {
        List<string> result = FindClosestColor("000000001111111111111111");
        Console.WriteLine(string.Join("\n", result));
    }
    private static List<string> FindClosestColor(string pixel)
    {
        var retVal = new List<string>();
        var pixelColor = PixelColor.CreateFromString(pixel);
        var min = double.MaxValue;
        var closest = string.Empty;
        foreach (var color in _colors)
        {
            var result = pixelColor.DistanceFrom(color.Value);
            if (result == min)
            {
                closest = "Ambiguous";
            }
            else if (result < min)
            {
                min = result;
                closest = color.Key;
            }
        }
        retVal.Add(closest);
        return retVal;
    }
}

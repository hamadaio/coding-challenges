using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{
    /*
     * Complete the 'closestColor' function below.
     *
     * The function is expected to return a STRING_ARRAY.
     * The function accepts STRING_ARRAY pixels as parameter.
     */
    
    private static readonly IDictionary<string, PixelColor> _colors = new Dictionary<string, PixelColor>
    {
        { "Black", new PixelColor { R = 0, G = 0, B = 0 } },
        { "White", new PixelColor { R = 255, G = 255, B = 255 } },
        { "Red", new PixelColor { R = 255, G = 0, B = 0 } },
        { "Green", new PixelColor { R = 0, G = 255, B = 0 } },
        { "Blue", new PixelColor { R = 0, G = 0, B = 255 } }
    };
    
    public static List<string> closestColor(List<string> pixels)
    {
        var retVal = new List<string>();
        foreach (var pixel in pixels)
        {
            var bytes = GetBytes(pixel);
            var pixelColor = new PixelColor { R = bytes[0], G = bytes[1], B = bytes[2] };
            var min = double.MaxValue;
            var closest = string.Empty;
            foreach (var color in _colors)
            {
                var result = Math.Sqrt(Math.Pow(pixelColor.R - color.Value.R, 2) + Math.Pow(pixelColor.G - color.Value.G, 2) + Math.Pow(pixelColor.B - color.Value.B, 2));
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
        }
        return retVal;
    }
    
    public static byte[] GetBytes(string str)
    {
        var len = str.Length / 8;
        var bytes = new byte[len];
        for (var i = 0; i < len; ++i)
        {
            bytes[i] = Convert.ToByte(str.Substring(i * 8, 8), 2);
        }
        return bytes;
    }
}

public class PixelColor 
{
    public byte R { get; set; }
    public byte G { get; set; }
    public byte B { get; set; }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int pixelsCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<string> pixels = new List<string>();

        for (int i = 0; i < pixelsCount; i++)
        {
            string pixelsItem = Console.ReadLine();
            pixels.Add(pixelsItem);
        }

        List<string> result = Result.closestColor(pixels);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}

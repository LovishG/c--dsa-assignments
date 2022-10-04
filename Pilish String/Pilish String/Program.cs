using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("enter string:");
        string str = Console.ReadLine()!;
        string ans = PilishString(str);
        Console.WriteLine("pilish String :\n" + ans);


    }

    private static string piString = Math.PI.ToString().Replace(".", "").Substring(0, 15);

    public static string PilishString(string txt)
    {
        if (txt == "")
        {
            return "";
        }
        var place = 0;
        var iterator = 0;
        var accumulator = new List<string>();
        var length = txt.Length;
        var search = txt + new string(txt.Last(), 9);
        while (place < length && iterator < 15)
        {
            var current = int.Parse(piString[iterator].ToString());
            accumulator.Add(search.Substring(place, current));
            place += current;
            iterator++;
        }
        return string.Join(" ", accumulator);
    }


}
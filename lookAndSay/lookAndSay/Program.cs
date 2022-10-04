using System;
using System.Text.RegularExpressions;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("enter start value:");
        long start = long.Parse(Console.ReadLine()!);
        Console.WriteLine("enter n value:");
        int n = int.Parse(Console.ReadLine()!);
        long[] ans = LookAndSay(start,n);
        for (int i = 0; i < ans.Length; i++)
        {
            if (i == ans.Length - 1)
            {
                Console.Write(ans[i]);
                break;
            }
            Console.Write($"{ans[i]},");
        }


    }

    public static long[] LookAndSay(long start, int n)
    {
        List<long> res = new List<long> { start };
        string s;
        for (int i = 0; i < n - 1; i++)
        {
            s = "";
            foreach (Match m in Regex.Matches(res[res.Count - 1].ToString(), @"(\d)\1*"))
            {
                s += m.ToString().Length.ToString() + m.ToString().Substring(0, 1);
            }
            res.Add(long.Parse(s));
        }
        return res.ToArray();
    }


}
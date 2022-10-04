using System;
using System.Text;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("enter String:");
        string str = Console.ReadLine()!;
        Console.WriteLine("enter key:");
        string key = Console.ReadLine()!;
        string cipheredStr = NicoCipher(str,key);
        Console.WriteLine($"cipher = {cipheredStr}");


    }

    public static string NicoCipher(string message, string key)
    {
        int len_k = key.Length;
        List<List<char>> m = new List<List<char>>();
        for (int i = 0; i < len_k; i++)
        {
            m.Add(new List<char>());
            m[i].Add(key[i]);
        }
        for (int i = 0; i < message.Length; i++)
        {
            m[i % len_k].Add(message[i]);
        }
        int len_m0 = m[0].Count;
        for (int r = 0; r < m.Count; r++)
            for (int i = 0; i < len_m0 - m[r].Count; i++)
                m[r].Add(' ');
        m.Sort((a, b) => a[0] < b[0] ? -1 : (a[0] > b[0] ? 1 : 0));
        StringBuilder sb = new StringBuilder(len_k * len_m0);
        for (int i = 1; i < len_m0; i++)
            for (int r = 0; r < len_k; r++)
                sb.Append(m[r][i]);
        return sb.ToString();
    }


}
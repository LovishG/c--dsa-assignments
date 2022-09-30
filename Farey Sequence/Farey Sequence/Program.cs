using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("enter value of n:");
        int r = int.Parse(Console.ReadLine()!);
        string[] fareySequence = Farey(r);

        for(int i = 0; i < fareySequence.Length; i++)
            if(fareySequence.Length-1 == i)
                Console.Write(fareySequence[i] + "\n");
        else
                Console.Write(fareySequence[i] + ", ");


    }

    public static string[] Farey(int n)
    {
        var farey = new Dictionary<string, double>
        {
            { "0/1", 0 },
            { "1/1", 1 }
        };

        for (double i = 1; i < n; i++)
        {
            for (double j = n; j > i; j--)
            {
                if (!farey.ContainsValue(i / j))
                    farey.Add($"{i}/{j}", i / j);
            }
        }

        return farey.OrderBy(x => x.Value).Select(x => x.Key).ToArray();
    }


}
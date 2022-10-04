using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("enter the time:");
        string time = Console.ReadLine();
        string[] binary = BinaryClock(time);

        for (int i = 0; i < binary.Length; i++)
        {
            Console.WriteLine(binary[i]);
        }

    }

    public static string[] BinaryClock(string time)
    {
        int[] values = new int[]{int.Parse(time[0].ToString()),
                                 int.Parse(time[1].ToString()),
                                 int.Parse(time[3].ToString()),
                                 int.Parse(time[4].ToString()),
                                 int.Parse(time[6].ToString()),
                                 int.Parse(time[7].ToString())};

        List<char> row1 = new List<char>(" 0 0 0".ToCharArray());
        List<char> row2 = new List<char>(" 00000".ToCharArray());
        List<char> row3 = new List<char>("000000".ToCharArray());
        List<char> row4 = new List<char>("000000".ToCharArray());


        for (int i = 0; i < 6; i++)
        {
            int val = values[i];

            if (val >= 8)
            {
                row1[i] = '1';
                val -= 8;
            }

            if (val >= 4)
            {
                row2[i] = '1';
                val -= 4;
            }

            if (val >= 2)
            {
                row3[i] = '1';
                val -= 2;
            }

            if (val >= 1)
            {
                row4[i] = '1';
            }
        }

        return new string[] { new string(row1.ToArray()),
                              new string(row2.ToArray()),
                              new string(row3.ToArray()),
                              new string(row4.ToArray())};
    }


}
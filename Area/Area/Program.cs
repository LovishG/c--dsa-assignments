using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("enter value of r:");
        int r = int.Parse(Console.ReadLine()!);
        double area = RedArea(r);
        Console.WriteLine("ans is " + area);


    }



    public static double RedArea(int r) => 
        Math.Round(Math.Pow(r, 2) * (Math.Atan(1d / 2d) + .4d - Math.PI / 4), 3);
}
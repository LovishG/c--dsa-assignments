using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("enter value of n:");
        int n = int.Parse(Console.ReadLine()!);
        Console.WriteLine("enter value of k:");
        int k = int.Parse(Console.ReadLine()!);
        bool isBalanced = Centrifuge(n,k);
        Console.WriteLine("isBalanced = " + isBalanced);


    }


    public static bool IsPrime(int n)
    {
        if (n == 2 || n == 3) return true;
        if (n < 2 || n % 2 == 0) return false;
        for (int i = 3; i <= Math.Sqrt(n); i += 2)
        {
            if (n % i == 0) return false;
        }
        return true;
    }

    public static bool Centrifuge(int n, int k)
    {
        if (n == 1 || k == 1 || n - k == 1) return false;
        if (n == k || n % 2 == 0) return true;
        return !IsPrime(n) && k % 2 == 0;
    }

}
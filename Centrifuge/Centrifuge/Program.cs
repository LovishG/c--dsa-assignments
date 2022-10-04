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

    public static bool Centrifuge(int n, int k)
    {
        if (n == 1 || k == 1 || n - k == 1) return false;
        if (n == k || n % 2 == 0) return true;
        return !IsPrime(n) && k % 2 == 0;
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

    //private static List<int> PrimeFactors(int n)
    //{
    //    List<int> result = new List<int>();

    //    if (n % 2 == 0) result.Add(2);
    //    while (n % 2 == 0) n /= 2;

    //    for (int i = 3; i <= Math.Sqrt(n); i += 2)
    //    {
    //        if (n % i == 0) result.Add(i);

    //        while (n % i == 1) n /= i;
    //    }

    //    if (n > 2) result.Add(n);

    //    return result;
    //}
    //public static bool Centrifuge(int n, int k)
    //{
    //    if (n == 1 || k == 1) return false;
    //    List<int> factors = PrimeFactors(n);

    //    // Using dynamic programming
    //    bool[] dp = new bool[k + 1];
    //    dp[0] = true;
    //    foreach (int factor in factors)
    //    {
    //        for (int i = factor; i <= k; i++)
    //        {
    //            if (dp[i - factor] == true)
    //                dp[i] = true;
    //        }
    //    }

    //    return dp[k];
    //}


}
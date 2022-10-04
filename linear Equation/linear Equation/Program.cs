using System;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("enter Equation");
        string eqn = Console.ReadLine()!;
        string valueOfX = FindX(eqn);
        Console.WriteLine("ans is " + valueOfX);


    }

    public static string FindX(string eq)
    {

        float a = 0;
        float b = 0;

        string num_temp = "";

        bool equal_sign_has_been_passed = false;
        bool number_has_been_passed = false;

        for (int i = 0; i < eq.Length; i++)
        {
            char current_chr = eq[i];

            if (Char.IsDigit(current_chr))
            {
                if (!number_has_been_passed) { number_has_been_passed = true; }
                num_temp += current_chr;
            }

            else if (current_chr == '+' || current_chr == '-')
            {
                if (!number_has_been_passed) { num_temp += current_chr; }
                else
                {
                    int current_integer = int.Parse(num_temp);
                    a += equal_sign_has_been_passed ? current_integer : current_integer * -1;
                    number_has_been_passed = false;
                    num_temp = "" + current_chr;
                }
            }

            else if (current_chr == 'x')
            {
                if (num_temp == "+" || num_temp == "-" || num_temp == "")
                    num_temp += "1";

                int current_integer = int.Parse(num_temp);
                b += equal_sign_has_been_passed ? current_integer * -1 : current_integer;
                number_has_been_passed = false;
                num_temp = "";
            }

            if (current_chr == '=' || i == eq.Length - 1)
            {
                if (number_has_been_passed)
                {
                    int current_integer = int.Parse(num_temp);
                    a += equal_sign_has_been_passed ? current_integer : current_integer * -1;
                    number_has_been_passed = false;
                    num_temp = "";
                }
                equal_sign_has_been_passed = true;
            }

        }

        if (b == 0 && a == 0)
            return "Infinite solutions";
        else if (b == 0)
            return "No solution";
        else
            return "x=" + Math.Round(a / b, 2).ToString();
    }



}
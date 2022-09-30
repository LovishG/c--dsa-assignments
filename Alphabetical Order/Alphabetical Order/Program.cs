using System;
using System.Linq;

class AlpahbeticOrder
{
    public static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("*************");
        Console.WriteLine("   Welcome   ");
        Console.WriteLine("*************");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Please Enter the String to reverse:");
        Console.ResetColor();

        string str = Console.ReadLine()!;
        string sortedStr = SortString(str.Trim().ToLower());

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nYour Entered String is:");
        Console.WriteLine(str);
        Console.WriteLine("\nYour sorted String is:");
        Console.WriteLine(sortedStr);
        Console.ResetColor();
    }


    // Main Logic Function
    //public static string SortString(string str)
    //{
    //    string withoutSpace = str.Replace(" ", "");

    //    char[] arr = withoutSpace.ToCharArray();
    //    Array.Sort(arr);
    //    string sortedStr = string.Join("", arr);


    //    for (int i = 0; i < str.Length; i++)
    //    {
    //        if (str[i] == ' ')
    //        {
    //            sortedStr = sortedStr.Insert(i, " ");
    //        }    
    //    }
    //    return sortedStr;
    //}

    public static string SortString(string str)
    {   
        string withoutSpaceString = str.Replace(" ", "");
        int[] charsCount = new int[26];
        char[] chars = new char[str.Length];


        for(int j = 0; j < withoutSpaceString.Length; j++)
        {
            charsCount[(int)withoutSpaceString[j] - (int)'a']++;
        }

        int index = 0;
        int i = 0;
        while (index < 26 && i < str.Length){

            if (index < 26)
            {
                if (charsCount[index] > 0)
                {
                    while (charsCount[index]> 0)
                    {
                        if (str[i] == ' ') {
                            chars[i]= ' ';
                            i++;
                        }
                            
                        chars[i] = (char)('a' + index);
                        charsCount[index]--;
                        i++;
                    }
                }
            }
            index++;
        }
        
        string sortedStr = string.Join("", chars);
        return sortedStr;
    }
}                              
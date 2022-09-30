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



    public static double RedArea(int r)
    {
        // If circle is centered at the origin, point of intersection found by substitution (-3r/5, -4r/5)

        double theta = Math.Atan2(4, 3) * 2;
        double areaOfPieSlice = theta * r * r / 2.0;
        double areaOfTriangleInCircle = 2 * (4 / 5.0) * (3 / 5.0) / 2 * r * r;
        double areaOfLeftSliceOfHalfCircle = areaOfPieSlice - areaOfTriangleInCircle;
        double areaOfHalfCircle = Math.PI * r * r / 2.0;
        double areaOfRightSlideOfHalfCircle = areaOfHalfCircle - areaOfLeftSliceOfHalfCircle;
        double areaOfRectangleOverRightSideOfHalfCircle = 3 / 5.0 * 2 * r * r;
        double areaOfRightRedUnderCircle = (areaOfRectangleOverRightSideOfHalfCircle - areaOfRightSlideOfHalfCircle) / 2.0;
        double areaOfLeftRedTriangle = (r - 3 * r / 5.0) * (r - 4 * r / 5.0) / 2.0;
        double areaOfRed = areaOfLeftRedTriangle + areaOfRightRedUnderCircle;

        return Math.Round(areaOfRed, 3);
    }
}
using System;

namespace CTService.Calculs
{
    public class Calculs
    {
        public static double ConvertFToC(double temp)
        {
            return Math.Round((temp - 32) / 1.8, 2);
        }

        public static double ConvertCToF(double temp)
        {
            return Math.Round(1.8 * temp + 32, 2);
        }
    }
}

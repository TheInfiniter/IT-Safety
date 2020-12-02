using GaussLib;
using System;

namespace Tmp
{
    class Program
    {
        static void Main(string[] args)
        {
            double amp = 1;
            double disp = 2;
            int center = 32;
            int shift = 0;

            double[] array = Gauss.GetGaussDome(64, amp, disp, center, shift);
            double D = 1 / (amp * Math.Sqrt(2 * Math.PI));
            double M;

            double temp = 0;
            for (int i = 0; i < array.Length; i++)
            {
                temp += array[i];
            }
            temp /= array.Length;            

            Console.WriteLine(D.ToString());
            Console.ReadKey();
        }
    }
}

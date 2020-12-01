using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaussLib
{
    public static class Gauss
    {
        public static double[] GetGaussDome(int size, int amount, int amp, double disp, int center)
        {
            //RandomInit();
            double[] array = new double[size];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = 0;
                for (int j = 0; j < amount; j++)
                {
                    array[i] += GaussDome(amp, disp, center, i);
                }
            }
            return array;
        }

        private static double GaussDome(double amp, double disp, double center, int i, double shift = 0)
        {
            return amp * Math.Exp(-(i - (center + shift)) * (i - (center + shift)) / (disp * disp));
        }
    }
}

using System;

namespace GaussLib
{
    public static class Gauss
    {
        /// <summary>
        /// Получить массив значений купола.
        /// </summary>
        /// <param name="size">Размер массива.</param>
        /// <param name="amp">Амплитуда.</param>
        /// <param name="disp">Дисперсия.</param>
        /// <param name="center">Центр купола.</param>
        /// <param name="shift">Смещение купола.</param>
        /// <returns>Массив значений.</returns>
        public static double[] GetGaussDome(int size, double amp, double disp, double center, double shift)
        {
            double[] array = new double[size];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = GaussDome(amp, disp, center, (double)i, shift);
            }

            return array;
        }

        /// <summary>
        /// Вычислить значение гауссова купола в указанной координате.
        /// </summary>
        /// <param name="amp">Амплитуда купола.</param>
        /// <param name="disp">Дисперсия купола.</param>
        /// <param name="center">Центр купола.</param>
        /// <param name="i">Координата x.</param>
        /// <param name="shift">Смещение купола.</param>
        /// <returns>Значение купола в данной точке х.</returns>
        public static double GaussDome(double amp, double disp, double center, double i, double shift = 0)
        {
            double result;

            if (disp <= 0)
            {
                throw new DivideByZeroException("Divide by zero");
            }
            else if ((center - shift) < 0)
            {
                throw new ArgumentException("Center is less than zero");
            }
            else
            {
                result = amp * Math.Exp(-(i - (center + shift)) * (i - (center + shift)) / (2 * (disp * disp)));
                return result;
            }
            /*
            try
            {
                result = amp * Math.Exp(-(i - (center + shift)) * (i - (center + shift)) / (disp * disp));
                return result;
            }
            catch(DivideByZeroException)
            {
                throw new DivideByZeroException("Divide by zero");
            }
            */
        }
    }
}

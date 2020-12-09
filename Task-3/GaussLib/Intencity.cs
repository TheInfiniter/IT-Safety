using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaussLib
{
    public static class Intencity
    {
        /// <summary>
        /// Получить интенсивность отраженного от поверхности света.
        /// </summary>
        /// <param name="plateSize">Размер фотопластинки, на которой регистрируется свет.</param>
        /// <param name="signalArray">Поверхность, отражающая свет.</param>
        /// <returns>Массив отсчетов интенсивности.</returns>
        public static double[] GetIntencity(int plateSize, double[] signalArray, Line plate, Pointer source, double lambda)
        {
            double range; //расстояние
            double cos = 0, sin = 0;
            Pointer curPoint = new Pointer(0, 0); //координаты отсчета
            Pointer platePoint;

            double[] intArray = new double[plateSize];

            for (int i = 0; i < intArray.Length; i++)
            {
                platePoint = CurrentPoint(plate, i, plateSize);
                for (int j = 0; j < signalArray.Length; j++)
                {
                    curPoint.X = j;
                    curPoint.Y = signalArray[j];

                    range = GetRange(source, curPoint, platePoint);
                    cos += CountCos(range, lambda);
                    sin += CountSin(range, lambda);
                    //intArray[i] += Intencity(range, lambda);
                }
                /*
                cos /= range;
                sin /= range;
                */

                intArray[i] = Math.Sqrt(Math.Pow(cos, 2) + Math.Pow(sin, 2));
                cos = sin = 0;
            }
            return intArray;
        }

        /// <summary>
        /// Получить расстояние от источника света до точки поверхности.
        /// </summary>
        /// <param name="sourcePoint">Координаты источника света.</param>
        /// <param name="curPoint">Координаты точки поверхности.</param>
        /// <returns>Расстояние от источника до точки поверхности.</returns>
        private static double SourceTargetLength(Pointer sourcePoint, Pointer curPoint)
        {
            double height = Math.Abs(sourcePoint.Y - curPoint.Y);
            double width = Math.Abs(sourcePoint.X - curPoint.X);

            return Math.Sqrt(width * width + height * height);
        }

        /// <summary>
        /// Получить координату текущей точки пластины.
        /// </summary>
        /// <param name="plating">Координаты начала и конца пластины.</param>
        /// <param name="step">Номер необходимой точки.</param>
        /// <param name="amount">Количество точек на пластине.</param>
        /// <returns>Координата точки на пластине.</returns>
        private static Pointer CurrentPoint(Line plating, int step, int amount)
        {
            Pointer current = new Pointer(0, 0);
            double width = Math.Abs(plating.xEnd - plating.xBegin);
            double height = Math.Abs(plating.yEnd - plating.yBegin);

            for (int i = 0; i < step; i++)
            {
                current.X += width / amount;
            }
            current.X += plating.xBegin;

            if (plating.yBegin > plating.yEnd)
            {
                for (int i = 0; i < step; i++)
                {
                    current.Y += height / amount;
                }
                current.Y = plating.yBegin - current.Y;
            }
            else
            {
                for (int i = 0; i < step; i++)
                {
                    current.Y += height / amount;
                }
                current.Y += plating.yBegin;
            }

            return current;
        }

        /// <summary>
        /// Получить расстояние от точки поверхности до точки на фотопластинке.
        /// </summary>
        /// <param name="platePoint">Точка фотопластинки.</param>
        /// <param name="curPoint">Точка поверхности.</param>
        /// <returns>Расстояние от точки поверхности до точки пластины.</returns>
        private static double TargetPlateLength(Pointer platePoint, Pointer curPoint)
        {
            double width = Math.Abs(curPoint.X - platePoint.X);
            double height = Math.Abs(curPoint.Y - platePoint.Y);

            return Math.Sqrt(width * width + height * height);
        }

        /// <summary>
        /// Получить расстояние, пройденное лазером.
        /// </summary>
        /// <param name="sourcePoint">Координаты источника света.</param>
        /// <param name="curPoint">Точка поверхности.</param>
        /// <param name="platePoint">Точка пластины.</param>
        /// <returns>Пройденное лазером расстояние.</returns>
        private static double GetRange(Pointer sourcePoint, Pointer curPoint, Pointer platePoint)
        {
            double targetRange = SourceTargetLength(sourcePoint, curPoint);
            double plateRange = TargetPlateLength(platePoint, curPoint);

            return targetRange + plateRange;
        }

        /// <summary>
        /// Получить значение синуса для интенсивности.
        /// </summary>
        /// <param name="range">Расстояние, пройденное светом.</param>
        /// <param name="lambda">Длина волны света.</param>
        /// <returns>Значение синуса для интенсивности.</returns>
        private static double CountSin(double range, double lambda)
        {
            double k = 2 * Math.PI / lambda;

            double sin = Math.Sin(k * range) / Math.Abs(range);
            return sin;
            /*
            double answer = sin / Math.Abs(range);
            return answer;
            */
        }

        /// <summary>
        /// Получить значение косинуса для интенсивности.
        /// </summary>
        /// <param name="range">Расстояние, пройденное светом.</param>
        /// <param name="lambda">Длина волны света.</param>
        /// <returns>Значение косинуса для интенсивности.</returns>
        private static double CountCos(double range, double lambda)
        {
            double k = 2 * Math.PI / lambda;

            double cos = Math.Cos(k * range) / Math.Abs(range);
            return cos;
            /*
            double answer = cos / Math.Abs(range);
            return answer;
            */
        }
    }
}

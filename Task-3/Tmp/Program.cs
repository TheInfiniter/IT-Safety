using GaussLib;
using System;

namespace Tmp
{
    class Program
    {
        static void Main(string[] args)
        {
            Line plate = new Line();
            int plateSize;
            Pointer source = new Pointer();
            double lambda;

            plate.xBegin = 512;
            plate.yBegin = 10024;
            plate.xEnd = 1024;
            plate.yEnd = 9524;

            plateSize = 256;

            source.X = 0;
            source.Y = 9800;

            lambda = 0.63;

            Random rand = new Random();
            /*
            double[] array = Gauss.GetRandomGaussDome(1024, 256, 0, rand);
            double[] shift_array = Gauss.GetRandomGaussDome(1024, 256, 5, rand);
            

            double[] intence = Intencity.GetIntencity(plateSize, array, plate, source, lambda);
            double[] shift_intence = Intencity.GetIntencity(plateSize, shift_array, plate, source, lambda);

            double max = 0;
            int index = 0;

            for (int i = 0; i < intence.Length; i++)
            {
                if (intence[i] > max)
                {
                    max = intence[i];
                    index = i;
                }
            }

            double shift_max = 0;
            int shift_index = 0;

            for (int i = 0; i < shift_intence.Length; i++)
            {
                if (shift_intence[i] > shift_max)
                {
                    shift_max = shift_intence[i];
                    shift_index = i;
                }
            }

            Console.WriteLine(index.ToString());
            Console.WriteLine(shift_index.ToString());
            */
            Console.ReadKey();
        }
    }
}

using NUnit.Framework;
using GaussLib;
using System;

namespace UnitTest
{
    class IntencityTests
    {
        Line plate;
        int plateSize, amount, size;
        Pointer source;
        double lambda;

        double[] amp, disp, center;
        double[] ampEdge, dispEdge, centerEdge;

        Random rand = new Random();

        [SetUp]
        public void SetUp()
        {
            plate = new Line
            {
                xBegin = 512,
                yBegin = 10024,
                xEnd = 1024,
                yEnd = 9524
            };

            plateSize = 256;

            source = new Pointer
            {
                X = 0,
                Y = 9800
            };

            lambda = 0.63;

            amount = 256;
            size = 1024;

            ampEdge = new double[2];
            ampEdge[0] = -0.5;
            ampEdge[1] = 0.5;

            dispEdge = new double[2];
            dispEdge[0] = 5;
            dispEdge[1] = 7;

            centerEdge = new double[2];
            centerEdge[0] = 1;
            centerEdge[1] = size;

            RandomInit(ampEdge, centerEdge, dispEdge, rand);
        }

        [Test]
        public void CorrectShift()
        {
            int shift = 5;

            double[] array = Gauss.GetRandomGaussDome(size, amount, 0, amp, disp, center);
            double[] shift_array = Gauss.GetRandomGaussDome(size, amount, shift, amp, disp, center);

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

            Assert.AreEqual(index, shift_index, shift);
        }

        [Test]
        public void CorrectNegativeShift()
        {
            int shift = -5;

            double[] array = Gauss.GetRandomGaussDome(size, amount, 0, amp, disp, center);
            double[] shift_array = Gauss.GetRandomGaussDome(size, amount, shift, amp, disp, center);

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

            Assert.AreEqual(index, shift_index, Math.Abs(shift));
        }

        [Test]
        public void ZeroShift()
        {
            double[] array = Gauss.GetRandomGaussDome(size, amount, 0, amp, disp, center);
            double[] shift_array = Gauss.GetRandomGaussDome(size, amount, 0, amp, disp, center);

            double[] intence = Intencity.GetIntencity(plateSize, array, plate, source, lambda);
            double[] shift_intence = Intencity.GetIntencity(plateSize, shift_array, plate, source, lambda);

            Assert.That(intence, Is.EqualTo(shift_intence));
        }

        /*
        [Test]
        public void CorrectShift2()
        {
            RandomInit(ampEdge, centerEdge, dispEdge, rand);
            int shift = 5;

            double[] array = Gauss.GetRandomGaussDome(size, amount, 0, amp, disp, center);
            double[] shift_array = Gauss.GetRandomGaussDome(size, amount, shift, amp, disp, center);

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

            int shift_index = index + shift;
            double shift_max = shift_intence[shift_index];

            Assert.AreEqual(max, shift_max, 0.1);
        }
        */

        public void RandomInit(double[] ampEdges, double[] centerEdges, double[] dispEdges, Random rand)
        {
            amp = new double[amount];
            disp = new double[amount];
            center = new double[amount];

            for (int i = 0; i < amount; i++)
            {
                amp[i] = GetRandom(ampEdges[0], ampEdges[1], rand);
                center[i] = GetRandom(centerEdges[0], centerEdges[1], rand);
                disp[i] = GetRandom(dispEdges[0], dispEdges[1], rand);
            }
        }

        private static double GetRandom(double minimum, double maximum, Random rand)
        {
            return rand.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}

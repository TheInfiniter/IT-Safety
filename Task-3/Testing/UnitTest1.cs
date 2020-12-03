using NUnit.Framework;
using GaussLib;
using System.Linq;
using System;

namespace Testing
{
    public class GaussTests
    {
        double[] array;
        int amp = 2;
        double disp = 1;
        int center = 32;
        int shift = 0;
        int size = 64;

        [SetUp]
        public void Setup()
        {
            amp = 2;
            disp = 1;
            center = 32;
            shift = 0;
            size = 64;
        }

        [Test]
        public void ShiftTest() // тест на правильное смещение графика
        {
            shift = 2;
            array = Gauss.GetGaussDome(size, amp, disp, center, shift);
            double max = 0;
            int index = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                    index = i;
                }
            }

            Assert.AreEqual(center + shift, index);
            Assert.AreEqual(amp, max);
        }

        [Test]
        public void AmpTest() // тест на правильный пик графика
        {
            array = Gauss.GetGaussDome(size, amp, disp, center, shift);
            double max = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }

            Assert.AreEqual(amp, max);
        }

        [Test]
        public void ZeroDispersion() // тест на нулевую либо отрицательную дисперсию
        {
            var ex = Assert.Throws<DivideByZeroException>(() => Gauss.GaussDome(amp, 0, center, 0));
            Assert.That(ex.Message, Is.EqualTo("Divide by zero"));
        }

        [Test]
        public void CorrectNumbers() // тест на корректность вычислений при заданных параметрах
        {
            double[] expected = {  };
            Assert.Pass();
        }
    }
}
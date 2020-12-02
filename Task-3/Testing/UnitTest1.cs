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
        }

        [Test]
        public void ZeroDispersion() // тест на нулевую либо отрицательную дисперсию
        {
            var ex = Assert.Throws<DivideByZeroException>(() => Gauss.GaussDome(amp, 0, center, 0));
            Assert.That(ex.Message, Is.EqualTo("Divide by zero"));
        }

        [Test]
        public void CorrectDispersion() // тест на корректность дисперсии (полуширина)
        {
            Assert.Fail();
        }
    }
}
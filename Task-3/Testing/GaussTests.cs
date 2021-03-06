using NUnit.Framework;
using GaussLib;
using System;

namespace UnitTest
{
    public class GaussTests
    {
        //double[] array;
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
        public void ShiftTest() // ���� �� ���������� �������� �������
        {
            shift = 2;
            double[] array = Gauss.GetGaussDome(size, amp, disp, center, shift);
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
        public void AmpTest() // ���� �� ���������� ��� �������
        {
            double[] array = Gauss.GetGaussDome(size, amp, disp, center, shift);
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
        public void CorrectNumbers() // ���� �� ������������ ���������� ��� �������� ����������
        {
            double[] expected = { 0.000000, 0.000000, 0.000000, 0.000000, 0.000000, 0.000000, 0.000000, 0.000000, 0.000000, 0.000000, 0.000000,
                0.000007, 0.000671, 0.022218, 0.270671, 1.213061, 2.000000, 1.213061, 0.270671, 0.022218, 0.000671, 0.000007, 0.000000, 0.000000,
                0.000000, 0.000000, 0.000000, 0.000000, 0.000000, 0.000000, 0.000000, 0.000000 };

            double[] array = Gauss.GetGaussDome(32, 2, 1, 16, 0);
            Assert.That(array, Is.EqualTo(expected).Within(0.0001));
        }

        [Test]
        public void ZeroDispersion() // ���� �� ������� ���� ������������� ���������
        {
            var ex = Assert.Throws<DivideByZeroException>(() => Gauss.GaussDome(amp, 0, center, 0));
            Assert.That(ex.Message, Is.EqualTo("Dispertion is less or equal zero"));
        }

        [Test]
        public void NegativeCenter() // ���� �� ������������� �����
        {
            var ex = Assert.Throws<ArgumentException>(() => Gauss.GaussDome(amp, 1, -2, 0));
            Assert.That(ex.Message, Is.EqualTo("Center is less than zero"));
        }

        [Test]
        public void LessThanZeroShift() // ���� �� �������� ������ ���� ����
        {
            var ex = Assert.Throws<ArgumentException>(() => Gauss.GaussDome(amp, 1, 4, 0, 6));
            Assert.That(ex.Message, Is.EqualTo("Center is less than zero"));
        }
    }
}
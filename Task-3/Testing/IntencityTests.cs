using NUnit.Framework;
using GaussLib;
using System;

namespace UnitTest
{
    class IntencityTests
    {
        Line plate;
        int plateSize;
        Pointer source;
        double lambda;

        Random rand = new Random();

        [SetUp]
        public void SetUp()
        {
            plate.xBegin = 512;
            plate.yBegin = 10024;
            plate.xEnd = 1024;
            plate.yEnd = 9524;

            plateSize = 256;

            source.X = 0;
            source.Y = 9800;

            lambda = 0.63;
        }

        [Test]
        public void Test()
        {
            double[] array = Gauss.GetRandomGaussDome(1024, 256, 0, rand);
        }
    }
}

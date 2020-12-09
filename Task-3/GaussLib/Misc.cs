using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaussLib
{
    public struct Line
    {
        public double xBegin { get; set; }
        public double yBegin { get; set; }
        public double xEnd { get; set; }
        public double yEnd { get; set; }
    }

    //структура для хранения координат точек
    public struct Pointer
    {
        public Pointer(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public double X { get; set; }
        public double Y { get; set; }
    }
}

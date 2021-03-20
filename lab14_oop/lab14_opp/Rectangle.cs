using System;
using System.Collections.Generic;
using System.Text;

namespace lab14_opp
{
    class Rectangle
    {
        ////attributes
        //public int length;
        //public int width;

        //properties
        public int Length { get; set; }
        public int Width { get; set; }

        //ctors
        public Rectangle()
        {
            //create an object with no values assigned to attributes
        }

        public Rectangle(int len, int w)
        {
            Length = len;
            Width = w;
        }

        //Methods
        public int CalcArea()
        {
            return Length * Width;
        }

        public double CalcPerimeter()
        {
            return (2 * Length * Width);
        }

        public double CalcDiagonal()
        {
            return Math.Sqrt((Math.Pow(Length, 2) + Math.Pow(Width, 2)));
        }

        public override string ToString()
        {
            return $"Length: {Length}\n" +
                $"Width: {Width}\n" +
                $"Area: {CalcArea()}\n" +
                $"Diagonal: {CalcDiagonal()}";
        }
    }

}

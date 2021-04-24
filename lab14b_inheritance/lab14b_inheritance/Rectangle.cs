using System;
using System.Collections.Generic;
using System.Text;

namespace lab14b_inheritance
{
    class Rectangle
    {
        //attributes
        private double _length;

        private double _width;

        //properties
        public double Width
        {
            get { return _width; }
            set { _width = value; }
        }


        public double Length
        {
            get { return _length; }
            set { _length = value; }
        }

        //ctors
        public Rectangle()
        {

        }

        public Rectangle(double width, double length)
        {
            Width = width;
            Length = length;
        }

        //methods
        public virtual double CalcArea()
        {            
            return _width * _length;
        }

        public override string ToString()
        {
            return $"The area of a rectangle of length {_length} and width {_width} is {CalcArea()}";
        }

    }
}

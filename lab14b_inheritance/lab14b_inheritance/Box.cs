using System;
using System.Collections.Generic;
using System.Text;

namespace lab14b_inheritance
{
    class Box : Rectangle
    {
        //attributes
        double _depth;

        //properties
        public double Depth
        {
            get { return _depth; }
            set { _depth = value; }
        }

        //ctor
        public Box()
        {

        }

        public Box(double width, double length, double height) : base(width, length) 
        {
            _depth = height;
        }

        //methods
        public override double CalcArea()
        {
            return (4 * (Length * Width)) + (2 * (Width * _depth));
        }
        public double CalcVolume()
        {
            return Width * Length * _depth;
        }

        public override string ToString()
        {
            return $"The area of a box of length {Length}, width {Width} and depth {_depth} is {CalcArea()}\n" +
                $"The volume of this box is {CalcVolume()}";

        }


    }
}

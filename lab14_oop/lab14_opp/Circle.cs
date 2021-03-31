using System;
using System.Collections.Generic;
using System.Text;

namespace lab14_opp
{
    class Circle
    {
        //attributes
        double radius;

        //properties
        public double Radius
        {
            get
            {
                return radius;
            }
            set
            {
                radius = value;
            }
        }
        //constructors
        public Circle()         //default ctor
        {
            radius = 1;
        }

        //paramaterised ctor - when the object is created using this ctor, 
        //the passed arg will be used for the radius
        public Circle(int r)    
        {
            Radius = r;
        }

        //method
        public double GetArea()
        {
            return Math.PI * (Radius * Radius);
        }

        public override string ToString()
        {            
            return $"I am a Circle of radius {Radius} and area {GetArea()}";
        }

    }
}

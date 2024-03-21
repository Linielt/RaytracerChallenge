using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.ColorDomain
{
    public class Color
    {
        public double Red { get; }
        public double Green { get; }
        public double Blue { get; }
        public Color(double red, double green, double blue)
        {
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
        }

        public static Color operator +(Color a, Color b)
        {
            return new Color(a.Red + b.Red, a.Green + b.Green, a.Blue + b.Blue);
        }

        public static Color operator -(Color a, Color b)
        {
            return new Color(a.Red - b.Red, a.Green - b.Green, a.Blue - b.Blue);
        }

        public static Color operator *(Color a, double scalar)
        {
            return new Color(a.Red * scalar, a.Green * scalar, a.Blue * scalar);
        }

        public static Color operator *(Color a, Color b)
        {
            return new Color(a.Red * b.Red, a.Green * b.Green, a.Blue * b.Blue);
        }

        public bool Equivalence(Color other) // TODO -  May add this method to other classes
        {
            return Red.floatCompare(other.Red) && Green.floatCompare(other.Green) &&
                Blue.floatCompare(other.Blue);
        }
    }
}

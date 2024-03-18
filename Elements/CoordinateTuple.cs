using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaytracerChallenge.Elements
{
    public class CoordinateTuple
    {
        public double X { get; }
        public double Y { get; }
        public double Z { get; }
        public double W { get; }

        public CoordinateTuple(double x, double y, double z, double w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public bool Equals(CoordinateTuple other)
        {
            return GetType() == other.GetType() &&
                X == other.X && Y == other.Y &&
                Z == other.Z && W == other.W;
        }
    }
}

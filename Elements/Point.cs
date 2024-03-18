using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaytracerChallenge.Elements
{
    public class Point : CoordinateTuple
    {
        public Point(double x, double y, double z, double w = 1.0) : base(x, y, z, w)
        {

        }

        public static Point operator +(Point p, Vector v)
        {
            return new Point(p.X + v.X, p.Y + v.Y, p.Z + v.Z);
        }

        public static Vector operator -(Point a, Point b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public static Point operator -(Point p, Vector v)
        {
            return new Point(p.X - v.X, p.Y - v.Y, p.Z - v.Z);
        }

        public static Point operator -(Point p)
        {
            return new Point(-p.X, -p.Y, -p.Z);
        }

        public override bool Equals(object other)
        {
            if (other == null)
            {
                return false;
            }

            if (GetType() != other.GetType())
            {
                return false;
            }
            return Equals((Point)other);
        }

        public bool Equals(Point other)
        {
            return other != null &&
                X == other.X &&
                Y == other.Y &&
                Z == other.Z &&
                W == other.W;
        }
    }
}

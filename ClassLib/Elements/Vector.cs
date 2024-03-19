using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Elements
{
    public class Vector : CoordinateTuple
    {
        public Vector(double x, double y, double z, double w = 0.0) : base(x, y, z, w)
        {

        }

        public double Magnitude() => Math.Sqrt(X * X + Y * Y + Z * Z);

        public Vector Normalize() => new Vector(X / Magnitude(),
                                                Y / Magnitude(),
                                                Z / Magnitude());

        public double Dot(Vector vector)
        {
            return X * vector.X + Y * vector.Y + Z * vector.Z;
        }

        public Vector Cross(Vector vector)
        {
            return new Vector(Y * vector.Z - Z * vector.Y,
                              Z * vector.X - X * vector.Z,
                              X * vector.Y - Y * vector.X);
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public static Vector operator -(Vector v)
        {
            return new Vector(-v.X, -v.Y, -v.Z);
        }

        public static Vector operator *(Vector v, double scalar)
        {
            return new Vector(v.X * scalar, v.Y * scalar, v.Z * scalar);
        }

        public static Vector operator /(Vector v, double scalar)
        {
            return new Vector(v.X / scalar, v.Y / scalar, v.Z / scalar);
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
            return Equals((Vector)other);
        }

        public bool Equals(Vector other)
        {
            return other != null &&
                X == other.X &&
                Y == other.Y &&
                Z == other.Z &&
                W == other.W;
        }
    }
}

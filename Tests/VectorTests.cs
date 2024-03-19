using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLib.Elements;

namespace Tests
{
    public class VectorTests
    {
        [Fact]
        public void ConstructionCreatesTupleWithWEqualsZero()
        {
            Vector a = new(4.3, -4.2, 3.1);

            Assert.Equal(4.3, a.X);
            Assert.Equal(-4.2, a.Y);
            Assert.Equal(3.1, a.Z);
            Assert.Equal(0.0, a.W);
        }

        [Fact]
        public void AdditionOfTwoVectors()
        {
            Vector a = new(3, 2, 1);
            Vector b = new(1, 2, 3);

            Assert.Equal(new Vector(4, 4, 4, 0), a + b);
        }

        [Fact]
        public void SubtractionOfAVectorFromAPoint()
        {
            Point p = new(3, 2, 1);
            Vector v = new(5, 6, 7);

            Assert.Equal(new Point(-2, -4, -6), p - v);
        }

        [Fact]
        public void SubtractingTwoVectors()
        {
            Vector v1 = new(3, 2, 1);
            Vector v2 = new(5, 6, 7);

            Assert.Equal(new Vector(-2, -4, -6), v1 - v2);
        }

        [Fact]
        public void SubtractionFromZeroVector()
        {
            Vector zero = new(0, 0, 0);
            Vector v = new(1, -2, 3);

            Assert.Equal(new Vector(-1, 2, -3), zero - v);
        }

        [Fact]
        public void NegationOfAVector()
        {
            Vector v = new(1, -2, 3);

            Assert.Equal(new Vector(-1, 2, -3), -v);
        }

        [Fact]
        public void ScalarMultiplication()
        {
            Vector v = new(1, -2, 3);

            Assert.Equal(new Vector(3.5, -7, 10.5), v * 3.5);
        }

        [Fact]
        public void FractionalMultiplication()
        {
            Vector v = new(1, -2, 3);

            Assert.Equal(new Vector(0.5, -1, 1.5), v * 0.5);
        }

        [Fact]
        public void ScalarDivision()
        {
            Vector v = new(1, -2, 3);

            Assert.Equal(new Vector(0.5, -1, 1.5), v / 2);
        }

        [Fact]
        public void CalculateMagnitudeTest()
        {
            Vector v = new(1, 0, 0);

            Assert.Equal(1, v.Magnitude());

            v = new(0, 1, 0);

            Assert.Equal(1, v.Magnitude());

            v = new(0, 0, 1);

            Assert.Equal(1, v.Magnitude());

            v = new(1, 2, 3);

            Assert.Equal(Math.Sqrt(14), v.Magnitude());

            v = new(-1, -2, -3);

            Assert.Equal(Math.Sqrt(14), v.Magnitude());
        }

        [Fact]
        public void Normalization()
        {
            Vector v = new(4, 0, 0);

            Assert.Equal(new Vector(1, 0, 0), v.Normalize());

            v = new(1, 2, 3);
            Vector normalizedV = v.Normalize();

            // Test that length of normalized vector is 1.
            Assert.Equal(1, normalizedV.Magnitude());
        }

        [Fact]
        public void DotProduct()
        {
            Vector a = new(1, 2, 3);
            Vector b = new(2, 3, 4);

            Assert.Equal(20, a.Dot(b));
        }

        [Fact]
        public void CrossProduct()
        {
            Vector a = new(1, 2, 3);
            Vector b = new(2, 3, 4);

            Assert.Equal(new Vector(-1, 2, -1), a.Cross(b));
            Assert.Equal(new Vector(1, -2, 1), b.Cross(a));
        }
    }
}

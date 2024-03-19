using ClassLib.Elements;

namespace Tests
{
    public class PointTests
    {
        [Fact]
        public void ConstructionCreatesTupleWithWEqualsOne()
        {
            Point a = new(4.3, -4.2, 3.1);
            Assert.Equal(4.3, a.X);
            Assert.Equal(-4.2, a.Y);
            Assert.Equal(3.1, a.Z);
            Assert.Equal(1.0, a.W);
        }

        [Fact]
        public void AdditionOfAVectorAndPoint()
        {
            Point a1 = new(3, -2, 5);
            Vector a2 = new(-2, 3, 1);

            Assert.Equal(new Point(1, 1, 6, 1), a1 + a2);
        }

        [Fact]
        public void SubtractionOfTwoPoints()
        {
            Point p1 = new(3, 2, 1);
            Point p2 = new(5, 6, 7);

            Assert.Equal(new Vector(-2, -4, -6), p1 - p2);
        }

        [Fact]
        public void NegationOfAPoint()
        {
            Point p = new(3, -2, 1);

            Assert.Equal(new Point(-3, 2, -1), -p);
        }
    }
}
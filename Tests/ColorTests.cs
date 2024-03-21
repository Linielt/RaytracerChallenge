using ClassLib.ColorDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class ColorTests
    {
        [Fact]
        public void ColorTupleTest()
        {
            Color c = new(-0.5, 0.4, 1.7);

            Assert.Equal(-0.5, c.Red);
            Assert.Equal(0.4, c.Green);
            Assert.Equal(1.7, c.Blue);
        }

        [Fact]
        public void ColorAddition()
        {
            Color c1 = new(0.9, 0.6, 0.75);
            Color c2 = new(0.7, 0.1, 0.25);

            Assert.True(new Color(1.6, 0.7, 1.0).Equivalence(c1 + c2));
        }

        [Fact]
        public void ColorSubtraction()
        {
            Color c1 = new(0.9, 0.6, 0.75);
            Color c2 = new(0.7, 0.1, 0.25);

            Assert.True(new Color(0.2, 0.5, 0.5).Equivalence(c1 - c2));
        }

        [Fact]
        public void ColorMultiplication()
        {
            Color c = new(0.2, 0.3, 0.4);

            Assert.True(new Color(0.4, 0.6, 0.8).Equivalence(c * 2));

            Color c1 = new(1, 0.2, 0.4);
            Color c2 = new(0.9, 1, 0.1);

            Assert.True(new Color(0.9, 0.2, 0.04).Equivalence(c1 * c2));
        }


    }
}

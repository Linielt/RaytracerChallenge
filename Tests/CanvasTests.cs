using ClassLib.ColorDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class CanvasTests
    {
        [Fact]
        public void CreateCanvas()
        {
            Canvas c = new Canvas(10, 20);
            Color black = new(0, 0, 0);
            bool canvasIsFullyBlack = true;
            
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (!c.getPixel(i, j).Equivalence(black))
                    {
                        canvasIsFullyBlack = false;
                        break;
                    }
                }
            }

            Assert.True(canvasIsFullyBlack);
        }

        [Fact]
        public void WritePixelToCanvas()
        {
            Canvas c = new(10, 20);
            Color red = new(1, 0, 0);

            c.WritePixel(2, 3, red);

            Assert.Equal(c.getPixel(2, 3), red);
        }
    }
}

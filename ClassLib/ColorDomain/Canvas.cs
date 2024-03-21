using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.ColorDomain
{
    public class Canvas
    {
        public int width { get; }
        public int height { get; }
        public Color[][] pixels { get; }

        public Canvas(int width, int height)
        {
            this.width = width;
            this.height = height;
            pixels = new Color[height][];

            for (int i = 0; i < height; i++)
            {
                pixels[i] = new Color[width];

                Array.Fill(pixels[i], new Color(0, 0, 0));
            }
        }

        public void WritePixel(int x, int y, Color color)
        {
            pixels[y][x] = color;
        }

        public Color getPixel(int x, int y)
        {
            return pixels[y][x];
        }
    }
}

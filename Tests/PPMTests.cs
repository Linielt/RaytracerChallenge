using ClassLib.ColorDomain;
using ClassLib.PPMDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class PPMTests
    {
        string projDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
        [Fact]
        public void HeaderConstruction()
        {
            Canvas c = new(5, 3);
            PPMFormatter ppmFormatter = new PPMFormatter();
            string fileName = "header.ppm";

            ppmFormatter.CanvasToPPM(c, fileName);


            string[] pixelData;
            using (StreamReader sr = new StreamReader($@"{projDirectory}\Images\{fileName}"))
            {
                var wholeFile = sr.ReadToEnd();
                pixelData = wholeFile.Split(Environment.NewLine);
            }
            Assert.Equal("P3", pixelData[0]);
            Assert.Equal("5 3", pixelData[1]);
            Assert.Equal("255", pixelData[2]);
        }

        [Fact]
        public void PixelDataConstruction()
        {
            Canvas c = new(5, 3);
            Color c1 = new(1.5, 0, 0);
            Color c2 = new(0, 0.5, 0);
            Color c3 = new(-0.5, 0, 1);

            c.WritePixel(0, 0, c1);
            c.WritePixel(2, 1, c2);
            c.WritePixel(4, 2, c3);
            PPMFormatter ppmFormatter = new PPMFormatter();
            string fileName = "pixelData.ppm";

            ppmFormatter.CanvasToPPM(c, fileName);


            string[] pixelData;
            using (StreamReader sr = new StreamReader($@"{projDirectory}\Images\{fileName}"))
            {
                var wholeFile = sr.ReadToEnd();
                pixelData = wholeFile.Split(Environment.NewLine);
            }
            Assert.Equal("255 0 0 0 0 0 0 0 0 0 0 0 0 0 0", pixelData[3]);
            Assert.Equal("0 0 0 0 0 0 0 128 0 0 0 0 0 0 0", pixelData[4]);
            Assert.Equal("0 0 0 0 0 0 0 0 0 0 0 0 0 0 255", pixelData[5]);
        }

        [Fact]
        public void SplitLongLinesInPPMFiles()
        {
            Canvas c = new(10, 2);
            Color color = new(1, 0.8, 0.6);
            PPMFormatter ppmFormatter = new PPMFormatter();
            string fileName = "splitLongLines.ppm";

            for (int y = 0; y < 2; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    c.WritePixel(x, y, color);
                }
            }

            ppmFormatter.CanvasToPPM(c, fileName);

            string[] pixelData;
            using (StreamReader sr = new StreamReader($@"{projDirectory}\Images\{fileName}"))
            {
                var wholeFile = sr.ReadToEnd();
                pixelData = wholeFile.Split(Environment.NewLine);
            }

            Assert.Equal("255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204", pixelData[3]);
            Assert.Equal("153 255 204 153 255 204 153 255 204 153 255 204 153", pixelData[4]);
            Assert.Equal("255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204", pixelData[5]);
            Assert.Equal("153 255 204 153 255 204 153 255 204 153 255 204 153", pixelData[6]);
        }
    }
}

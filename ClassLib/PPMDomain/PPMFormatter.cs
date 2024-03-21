using ClassLib.ColorDomain;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.PPMDomain
{
    public class PPMFormatter
    {

        public void GetHeader(Canvas c, StreamWriter writer)
        {
            writer.WriteLine($"""
                P3
                {c.width} {c.height}
                255
                """);
        }

        public void GetPixelData(Canvas c, StreamWriter writer)
        {
            int lengthOfLine = 0;
            List<string> pixelData = new List<string>();

            for (int y = 0; y < c.height; y++)
            {
                for (int x = 0; x < c.width; x++)
                {
                    ColorDomain.Color pixel = c.getPixel(x, y);
                    double[] colors = { pixel.Red, pixel.Green, pixel.Blue };

                    for (int k = 0; k < colors.Length; k++)
                    {
                        colors[k] = Math.Ceiling(Math.Clamp(colors[k] * 255, 0, 255));

                        //if (x == c.width - 1 && k == 2)
                        //{
                        //    writer.Write(colors[k]);
                        //}
                        //else if ((lengthOfLine + colors[k].ToString().Length) > 70)
                        //{
                        //    writer.WriteLine();
                        //    writer.Write($"{colors[k]} ");
                        //    lengthOfLine = $"{colors[k]} ".Length;
                        //}
                        //else
                        //{
                        //    writer.Write($"{colors[k]} ");
                        //    lengthOfLine += $"{colors[k]} ".Length;
                        //}

                        if ((lengthOfLine + colors[k].ToString().Length + 1) >= 70)
                        {
                            string line = string.Join(" ", pixelData);
                            writer.WriteLine(line);
                            pixelData.Clear();
                            pixelData.Add(colors[k].ToString());
                            lengthOfLine = colors[k].ToString().Length + 1;
                        }
                        else
                        {
                            pixelData.Add(colors[k].ToString());
                            lengthOfLine += colors[k].ToString().Length + 1;
                        }
                    }
                }
                string terminatingLine = string.Join(" ", pixelData);
                writer.WriteLine(terminatingLine);
                pixelData.Clear();
                lengthOfLine = 0;
            }
        }

        public void CanvasToPPM(Canvas c, string fileName)
        {
            String projDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            if (!Directory.Exists($@"{projDirectory}\Images"))
            {
                Directory.CreateDirectory($@"{projDirectory}\Images");
            }

            using (StreamWriter writer = File.CreateText($@"{projDirectory}\Images\{fileName}"))
            {
                GetHeader(c, writer);
                GetPixelData(c, writer);
            }
        }
    }
}

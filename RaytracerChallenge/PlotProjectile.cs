using ClassLib.ColorDomain;
using ClassLib.Elements;
using ClassLib.PPMDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectileDemo
{
    public class PlotProjectile
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running");
            Point start = new(0, 1, 0);
            Vector velocity = new(1, 1.8, 0);
            velocity = velocity.Normalize() * 10.25;
            Projectile projectile = new(start, velocity);

            Vector gravity = new(0, -0.1, 0);
            Vector wind = new(-0.001, 0, 0);
            ClassLib.Elements.Environment environment = new(gravity, wind);

            Cannon cannon = new Cannon();

            Canvas canvas = new(900, 500);
            Color color = new(1, 0, 0);

            while (projectile.Position.Y > 0)
            {
                int canvasXCoord = (int) projectile.Position.X;
                int canvasYCoord = (int) (canvas.height - projectile.Position.Y);

                if (canvasXCoord >= 0 && canvasXCoord <= 900 &&
                    canvasYCoord >= 0 && canvasYCoord <= 500)
                {
                    canvas.WritePixel(canvasXCoord, canvasYCoord, color);
                }
                Console.WriteLine($"X: {canvasXCoord}, Y: {canvasYCoord}");
                projectile = cannon.tick(environment, projectile);
            }

            PPMFormatter ppmFormatter = new PPMFormatter();
            string fileName = "PlotProjectile.ppm";

            ppmFormatter.CanvasToPPM(canvas, fileName);
        }
    }
}

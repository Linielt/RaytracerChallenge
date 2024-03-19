using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Elements
{
    public class Projectile
    {
        public Point Position { get; }
        public Vector Velocity { get; }

        public Projectile(Point position, Vector velocity)
        {
            Position = position;
            Velocity = velocity;
        }
    }
}

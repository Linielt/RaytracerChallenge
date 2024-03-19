using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Elements
{
    public class Cannon
    {
        public Projectile tick(Environment env, Projectile proj)
        {
            Point newPosition = proj.Position + proj.Velocity;
            Vector newVelocity = proj.Velocity + env.Gravity + env.Wind;
            return new Projectile(newPosition, newVelocity);
        }
    }
}

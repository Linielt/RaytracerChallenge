using RaytracerChallenge.Elements;

// Projectile begins one unit above the origin.
// Velocity is normalized to 1 unit per tick.
Projectile p = new(new Point(0, 1, 0), new Vector(1, 1, 0).Normalize());

// Gravity is set to -0.1 units per tick and wind is set to -0.01 units per rick.
RaytracerChallenge.Elements.Environment e = new(new Vector(0, -0.1, 0), new Vector(-0.01, 0, 0));

Cannon cannon = new Cannon();

while (p.Position.Y > 0)
{
    Console.WriteLine($"X: {p.Position.X}, Y: {p.Position.Y}");
     p = cannon.tick(e, p);
}


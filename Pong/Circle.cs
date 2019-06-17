using System;
using Microsoft.Xna.Framework;

namespace Pong
{
    public struct Circle
    {
        public int X;
        public int Y;
        public int Radius;

        public bool Contains(Point point)
        {

            double distanceSquared = Math.Pow((point.X - X), 2) + Math.Pow((point.Y - Y), 2);
            return distanceSquared < (Radius * Radius);
        }

        public bool Intersects(Circle other)
        {
            double distanceSquared = Math.Pow((other.X - X), 2) + Math.Pow((other.Y - Y), 2);
            return distanceSquared <= Math.Pow(Radius + other.Radius,2);
        }

    }
}


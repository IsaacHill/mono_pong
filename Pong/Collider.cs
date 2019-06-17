using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Pong
{
    public static class Collider
    {
       

      
        
        public static bool RectangularCollision(Rectangle rectangleA, Rectangle rectangleB)
        {

            return rectangleA.Intersects(rectangleB);
        }

        public static bool RectangularCollision(Sprite spriteA, Sprite spriteB, out Vector2 normal)
        {
            normal = Vector2.Zero;
            if (!RectangularCollision(spriteA.Rectangle(), spriteB.Rectangle())) return false;

            Vector2 delta = spriteA.Position() - spriteB.Position();

            float halfHeight = spriteB.Rectangle().Height / 2;
            float halfWidth = spriteB.Rectangle().Width / 2;
            float absDeltaY = Math.Abs(delta.Y);
            float absDeltaX = Math.Abs(delta.X);

            //right side
            if (delta.X > 0 && absDeltaY <= halfHeight && spriteA.Position().X < 0) normal = new Vector2(1, 0);
            //left side
            if (delta.X < 0 && absDeltaY <= halfHeight && spriteB.Position().X > 0) normal = new Vector2(-1,0);
            //topside
            if  (delta.Y < 0 && absDeltaX <= halfWidth && spriteA.Position().Y > 0) normal = new Vector2(0,-1);
            //bottomside
            if (delta.Y > 0 && absDeltaX <= halfWidth && spriteA.Position().Y > 0) normal = new Vector2(0,1);


            return true;
        }

   
    }

}
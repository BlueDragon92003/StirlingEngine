using Microsoft.Xna.Framework;

namespace StirlingEngine.Framework.Colliders
{
    public class RectangleCollider : Collider
    {
        //  Properties  -------------------------------------------------------------------------------------------------------
        private Rectangle collisionRectangle;

        //  Constructors    ---------------------------------------------------------------------------------------------------
        public RectangleCollider(Point posistion, Point size)
        {
            collisionRectangle = new Rectangle(posistion - (size / new Point(2,2)), size);
        }

        //  Methods     -------------------------------------------------------------------------------------------------------
        public void MoveTo(Point center)
        {
            collisionRectangle.X = center.X - collisionRectangle.Width / 2;
            collisionRectangle.Y = center.Y - collisionRectangle.Height / 2;
        }
        
        /*      Name: CollidesWith
         *   Purpose: Checks if this collider collides with the given collider
         *   Precons: A valid Collider to check collision.
         *  Postcons: Returns if the colliders collide.
         */
        public bool CollidesWith(Collider collider)
        {
            switch(collider)
            {
                case RectangleCollider rc:
                    return CollidesWith(rc);
                default:
                    return collider.CollidesWith(this);
            }
        }

        /*      Name: CollidesWith (RectangleCollider)
         *   Purpose: Checks if this rectangle collider collides with the given rectangle collider
         *   Precons: A valid Rectangle Collider to check collision.
         *  Postcons: Returns if the colliders collide
         */
        private bool CollidesWith(RectangleCollider rectCollider)
        {
            return collisionRectangle.Intersects(rectCollider.collisionRectangle);
        }
    }
}

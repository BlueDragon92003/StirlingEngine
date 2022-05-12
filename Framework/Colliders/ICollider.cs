/*  Interface Collider
 *  
 *  Represents a shape that can be collided with.
 *  Requires a CollidesWith method, that takes another
 *  collider object and returns if the two colliders
 *  intersect.
 *  
 *  All colliders not provided by this engine must
 *  provide a system to collide with all existing
 *  colliders, due to how the system works.
 *  
 */

using Microsoft.Xna.Framework;

namespace StirlingEngine.Framework.Colliders
{
    public interface ICollider
    {
        /*      Name: CollidesWith
         *   Purpose: Checks if this collider collides with the given collider
         *   Precons: A valid Collider to check collision.
         *  Postcons: Returns if the colliders collide.
         */
        public bool CollidesWith(ICollider collider);

        /*      Name: MoveTo
         *   Purpose: Moves the collider to the specified point
         *   Precons: Point to move the collider to
         *  Postcons: A moved collider.
         */
        public void MoveTo(Point center);
    }
}

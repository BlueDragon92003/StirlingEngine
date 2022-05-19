/*  Interface ICollidable
 * 
 *  Something that can be
 *  collided with, but is
 *  not a collider itself.
 */

namespace StirlingEngine.Framework.Colliders
{
    public interface ICollidable : ICollider
    {
        public void OnCollision(ICollidable collidable);
    }
}

/*  Abstract Class Entity
 * 
 *  Entities are game objects that
 *  do not have a static position.
 *  They are used for enemies,
 *  players, some items, etc.
 * 
 */

using Microsoft.Xna.Framework;
using StirlingEngine.Framework.Colliders;

namespace StirlingEngine.Framework.GameObjects
{
    public abstract class Entity : GameObject
    {
        //  Constructors    ---------------------------------------------------------------------------------------------------
        protected Entity(Point position, Collider collider, Rectangle drawRectangle) : base(position, collider, drawRectangle) { }

        //  Methods     -------------------------------------------------------------------------------------------------------
        /*      Name: Move
         *   Purpose: Moves the Entity in and by the direction provided
         *   Precons: Point or Vector2 direction
         *  Postcons: Object moved
         */
        public void Move(Point direction)
        {
            Position += direction;
        }
        public void Move(Vector2 direction)
        {
            Position = new Point(
                Position.X + (int)direction.X,
                Position.Y + (int)direction.Y
                );
        }

        /*      Name: SetLocation
         *   Purpose: Sets the Entity's location to the point provided
         *   Precons: Point location
         *  Postcons: Object moved
         */
        public void SetLocation(Point location)
        {
            Position = location;
        }
    }
}

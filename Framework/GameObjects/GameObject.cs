/*  Abstract Class GameObject
 * 
 *  A Game Object is an object within the game.
 *  It can be collided with, drawn onto the screen,
 *  and holds a position.
 * 
 *  Properties:
 *      Collider collider
 *      Rectangle drawRectangle
 */

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StirlingEngine.Framework.Graphics;
using StirlingEngine.Framework.Colliders;

namespace StirlingEngine.Framework.GameObjects
{
   public  abstract class GameObject : Drawable
    {
        //  Properties  -------------------------------------------------------------------------------------------------------
        private Collider collider;  //  Object's collider object
        protected Rectangle drawRectangle;
        protected Point Position
        {
            get { return drawRectangle.Center; }
            set
            {
                collider.MoveTo(Position);
                drawRectangle.X = Position.X - drawRectangle.Width / 2;
                drawRectangle.Y = Position.Y - drawRectangle.Height / 2;
            }
        }

        //  Constructors    ---------------------------------------------------------------------------------------------------
        protected GameObject(Point position, Collider collider, Rectangle drawRectangle)
        {
            this.collider = collider;
            this.drawRectangle = drawRectangle;
            Position = position;
        }

        //  Methods     -------------------------------------------------------------------------------------------------------
        public abstract void Draw(SpriteBatch _spriteBatch);

        public bool CollidesWith(GameObject gameObject)
        {
            return collider.CollidesWith(gameObject.collider);
        }
    }
}

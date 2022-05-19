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
using StirlingEngine.Framework.Colliders;

namespace StirlingEngine.Framework.GameObjects
{
   public  abstract class GameObject : Graphics.IDrawable, ICollidable
    {
        //  Properties  -------------------------------------------------------------------------------------------------------
        private readonly ICollider collider;  //  Object's collider object
        protected Rectangle drawRectangle;
        public Point Position
        {
            get { return drawRectangle.Center; }
            set
            {
                collider.MoveTo(value);
                drawRectangle.X = value.X - drawRectangle.Width / 2;
                drawRectangle.Y = value.Y - drawRectangle.Height / 2;
            }
        }

        //  Constructors    ---------------------------------------------------------------------------------------------------
        protected GameObject(Point position, ICollider collider, Rectangle drawRectangle)
        {
            this.collider = collider;
            this.drawRectangle = drawRectangle;
            Position = position;
        }

        //  Methods     -------------------------------------------------------------------------------------------------------
        public abstract void Draw(SpriteBatch _spriteBatch, GameTime gameTime);

        public abstract void OnCollision(ICollidable collidable);

        public bool CollidesWith(ICollider collider)
        {
            return this.collider.CollidesWith(collider);
        }

        public void MoveTo(Point position)
        {
            Position = position;
        }
    }
}

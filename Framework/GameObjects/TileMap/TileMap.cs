/*  Abstract Class TileMap
 *  
 *  
 * 
 */

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StirlingEngine.Framework.Colliders;

namespace StirlingEngine.Framework.GameObjects.TileMap
{
    abstract class TileMap<T> : ICollidable, Graphics.IDrawable
    {
        protected Point position;    //  Top-Left
        protected Point tileSize;     //  Width & height of tiles

        public Point GetLocationOf(GameObject gameObject)
        {
            Point location = new Point(0, 0)
            {
                X = (gameObject.Position.X - position.X) / tileSize.X,
                Y = (gameObject.Position.Y - position.Y) / tileSize.Y
            };

            return location;
        }
        
        public abstract T GetItemAt(Point position);

        public abstract void SetItemAt(Point position, T item);

        public abstract bool CollidesWith(ICollider collider);

        public abstract void OnCollision(ICollidable collidable);

        public abstract void Draw(SpriteBatch _spriteBatch, GameTime gameTime);

        public void MoveTo(Point position)
        {
            this.position = position;
        }
    }
}

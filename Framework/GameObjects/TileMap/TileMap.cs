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
    abstract class TileMap<T> : GameObject
    {
        protected Point position;    //  Top-Left
        protected Point tileSize;     //  Width & height of tiles

        protected TileMap(Point position, TileMapCollider collider) : base(position, collider, new Rectangle(0, 0, 0, 0)) { }

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
    }
}

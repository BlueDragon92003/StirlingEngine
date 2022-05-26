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
        protected Point tileSize;     //  Width & height of tiles
        protected T[,] tiles;

        protected TileMap(Point position) : base(position, new TileMapCollider(Point.Zero, new Tile[0,0]), new Rectangle(0, 0, 0, 0)) { }

        public Point GetLocationOf(GameObject gameObject)
        {
            Point location = new Point(0, 0)
            {
                X = tiles.GetLength(1) / 2 + (gameObject.Position.X - Position.X) / tileSize.X,
                Y = tiles.GetLength(0) / 2 + (gameObject.Position.Y - Position.Y) / tileSize.Y
            };

            return location;
        }

        public void SetTiles(T[,] tiles)
        {
            this.tiles = tiles;
        }
        
        public abstract T GetItemAt(Point position);

        public abstract void SetItemAt(Point position, T item);
    }
}

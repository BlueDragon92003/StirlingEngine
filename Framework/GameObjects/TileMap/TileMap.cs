/*  Abstract Class TileMap
 *  
 *  
 * 
 */

using Microsoft.Xna.Framework;

namespace StirlingEngine.Framework.GameObjects.TileMap
{
    abstract class TileMap<T>
    {
        protected Point posistion;    //  Top-Left
        protected Point tileSize;     //  Width & height of tiles

        public Point GetLocationOf(GameObject gameObject)
        {
            Point location = new Point(0, 0);

            location.X = (gameObject.Position.X - posistion.X) / tileSize.X;
            location.Y = (gameObject.Position.Y - posistion.Y) / tileSize.Y;

            return location;
        }

        public abstract T GetItemAt(Point position);

        public abstract void SetItemAt(Point position, T item);
    }
}

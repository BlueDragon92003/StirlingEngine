using StirlingEngine.Framework.GameObjects.TileMap;
using Microsoft.Xna.Framework;

namespace StirlingEngine.Framework.Colliders
{
    class TileMapCollider : ICollider
    {
        private RectangleCollider[,] tileColliders;
        private Point TileSize;

        public TileMapCollider(Point tileSize, Tile[,] tiles)
        {

        }

        public Point GetPosition()
        {
            int x = tileColliders.GetLength(1) * TileSize.X;
            x /= 2;

            int y = tileColliders.GetLength(0) * TileSize.Y;
            y /= 2;

            return new Point(x, y);
        }

        public void MoveTo(Point position)
        {

        }

        public bool CollidesWith(ICollider collider)
        {
            bool hitSomething = false;

            foreach (RectangleCollider tile in tileColliders)
            {
                if (tile.CollidesWith(collider)) hitSomething = true;
            }

            return hitSomething;
        }
    }
}

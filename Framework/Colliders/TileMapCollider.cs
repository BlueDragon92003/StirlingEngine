using StirlingEngine.Framework.GameObjects;
using Microsoft.Xna.Framework;

namespace StirlingEngine.Framework.Colliders
{
    class TileMapCollider : ICollider
    {
        private ICollider[,] tileColliders;
        private Point tileSize;

        public TileMapCollider(Point tileSize, GameObject[,] tiles)
        {
            tileColliders = new ICollider[tiles.GetLength(0), tiles.GetLength(1)];

            for (int y = 0; y < tileColliders.GetLength(0); y++)
            {
                for (int x = 0; x < tileColliders.GetLength(1); x++)
                {
                    tileColliders[y, x] = tiles[y, x].GetCollider();
                }
            }

            this.tileSize = tileSize;
        }

        public Point GetPosition()
        {
            int x = tileColliders.GetLength(1) * tileSize.X;
            x /= 2;

            int y = tileColliders.GetLength(0) * tileSize.Y;
            y /= 2;

            return new Point(x, y);
        }

        public void MoveTo(Point position)
        {
            for (int y = 0; y < tileColliders.GetLength(0); y++)
            {
                for (int x = 0; x < tileColliders.GetLength(1); x++)
                {
                    tileColliders[y, x].MoveTo(new Point(
                        (int)((x - tileColliders.GetLength(1) / 2.0) * tileSize.X),
                        (int)((y - tileColliders.GetLength(0) / 2.0) * tileSize.Y)
                        ));
                }
            }
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

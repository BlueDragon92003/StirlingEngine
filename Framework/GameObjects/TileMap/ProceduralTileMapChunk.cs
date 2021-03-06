/*  Class Procdecural Tile Map Chunk
 *  
 *  A procedural tile map is a 
 *  tile map that generates itself
 *  based on a function, seed, and
 *  position.
 *  
 *  For memory concerns, procedural
 *  tile maps are broken into chunks
 *  that are generated, loaded, and
 *  unloaded. These are stored in an
 *  sparse array that represent the
 *  entire world.
 */

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StirlingEngine.Framework.Colliders;
using System;

namespace StirlingEngine.Framework.GameObjects.TileMap
{
    class ProceduralTileMapChunk : TileMap<Tile>
    {
        public ProceduralTileMapChunk(Point location, Point chunkSize, Point tileSize, Func<int, int, Point, Tile> getTile)
            : base (location * tileSize * chunkSize)
        {
            this.tileSize = tileSize;
            tiles = new Tile[chunkSize.X, chunkSize.Y];
            for (int y = 0; y < chunkSize.Y; y++)
            {
                for (int x = 0; x < chunkSize.X; x++)
                {
                    tiles[y, x] = getTile(location.X + x * tileSize.X, location.Y + y * tileSize.Y, tileSize);
                }
            }

            SetCollider(new TileMapCollider(tileSize, tiles));
        }

        public override Tile GetItemAt(Point position)
        {
            return tiles[position.X, position.Y];
        }

        public override void SetItemAt(Point position, Tile item)
        {
            tiles[position.Y, position.X] = item;
        }
        
        public override void OnCollision(GameObject collidable)
        {
            foreach (Tile tile in tiles)
            {
                if (tile.CollidesWith(collidable.GetCollider()))
                {
                    tile.OnCollision(collidable);
                }
            }
        }

        public override void Draw(SpriteBatch _spriteBatch, GameTime gameTime)
        {
            foreach (Tile tile in tiles)
            {
                tile.Draw(_spriteBatch, gameTime);
            }
        }
    }
}

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
using System;

namespace StirlingEngine.Framework.GameObjects.TileMap
{
    class ProceduralTileMapChunk : TileMap<Tile>
    {
        private readonly Tile[,] tiles;

        public ProceduralTileMapChunk(Point chunkSize, Point tileSize, Func<int, int, Point, Tile> getTile)
        {
            this.tileSize = tileSize;
            tiles = new Tile[chunkSize.X, chunkSize.Y];
            for (int y = 0; y < chunkSize.Y; y++)
            {
                for (int x = 0; x < chunkSize.X; x++)
                {
                    tiles[y, x] = getTile(x, y, tileSize);
                }
            }
        }

        public override Tile GetItemAt(Point position)
        {
            return tiles[position.X, position.Y];
        }

        public override void SetItemAt(Point position, Tile item)
        {
            tiles[position.Y, position.X] = item;
        }
    }
}

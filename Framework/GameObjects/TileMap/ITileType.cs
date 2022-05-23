/*  Interface ITileType
 * 
 *  Tile Types represent a type of tile;
 *  they possess a sprite and a method of
 *  handling collisions with it.
 * 
 */

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using StirlingEngine.Framework.Colliders;

namespace StirlingEngine.Framework.GameObjects.TileMap
{
    public interface ITileType
    {
        public Texture2D GetTexture(GameTime gameTime);

        public void Load(ContentManager contentManager);

        public void OnCollision(Tile tile, GameObject collidable);
    }
}

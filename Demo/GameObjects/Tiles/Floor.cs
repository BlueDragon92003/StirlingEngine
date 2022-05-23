using StirlingEngine.Framework.GameObjects;
using StirlingEngine.Framework.GameObjects.TileMap;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace StirlingEngine.Demo.GameObjects.Tiles
{
    class Floor : ITileType
    {
        public static Texture2D texture;

        public Floor(ContentManager contentManager)
        {
            Load(contentManager);
        }

        public void OnCollision(Tile tile, GameObject collidable) { }

        public Texture2D GetTexture(GameTime gameTime)
        {
            return texture;
        }

        public void Load(ContentManager contentManager)
        {
            texture = contentManager.Load<Texture2D>("floor");
        }
    }
}

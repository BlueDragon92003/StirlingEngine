using StirlingEngine.Framework.Colliders;
using StirlingEngine.Framework.GameObjects.TileMap;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace StirlingEngine.Demo.GameObjects.Tiles
{
    class Wall : ITileType
    {
        public static Texture2D texture;

        public Wall(ContentManager contentManager)
        {
            Load(contentManager);
        }

        public void OnCollision(ICollidable collidable) {

        }

        public Texture2D GetTexture(GameTime gameTime)
        {
            return texture;
        }

        public void Load(ContentManager contentManager)
        {
            texture = contentManager.Load<Texture2D>("wall");
        }
    }
}

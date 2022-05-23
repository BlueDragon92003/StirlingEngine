using StirlingEngine.Framework.GameObjects;
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

        public void OnCollision(Tile tile, GameObject collidable)
        {
            while(tile.CollidesWith(collidable.GetCollider()))
            {
                Vector2 directionVector = new Vector2(collidable.Position.X - tile.Position.X,
                   collidable.Position.Y - tile.Position.Y);
                directionVector = Vector2.Normalize(directionVector);

                
            }
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

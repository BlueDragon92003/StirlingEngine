using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StirlingEngine.Framework.Colliders;

namespace StirlingEngine.Framework.GameObjects.TileMap
{
    public class Tile : GameObject
    {
        private ITileType type;

        public Tile(Point position, Point size, ITileType type) : base (
            position,
            new RectangleCollider(position, size),
            new Rectangle(position - new Point(size.X / 2, size.Y / 2), size)
            )
        {
            this.type = type;
        }

        public override void Draw(SpriteBatch _spriteBatch, GameTime gameTime)
        {
            _spriteBatch.Draw(type.GetTexture(gameTime), drawRectangle, Color.White);
        }

        public void SetType(ITileType type)
        {
            this.type = type;
        }

        public override void OnCollision(GameObject collidable)
        {
            type.OnCollision(this, collidable);
        }
    }
}

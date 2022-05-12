using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StirlingEngine.Framework.Colliders;

namespace StirlingEngine.Framework.GameObjects.TileMap
{
    class Tile : GameObject
    {
        private ITileType type;

        public Tile(Point position, int size, ITileType type) : base (
            position,
            new RectangleCollider(position, new Point(size, size)),
            new Rectangle(position - new Point(size / 2, size / 2), new Point(size,size))
            )
        {
            this.type = type;
        }

        public override void Draw(SpriteBatch _spriteBatch, GameTime gameTime)
        {
            _spriteBatch.Draw(type.GetTexture(gameTime), drawRectangle, Color.White);
        }

        public void Collision(GameObject gameObject)
        {
            if (CollidesWith(gameObject))
            {
                gameObject.OnCollision(this);
                OnCollision(gameObject);
            }
        }

        public void SetType(ITileType type)
        {
            this.type = type;
        }

        public override void OnCollision(GameObject gameObject)
        {
            type.OnCollision(gameObject);
        }
    }
}

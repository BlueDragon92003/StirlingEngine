using StirlingEngine.Framework.GameObjects;
using StirlingEngine.Framework.Colliders;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StirlingEngine.Demo.GameObjects
{
    class BasicSquareItem : Entity
    {
        private readonly Texture2D texture;

        public BasicSquareItem(Point position, int size, Texture2D texture)
            : base(position,
            new RectangleCollider(position, new Point(size,size)),
            new Rectangle(position, new Point(size, size)))
        {
            this.texture = texture;
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(texture, drawRectangle, Color.White);
        }

    }
}

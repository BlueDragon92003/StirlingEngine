using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using StirlingEngine.Framework.GameObjects;
using StirlingEngine.Framework.Colliders;

namespace StirlingEngine.Demo.GameObjects
{
    public class Player : Entity
    {
        public Player(Point position, ICollider collider, Rectangle drawRectangle) : base (position, collider, drawRectangle)
        {

        }

        public override void Draw(SpriteBatch _spriteBatch, GameTime gameTime)
        {
            
        }

        public override void OnCollision(GameObject gameObject)
        {
            
        }
    }
}

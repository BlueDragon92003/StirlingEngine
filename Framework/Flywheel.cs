using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using StirlingEngine.Framework;
using StirlingEngine.Framework.Input;

namespace StirlingEngine.Framework
{
    public class Flywheel : Game
    {
        private GraphicsDeviceManager _graphics;
        private Scene scene;

        public Flywheel(Scene scene)
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            this.scene = scene;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            scene.Load(_graphics.GraphicsDevice, Content.ServiceProvider);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if(scene.IsLoaded())
            {
                scene = scene.Update(gameTime);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            if(scene.IsLoaded())
            {
                scene.Draw(gameTime);
            }

            base.Draw(gameTime);
        }
    }
}

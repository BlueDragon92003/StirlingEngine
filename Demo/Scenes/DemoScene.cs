using System.Threading;
using System;
using System.Collections.Generic;
using StirlingEngine.Framework;
using StirlingEngine.Framework.Graphics;
using StirlingEngine.Framework.Input;
using StirlingEngine.Demo.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace StirlingEngine.Demo.Scenes
{
    sealed class DemoScene : Scene
    {
        //  Content Management
        private ContentManager contentManager;
        private IList<string> content;

        //  Properties  -------------------------------------------------------------------------------------------------------
        private bool isLoaded;

        private KeyboardInputManager keyboardInputManager;

        private Camera camera;

        private BasicSquareItem playersquare;

        //  Methods    ---------------------------------------------------------------------------------------------------
        public void Load(GraphicsDevice graphics, IServiceProvider service)
        {
            contentManager = new ContentManager(service, "Content");
            Thread contentThread = new Thread(LoadContent);
            contentThread.Start();
            camera = new Camera(new Point(0, 0), graphics);
            keyboardInputManager = KeyboardInputManager.Instance;
            keyboardInputManager.registerKeyInput("left", Keys.A);
            keyboardInputManager.registerKeyInput("left", Keys.Left);
            keyboardInputManager.registerKeyInput("right", Keys.D);
            keyboardInputManager.registerKeyInput("right", Keys.Right);
            keyboardInputManager.registerKeyInput("up", Keys.W);
            keyboardInputManager.registerKeyInput("up", Keys.Up);
            keyboardInputManager.registerKeyInput("down", Keys.S);
            keyboardInputManager.registerKeyInput("down", Keys.Down);
        }

        private void LoadContent()
        {
            Texture2D squareTexture = contentManager.Load<Texture2D>("square");
            playersquare = new BasicSquareItem(new Point(0, 0), 60, squareTexture);
            isLoaded = true;
        }

        public void Unload()
        {
            Thread contentThread = new Thread(UnloadContent);
            contentThread.Start();
        }

        private void UnloadContent()
        {
            contentManager.Unload();
            isLoaded = false;
        }

        public bool IsLoaded()
        {
            return isLoaded;
        }

        public Scene Update(GameTime gameTime)
        {
            if (keyboardInputManager.getInputState("left") == KeyState.Down)    playersquare.Move(new Point(-1,  0));
            if (keyboardInputManager.getInputState("right") == KeyState.Down)   playersquare.Move(new Point( 1,  0));
            if (keyboardInputManager.getInputState("up") == KeyState.Down)      playersquare.Move(new Point( 0, -1));
            if (keyboardInputManager.getInputState("down") == KeyState.Down)    playersquare.Move(new Point( 0,  1));

            return this;
        }

        public void Draw(GameTime gameTime)
        {
            camera.setBackgroundColor(Color.CornflowerBlue);
            camera.AddItem(playersquare);
            camera.Draw();
        }
    }
}

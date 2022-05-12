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
        private bool oneLoaded;

        private KeyboardInputManager keyboardInputManager;

        private Camera camera;

        //  Methods    ---------------------------------------------------------------------------------------------------
        public void Load(GraphicsDevice graphics, IServiceProvider service)
        {
            contentManager = new ContentManager(service, "Content");
            Thread contentThread = new Thread(LoadContent);
            contentThread.Start();
            camera = new Camera(new Point(0, 0), graphics);
            if (oneLoaded) isLoaded = true; else oneLoaded = true;
        }

        private void LoadContent()
        {
            if (oneLoaded) isLoaded = true; else oneLoaded = true;
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
            return this;
        }

        public void Draw(GameTime gameTime)
        {
            camera.setBackgroundColor(Color.Black);
            camera.Draw(gameTime);
        }
    }
}

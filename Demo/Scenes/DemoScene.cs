using System.Threading;
using System;
using System.Collections.Generic;
using StirlingEngine.Framework;
using StirlingEngine.Framework.Graphics;
using StirlingEngine.Framework.Input;
using StirlingEngine.Framework.Noise;
using StirlingEngine.Framework.Colliders;
using StirlingEngine.Framework.GameObjects.TileMap;
using StirlingEngine.Demo.GameObjects.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using StirlingEngine.Demo.GameObjects;

using System.Diagnostics;

namespace StirlingEngine.Demo.Scenes
{
    sealed class DemoScene : Scene
    {
        //  Content Management
        private ContentManager contentManager;

        //  Properties  -------------------------------------------------------------------------------------------------------
        private bool isLoaded;
        private bool oneLoaded;

        private KeyboardInputManager keyboardInputManager;

        private Camera camera;

        private ProceduralTileMapChunk smallWorld;

        private Player player;

        //  Methods    ---------------------------------------------------------------------------------------------------
        public void Load(GraphicsDevice graphics, IServiceProvider service)
        {
            contentManager = new ContentManager(service, "Content");

            Thread contentThread = new Thread(LoadContent);
            contentThread.Start();

            camera = new Camera(new Point(0, 0), graphics);

            keyboardInputManager = new KeyboardInputManager();

            Point playerPosition = new Point(0);

            Point playerSize = new Point(40);
            player = new Player(playerPosition,
                new RectangleCollider(playerPosition, playerSize),
                new Rectangle(playerPosition, playerSize),
                contentManager,
                keyboardInputManager
                );

            if (oneLoaded) isLoaded = true; else oneLoaded = true;
        }

        private void LoadContent()
        {
            OpenSimplexNoise noise = new OpenSimplexNoise();
            Dictionary<byte, ITileType> tiles = new Dictionary<byte, ITileType>();
            tiles.Add(0, new Floor(contentManager));
            tiles.Add(1, new Wall(contentManager));

            smallWorld = new ProceduralTileMapChunk(new Point(-600), new Point(24), new Point(50), (x, y, size) =>
            {
                return new Tile(new Point(x, y), size,
                    noise.Evaluate(x / (double)size.X, y / (double)size.Y) < 0.1 ? tiles[0] : tiles[1]
                    );
            });

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
            keyboardInputManager.Update();

            player.Update(keyboardInputManager);

            camera.MoveTo(player.Position);

            return this;
        }

        public void Draw(GameTime gameTime)
        {
            camera.SetBackgroundColor(Color.Black);
            camera.AddItem(smallWorld);
            camera.AddItem(player);
            camera.Draw(gameTime);
        }
    }
}

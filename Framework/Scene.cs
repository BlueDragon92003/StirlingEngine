/*  abstract class Scene
 * 
 *  A screen is a section of a game,
 *  such as a Title Scene, Menu Scene,
 *  an actual game, a shop, etc.
 *  
 *  Each screen should be a subclass of
 *  Scene and should be loaded and
 *  unloaded in a new thread
 * 
 */

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StirlingEngine.Framework
{
    public interface Scene
    {
        /*      Name: Draw
         *   Purpose: Draws the content in the screen to the window
         *   Precons: Time since last draw
         *  Postcons: Content drawn
         */
        public void Draw(GameTime gameTime);

        /*      Name: Update
         *   Purpose: Updates the content in the screen
         *   Precons: The scene is loaded; the time elapsed since last update
         *  Postcons: Updated screen. Returns `this` to continue using the current screen, 
         *              or returns a new screen if the screen is changing
         */
        public Scene Update(GameTime gameTime);

        /*      Name: Load
         *   Purpose: Sets the scene up so it can be used. 
         *   Precons: A graphics device for the scene to use;
         *              All content the scene is used exists
         *              in the content folder.
         *  Postcons: The scene is ready to run.
         */
        public void Load(GraphicsDevice graphics, IServiceProvider service);

        /*      Name: Unload
         *   Purpose: Unloads the required content of the screen from memory
         *   Precons: The content is loaded
         *  Postcons: The content is unloaded from memory
         */
        public void Unload();

        /*      Name: IsLoaded
         *   Purpose: Returns if the content is loaded into or unloaded from memory
         *   Precons: None
         *  Postcons: If the content is loaded into or unloaded from memory
         */
        public bool IsLoaded();
    }
}

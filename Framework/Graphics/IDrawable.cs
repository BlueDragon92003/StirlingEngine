/*  Interface Drawable
 *  
 *  Represents an object that can be displayed to the screen.
 *  Requires a draw method, which takes a sprite batch.
 *  This sprite batch is used to draw the object in the method
 *  that the object requires.
 *  
 */

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StirlingEngine.Framework.Graphics
{
    public interface IDrawable
    {
        /*      Name: Draw
         *   Purpose: Draws the drawable object to the screen using the provided spritebatch
         *   Precons: A valid Sprite Batch to draw to
         *  Postcons: The object has been drawn to the screen.
         */
        public void Draw(SpriteBatch _spriteBatch, GameTime gameTime);
    }
}

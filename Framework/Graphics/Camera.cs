/*  Class Camera
 *  
 *  A camera object allows for displaying sprites to the screen.
 *  
 *  Properties:
 *      Point Position: X,Y position of the camera.
 *      List<Drawable> items: List of drawable items to be drawn to the screen
 *  
 *  Methods:
 *  AddItem
 *      Adds the drawable item to the list of items to be drawn.
 *  Draw
 *      Draws all content added to the screen.
 *  Move
 *      Adjusts the camera position by a provided Vector2
 *  MoveTo
 *      Sets the position of the camera.
 *      Takes a Point or GameObject to align to.
 *      
 */

using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StirlingEngine.Framework.Graphics
{
    public sealed class Camera
    {
        //  Properties  -------------------------------------------------------------------------------------------------------
        private Point position;
        private readonly List<IDrawable> items;
        private readonly SpriteBatch spriteBatch;
        private readonly GraphicsDevice graphicsDevice;

        private Color? bgColor;

        private SpriteSortMode sortMode;
        private BlendState blendState;
        private SamplerState samplerState;
        private DepthStencilState depthStencilState;
        private RasterizerState rasterizerState;
        private Effect effect;

        //  Constructors    ---------------------------------------------------------------------------------------------------
        public Camera(Point position, GraphicsDevice graphicsDevice, SpriteSortMode sortMode = SpriteSortMode.Deferred, BlendState blendState = null,
                        SamplerState samplerState = null, DepthStencilState depthStencilState = null, RasterizerState rasterizerState = null,
                        Effect effect = null)
        {
            this.position = position;
            items = new List<IDrawable>();
            this.graphicsDevice = graphicsDevice;
            spriteBatch = new SpriteBatch(graphicsDevice);

            this.sortMode = sortMode;
            this.blendState = blendState;
            this.samplerState = samplerState;
            this.depthStencilState = depthStencilState;
            this.rasterizerState = rasterizerState;
            this.effect = effect;
        }

        //  Methods     -------------------------------------------------------------------------------------------------------
        /*      Name: AddItem
         *   Purpose: Adds a provided drawable to the list of drawables to be drawn
         *   Precons: A valid Drawable to add to the list
         *  Postcons: Drawable added to the list.
         */
        public void AddItem(IDrawable item)
        {
            items.Add(item);
        }

        public void SetBackgroundColor(Color color)
        {
            bgColor = color;
        }

        /*      Name: Draw
         *   Purpose: Draws all items in the drawable list to the screen.
         *   Precons: None
         *  Postcons: All items in drawable list have been drawn and the list has been cleared.
         */
        public void Draw(GameTime gameTime)
        {
            Matrix transformMatrix = Matrix.CreateScale(1);
            transformMatrix *= Matrix.CreateTranslation(new Vector3(
                    graphicsDevice.Viewport.Width / 2 - position.X,
                    graphicsDevice.Viewport.Height / 2 - position.Y,
                    0
                ));

            //  Begin spritebatch with position centered on the screen
            spriteBatch.Begin(sortMode: sortMode, blendState: blendState, samplerState: samplerState, depthStencilState: depthStencilState,
                rasterizerState: rasterizerState, effect: effect,
                transformMatrix: transformMatrix
                );

            if (!(bgColor is null))
            {
                graphicsDevice.Clear((Color) bgColor);
            }

            foreach (IDrawable item in items)
            {
                item.Draw(spriteBatch, gameTime);
            }

            spriteBatch.End();

            items.Clear();
            bgColor = null;
        }

        public void MoveTo(Point location)
        {
            position = location;
        }

        public void MoveBy(Point direction)
        {
            position += direction;
        }

        public Point GetPosition()
        {
            return position;
        }
    }
}

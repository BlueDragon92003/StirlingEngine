using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using StirlingEngine.Framework.GameObjects;
using StirlingEngine.Framework.Input;
using StirlingEngine.Framework.Colliders;
using StirlingEngine.Framework;
using System;
using System.Diagnostics;

namespace StirlingEngine.Demo.GameObjects
{
    public class Player : Entity
    {
        private MoveState moveState;
        private ActionState actionState;
        
        private byte frame;
        private float player_anim_fps;
        private float speed;

        private Direction facing;
        private Direction moveDirection;

        private Texture2D spriteSheet;

        public Player(Point position, ICollider collider, Rectangle drawRectangle, ContentManager contentManager, KeyboardInputManager keyboardInputManager) : base (position, collider, drawRectangle)
        {
            speed = 5;
            frame = 0;

            player_anim_fps = 4;

            facing = Direction.Down;
            moveDirection = Direction.Down;

            spriteSheet = contentManager.Load<Texture2D>("characterSheet");

            keyboardInputManager.RegisterKeyInput("player_um", Keys.W);
            keyboardInputManager.RegisterKeyInput("player_uf", Keys.Up);
            keyboardInputManager.RegisterKeyInput("player_lm", Keys.A);
            keyboardInputManager.RegisterKeyInput("player_lf", Keys.Left);
            keyboardInputManager.RegisterKeyInput("player_dm", Keys.S);
            keyboardInputManager.RegisterKeyInput("player_df", Keys.Down);
            keyboardInputManager.RegisterKeyInput("player_rm", Keys.D);
            keyboardInputManager.RegisterKeyInput("player_rf", Keys.Right);

            keyboardInputManager.RegisterKeyInput("player_run", Keys.LeftShift);
            keyboardInputManager.RegisterKeyInput("player_mine", Keys.C);
        }

        public override void Draw(SpriteBatch _spriteBatch, GameTime gameTime)
        {
            Rectangle sourceRect = new Rectangle(0, 0, 16, 16);

            frame = (byte)(gameTime.ElapsedGameTime.TotalSeconds / player_anim_fps % (spriteSheet.Height / 16));

            sourceRect.X += 624 * (int)actionState;

            if (moveState != MoveState.Idle)
            {
                if (moveState == MoveState.Running)
                {
                    sourceRect.X += 320;
                }

                sourceRect.X += 64 * ((int)moveDirection + 1);
            }

            sourceRect.X += 16 * (int)facing;
            sourceRect.Y += 16 * frame;

            Debug.WriteLine(sourceRect);

            _spriteBatch.Draw(spriteSheet, drawRectangle, sourceRect, Color.White);
        }

        public override void OnCollision(GameObject gameObject)
        {
            
        }

        public void Update(KeyboardInputManager keyboardInputManager)
        {
            actionState = ActionState.Nothing;

            if (keyboardInputManager.GetInputState("player_mine") == KeyState.Down)
            {
                actionState = ActionState.Mining;
            }

            switch (actionState)
            {
                default:
                    break;
            }

            HandleMovement(keyboardInputManager);
        }

        private void HandleMovement(KeyboardInputManager keyboardInputManager)
        {
            Vector2 dir = new Vector2(0);

            moveState = MoveState.Idle;

            if (keyboardInputManager.GetInputState("player_um") == KeyState.Down)
            {
                dir += new Vector2(0, -1);
                moveDirection = Direction.Up;
                facing = Direction.Up;
                moveState = MoveState.Moving;
            }
            if (keyboardInputManager.GetInputState("player_dm") == KeyState.Down)
            {
                dir += new Vector2(0, 1);
                moveDirection = Direction.Down;
                facing = Direction.Down;
                moveState = MoveState.Moving;
            }
            if (keyboardInputManager.GetInputState("player_lm") == KeyState.Down)
            {
                dir += new Vector2(-1, 0);
                moveDirection = Direction.Left;
                facing = Direction.Left;
                moveState = MoveState.Moving;
            }
            if (keyboardInputManager.GetInputState("player_rm") == KeyState.Down)
            {
                dir += new Vector2(1, 0);
                moveDirection = Direction.Right;
                facing = Direction.Right;
                moveState = MoveState.Moving;
            }

            if (keyboardInputManager.GetInputState("player_uf") == KeyState.Down) { facing = Direction.Up; }
            if (keyboardInputManager.GetInputState("player_df") == KeyState.Down) { facing = Direction.Down; }
            if (keyboardInputManager.GetInputState("player_lf") == KeyState.Down) { facing = Direction.Left; }
            if (keyboardInputManager.GetInputState("player_rf") == KeyState.Down) { facing = Direction.Right; }

            if (dir != Vector2.Zero)
            {
                dir = Vector2.Normalize(dir) * speed;

                if (facing != moveDirection)
                {
                    if (facing.IsPerpendicular(moveDirection))
                    {
                        dir *= new Vector2(0.7f);
                    }
                    dir *= new Vector2(0.7f);
                }

                if (keyboardInputManager.GetInputState("player_run") == KeyState.Down)
                {
                    moveState = MoveState.Running;
                    dir *= new Vector2(1.3f);
                }
            }

            MoveBy(new Point((int)dir.X, (int)dir.Y));
        }

        public enum ActionState
        {
            Nothing,
            Mining,
        }

        public enum MoveState
        {
            Idle,
            Moving,
            Running,
        }
    }
}

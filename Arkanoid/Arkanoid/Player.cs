using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arkanoid
{
    public class Player
    {

        public const int width = 53;
        public const int height = 10;
        const int distFromWindowBottom = 50;
        private readonly float speed;
        const String spriteTexture = @"Images/player";

        private int score = 0;
        public int Lives {get ; set; }


        Game1 game;
        public Vector2 position;

        private Texture2D sprite;
        private Rectangle rectangle;
        private Rectangle frameTwoRectangle; //The frame on the spritesheet where paddle is glowing
        private int currentAnimationFrame;

        public Player(Game1 game)
        {
            this.game = game;
            
            speed = game.GameManager.playerSpeedDefault;
            sprite = game.Content.Load<Texture2D>(spriteTexture);
            rectangle = new Rectangle(0, 0,
                width,
                height);

            frameTwoRectangle = new Rectangle(0, height,
                width,
                2*height);

            currentAnimationFrame = 0;

        }



        public void SetPos(float x, float y)
        {
            position.X = x;
            position.Y = y;
            IsOutOfBounds();
            if (!game.Ball.Launched)
                game.Ball.Position = GetBallStartingPos();
        }
        public void MoveOnXAxis(float distance)
        {
            position.X += distance;
            if (IsOutOfBounds()) return; //return so we wont move the ball if 

            if (!game.Ball.Launched)
                game.Ball.MoveOnXAxis(distance);
        }

        Vector2 GetDefaultPos()
        {
            return new Vector2(
                (game.Window.ClientBounds.Width / 2) - (width / 2),
                (game.Window.ClientBounds.Height - distFromWindowBottom) - (height / 2));
        }

        public void ResetPosition()
        {
            position = GetDefaultPos();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(
                sprite, Position, rectangle, Color.White,
                0, Vector2.Zero, 1, SpriteEffects.None, 0);
            Animate();
        }

        /** Shifts the source rectangle of the sprite */
        private void Animate()
        {
            if ((currentAnimationFrame + 1) % 10 == 0)
            {
                //Update animation frame
                if (currentAnimationFrame < 50)
                    rectangle.Offset(0, height);
                else
                    rectangle.Offset(0, -height);
            }
            currentAnimationFrame++;
            if (currentAnimationFrame > 90)
            {
                currentAnimationFrame = 0;
                (rectangle.Y) = 0;
            }
        }

        /** Returns whether or not we're touching a window wall. Also 
         * ensures we dont go through the wall */
        private bool IsOutOfBounds()
        {
            //Check that we dont move out of the window
            if (position.X < 0)
            {
                position.X = 0;
                return true;
            }
            else if (position.X > game.GameArea.Width - width)
            {
                position.X = game.GameArea.Width - width;
                return true;
            }
            return false;
        }

        /** Returns the Coordinates where the ball would be positioned
         * at the center of the plaeyer's racket. */
        public Vector2 GetBallStartingPos()
        {
            return new Vector2(position.X + (width / 2) - (Ball.width / 2),
                position.Y - Ball.height);
        }


        public int Score
        {
            get { return score; }
            set { score = value; }
        }
        public float Speed
        {
            get { return speed; }
        }
        public Vector2 Position
        {
            get { return position; }
        }

    }
}

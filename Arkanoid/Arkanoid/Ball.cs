using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arkanoid
{
    public class Ball
    {
        const int speed = 4;
        const String spriteTexture = @"Images/ball"; 
        public const int width = 8;
        public const int height = 8;
        public enum CollidedSide {TopBottom, LeftRight, None};

        Vector2 position;
        Vector2 angle;
        Game1 game;

        private bool launched;
        private bool falling;
        private Texture2D sprite;
        private Rectangle rectangle;
        Rectangle collisionRect;

        public Ball(Game1 game, Vector2 position)
        {
            this.game = game;
            this.position = position;
            
            falling = false;
            launched = false;
            Sprite = game.Content.Load<Texture2D>(spriteTexture);

            collisionRect = new Rectangle(
                (int) position.X,
                (int) position.Y,
                width,
                height);

            rectangle = new Rectangle(0, 0,
                width,
                height);
        }

        public void Launch()
        {
            launched = true;
            falling = false;
            angle = new Vector2(speed, -speed);

        }

        /** checks if we're hitting something, and if so,
         * bounces (changes the balls movement direction)
         * */
        public void CheckCollisions()
        {
            //Wall (window) bounces
            if (position.X < game.GameArea.X)
            {
                position.X = game.GameArea.X;
                angle.X = -angle.X;
            }
            else if (position.X > game.GameArea.Width - width)
            {
                position.X = game.GameArea.Width - width;
                angle.X = -angle.X;
            }
            if (position.Y < game.GameArea.Y)
            {
                position.Y = game.GameArea.Y;
                angle.Y = -angle.Y;
            }
            if (falling && position.Y > game.Window.ClientBounds.Height)
            {
                game.LostBall();
                return;
            }
            // Collisions with Cells
            CollidedSide CellCollision = game.Cells.CollisionWith(this);
            if (CellCollision != CollidedSide.None)
            {
                if (CellCollision == CollidedSide.TopBottom)
                    angle.Y = -angle.Y;
                else
                    angle.X = -angle.X;
            }

            //Racket collisions
            else if (position.Y + height > game.Player.Position.Y) //if were on level with the racket
            {
                if (!falling && HitRacket())
                {
                    //The ball hit the player's racket, bounce it back
                    position.Y = game.Player.Position.Y - height;

                    float racketCenter = game.Player.Position.X + (Player.width / 2);
                    float ballCenter = position.X + (width / 2);
                    float normalizedDistance = Math.Abs(ballCenter - racketCenter) / (Player.width / 2);
                    
                    if (angle.X < 0)
                        angle.X = -game.GameManager.playerSpeedDefault * normalizedDistance;
                    else
                        angle.X = game.GameManager.playerSpeedDefault* normalizedDistance;

                    angle.Y = (game.GameManager.playerSpeedDefault - normalizedDistance) *-1;
                }
                else
                {
                    //The player wasnt able to catch the ball, 
                    //mark the ball as falling out of bounds
                    falling = true;
                }
            }
        }

        /** Returns whether the ball has hit the player's racket */
        private bool HitRacket()
        {
            return (position.X + width > game.Player.Position.X && 
                position.X < game.Player.Position.X + Player.width);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Sprite, position, Color.White);
        }

        public void Move()
        {
            position += angle;
            collisionRect.X = (int) position.X;
            collisionRect.Y = (int) position.Y;
            CheckCollisions();
        }

        /** Sets the ball's position in the
         *  middle of the players paddle */
        public void Reset(Player player)
        {
            launched = false;
            falling = false;
            position = player.GetBallStartingPos();
        }

        public void MoveOnXAxis(float distance)
        {
            position.X += distance;
        }

        public Rectangle Rectangle
        {
            get { return rectangle; }
        }

        public float Speed
        {
            get { return speed; }
        }
        public Rectangle CollisionRect
        {
            get { return collisionRect; }
        }

        public Boolean Launched
        {
            get { return launched; }
            set { launched = value; }
        }
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public Texture2D Sprite
        {
            get { return sprite; }
            set { sprite = value; }
        }
    }
}

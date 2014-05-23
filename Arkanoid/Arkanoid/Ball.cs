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
        public const int width = 8;
        public const int height = 8;

        int curXSpeed;
        int curYSpeed;

        Vector2 position;
        Game1 game;

        private bool launched;
        private bool falling;
        private Texture2D sprite;
        private Rectangle rectangle;

        public Ball(Game1 game, Vector2 position)
        {
            this.game = game;
            this.position = position;
            
            falling = false;
            launched = false;

            rectangle = new Rectangle(0, 0,
                width,
                height);
        }

        public void Launch()
        {
            launched = true;
            curXSpeed = speed;
            curYSpeed = -speed; //negative because we launch the ball "up", not down
        }

        /** checks if we're hitting something, and if so,
         * bounces (changes the balls movement direction)
         * */
        public void CheckCollisions()
        {
            if (position.X < 0)
            {
                position.X = 0;
                curXSpeed = -curXSpeed;
            }
            else if (position.X > game.Window.ClientBounds.Width - width)
            {
                position.X = game.Window.ClientBounds.Width - width;
                curXSpeed = -curXSpeed;
            }

            if (position.Y < 0)
            {
                position.Y = 0;
                curYSpeed = -curYSpeed;
            }

            if (falling)
            {
                if (position.Y > game.Window.ClientBounds.Height)
                    game.LostBall();
            }

            else if (position.Y + height > game.Player.Position.Y)
            {
                if (position.X + width >= game.Player.Position.X &&
                    position.X <= game.Player.Position.X + Player.width)
                {
                    //The ball hit the player's racket, bounce it back
                    position.Y = game.Player.Position.Y - height;
                    curYSpeed = -curYSpeed;
                }
                else
                {
                    //The player wasnt able to catch the ball, mark the ball as falling
                    falling = true;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Sprite, Position, Color.White);
        }

        public void Move()
        {
            position.X += curXSpeed;
            position.Y += curYSpeed;
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


        public Vector2 Position
        {   
            get { return position; }
            set { position = value; }
        }

        public Rectangle Rectangle
        {
            get { return rectangle; }
        }

        public float Speed
        {
            get { return speed; }
        }



        public Boolean Launched
        {
            get { return launched; }
            set { launched = value; }
        }

        public Texture2D Sprite
        {
            get { return sprite; }
            set { sprite = value; }
        }
    }
}

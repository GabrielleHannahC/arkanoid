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
        //These determine which portion of the texture png to load,
        //and thus the general dimensions of the player
        public const int width = 32;
        public const int height = 8;
        public const float speed = 2;

        int score = 0;
        int lives = 3;


        Game1 game;
        public Vector2 position;

        private Texture2D sprite;
        private Rectangle rectangle;

        

        public Player(Game1 game, float x, float y)
        {
            this.game = game;
            position = new Vector2(x, y);

            rectangle = new Rectangle(0, 0,
                width,
                height);

        }

        public Rectangle Rectangle
        {
            get { return rectangle; }
        }

        public float Speed
        {
            get { return speed; }
        }

        public Vector2 Position
        {
            get { return position; }
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
            else if (position.X > game.Window.ClientBounds.Width - width)
            {
                position.X = game.Window.ClientBounds.Width - width;
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


        public Texture2D Sprite
        {
            get { return sprite; }
            set { sprite = value; }
        }

        public int Lives
        {
            get { return lives; }
            set { lives = value; }
        }
    }
}

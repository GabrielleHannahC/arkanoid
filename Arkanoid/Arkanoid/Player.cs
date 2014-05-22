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
            set
            {
                position = value;
                checkIfOutOfBounds();
            }
        }

        public void moveOnXAxis(float distance)
        {
            position.X += distance;
            checkIfOutOfBounds();
        }

        private void checkIfOutOfBounds()
        {
            //Check that we dont move out of the window
            if (position.X < 0)
                position.X = 0;
            else if (position.X > game.Window.ClientBounds.Width - width)
                position.X = game.Window.ClientBounds.Width - width;
        }

        public Vector2 GetBallStartPos()
        {
            return new Vector2(position.X + width / 2,
                position.Y);
        }


        public Texture2D Sprite
        {
            get { return sprite; }
            set { sprite = value; }
        }

    }
}

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
        const float speed = 2;

        int score = 0;
        int lives = 3;

        float posX;
        float posY;


        Game1 game;
        //public Vector2 position;

        private Texture2D sprite;
        private Rectangle rectangle;

        

        public Player(Game1 game, int x, int y)
        {
            this.game = game;
            posX = x;
            posY = y;
            //position = new Vector2(x, y);

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

        //public vector2 position
        //{
        //    get { return position; }
        //    set { position = value; }
        //}

        public float PosX
        {
            get { return posX; }
            set
            {
                System.Diagnostics.Debug.WriteLine("Setting PosX");
                posX = value;
                //Check that we dont move out of the window
                if (posX < 0) posX = 0;
                if (posX > game.Window.ClientBounds.Width - width)
                    posX = game.Window.ClientBounds.Width - width;
            }
        }

        public float PosY
        {
            get { return posY; }
            set { posY = value; }
        }


        public Texture2D Sprite
        {
            get { return sprite; }
            set { sprite = value; }
        }

    }
}

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

        public Vector2 position;

        private Texture2D sprite;
        private Rectangle rectangle;

        

        public Player(int x, int y)
        {
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

        public Texture2D Sprite
        {
            get { return sprite; }
            set { sprite = value; }
        }

    }
}

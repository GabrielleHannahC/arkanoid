using System;
namespace Arkanoid
{
    public class Player
    {

        int score = 0;
        int lives = 3;

        int playerX;
        int playerY;

        private Texture2D sprite;

        public Texture2D Sprite
        {
            get { return sprite; }
        }


        public Player()
        {
        }


    }
}
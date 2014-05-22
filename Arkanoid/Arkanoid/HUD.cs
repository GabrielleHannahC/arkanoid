﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arkanoid
{
    public class HUD
    {
        private Vector2 scorePos = new Vector2(20, 10);
        private Vector2 livesPos = new Vector2(120, 10);
        public SpriteFont Font { get; set; }

        public int Score { get; set; }
        public int Lives { get; set; }
        Game1 game;

        public HUD(Game1 game)
        {
            this.game = game;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw the Score in the top-left of screen
            spriteBatch.DrawString(
                Font,
                "Score: " + Score.ToString(),
                scorePos,
                Color.White);

            // Draw Lives
            spriteBatch.DrawString(
                Font,
                "LIVES: " + Lives.ToString(),
                livesPos,
                Color.White);
        }
    }
}
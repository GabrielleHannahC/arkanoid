using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arkanoid
{
    class Cell
    {
        const String spriteTexture = @"Images/cell"; 

        public Texture2D Sprite { get; set; }
        Vector2 Position { get; set; }

        Game1 game;

        public Cell(Game1 game, Vector2 position)
        {
            this.game = game;
            this.Position = position;

            Sprite = game.Content.Load<Texture2D>(spriteTexture);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Sprite, Position, Color.White);
        }
    }
}

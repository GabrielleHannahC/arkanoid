using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arkanoid
{
    public class Cell
    {
        const String spriteTexture = @"Images/cells"; 

        public static Texture2D Sprite { get; set; }
        Vector2 Position { get; set; }
        Rectangle rectangle;
        public const int height = 32;
        public const int width = 64;

        Game1 game;

        public Cell(Game1 game, Vector2 position)
        {
            this.game = game;
            this.Position = position;
            rectangle = new Rectangle(0, 0, width, height);

            Sprite = game.Content.Load<Texture2D>(spriteTexture);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                Sprite, Position, rectangle, Color.White,
                0, Vector2.Zero, 1, SpriteEffects.None, 0);
        }
    }
}

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
        public Vector2 Position { get; set; }
        Rectangle rectangle;
        public const int height = 16;
        public const int width = 32;

        Rectangle collisionRect;
        Game1 game;

        public Cell(Game1 game, Vector2 position, bool alternateColor)
        {
            this.game = game;
            this.Position = position;
            rectangle = new Rectangle(0, 0, width, height);
            if (alternateColor)
                rectangle.Y+=height;

            collisionRect = new Rectangle(
                (int)position.X,
                (int)position.Y,
                width,
                height);

            Sprite = game.Content.Load<Texture2D>(spriteTexture);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                Sprite, Position, rectangle, Color.White,
                0, Vector2.Zero, 1, SpriteEffects.None, 0);
        }

        public Rectangle CollisionRect
        {
            get { return collisionRect; }
        }
    }
}

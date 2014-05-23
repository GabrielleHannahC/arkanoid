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

        public Texture2D Sprite { get; set; }
        public Rectangle rectangle;
        Vector2 position;

        Game1 game;

        public Cell(Game1 game, Vector2 position)
        {
            this.game = game;
            this.position = position;
        }
    }
}

using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arkanoid
{
    class CellSet
    {
        ArrayList Cells { get; set; }
        Game1 game;

        public CellSet(Game1 game)
        {
            this.game = game;
        }

        public void InitializeTextures()
        {
            foreach (Cell c in Cells)
            {
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(Sprite, Position, Color.White);
        }
    }
}

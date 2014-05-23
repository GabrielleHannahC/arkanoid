using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arkanoid
{
    public class CellSet
    {
        Cell[][] Cells;
        Game1 game;
        Vector2 position;
        int rows;
        int cols;

        public CellSet(Game1 game, Vector2 position, int rows, int cols)
        {
            this.position = position;
            this.game = game;
            this.rows = rows;
            this.cols = cols;

            Cells = new Cell[rows][];
            for (int i = 0; i < rows; i++)
            {
                Cells[i] = new Cell[cols];
                for (int j = 0; j < cols; j++)
                {
                    Cells[i][j] = new Cell(
                        game,
                        position + new Vector2(
                            j * Cell.width, i * Cell.height));
                }
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (Cells[i][j]!=null)
                    {
                        Cells[i][j].Draw(spriteBatch);

                    }
                }
            }
        }
    }
}

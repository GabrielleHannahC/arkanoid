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
        public int CellsAlive { get; set; }

        public CellSet(Game1 game, int rows, int cols)
        {
            this.game = game;
            this.rows = rows;
            this.cols = cols;
            if (this.cols > 10) this.cols = 10; // Hardcode - ensure we dont add more cols
                                                // than the current window size

                        //Calculate where to start drawing the cells
            //so that the cell matrix would be center-aligned.
            int topLeft = (game.GameArea.Width - (cols * Cell.width)) / 2;

            position = new Vector2(topLeft, HUD.height + 40);
            CellsAlive = rows * cols;

            Cells = new Cell[rows][];
            for (int i = 0; i < rows; i++){
                Cells[i] = new Cell[cols];
                for (int j = 0; j < cols; j++){
                    bool alternateColor = ((i % 2) == 1);
                    Cells[i][j] = new Cell(
                        game,
                        position + new Vector2(
                            j * Cell.width, i * Cell.height),
                        alternateColor);
                }
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < rows; i++){
                for (int j = 0; j < cols; j++){
                    if (Cells[i][j]!=null)
                    {
                        Cells[i][j].Draw(spriteBatch);
                    }
                }
            }
        }

        internal Ball.CollidedSide CollisionWith(Ball ball)
        {
            Ball.CollidedSide result = Ball.CollidedSide.None;
            for (int i = 0; i < rows; i++){
                for (int j = 0; j < cols; j++) {
                    if (Cells[i][j] != null)
                    {
                        if (Cells[i][j].CollisionRect.Intersects(
                            ball.CollisionRect))
                        {
                            //See which side of the cell we hit
                            if (Cells[i][j].CollisionRect.Top < ball.CollisionRect.Top &&
                                Cells[i][j].CollisionRect.Bottom >= ball.CollisionRect.Bottom)
                                result = Ball.CollidedSide.LeftRight;
                            else
                                result = Ball.CollidedSide.TopBottom;

                            Cells[i][j] = null;
                            game.Player.Score += game.ConfigManager.scorePerCellDefault;
                            CellsAlive--;

                            return result;
                        }
                    }
                }
            }
            return result;
        }
    }
}

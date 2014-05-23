using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Arkanoid
{
    public class HUD
    {
        public const int height = 50;

        private Vector2 scorePos = new Vector2(20, 10);
        private Vector2 livesPos = new Vector2(110, 10);
        private Vector2 hiscorePos = new Vector2(190, 10);
        public SpriteFont Font { get; set; }

        public int Score { get; set; }
        Game1 game;

        public HUD(Game1 game)
        {
            this.game = game;
            Font = game.Content.Load<SpriteFont>("Arial");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw the Score in the top-left of screen
            spriteBatch.DrawString(
                Font,
                "Score: " + game.Player.Score.ToString(),
                scorePos,
                Color.White);

            // Draw Lives
            spriteBatch.DrawString(
                Font,
                "LIVES: " + game.Player.Lives.ToString(),
                livesPos,
                Color.White);

            // Draw Hi-SCore
            spriteBatch.DrawString(
                Font,
                "HI-SCORE: " + ConfigManager.highscore.ToString(),
                hiscorePos,
                Color.White);
        }

        /** Shows the game over dialog */
        public void LoadDialog(String Message)
        {
            DialogResult dialogResult = MessageBox.Show(
                "Play Again?",
                Message,
                MessageBoxButtons.YesNo
                );

            if (dialogResult == DialogResult.Yes)
            {
                game.Restart();
            }
            else if (dialogResult == DialogResult.No)
            {
                game.Exit();
            }
        }
    }
}

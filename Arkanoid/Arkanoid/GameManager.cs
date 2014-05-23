using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace Arkanoid
{
    class GameManager
    {
        const String configPath = @"Content\gameconfig.xml";

        Game1 game;

        public GameManager(Game1 game)
        {
            this.game = game;
            StartNewGame();
        }


        void StartNewGame()
        {
            LoadGameConfig();
            game.Player.ResetPosition();
        }


        void LoadGameConfig()
        {
            if (File.Exists(configPath))
            {

                XmlDocument doc = new XmlDocument();
                doc.Load(configPath);
                XmlNode configNode = doc.SelectSingleNode("/Conf");

                int playerLives = Int32.Parse(configNode["playerlives"].InnerText);
                int scorePerCell = Int32.Parse(configNode["points_per_cell"].InnerText);
                int cellRows = Int32.Parse(configNode["no_of_cell_rows"].InnerText);

                game.Player.Lives = playerLives;

            } else
            {
              
            }
        }






    }



}

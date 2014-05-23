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
        public readonly int playerLivesDefault;
        public readonly int cellRowsDefault;
        public readonly int cellColsDefault =5; //hardcode
        public readonly int scorePerCellDefault;

        Game1 game;

        public GameManager(Game1 game)
        {
            this.game = game;
            XmlNode conf = LoadConfig();
            playerLivesDefault = Int32.Parse(conf["playerlives"].InnerText);
            scorePerCellDefault = Int32.Parse(conf["points_per_cell"].InnerText);
            cellRowsDefault = Int32.Parse(conf["no_of_cell_rows"].InnerText);

            
        }


        public void StartNewGame()
        {
            
            game.Player.ResetPosition();
        }


        XmlNode LoadConfig()
        {
            if (File.Exists(configPath))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(configPath);
                return doc.SelectSingleNode("/Conf");
            } else
            {
              return null;
            }
        }






    }



}

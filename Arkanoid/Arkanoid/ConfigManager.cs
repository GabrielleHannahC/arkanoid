using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace Arkanoid
{
    public class ConfigManager
    {
        const String configPath = "gameconfig.xml";
        public readonly int playerLivesDefault;
        public readonly int playerSpeedDefault;
        public readonly int cellRowsDefault;
        public readonly int cellColsDefault;
        public readonly int scorePerCellDefault;
        public static int highscore;

        Game1 game;

        public ConfigManager(Game1 game)
        {
            this.game = game;
            XmlNode conf = LoadConfig();

            playerLivesDefault = Int32.Parse(conf["playerlives"].InnerText);
            playerSpeedDefault = Int32.Parse(conf["playerspeed"].InnerText);
            scorePerCellDefault = Int32.Parse(conf["points_per_cell"].InnerText);
            cellRowsDefault = Int32.Parse(conf["no_of_cell_rows"].InnerText);
            cellColsDefault = Int32.Parse(conf["no_of_cell_cols"].InnerText);

            highscore = Int32.Parse(conf["highscore"].InnerText);
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

        public void WriteHighScore(int score)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(configPath);
            doc.SelectSingleNode("/Conf")["highscore"].InnerText = score.ToString();
            doc.Save(configPath);
            highscore = score;
        }
    }
}

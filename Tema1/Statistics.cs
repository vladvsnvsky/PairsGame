using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tema1
{
    [Serializable]
    [XmlRoot("Stats")]
    public class Statistics
    {
        [XmlElement("ConsecutiveGamesWon")]
        public int consecutive_games_won = 0;

        [XmlElement("GamesPlayed")]
        public int games_played = 0;

        [XmlElement("GamesWon")]
        public int games_won = 0;

        public Statistics()
        {

        }

        public Statistics(int param1, int param2, int param3)
        {
            consecutive_games_won = param1;
            games_played = param2;
            games_won = param3;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tema1
{
    [Serializable]
    [XmlRoot("List")]
    public class PlayersList
    {
        [XmlElement("Players")]
        public List<Player> Players; 

        public PlayersList()
        {
        }

        public PlayersList(List<Player> players)
        {
            this.Players = players;
        }
    }
}

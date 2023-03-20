using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tema1
{
    [Serializable]
    [XmlRoot("PlayerDetails")]
    public class Player
    {
        [XmlElement("PlayerName")]
        public string Name { get; set; }
        [XmlElement("PlayerProfilePicturePath")]
        public string ProfilePicturePath { get; set; }

        [XmlElement("Board")] public Board savedGame { get; set; }
    }
}

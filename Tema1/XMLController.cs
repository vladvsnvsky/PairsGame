using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tema1
{
    class XMLController
    {
        public static void SerializePlayersToXmlFile(List<Player> _playerList, string location)
        {
            var playerList = _playerList;

            var xmlSerializer = new XmlSerializer(typeof(List<Player>));

            using (var writer = new StreamWriter(location))
            {
                xmlSerializer.Serialize(writer, playerList);
            }
        }

        public static void SerializePlayersToXmlFile(List<Player> _playerList)
        {
            var playerList = _playerList;

            var xmlSerializer = new XmlSerializer(typeof(List<Player>));

            using (var writer = new StreamWriter(@"D:\FACULTATE\Facultate\An_2_sem_2\MVP_MediiVisualeDeProgramare\PairsGame\Tema1\Assets\players.xml"))
            {
                xmlSerializer.Serialize(writer, playerList);
            }
        }

        public static void SerializePlayersToXmlFile(PlayersList _playerList, string location)
        {
            var playerList = _playerList;

            var xmlSerializer = new XmlSerializer(typeof(PlayersList));

            using (var writer = new StreamWriter(location))
            {
                xmlSerializer.Serialize(writer, playerList);
            }
        }

        public static void SerializePlayersToXmlFile(PlayersList _playerList)
        {
            var playerList = _playerList;

            var xmlSerializer = new XmlSerializer(typeof(PlayersList));

            using (var writer = new StreamWriter(@"D:\FACULTATE\Facultate\An_2_sem_2\MVP_MediiVisualeDeProgramare\PairsGame\Tema1\Assets\players.xml"))
            {
                xmlSerializer.Serialize(writer, playerList);
            }
        }

        public static PlayersList DeserializePlayersFromXmlFile(string location)
        {
            var xmlDeserializer = new XmlSerializer(typeof(PlayersList));
            using(var reader = new StreamReader(location))
            {
                PlayersList players =(PlayersList)xmlDeserializer.Deserialize(reader);
                return players;
            }
        }
    }
}

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
                writer.Close();
            }
        }

        public static void SerializePlayersToXmlFile(PlayersList _playerList)
        {
            var playerList = _playerList;

            using (var writer = new StreamWriter(@"D:\FACULTATE\Facultate\An_2_sem_2\MVP_MediiVisualeDeProgramare\PairsGame\Tema1\Assets\players.xml"))
            {
                var xmlSerializer = new XmlSerializer(typeof(PlayersList));
                xmlSerializer.Serialize(writer, playerList);
                writer.Close();
            }
        }

        public static PlayersList DeserializePlayersFromXmlFile(string location)
        {
            FileStream stream = new FileStream(location, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using(var reader = new StreamReader(stream))
            {
                var xmlDeserializer = new XmlSerializer(typeof(PlayersList));
                PlayersList players = (PlayersList)xmlDeserializer.Deserialize(reader);
                return players;
            }
        }
    }
}

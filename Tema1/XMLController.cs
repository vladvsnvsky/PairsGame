using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
                writer.Close();
            }
        }

        public static void SerializePlayersToXmlFile(PlayersList _playerList, string location)
        {
            var playerList = _playerList;

            File.WriteAllText(location, "");
            FileStream stream = new FileStream(location, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
            var writer = new StreamWriter(stream, Encoding.UTF8);
            var xmlSerializer = new XmlSerializer(typeof(PlayersList));
            xmlSerializer.Serialize(writer, playerList);
            writer.Flush();
            writer.Close();
            stream.Close();
        }

        //public static void SerializePlayersToXmlFile(PlayersList _playerList)
        //{
        //    var playerList = _playerList;

        //    using (var writer = new StreamWriter(@"D:\FACULTATE\Facultate\An_2_sem_2\MVP_MediiVisualeDeProgramare\PairsGame\Tema1\Assets\players.xml"))
        //    {
        //        var xmlSerializer = new XmlSerializer(typeof(PlayersList));
        //        xmlSerializer.Serialize(writer, playerList);
        //        writer.Close();
        //    }
        //}

        public static void SerializePlayersToXmlFile(PlayersList _playerList)
        {
            var playerList = _playerList;
            FileStream stream = new FileStream(@"D:\FACULTATE\Facultate\An_2_sem_2\MVP_MediiVisualeDeProgramare\PairsGame\Tema1\Assets\players.xml", FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
            var writer = new StreamWriter(stream, Encoding.UTF8);
            var xmlSerializer = new XmlSerializer(typeof(PlayersList));
            xmlSerializer.Serialize(writer, playerList);
            writer.Flush();
            stream.Close();
            writer.Close();
        }

        //public static PlayersList DeserializePlayersFromXmlFile(string location)
        //{
        //    FileStream stream = new FileStream(location, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        //    using(var reader = new StreamReader(stream, Encoding.UTF8))
        //    {
        //        var xmlDeserializer = new XmlSerializer(typeof(PlayersList));
        //        var players = (PlayersList)xmlDeserializer.Deserialize(reader);
        //        reader.Close();
        //        return players;

        //    }
        //}

        public static PlayersList DeserializePlayersFromXmlFile(string location)
        {
            FileStream stream = new FileStream(location, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            var reader = new StreamReader(stream, Encoding.UTF8);
            var xmlDeserializer = new XmlSerializer(typeof(PlayersList));
            var players = (PlayersList)xmlDeserializer.Deserialize(reader);
            stream.Close();
            reader.Close();
            return players;
        }
    }
}

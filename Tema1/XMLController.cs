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

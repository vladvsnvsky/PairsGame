using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tema1
{
    public static class DataStorage
    {
        private const string PlayerListFilePath = "playerlist.xml";

        public static PlayerList LoadPlayerList()
        {
            if (!File.Exists(PlayerListFilePath))
            {
                return new PlayerList();
            }

            using (var reader = new StreamReader(PlayerListFilePath))
            {
                var serializer = new XmlSerializer(typeof(PlayerList));
                return (PlayerList)serializer.Deserialize(reader);
            }
        }

        public static void SavePlayerList(PlayerList playerList)
        {
            using (var writer = new StreamWriter(PlayerListFilePath))
            {
                var serializer = new XmlSerializer(typeof(PlayerList));
                serializer.Serialize(writer, playerList);
            }
        }
    }
}

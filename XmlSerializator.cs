using System.IO;
using System.Xml.Serialization;

namespace Serializator
{
    public static class XmlSerializator
    {
        public static void SerializeToXml<T>(T objectGraph, string filePath) where T : class
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                xmlSerializer.Serialize(writer, objectGraph);
            }
        }

        public static T DeserializeFromXml<T>(string filePath) where T : class
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            using (StreamReader reader = new StreamReader(filePath))
            {
                return xmlSerializer.Deserialize(reader) as T;
            }
        }
    }
}

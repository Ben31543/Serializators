using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Serializator
{
    public static class BinarySerializator
    {
        public static void SerializeToBinary<T>(T objectGraph, string pathName) where T : class
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream writer = new FileStream(pathName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(writer, objectGraph);
            }
        }

        public static T DeserializeFromBinary<T>(string pathName) where T:class
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream reader = new FileStream(pathName, FileMode.Open))
            {
                return formatter.Deserialize(reader) as T;
            }
        }
    }
}

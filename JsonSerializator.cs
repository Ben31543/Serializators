using Newtonsoft.Json;
using System.IO;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Serializator
{
    public static class JsonSerializator
    {
        public static void SerializeToJson<T>(T objectGraph, string filePath)
        {
            var json = JsonSerializer.Serialize(objectGraph, typeof(T));

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(json);
            }
        }

        public static T DeserializeFromJson<T>(string filePath)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(filePath));
        }
    }
}

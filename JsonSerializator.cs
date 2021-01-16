using Newtonsoft.Json;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Reflection;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Serializator
{
    public static class JsonSerializator
    {
        public static void SerializeToJson<T>(T objectGraph, string filePath)
        {
            Type type = typeof(T);
            MemberInfo[] memberInfo = type.GetMethods();

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (MethodInfo method in memberInfo)
                {
                    if (Attribute.IsDefined(method, typeof(OnSerializingAttribute)))
                    {
                        method.Invoke(method, null);
                    }
                }
                var json = JsonSerializer.Serialize(objectGraph, typeof(T));
                writer.WriteLine(json);
            }
        }

        public static T DeserializeFromJson<T>(string filePath)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(filePath));
        }
    }
}

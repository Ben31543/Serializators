using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace Serializator
{
    [Serializable]
    public class User : ISerializable
    {
        public int Age { get; set; }

        public string Name { get; set; }

        public string Nationality { get; set; }

        [OnSerializing]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Type type = typeof(User);
            MemberInfo[] memberInfo = type.GetMembers();

            for (int i = 0; i < memberInfo.Length; i++)
            {
                if (memberInfo[i].GetType().Equals("System.Int32"))
                    info.GetInt32("Age");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\benat\\Desktop\\file.xml";
            var user = new User
            {
                Age = 17,
                Name = "Ben",
                Nationality = "Arm"
            };

            Console.WriteLine("OK");
        }
    }
}

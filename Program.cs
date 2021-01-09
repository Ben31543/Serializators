using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace Serializator
{
    [Serializable]
    public class User
    {
        public int Age { get; set; }

        public string Name { get; set; }

        public string Nationality { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\benat\\Desktop\\file.bin";
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

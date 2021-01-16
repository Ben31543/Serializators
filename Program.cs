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

        [OnSerializing]
        private void OnSerializing(StreamingContext context)
        {
            Type type = typeof(User);
            MemberInfo[] memberInfo = type.GetProperties();

            foreach (PropertyInfo property in memberInfo)
            {
                if (property.PropertyType == typeof(int))
                {
                    property.SetValue(this, 
                        (int)property
                        .GetValue(this) - 1);
                }
            }
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            Type type = typeof(User);
            MemberInfo[] memberInfo = type.GetProperties();

            foreach (PropertyInfo property in memberInfo)
            {
                if (property.PropertyType == typeof(int))
                {
                    property.SetValue(this,
                        (int)property
                        .GetValue(this) + 1);
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\benat\Desktop\file.txt";

            var user = new User
            {
                Name = "Ben",
                Age = 17,
                Nationality = "Arm"
            };

            JsonSerializator.SerializeToJson<User>(user, filePath);
        }
    }
}

namespace Serializator
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\benat\Desktop\bla.json";

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

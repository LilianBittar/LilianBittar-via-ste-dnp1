using System;

namespace JSON
{
    class Program
    {
        static void Main(string[] args)
        {

            Person p1 = new()
            {
                FirstName = "Lilian",
                LastName = "Bittar",
                Age = 28,
                Height = 168,
                IsMarried = false,
                Sex = 'F',
                Hobbies = new string [] {"reading", "playing guitar", "drawing"}
            };

            Person p2 = new()
            {
                FirstName = "Andrew",
                LastName = "Guld",
                Age = 30,
                Height = 180,
                IsMarried = false,
                Sex = 'M',
                Hobbies = new string [] {"reading", "fitness", "running"}
            };
            
            Person p3 = new()
            {
                FirstName = "Alina",
                LastName = "Jorden",
                Age = 34,
                Height = 160,
                IsMarried = true,
                Sex = 'F',
                Hobbies =  new string[] { "cooking", "smoking"}

            };
            
            List<Person> Persons = new ();
            Persons.Add(p1);
            Persons.Add(p2);
            Persons.Add(p3);

            string personsAsJsonString = JsonSerializer.Serialize(Persons, new JsonSerializerOptions()
            {
                WriteIndented = true
            });
            Console.WriteLine(personsAsJsonString);
        }
    }
}
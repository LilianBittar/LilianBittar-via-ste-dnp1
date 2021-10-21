using System;

namespace SimplePerson
{
    class Person
    {
        private string name;
        public void Introduce(){
            Console.WriteLine($"Hi, I am {name}");
        }
        static void Main(string[] args)
        {
            Person p = new(){
                name = "Lilian"
            };
            p.Introduce();

        }
    }
}
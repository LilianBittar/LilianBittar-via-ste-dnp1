using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using DataGenerator.Generator;
using LINQTraining.Generator;
using Models;

namespace LINQTraining
{
    class Program
    {
        // static void Main(string[] args)
        // {
        // CreateAndSeed();
        // }

        private static void CreateAndSeed()
        {
            IList<Family> families = new FamilyGenerator().GenerateFamilies(500);
            string famSerialized = JsonSerializer.Serialize(families, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText("families.txt", famSerialized);
            DBSeeder.Seed(families);
        }
    }
}
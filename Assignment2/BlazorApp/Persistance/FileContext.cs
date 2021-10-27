using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Assignment1.Models;
using BlazorApp.Data;
using BlazorApp.Models;

namespace FileData
{
    public class FileContext : IAdultData
    {
        private readonly string adultsFile = "adults.json";

        private readonly string familiesFile = "families.json";

        public FileContext()
        {
            Families = File.Exists(familiesFile) ? ReadData<Family>(familiesFile) : new List<Family>();
            Adults = File.Exists(adultsFile) ? ReadData<Adults>(adultsFile) : new List<Adults>();
        }

        public IList<Family> Families { get; }
        public IList<Adults> Adults { get; }

        private IList<T> ReadData<T>(string s)
        {
            using (var jsonReader = File.OpenText(s))
            {
                return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd());
            }
        }

        public void SaveChanges()
        {
            // storing families
            var jsonFamilies = JsonSerializer.Serialize(Families, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using (var outputFile = new StreamWriter(familiesFile, false))
            {
                outputFile.Write(jsonFamilies);
            }

            // storing persons
            var jsonAdults = JsonSerializer.Serialize(Adults, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using (var outputFile = new StreamWriter(adultsFile, false))
            {
                outputFile.Write(jsonAdults);
            }
        }

        public IList<Adults> GetAdults()
        {
            List<Adults> tmp = new List<Adults>(Adults);
            return tmp;
        }

        public void AddAdult(Adults adult)
        {
            int max = Adults.Max(adult => adult.Id);
            adult.Id = (++max);
             Adults.Add(adult);
             SaveChanges();
        }
    }
}
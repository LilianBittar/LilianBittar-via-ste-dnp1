using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebAPI.Data;
using WebApp.Models;

namespace FileData
{
    public class FileContext : IAdultData
    {
        private readonly string adultsFile = "adults.json";
        public IList<Adult> Adults { get; }

        
        public FileContext()
        {
           
            Adults = File.Exists(adultsFile) ? ReadData<Adult>(adultsFile) : new List<Adult>();
        }
        
      

        private IList<T> ReadData<T>(string s)
        {
            using (var jsonReader = File.OpenText(s))
            {
                return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd());
            }
        }

        public void SaveChanges()
        {
            
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

        public IList<Adult> GetAdults()
        {
            List<Adult> tmp = new List<Adult>(Adults);
            return tmp;
        }

       

        public async Task<List<Adult>> GetAdultsAsync(int? id, string name, int? age, string sex)
        {
            List<Adult> temp = new List<Adult>();
            if (id != null) temp = temp.Where(t => t.Id == id).ToList();
            if (name != null)
                temp = temp.Where(t => (t.FirstName + " " + t.LastName).ToLowerInvariant().Contains(name.ToLower()))
                    .ToList();
            if (age != null) temp = temp.Where(t => t.Age == age).ToList();
            if (sex != null) temp = temp.Where(t => t.Sex == sex).ToList();

            return temp;

        }
        
        
        public async Task<Adult> AddAdultAsync(Adult adult)
        {
            int max = Adults.Max(adult => adult.Id);
            adult.Id = (++max);
            Adults.Add(adult);
            SaveChanges();
            return adult;
        }

        
        public async Task RemoveAdultAsync(int adultId)
        {
            foreach (var adult in Adults)
            {
                if (adult.Id == adultId)
                {
                    Adults.Remove(adult);
                    return;
                }
            }
        }
        
        

        public async Task<Adult> UpdateAdultAsync(Adult adult)
        {
            foreach (var temp in Adults)
            {
                if (temp.Id == adult.Id)
                {
                    temp.FirstName = adult.FirstName;
                    temp.LastName = adult.LastName;
                    temp.Age = adult.Age;
                    temp.Sex = adult.Sex;
                    temp.Height = adult.Height;
                    temp.Weight = adult.Weight;
                    temp.EyeColor = adult.EyeColor;
                    temp.JobTitle = adult.JobTitle;
                    temp.HairColor = adult.HairColor;
                }
            }

            return null;
        }
    }
}
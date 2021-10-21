using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace JSONFileStorage
{
    class PersonPersistance
    {
        public static void StoreObject(List<Person> persons){
            string personsAsJsonString = JsonSerializer.Serialize(persons, new JsonSerializerOptions()
            {
                WriteIndented = true
            });
            File.WriteAllText("exmple.json", personsAsJsonString);
        }

        public static string ReadJSON(string FileName){
            return System.IO.File.ReadAllText(FileName);
        }    
    }
}
using System.Collections.Generic;

namespace WebApp.Models
{
    public class Family
    {
        public Family()
        {
            Adults = new List<Adult>();
        }
        
        //public int Id { get; set; }
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }
        
        public List<Adult> Adults { get; set; }
        public List<Child> Children { get; set; }
        public List<Pet> Pets { get; set; }
    }
}
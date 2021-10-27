using System.Collections.Generic;
using BlazorApp.Models;

namespace Assignment1.Models
{
    public class Family
    {
        public Family()
        {
            Adults = new List<Adults>();
        }
        
        //public int Id { get; set; }
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }
        
        public List<Adults> Adults { get; set; }
        public List<Child> Children { get; set; }
        public List<Pet> Pets { get; set; }
    }
}
using System.Collections.Generic;
using BlazorApp.Models;

namespace Assignment1.Models
{
    public class Child : Person

    {
        public List<interest> Interests { get; set; }
        public List<Pet> Pets {get; set; }
    }
}
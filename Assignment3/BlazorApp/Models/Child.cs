using System.Collections.Generic;

namespace BlazorApp.Models
{
    public class Child : Person

    {
          public List<interest> Interests { get; set; }
          public List<Pet> Pets {get; set; }
    }
}
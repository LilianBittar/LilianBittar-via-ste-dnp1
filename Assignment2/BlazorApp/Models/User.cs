using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public class User 
    {
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int BirthYear { get; set; }
        public int SecurityLevel { get; set;  }
    }
}
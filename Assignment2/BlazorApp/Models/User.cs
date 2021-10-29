using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlazorApp.Models
{
    public class User 
    {
        [JsonPropertyName("firstName")]
        public string UserFirstName { get; set; }
        [JsonPropertyName("lastName")]
        public string UserLastName { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
        public int BirthYear { get; set; }
        [JsonPropertyName("securityLevel")]
        public int SecurityLevel { get; set;  }
    }
}
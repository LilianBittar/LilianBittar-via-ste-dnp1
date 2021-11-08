
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Library.Models
{
    public class Author
    {
   
        [Key, MaxLength(200)]
        public int AuthorId { get; set; }
        [Required, MaxLength(300)]
        public string FirstName { get; set;  }
        [Required, MaxLength(200)]
        public string LastName { get; set; }
        public string Bio { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }
    }
}
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Library.Models
{
    public class Genres
    {
        [Key, MaxLength(30)]
        public int GenreId { get; set; }
        [Required, MaxLength(300)]
        public string GenreName { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }
    }
}
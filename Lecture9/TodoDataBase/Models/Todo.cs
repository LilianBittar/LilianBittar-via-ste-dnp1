using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TodoDataBase.Models {
    public class Todo {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int UserId { get; set; }
        [JsonPropertyName("id"), Key]
        public int TodoId { get; set; }
        [Required, MaxLength(128)]
        public string Title { get; set; }
        [JsonPropertyName("completed"), Required]
        public bool IsCompleted { get; set; }
    }
}
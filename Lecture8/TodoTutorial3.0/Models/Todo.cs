using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TodoTutorial3._0.Models
{
    public class Todo
    {
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int UserId { get; set; }
        [JsonPropertyName("id")]
        public int TodoId { get; set;  }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}
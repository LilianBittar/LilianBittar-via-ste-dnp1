using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TodoWebAPI_withoutBlazor
{
    public class Todo
    {
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int userId { get; set; }
        [JsonPropertyName("id")]
        public int id { get; set;  }
        public string title { get; set; }
        public bool completed { get; set; }
    }
}
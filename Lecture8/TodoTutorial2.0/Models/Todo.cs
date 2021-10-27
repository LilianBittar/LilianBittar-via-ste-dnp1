using System.ComponentModel.DataAnnotations;

namespace TodoTutorial2._0.Models
{
    public class Todo
    {
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int UserId { get; set; }
        public int TodoId { get; set;  }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}
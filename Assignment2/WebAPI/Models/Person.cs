using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Person
    {
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than (1)")]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string FirstName { get; set; }
        [Required, MaxLength(100)]
        public string LastName { get; set; }
        public string HairColor { get; set; }
        [Required, MaxLength(7)]
        public string EyeColor { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a positive age")]
        public int Age { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a positive age")]
        public float Weight { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a positive value")]
        public int Height { get; set; }
        public string Sex { get; set; }
    }
}
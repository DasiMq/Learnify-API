using System.ComponentModel.DataAnnotations;

namespace LearnifyAPI.Dtos
{
    public class AddCourse
    {
        [Required]
        public string CourseName { get; set; } = null!;
        [Required]
        public string CourseDescription { get; set; } = null!;
        [Required]
        public int CourseDuration { get; set; }
        [Required]
        public decimal CoursePrice { get; set; }
    }
}

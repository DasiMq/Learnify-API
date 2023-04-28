using System.ComponentModel.DataAnnotations;

namespace LearnifyAPI.Dtos
{
    public class UpdateCourse
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = null!;
        public string CourseDescription { get; set; } = null!;
        public int CourseDuration { get; set; }
        public decimal CoursePrice { get; set; }
    }
}

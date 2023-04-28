using System.ComponentModel.DataAnnotations;

namespace LearnifyAPI.Dtos
{
    public class AddProgress
    {
        [Required]
        public int ProgressId { get; set; }
        [Required]
        public int CourseProgress { get; set; }
        [Required]
        public string CompletionStatus { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int ProgressEnrollmentId { get; set; }
        [Required]
        public int ProgressCourseId { get; set; }
    }
}

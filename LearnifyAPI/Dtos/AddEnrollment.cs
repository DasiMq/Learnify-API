using System.ComponentModel.DataAnnotations;

namespace LearnifyAPI.Dtos
{
    public class AddEnrollment
    {
        [Required]
        public int EnrollmentId { get; set; }
        [Required]
        public DateTime EnrollmentDate { get; set; }
        [Required]
        public string PaymentStatus { get; set; } = null!;
        [Required]
        public int EnrollmentStudentId { get; set; }
        [Required]
        public int EnrollmentCourseId { get; set; }
    }
}

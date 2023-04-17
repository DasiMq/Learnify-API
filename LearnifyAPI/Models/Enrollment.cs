using System;
using System.Collections.Generic;

namespace LearnifyAPI.Models;

public partial class Enrollment
{
    public int EnrollmentId { get; set; }

    public DateTime EnrollmentDate { get; set; }

    public string PaymentStatus { get; set; } = null!;

    public int EnrollmentStudentId { get; set; }

    public int EnrollmentCourseId { get; set; }

    public virtual Course EnrollmentCourse { get; set; } = null!;

    public virtual User EnrollmentStudent { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Progress> Progresses { get; set; } = new List<Progress>();
}

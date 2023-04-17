using System;
using System.Collections.Generic;

namespace LearnifyAPI.Models;

public partial class Progress
{
    public int ProgressId { get; set; }

    public int CourseProgress { get; set; }

    public string CompletionStatus { get; set; } = null!;

    public DateTime Date { get; set; }

    public int ProgressEnrollmentId { get; set; }

    public int ProgressCourseId { get; set; }

    public virtual Course ProgressCourse { get; set; } = null!;

    public virtual Enrollment ProgressEnrollment { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace LearnifyAPI.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string CourseName { get; set; } = null!;

    public string CourseDescription { get; set; } = null!;

    public int CourseDuration { get; set; }

    public decimal CoursePrice { get; set; }

    public int CourseUserId { get; set; }

    public virtual User CourseUser { get; set; } = null!;

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual ICollection<Progress> Progresses { get; set; } = new List<Progress>();
}

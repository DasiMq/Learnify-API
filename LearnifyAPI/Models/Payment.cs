using System;
using System.Collections.Generic;

namespace LearnifyAPI.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public DateTime PaymentDate { get; set; }

    public decimal Amount { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public string? PaymentStatus { get; set; }

    public string? PayerName { get; set; }

    public int PaymentEnrollmentId { get; set; }

    public virtual Enrollment PaymentEnrollment { get; set; } = null!;
}

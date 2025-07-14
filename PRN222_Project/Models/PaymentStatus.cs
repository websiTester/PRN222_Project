using System;
using System.Collections.Generic;

namespace PRN222_Project.Models;

public partial class PaymentStatus
{
    public int PaymentStatusId { get; set; }

    public string? PaymentStatusName { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}

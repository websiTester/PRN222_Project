﻿using System;
using System.Collections.Generic;

namespace PRN222_Project.Models;

public partial class PaymentMethod
{
    public int PaymentMethodId { get; set; }

    public string? PaymentMethodName { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}

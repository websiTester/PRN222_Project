using System;
using System.Collections.Generic;

namespace PRN222_Project.Models;

public partial class Voucher
{
    public int VoucherId { get; set; }

    public string? VoucherName { get; set; }

    public string? Description { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public int? Quantity { get; set; }

    public decimal? Percent { get; set; }

    public bool? IsActive { get; set; }

    public string? VoucherCode { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}

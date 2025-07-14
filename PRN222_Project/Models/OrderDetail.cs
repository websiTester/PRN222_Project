using System;
using System.Collections.Generic;

namespace PRN222_Project.Models;

public partial class OrderDetail
{
    public int OrderDetailId { get; set; }
    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? Thumbnail { get; set; }

    public int SizeId { get; set; }

    public int? Quantity { get; set; }

    public int? UnitPrice { get; set; }

    public int? TotalPrice { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual Size Size { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace PRN222_Project.Models;

public partial class ProductSize
{
    public int SizeId { get; set; }

    public int ProductId { get; set; }

    public int? Quantity { get; set; }

    public int? Weight { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Size Size { get; set; } = null!;
}

using System;
using System.Collections.Generic;

namespace PRN222_Project.Models;

public partial class ProductImage
{
    public int ProductImageId { get; set; }

    public int? ProductId { get; set; }

    public string? ImageUrl { get; set; }

    public bool? IsActive { get; set; }

    public virtual Product? Product { get; set; }
}

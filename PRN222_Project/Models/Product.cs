using System;
using System.Collections.Generic;

namespace PRN222_Project.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public int? Price { get; set; }

    //public int? TotalQuantity { get; set; }

    public decimal? Discount { get; set; }

    public string? Description { get; set; }

    public string? Thumbnail { get; set; }

    public bool? IsActive { get; set; }

    public int? RatedStar { get; set; }

    public int? BrandId { get; set; }

    public int? ProductCategoryId { get; set; }

    public virtual Brand? Brand { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ProductCategory? ProductCategory { get; set; }

    public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

    public virtual ICollection<ProductSize> ProductSizes { get; set; } = new List<ProductSize>();

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
}

using System;
using System.Collections.Generic;

namespace PRN222_Project.Models;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public string? UserId { get; set; }

    public int? OrderId { get; set; }

    public int? ProductId { get; set; }

    public string? Review { get; set; }

    public string? Thumbnail { get; set; }

    public int? Rating { get; set; }

    public bool? IsActive { get; set; }

    public DateOnly? CreateAt { get; set; }

    public DateOnly? ModifiedAt { get; set; }

    public virtual User? Customer { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }
}

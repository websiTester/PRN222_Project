using System;
using System.Collections.Generic;

namespace PRN222_Project.Models;

public partial class Slider
{
    public int SliderId { get; set; }

    public string? Tittle { get; set; }

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public bool? IsActive { get; set; }
}

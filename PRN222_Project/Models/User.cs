using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
namespace PRN222_Project.Models;

public partial class User: IdentityUser
{
    public string? Password { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public bool? Gender { get; set; }

    public DateOnly? Dob { get; set; }
    public int Balance { get; set; }

    public string? VerificationCode { get; set; }

    public string? ResetPasswordCode { get; set; }

    public string? GoogleId { get; set; }

    public string? ProfilePictureUrl { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsBanned { get; set; }

    public int? RoleId { get; set; }

    public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; } = new List<CustomerAddress>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Order> OrderCustomers { get; set; } = new List<Order>();

    public virtual ICollection<Order> OrderSalers { get; set; } = new List<Order>();

    public virtual Role? Role { get; set; }
    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
}

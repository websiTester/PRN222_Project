using System;
using System.Collections.Generic;

namespace PRN222_Project.Models;

public partial class CustomerAddress
{
    public int CustomerAddressesId { get; set; }

    public string? Address { get; set; }

    public string? ProvinceId { get; set; }

    public string? ProvinceName { get; set; }

    public string? DistrictId { get; set; }

    public string? DistrictName { get; set; }

    public string? WardCode { get; set; }

    public string? WardName { get; set; }

    public string? Phone { get; set; }

    public string? ReceiverName { get; set; }

    public bool IsDefault { get; set; }

    public string? UserId { get; set; }

    public virtual User? Customer { get; set; }

	public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}

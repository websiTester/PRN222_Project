using System;
using System.Collections.Generic;

namespace PRN222_Project.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public string? UserId { get; set; }

    public DateTime? OrderedDate { get; set; }

    public DateTime? ReceiveDate { get; set; }

    public string? ReceiverName { get; set; }

    //public string? Phone { get; set; }

    //public string? Email { get; set; }

    //public string? Address { get; set; }

    //public string? WardCode { get; set; }

    //public string? WardName { get; set; }

    //public int? DistrictId { get; set; }

    //public string? DistrictName { get; set; }

    //public int? ProvinceId { get; set; }

    //public string? ProvinceName { get; set; }

    public int? TotalPrice { get; set; }

    public int? ShippingFee { get; set; }

    public int? VoucherId { get; set; }

    //public decimal? VoucherPercent { get; set; }

    public int? TotalAmount { get; set; }

    public int? TotalGram { get; set; }

    public int? PaymentMethodId { get; set; }

    public string? VnpTxnRef { get; set; }

    public string? VnpCreateDate { get; set; }

    public int? PaymentStatusId { get; set; }

    public int? OrderStatusId { get; set; }
    public int CustomerAddressId { get; set; }

    //public string? ShippingCode { get; set; }

    public string? SalerId { get; set; }

    public virtual User? Customer { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual OrderStatus? OrderStatus { get; set; }

    public virtual PaymentMethod? PaymentMethod { get; set; }

    public virtual PaymentStatus? PaymentStatus { get; set; }

    public virtual User? Saler { get; set; }

    public virtual Voucher? Voucher { get; set; }
    public virtual CustomerAddress? CustomerAddress { get; set; }
}

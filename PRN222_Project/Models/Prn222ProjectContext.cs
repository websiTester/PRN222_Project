using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace PRN222_Project.Models;

public partial class Prn222ProjectContext : IdentityDbContext<User>
{
    public Prn222ProjectContext()
    {
    }

    public Prn222ProjectContext(DbContextOptions<Prn222ProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<PaymentStatus> PaymentStatuses { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductImage> ProductImages { get; set; }

    public virtual DbSet<ProductSize> ProductSizes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Size> Sizes { get; set; }

    public virtual DbSet<Slider> Sliders { get; set; }

    //public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }
    public virtual DbSet<Cart> Carts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		var ConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("DefaultConnection");
		optionsBuilder.UseSqlServer(ConnectionString);
	}
	protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.BrandId).HasName("PK__Brands__5E5A8E272DAFCE8C");

            entity.Property(e => e.BrandId).HasColumnName("brand_id");
            entity.Property(e => e.BrandName)
                .HasMaxLength(255)
                .HasColumnName("brand_name");
            entity.Property(e => e.Description)
                .HasColumnType("ntext")
                .HasColumnName("description");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.Logo)
                .HasMaxLength(255)
                .HasColumnName("logo");
        });

        modelBuilder.Entity<CustomerAddress>(entity =>
        {
            entity.HasKey(e => e.CustomerAddressesId).HasName("PK__Customer__EFC17F4B1BB2C425");

            entity.ToTable("Customer_Addresses");

            entity.Property(e => e.CustomerAddressesId).HasColumnName("customer_addresses_id");
            entity.Property(e => e.Address)
                .HasMaxLength(2000)
                .HasColumnName("address");
            entity.Property(e => e.DistrictId).HasColumnName("district_id");
            entity.Property(e => e.DistrictName)
                .HasMaxLength(255)
                .HasColumnName("district_name");
            entity.Property(e => e.IsDefault).HasColumnName("is_default");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.ProvinceId).HasColumnName("province_id");
            entity.Property(e => e.ProvinceName)
                .HasMaxLength(255)
                .HasColumnName("province_name");
            entity.Property(e => e.ReceiverName)
                .HasMaxLength(255)
                .HasColumnName("receiver_name");
            entity.Property(e => e.WardCode)
                .HasMaxLength(255)
                .HasColumnName("ward_code");
            entity.Property(e => e.WardName)
                .HasMaxLength(255)
                .HasColumnName("ward_name");

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerAddresses)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Customer___custo__3E52440B");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__7A6B2B8CCA55C64D");

            entity.Property(e => e.FeedbackId).HasColumnName("feedback_id");
            entity.Property(e => e.CreateAt).HasColumnName("create_at");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.ModifiedAt).HasColumnName("modified_at");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Review)
                .HasColumnType("ntext")
                .HasColumnName("review");
            entity.Property(e => e.Thumbnail)
                .HasMaxLength(255)
                .HasColumnName("thumbnail");

            entity.HasOne(d => d.Customer).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Feedbacks__custo__66603565");

            entity.HasOne(d => d.Order).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Feedbacks__order__6754599E");

            entity.HasOne(d => d.Product).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Feedbacks__produ__68487DD7");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__46596229A60032E8");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            //entity.Property(e => e.Address)
            //    .HasMaxLength(2000)
            //    .HasColumnName("address");
            entity.Property(e => e.UserId).HasColumnName("customer_id");
            //entity.Property(e => e.DistrictId).HasColumnName("district_id");
            //entity.Property(e => e.DistrictName)
            //    .HasMaxLength(255)
            //    .HasColumnName("district_name");
            //entity.Property(e => e.Email)
            //    .HasMaxLength(255)
            //    .HasColumnName("email");
            entity.Property(e => e.OrderStatusId).HasColumnName("order_status_id");
            entity.Property(e => e.OrderedDate)
                .HasColumnType("datetime")
                .HasColumnName("ordered_date");
            entity.Property(e => e.PaymentMethodId).HasColumnName("payment_method_id");
            entity.Property(e => e.PaymentStatusId).HasColumnName("payment_status_id");
            //entity.Property(e => e.Phone)
            //    .HasMaxLength(20)
            //    .HasColumnName("phone");
            //entity.Property(e => e.ProvinceId).HasColumnName("province_id");
            //entity.Property(e => e.ProvinceName)
            //    .HasMaxLength(255)
            //    .HasColumnName("province_name");
            entity.Property(e => e.ReceiveDate)
                .HasColumnType("datetime")
                .HasColumnName("receive_date");
            entity.Property(e => e.ReceiverName)
                .HasMaxLength(255)
                .HasColumnName("receiver_name");
            entity.Property(e => e.SalerId).HasColumnName("salerId");
            //entity.Property(e => e.ShippingCode)
            //    .HasMaxLength(255)
            //    .HasColumnName("shipping_code");
            entity.Property(e => e.ShippingFee).HasColumnName("shipping_fee");
            entity.Property(e => e.TotalAmount).HasColumnName("total_amount");
            entity.Property(e => e.TotalGram).HasColumnName("total_gram");
            entity.Property(e => e.TotalPrice).HasColumnName("total_price");
            entity.Property(e => e.VnpCreateDate)
                .HasMaxLength(20)
                .HasColumnName("vnp_CreateDate");
            entity.Property(e => e.VnpTxnRef)
                .HasMaxLength(255)
                .HasColumnName("vnp_TxnRef");
            entity.Property(e => e.VoucherId).HasColumnName("voucher_id");
            //entity.Property(e => e.VoucherPercent)
            //    .HasColumnType("decimal(10, 2)")
            //    .HasColumnName("voucher_percent");
            //entity.Property(e => e.WardCode)
            //    .HasMaxLength(255)
            //    .HasColumnName("ward_code");
            //entity.Property(e => e.WardName)
            //    .HasMaxLength(255)
            //    .HasColumnName("ward_name");

            entity.HasOne(d => d.Customer).WithMany(p => p.OrderCustomers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Orders__customer__59FA5E80");

            entity.HasOne(d => d.OrderStatus).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderStatusId)
                .HasConstraintName("FK__Orders__order_st__5DCAEF64");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PaymentMethodId)
                .HasConstraintName("FK__Orders__payment___5BE2A6F2");

            entity.HasOne(d => d.PaymentStatus).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PaymentStatusId)
                .HasConstraintName("FK__Orders__payment___5CD6CB2B");

            entity.HasOne(d => d.Saler).WithMany(p => p.OrderSalers)
                .HasForeignKey(d => d.SalerId)
                .HasConstraintName("FK__Orders__salerId__5EBF139D");

            entity.HasOne(d => d.Voucher).WithMany(p => p.Orders)
                .HasForeignKey(d => d.VoucherId)
                .HasConstraintName("FK__Orders__voucher___5AEE82B9");

            entity.HasOne(d => d.CustomerAddress).WithMany(p => p.Orders)
                  .HasForeignKey(d => d.CustomerAddressId);
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__Order_De__32248F38D9974B06");

            entity.ToTable("Order_Details");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.SizeId).HasColumnName("size_id");
            entity.Property(e => e.ProductName)
                .HasMaxLength(255)
                .HasColumnName("product_name");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Thumbnail)
                .HasMaxLength(255)
                .HasColumnName("thumbnail");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order_Det__order__619B8048");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order_Det__produ__628FA481");

            entity.HasOne(d => d.Size).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.SizeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Order_Det__size___6383C8BA");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.HasKey(e => e.OrderStatusId).HasName("PK__Order_St__A499CF230917AEDE");

            entity.ToTable("Order_Status");

            entity.Property(e => e.OrderStatusId).HasColumnName("order_status_id");
            entity.Property(e => e.Description)
                .HasColumnType("ntext")
                .HasColumnName("description");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.OrderStatusName)
                .HasMaxLength(255)
                .HasColumnName("order_status_name");
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.HasKey(e => e.PaymentMethodId).HasName("PK__Payment___8A3EA9EBAD3FF358");

            entity.ToTable("Payment_Methods");

            entity.Property(e => e.PaymentMethodId).HasColumnName("payment_method_id");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.PaymentMethodName)
                .HasMaxLength(255)
                .HasColumnName("payment_method_name");
        });

        modelBuilder.Entity<PaymentStatus>(entity =>
        {
            entity.HasKey(e => e.PaymentStatusId).HasName("PK__Payment___E6BF5015D2E2EA69");

            entity.ToTable("Payment_Status");

            entity.Property(e => e.PaymentStatusId).HasColumnName("payment_status_id");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.PaymentStatusName)
                .HasMaxLength(255)
                .HasColumnName("payment_status_name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__47027DF54F16ECED");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.BrandId).HasColumnName("brand_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Discount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("discount");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ProductCategoryId).HasColumnName("product_category_id");
            entity.Property(e => e.ProductName)
                .HasMaxLength(255)
                .HasColumnName("product_name");
            entity.Property(e => e.RatedStar).HasColumnName("rated_star");
            entity.Property(e => e.Thumbnail)
                .HasMaxLength(255)
                .HasColumnName("thumbnail");
            //entity.Property(e => e.TotalQuantity).HasColumnName("total_quantity");

            entity.HasOne(d => d.Brand).WithMany(p => p.Products)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("FK__Products__brand___46E78A0C");

            entity.HasOne(d => d.ProductCategory).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductCategoryId)
                .HasConstraintName("FK__Products__produc__47DBAE45");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.ProductCategoryId).HasName("PK__Product___1F8847F9A0786309");

            entity.ToTable("Product_Categories");

            entity.Property(e => e.ProductCategoryId).HasColumnName("product_category_id");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.ProductCategoryName)
                .HasMaxLength(255)
                .HasColumnName("product_category_name");
        });

        modelBuilder.Entity<ProductImage>(entity =>
        {
            entity.HasKey(e => e.ProductImageId).HasName("PK__Product___0302EB4AA743D91E");

            entity.ToTable("Product_Images");

            entity.Property(e => e.ProductImageId).HasColumnName("product_image_id");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("image_url");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductImages)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Product_I__produ__4E88ABD4");
        });

        modelBuilder.Entity<ProductSize>(entity =>
        {
            entity.HasKey(e => new { e.SizeId, e.ProductId }).HasName("PK__Product___49BAE9EEB06B6076");

            entity.ToTable("Product_Size");

            entity.Property(e => e.SizeId).HasColumnName("size_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Weight).HasColumnName("weight");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductSizes)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product_S__produ__4BAC3F29");

            entity.HasOne(d => d.Size).WithMany(p => p.ProductSizes)
                .HasForeignKey(d => d.SizeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product_S__size___4AB81AF0");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__760965CC91661F61");

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Rolename)
                .HasMaxLength(255)
                .HasColumnName("rolename");
        });

        modelBuilder.Entity<Size>(entity =>
        {
            entity.HasKey(e => e.SizeId).HasName("PK__Sizes__0DCACE31BABCE0CB");

            entity.Property(e => e.SizeId).HasColumnName("size_id");
            entity.Property(e => e.Description)
                .HasColumnType("ntext")
                .HasColumnName("description");
            entity.Property(e => e.SizeName)
                .HasMaxLength(20)
                .HasColumnName("size_name");
        });

        modelBuilder.Entity<Slider>(entity =>
        {
            entity.HasKey(e => e.SliderId).HasName("PK__Sliders__5B89E3956E3E52E7");

            entity.Property(e => e.SliderId).HasColumnName("slider_id");
            entity.Property(e => e.Description)
                .HasColumnType("ntext")
                .HasColumnName("description");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .HasColumnName("image_url");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.Tittle)
                .HasMaxLength(255)
                .HasColumnName("tittle");
        });

        modelBuilder.Entity<User>(entity =>
        {

            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .HasColumnName("first_name");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.GoogleId)
                .HasMaxLength(255)
                .HasColumnName("google_id");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.IsBanned).HasColumnName("is_banned");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .HasColumnName("last_name");
           
            entity.Property(e => e.ProfilePictureUrl)
                .HasMaxLength(255)
                .HasColumnName("profile_picture_url");
            entity.Property(e => e.ResetPasswordCode)
                .HasMaxLength(6)
                .HasColumnName("reset_password_code");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.VerificationCode)
                .HasMaxLength(6)
                .HasColumnName("verification_code");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Users__role_id__3B75D760");
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.HasKey(e => e.VoucherId).HasName("PK__Voucher__80B6FFA81DE8B00A");

            entity.ToTable("Voucher");

            entity.HasIndex(e => e.VoucherCode, "UQ__Voucher__21731069545BAAEB").IsUnique();

            entity.Property(e => e.VoucherId).HasColumnName("voucher_id");
            entity.Property(e => e.Description)
                .HasColumnType("ntext")
                .HasColumnName("description");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.Percent)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("percent");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.VoucherCode)
                .HasMaxLength(255)
                .HasColumnName("voucher_code");
            entity.Property(e => e.VoucherName)
                .HasMaxLength(255)
                .HasColumnName("voucher_name");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId);
            entity.HasOne(e => e.User).WithMany(e => e.Carts).HasForeignKey(e => e.UserId);
            entity.HasOne(e => e.Product).WithMany(e => e.Carts).HasForeignKey(e => e.ProductId);
			entity.HasOne(e => e.Size).WithMany(e => e.Carts).HasForeignKey(e => e.SizeId);
		});

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

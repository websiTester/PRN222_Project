using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using PRN222_Project.Models;
using PRN222_Project.Repositories.Implementations;
using PRN222_Project.Repositories.Interfaces;
using PRN222_Project.Services.Implementations;
using PRN222_Project.Services.Interfaces;
using PRN222_Project.Services.VnPay;

namespace PRN222_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
			

			//Configure to usse Identity + Configure password complexity--C1
			builder.Services.AddIdentity<User, IdentityRole>(options =>
			{
				options.Password.RequiredLength = 3;
				options.Password.RequiredUniqueChars = 0;
				options.Password.RequireDigit = false;
				options.Password.RequireLowercase = false;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireUppercase = false;

				options.SignIn.RequireConfirmedEmail = true;

			}).AddEntityFrameworkStores<Prn222ProjectContext>()
			.AddDefaultTokenProviders();



			builder.Services.AddSession();

			builder.Services.AddAuthentication().AddGoogle(options =>
				{
					options.ClientId = builder.Configuration.GetSection("GoogleKeys:ClientId").Value;
					options.ClientSecret = builder.Configuration.GetSection("GoogleKeys:ClientSecret").Value;
				}
				);
			DIConfiguration(builder);

            var app = builder.Build();
			app.UseStaticFiles();

			app.UseAuthentication();
			app.UseAuthorization();
			app.UseSession();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=product}/{action=productlist}"
				);
			
			app.Run();
        }

		public static void DIConfiguration(WebApplicationBuilder builder)
		{
			//DBContext:
			builder.Services.AddScoped<Prn222ProjectContext, Prn222ProjectContext>();
			builder.Services.AddScoped<IDBContext, MyDBContext>();


			//Repositories
			builder.Services.AddScoped<IGetProductListRepository, GetProductListRepository>();
			builder.Services.AddScoped<IGetAllCategoriesRepository, GetAllCategoriesRepository>();
			builder.Services.AddScoped<IGetAllBrandsRepository, GetAllBrandsRepository>();
			builder.Services.AddScoped<IGetProductByIdRepository, GetProductByIdRepository>();
			builder.Services.AddScoped<IGetAllCartByUserIdRepository, GetAllCartsByUserIdRepository>();
			builder.Services.AddScoped<IAddToCartRepository, AddToCartRepository>();
			builder.Services.AddScoped<IGetCartByUserId_ProductId_SizeIdRepository, GetCartByUserId_ProductId_SizeIdRepository>();
			builder.Services.AddScoped<IUpdateCartRepository, UpdateCartRepository>();
			builder.Services.AddScoped<IDeleteAllCartByUserIdRepository, DeleteAllCartByUserIdRepository>();
			builder.Services.AddScoped<IDeleteCartByIdRepository, DeleteCartByIdRepository>();
			builder.Services.AddScoped<IGetAllVoucherRepository, GetAllVoucherRepository>();
			builder.Services.AddScoped<IUpdateUserProfileRepository, UpdateUserProfileRepository>();
			builder.Services.AddScoped<IGetUserWithAddressListRepository, GetUserWithAddressListRepository>();
			builder.Services.AddScoped<IAddNewAddressRepository, AddNewAddressRepository>();
			builder.Services.AddScoped<ITurnOffAvailableDefaultAddressRepository, TurnOffAvailableDefaultAddressRepository>();
			builder.Services.AddScoped<IDeleteAddressByIdRepository, DeleteAddressByIdRepository>();
			builder.Services.AddScoped<IGetAddressByIdRepository, GetAddressByIdRepository>();
			builder.Services.AddScoped<IUpdateAddressRepository, UpdateAddressRepository>();
			builder.Services.AddScoped<IGetVoucherByCodeRepository, GetVoucherByCodeRepository>();
			builder.Services.AddScoped<IGetDefaultAddressByUserIdRepository, GetDefaultAddressByUserIdRepository>();
			builder.Services.AddScoped<IAddNewOrderRepository, AddNewOrderRepository>();
			builder.Services.AddScoped<IAddNewOrderDetailRepository, AddNewOrderDetailRepository>();
			builder.Services.AddScoped<IGetVoucherByIdRepository, GetVoucherByIdRepository>();
			builder.Services.AddScoped<IUpdateVoucherRepository, UpdateVoucherRepository>();
			builder.Services.AddScoped<IGetListOrderByUserIdRepository, GetListOrderByUserIdRepository>();
			builder.Services.AddScoped<IGetOrderByIdRepository, GetOrderByIdRepository>();
			builder.Services.AddScoped<IUpdateOrderRepository, UpdateOrderRepository>();
			builder.Services.AddScoped<IDeleteOrderDetailRepository, DeleteOrderDetailRepository>();
			builder.Services.AddScoped<IUpdateProductSizeRepository, UpdateProductSizeRepository>();
			builder.Services.AddScoped<IGetAllOrderRepository, GetAllOrderRepository>();



			//Services
			builder.Services.AddScoped<IGetProductListService, GetProductListService>();
			builder.Services.AddScoped<IGetAllCategoriesService, GetAllCategoryService>();
			builder.Services.AddScoped<IGetAllBrandService, GetAllBrandService>();
			builder.Services.AddScoped<IGetProductByIdService, GetProductByIdService>();
			builder.Services.AddScoped<IGetAllCartsByUserIdService, GetAllCartsByUserIdService>();
			builder.Services.AddScoped<IAddToCartService, AddToCartService>();
			builder.Services.AddScoped<IGetCartByUserId_ProductId_SizeIdService, GetCartByUserId_ProductId_SizeIdService>();
			builder.Services.AddScoped<IUpdateCartService, UpdateCartService>();
			builder.Services.AddScoped<IDeleteAllCartByUserIdService, DeleteAllCartByUserIdService>();
			builder.Services.AddScoped<IDeleteCartByIdService, DeleteCartByIdService>();
			builder.Services.AddScoped<IGetAllVoucherService, GetAllVoucherService>();
			builder.Services.AddScoped<IUpdateUserProfileService, UpdateUserProfileService>();
			builder.Services.AddScoped<IGetUserWithAddressListService, GetUserWithAddressListService>();
			builder.Services.AddScoped<IAddNewAddressService, AddNewAddressService>();
			builder.Services.AddScoped<ITurnOffAvailableDefaultAddressService, TurnOffAvailableDefaultAddressService>();
			builder.Services.AddScoped<IDeleteAddressByIdService, DeleteAddressByIdService>();
			builder.Services.AddScoped<IGetAddressByIdService, GetAddressByIdService>();
			builder.Services.AddScoped<IUpdateAddressService, UpdateAddressService>();
			builder.Services.AddScoped<IGetVoucherByCodeService, GetVoucherByCodeService>();
			builder.Services.AddScoped<IGetDefaultAddressByUserIdService, GetDefaultAddressByUserIdService>();
			builder.Services.AddScoped<IAddNewOrderService, AddNewOrderService>();
			builder.Services.AddScoped<IAddNewOrderDetailService, AddNewOrderDetailService>();
			builder.Services.AddScoped<IGetVoucherByIdService, GetVoucherByIdService>();
			builder.Services.AddScoped<IUpdateVoucherService, UpdateVoucherService>();
			builder.Services.AddScoped<IGetListOrderByUserIdService, GetListOrderByUserIdService>();
			builder.Services.AddScoped<IGetOrderByIdService, GetOrderByIdService>();
			builder.Services.AddScoped<IUpdateOrderService, UpdateOrderService>();
			builder.Services.AddScoped<IDeleteOrderDetailService, DeleteOrderDetailService>();
			builder.Services.AddScoped<IUpdateProductSizeService, UpdateProductSizeService>();
			builder.Services.AddScoped<IGetAllOrderService, GetAllOrderService>();



			//Email
			builder.Services.AddTransient<IEmailSenderService, EmailSenderService>();

			//VnPay
			builder.Services.AddScoped<IVnPayService, VnPayService>();

		}
	}
}

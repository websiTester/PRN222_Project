using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PRN222_Project.Models;
using PRN222_Project.Models.VnPay;
using PRN222_Project.RequestHandlers.CartHandler;
using PRN222_Project.Services.Interfaces;
using PRN222_Project.Services.VnPay;
using PRN222_Project.ViewModels;

namespace PRN222_Project.Controllers
{
	[Authorize]
	public class CartController : Controller
	{
		private UserManager<User> _userManager;
		private IAddToCartService _addToCartService;
		private IGetCartByUserId_ProductId_SizeIdService _getCartByUserId_ProductId_SizeIdService;
		private IUpdateCartService _updateCartService;
		private IGetProductByIdService _getProductByIdService;
		private IGetAllCartsByUserIdService _getAllCartsByUserIdService;
		private IDeleteAllCartByUserIdService _deleteAllCartByUserIdService;
		private IDeleteCartByIdService _deleteCartByIdService;
		private IGetAllVoucherService _getAllVoucherService;
		private IGetVoucherByCodeService _getVoucherByCodeService;
		private IGetDefaultAddressByUserIdService _GetDefaultAddressByUserIdService;
		private IAddNewOrderService _addNewOrderService;
		private IAddNewOrderDetailService _addNewOrderDetailService;
		private IGetVoucherByIdService _getVoucherByIdService;
		private IUpdateVoucherService _updateVoucherService;
		

		public CartController(
			UserManager<User> userManager,
			IAddToCartService addToCartService,
			IGetCartByUserId_ProductId_SizeIdService getCartByUserId_ProductId_SizeIdService,
			IUpdateCartService updateCartService,
			IGetProductByIdService getProductByIdService,
			IGetAllCartsByUserIdService getAllCartsByUserIdService,
			IDeleteAllCartByUserIdService deleteAllCartByUserIdService,
			IDeleteCartByIdService deleteCartByIdService,
			IGetAllVoucherService getAllVoucherService,
			IGetVoucherByCodeService getVoucherByCodeService,
			IGetDefaultAddressByUserIdService GetDefaultAddressByUserIdService,
			IAddNewOrderService addNewOrderService,
			IAddNewOrderDetailService addNewOrderDetailService,
			IGetVoucherByIdService getVoucherByIdService,
			IUpdateVoucherService updateVoucherService)
		{
			_userManager = userManager;
			_addToCartService = addToCartService;
			_getCartByUserId_ProductId_SizeIdService = getCartByUserId_ProductId_SizeIdService;
			_updateCartService = updateCartService;
			_getProductByIdService = getProductByIdService;
			_getAllCartsByUserIdService = getAllCartsByUserIdService;
			_deleteAllCartByUserIdService = deleteAllCartByUserIdService;
			_deleteCartByIdService = deleteCartByIdService;
			_getAllVoucherService = getAllVoucherService;
			_getVoucherByCodeService = getVoucherByCodeService;
			_GetDefaultAddressByUserIdService = GetDefaultAddressByUserIdService;
			_addNewOrderService = addNewOrderService;
			_addNewOrderDetailService = addNewOrderDetailService;
			_getVoucherByIdService = getVoucherByIdService;
			_updateVoucherService = updateVoucherService;
		}

		public IActionResult AddToCart(int productId, int sizeId, int quantity)
		{
			var session = HttpContext.Session;
			User user = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);

			string? errorMessage = AddToCartHandler.AddToCart(session, user, 
				_getCartByUserId_ProductId_SizeIdService, 
				productId, sizeId, quantity, 
				_addToCartService, 
				_getProductByIdService, 
				_updateCartService);


			return RedirectToAction("ProductDetail", "Product", new { productId = productId, errorMessage = errorMessage, sizeId = sizeId });
		}


		public IActionResult CartList(string? voucherCode, string? noAddressError, string? quantityError)
		{
			
			User user = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
			CartListViewModel model = new CartListViewModel() { 
				CartList = _getAllCartsByUserIdService.GetAllCartsByUserId(user.Id),
				VoucherList = _getAllVoucherService.GetAllVoucher()
			};

			if (voucherCode != null)
			{
				Voucher voucher = _getVoucherByCodeService.GetVoucherByCode(voucherCode);
				if(voucher != null)
				{
					model.SelectedVoucher = voucher;
				} else
				{
					ViewBag.VoucherError = "Invalid Voucher";
				}
				
			}
			ViewBag.QuantityError = quantityError;
			ViewBag.NoAddressError = noAddressError;
			return View(model);
		}


		public IActionResult UpdateCartList(CartListViewModel model)
		{
			User user = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
			
			for (int i=0;i< model.CartList.Count;i++)
			{
				Cart cart = _getCartByUserId_ProductId_SizeIdService
					.GetCartByUserId_ProductId_SizeId(user.Id, model.CartList[i].ProductId, model.CartList[i].SizeId ??0);

				ProductSize productSize = cart.Product.ProductSizes.FirstOrDefault(x => x.SizeId == cart.SizeId);
				if(model.CartList[i].Quantity > productSize.Quantity)
				{
					ModelState.AddModelError($"CartList[{i}].Quantity", 
						$"Cart Quantity({model.CartList[i].Quantity}) is exceed Product Quantity({productSize.Quantity})");
				} else
				{
					cart.Quantity = model.CartList[i].Quantity;
					_updateCartService.UpdateCart(cart);
				}
					
			}
			CartListViewModel cartListViewModel = new CartListViewModel()
			{
				CartList = _getAllCartsByUserIdService.GetAllCartsByUserId(user.Id),
				VoucherList = _getAllVoucherService.GetAllVoucher()
			};
			return View("CartList", cartListViewModel);
		}

		public IActionResult DeleteAllCart()
		{
			User user = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
			_deleteAllCartByUserIdService.DeleteAllCartByUserId(user.Id);
			HttpContext.Session.SetInt32("TotalCart", 0);
			return RedirectToAction("CartList");
		}


		public IActionResult DeleteCartItem(int cartId)
		{
			User user = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
			_deleteCartByIdService.DeleteCartById(cartId);
			int totalCart = HttpContext.Session.GetInt32("TotalCart") ?? 0;
			HttpContext.Session.SetInt32("TotalCart", totalCart - 1);
			return RedirectToAction("CartList");
		}

		public IActionResult Checkout(int? voucherId)
		{
			User user = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
			CustomerAddress defaultAddress = _GetDefaultAddressByUserIdService.GetDefaultAddressByUserId(user.Id);
			List<Cart> cartList = _getAllCartsByUserIdService.GetAllCartsByUserId(user.Id);
			string errorMessage = CheckProductQuantityHandler.IsProductAvailable(cartList);
			
			if(errorMessage != "")
			{
				return RedirectToAction("CartList", new { quantityError = errorMessage });
			}
			if (cartList.Count == 0)
			{
				return RedirectToAction("CartList", new { noAddressError = "No Product in Cart..." });
			}else 
			if (defaultAddress == null)
			{
				return RedirectToAction("CartList", new { noAddressError = "No Default Address Added..." });
			}
			else
			{
				CheckoutViewModel model2 = new CheckoutViewModel()
				{
					CartList = cartList,
					SelectedVoucher = voucherId != null ? _getAllVoucherService.GetAllVoucher().FirstOrDefault(x => x.VoucherId == voucherId) : null,
					DefaultAddress = defaultAddress
				};
				return View(model2);
			}
				
			
		}

		public IActionResult CheckoutSuccess()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CheckoutSuccess(
			int totalPrice,
			int? voucherId,
			int totalQuantity,
			int paymentMethodId,
			int addressId)
		{
			User user = _userManager.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
			if (paymentMethodId == 2)
			{

				HttpContext.Session.SetInt32("totalPrice", totalPrice);
				if(voucherId != null) HttpContext.Session.SetInt32("voucherId", voucherId??0);
				HttpContext.Session.SetInt32("totalQuantity", totalQuantity);
				HttpContext.Session.SetInt32("paymentMethodId", paymentMethodId);
				HttpContext.Session.SetInt32("addressId", addressId);
				return RedirectToAction("CreatePaymentUrlVnpay", "VnPay", new {
					name = user.UserName,
					amount = totalPrice,
					orderType = "other",
					orderDescription = "Payment through VNPAY"
				});
			}

			
			Order newOrder = await CheckoutHandler.AddNewOrder(user, totalPrice, voucherId, totalQuantity, 
				paymentMethodId, addressId, _addNewOrderService,_getVoucherByIdService,
				_updateVoucherService);
			await CheckoutHandler.AddOrderDetail(newOrder, user, _addNewOrderDetailService, _getAllCartsByUserIdService);
			CheckoutHandler.DeleteAllCart(_deleteAllCartByUserIdService, user);
			HttpContext.Session.SetInt32("TotalCart", 0);

			return View();
		}
	}
}

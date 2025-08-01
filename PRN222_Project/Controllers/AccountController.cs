using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using PRN222_Project.Models;
using PRN222_Project.RequestHandlers.AccountHandler;
using PRN222_Project.RequestHandlers.DeleteOrderHandler;
using PRN222_Project.RequestHandlers.ProfileHandler;
using PRN222_Project.Services.Interfaces;
using PRN222_Project.ViewModels;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PRN222_Project.Controllers
{
	public class AccountController : Controller
	{
		private UserManager<User> _userManager;
		private SignInManager<User> _signInManager;
		private IGetAllCartsByUserIdService _getAllCartsByUserIdService;
		private IUpdateUserProfileService _updateUserProfileService;
		private IGetUserWithAddressListService _getUserWithAddressListService;
		private IAddNewAddressService _addNewAddressService;
		private ITurnOffAvailableDefaultAddressService _turnOffAvailableDefaultAddressService;
		private IDeleteAddressByIdService _deleteAddressByIdService;
		private IGetAddressByIdService _getAddressByIdService;
		private IUpdateAddressService _updateAddressService;
		private IGetListOrderByUserIdService _getListOrderByUserIdService;
		private IGetOrderByIdService _getOrderByIdService;
		private IDeleteOrderDetailService _deleteOrderDetailService;
		private IUpdateOrderService _updateOrderService;
		private IUpdateVoucherService _updateVoucherService;
		private IEmailSenderService _emailSenderService;
		private IUpdateProductSizeService _updateProductSizeService;

		public AccountController(
			UserManager<User> userManager, 
			SignInManager<User> signInManager,
			IGetAllCartsByUserIdService getAllCartsByUserIdService,
			IUpdateUserProfileService updateUserProfileService,
			IGetUserWithAddressListService getUserWithAddressListService,
			IAddNewAddressService addNewAddressService,
			ITurnOffAvailableDefaultAddressService turnOffAvailableDefaultAddressService,
			IDeleteAddressByIdService deleteAddressByIdService,
			IGetAddressByIdService getAddressByIdService,
			IUpdateAddressService updateAddressService,
			IGetListOrderByUserIdService getListOrderByUserIdService,
			IGetOrderByIdService getOrderByIdService,
			IDeleteOrderDetailService deleteOrderDetailService,
			IUpdateOrderService updateOrderService,
			IUpdateVoucherService updateVoucherService,
			IEmailSenderService emailSenderService,
			IUpdateProductSizeService updateProductSizeService)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_getAllCartsByUserIdService = getAllCartsByUserIdService;
			_updateUserProfileService = updateUserProfileService;
			_getUserWithAddressListService = getUserWithAddressListService;
			_addNewAddressService = addNewAddressService;
			_turnOffAvailableDefaultAddressService = turnOffAvailableDefaultAddressService;
			_deleteAddressByIdService = deleteAddressByIdService;
			_getAddressByIdService = getAddressByIdService;
			_updateAddressService = updateAddressService;
			_getListOrderByUserIdService = getListOrderByUserIdService;
			_getOrderByIdService = getOrderByIdService;
			_deleteOrderDetailService = deleteOrderDetailService;
			_updateOrderService = updateOrderService;
			_updateVoucherService = updateVoucherService;
			_emailSenderService = emailSenderService;
			_updateProductSizeService = updateProductSizeService;
		}

		[HttpGet]
		public async Task<IActionResult> Login(string? returnUrl)
		{
			LoginViewModel model = new LoginViewModel
			{
				ReturnUrl = returnUrl,
				ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
			};
			return View(model);
		}

		public async Task<IActionResult> IsEmailInUse(string Email)
		{
			var user = await _userManager.FindByEmailAsync(Email);
			if (user == null)
			{
				return Json(true);
			}
			else
			{
				return Json($"Email {Email} is already in use");
			}
		}

		[HttpPost]
		public async Task<IActionResult> ExternalLogin(string provider, string returnUrl)
		{
			//Redirect to ExternalLoginCallback in Account after login with google
			var redirectUrl = Url.Action("ExternalLoginCallback", "Account",
				new { ReturnUrl = returnUrl });

			var properties = _signInManager.ConfigureExternalAuthenticationProperties(
				provider, redirectUrl);
			return new ChallengeResult(provider, properties);
		}

		public async Task<IActionResult> ExternalLoginCallback(string? returnUrl, string? remoteError)
		{
			returnUrl = returnUrl ?? Url.Content("~/");
			LoginViewModel model = new LoginViewModel
			{
				ReturnUrl = returnUrl,
				ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
			};

			if (remoteError != null)
			{
				ModelState.AddModelError(string.Empty, $"Error from external provider: {remoteError}");
				return View("Login", model);
			}

			var info = await _signInManager.GetExternalLoginInfoAsync();
			if (info == null)
			{
				ModelState.AddModelError(string.Empty, "Error loading external login information.");
				return View("Login", model);
			}

			//Check if email if confirmed:
			var email = info.Principal.FindFirstValue(ClaimTypes.Email);
			User user = null;
			if (email != null)
			{
				user = await _userManager.FindByEmailAsync(email);
				if (user != null && user.EmailConfirmed == false)
				{
					ModelState.AddModelError("", "Email not confirmed yet");
					return View("Login", model);
				}
			}
			
			var signInResult = await _signInManager.ExternalLoginSignInAsync(
				info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
			if (signInResult.Succeeded)
			{
				return LocalRedirect(returnUrl);
			}
			else
			{
				if (email != null)
				{
					user = await _userManager.FindByEmailAsync(email);

					if (user == null)
					{
						//Create new user if user not exist
						user = new User
						{
							UserName = info.Principal.FindFirstValue(ClaimTypes.Email),
							Email = info.Principal.FindFirstValue(ClaimTypes.Email)
						};
						await _userManager.CreateAsync(user);

						string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
						var confirmationLink = Url.Action("ConfirmEmail", "Account", new
						{
							userId = user.Id,
							token = token
						}, Request.Scheme);
						await SendEmailHandler.SendConfirmationLink(_emailSenderService, confirmationLink, email);

						ViewBag.ErrorTitle = "Registration successful";
						ViewBag.ErrorMessage = "Before you can Login, please confirm your email by clicking on the confirmation link we just emailed you.";
						return View("Error");
					}


					//Login user
					await _userManager.AddLoginAsync(user, info);
					await _signInManager.SignInAsync(user, isPersistent: false);
					return LocalRedirect(returnUrl);
				} 

				//Else redirect to error page
				ViewBag.ErrorTitle = $"Email claim not received from: {info.LoginProvider}";
				ViewBag.ErrorMessage = "Please contact support on khuditru1520@gmail.com";
				return View("Error");
			}
		}

		public async Task<IActionResult> IsUsernameInUse(string Username)
		{
			var user = await _userManager.FindByNameAsync(Username);
			if (user == null)
			{
				return Json(true);
			}
			else
			{
				return Json($"Username {Username} is already in use");
			}
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model,string? ReturnUrl)
		{
			if (ModelState.IsValid)
			{
				
				var result = await _signInManager.PasswordSignInAsync(
					model.Username, model.Password, model.RememberMe, false);
				//model.RememberMe == isPersistent paremter
				//Decide to save in cookie permanent or not

				if (result.Succeeded)
				{
					User user = await _userManager.FindByNameAsync(model.Username);
					List<Cart> carts = _getAllCartsByUserIdService.GetAllCartsByUserId(user.Id);
					HttpContext.Session.SetInt32("TotalCart", carts.Count);


					if (string.IsNullOrEmpty(ReturnUrl) == false && Url.IsLocalUrl(ReturnUrl))
					{
						return Redirect(ReturnUrl);
					} else
					{
						return RedirectToAction("ProductList", "Product");
					}

						
				}
				else
				{
					User user = await _userManager.FindByNameAsync(model.Username);
					if(user != null && user.EmailConfirmed == false &&
						(await _userManager.CheckPasswordAsync(user, model.Password)))
					{
						ModelState.AddModelError("", "Email not confirmed yet");
					} else
					{
						//Error will display in asp-validation-summary
						ModelState.AddModelError("", "Invalid username or password");
					}
						
				}
			}
			model.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
			return View(model);
		}


		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
			if (ModelState.IsValid)
			{
				User user = new User()
				{
					UserName = model.Username,
					Email = model.Email
				};
				var result = await _userManager.CreateAsync(user, model.Password);

				if (result.Succeeded)
				{

					//Generate token and confirm email link when register success
					string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
					var confirmationLink = Url.Action("ConfirmEmail", "Account", new
					{
						userId = user.Id,
						token = token
					}, Request.Scheme);
					await SendEmailHandler
						.SendConfirmationLink(_emailSenderService, confirmationLink, user.Email);


					//true: save permanent in cookie
					//false: remove when browser close
					//Login for user
					//await _signInManager.SignInAsync(user, isPersistent:false);
					ViewBag.ErrorTitle = "Registration successful";
					ViewBag.ErrorMessage = "Before you can Login, please confirm your email by clicking on the confirmation link we just emailed you.";
					//return RedirectToAction("ProductList", "Product");
					return View("Error");
					
				} else
				{
					//Error will display in asp-validation-summary
					foreach (var error in result.Errors)
					{
						ModelState.AddModelError("", error.Description);
					}
				}
			}
			return View(model);
		}


		public async Task<IActionResult> ConfirmEmail(string userId, string token)
		{
			if (userId == null || token == null)
			{
				return RedirectToAction("ProductList", "Product");
			}

			var user = await _userManager.FindByIdAsync(userId);
			if (user == null)
			{
				ViewBag.ErrorTitle = "User not found";
				return View("Error");
			}

			var result = await _userManager.ConfirmEmailAsync(user, token);
			if (result.Succeeded)
			{
				ViewBag.ErrorTitle = "Thanks for your confirmation";
				return View("Error");
			} else
			{
				ViewBag.ErrorTitle = "Email cannot be confirmed";
				return View("Error");
			}
		}


		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("ProductList", "Product");
		}


		public IActionResult Profile(string? imageUploadError)
		{
			if(imageUploadError != null)
			{
				ViewBag.ImageUploadError = imageUploadError;	
			}
			User user = _userManager.Users
				.FirstOrDefault(x => x.UserName == User.Identity.Name);
			ProfileViewModel model = new ProfileViewModel
			{
				User = user
			};
			return View(model);
		}

		[HttpPost]
		public IActionResult Profile(ProfileViewModel model)
		{
			User user = _userManager.Users
				.FirstOrDefault(x => x.UserName == User.Identity.Name);

			user.FirstName = model.User.FirstName;
			user.LastName = model.User.LastName;
			user.PhoneNumber = model.User.PhoneNumber;
			user.Gender = model.User.Gender;
			user.Dob = model.User.Dob;
			_updateUserProfileService.UpdateUserProfile(user);

			model.User.ProfilePictureUrl = user.ProfilePictureUrl;
			ModelState.AddModelError("", "Updated successfully");
			return View(model);
		}



		[HttpPost]
		public async Task<IActionResult> UploadImage(IFormFile file)
		{
			if(file != null)
			{
				string fileExtension = Path.GetExtension(file.FileName);
				if(fileExtension == ".jpg" || fileExtension == ".png" 
					|| fileExtension == ".jpeg")
				{

					User user = _userManager.Users
						.FirstOrDefault(x => x.UserName == User.Identity.Name);
					
					await UploadImageHandler.SaveImage(file, user, _updateUserProfileService);
					
				} else
				{
					return RedirectToAction("Profile", new {imageUploadError = "Image must be .jpg, .png or .jpeg" });
				}
			}
			return RedirectToAction("Profile");
		}


		public IActionResult Address(string? error)
		{
			if(error != null)
			{
				ViewBag.ErrorTitle = error;
			}
			string userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
			AddressViewModel model = new AddressViewModel
			{

				User = _getUserWithAddressListService.GetUserWithAddressList(userId)
			};
			return View(model);
		}

		public IActionResult NewAddress()
		{
			User user = _userManager.Users
				.FirstOrDefault(x => x.UserName == User.Identity.Name);
			NewAddressViewModel model = new NewAddressViewModel
			{
				User = user
			};
			return View(model);
		}



		[HttpPost]
		public IActionResult NewAddress(NewAddressViewModel model)
		{
	
			AddNewAddressHandler.SaveAddress(model, _addNewAddressService, _turnOffAvailableDefaultAddressService);

			return RedirectToAction("Address");
		}

		public IActionResult DeleteAddress(int addressId)
		{
			string error = null;
			try
			{
				_deleteAddressByIdService.DeleteAddressById(addressId);
			} catch(Exception e)
			{
				error = "Address is being used in an order!";
			}
			

			return RedirectToAction("Address", new { error = error });
		}

		public IActionResult SetDefaultAddress(int addressId)
		{
			CustomerAddress address = _getAddressByIdService.GetAddressById(addressId);
			_turnOffAvailableDefaultAddressService.TurnOffAvailableDefaultAddress(address.UserId);
			address.IsDefault = true;
			_updateAddressService.UpdateAddress(address);
			
			return RedirectToAction("Address");
		}


		public IActionResult EditAddress(int addressId)
		{
			User user = _userManager.Users
				.FirstOrDefault(x => x.UserName == User.Identity.Name);
			NewAddressViewModel model = new NewAddressViewModel
			{
				User = user,
				Address = _getAddressByIdService.GetAddressById(addressId)
			};
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> EditAddress(NewAddressViewModel model)
		{

			await UpdateAddressHandler.UpdateAddress(model, 
				_turnOffAvailableDefaultAddressService ,_updateAddressService);
			return RedirectToAction("Address");
		}

		public IActionResult OrderHistory(int? page)
		{
			User user = _userManager.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
			
			OrderHistoryViewModel model = new OrderHistoryViewModel
			{
				User = user,
				OrderList = _getListOrderByUserIdService.GetListOrderByUserId(user.Id),
				Index = ((page ?? 1) - 1) * 5 + 1
			};

			model.OrderPageList = model.OrderList.ToPagedList(page??1, 5);
			return View(model);
		}


		public IActionResult OrderHistoryDetail(int orderId)
		{
			Order order = _getOrderByIdService.GetOrderById(orderId);
			OrderDetailViewModel model = new OrderDetailViewModel
			{
				Order = order
			};
			return View(model);
		}

		public async Task<IActionResult> DeleteOrder(int orderId)
		{
			await DeleteOrderHandler.CancelOrder(
				_getOrderByIdService, _updateVoucherService,
				_updateOrderService,
				_updateProductSizeService,
				orderId);
			return RedirectToAction("OrderHistory");
		}

		[HttpGet]
		public IActionResult ForgotPassword()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> ForgotPassword(ForgetPasswordViewModel model)
		{
			if (ModelState.IsValid)
			{
				User user = await _userManager.FindByEmailAsync(model.Email);
				if(user != null && await _userManager.IsEmailConfirmedAsync(user))
				{
					string token = await _userManager.GeneratePasswordResetTokenAsync(user);
					string callbackUrl = Url.Action("ResetPassword", "Account", 
						new { email = model.Email, token = token }, Request.Scheme);

					await _emailSenderService.SendEmailAsync(model.Email, "Reset Password", 
						"Please reset your password by clicking here: <a href=\"" + callbackUrl + "\">link</a>");
					
					ViewBag.ErrorTitle = "Reset Password";
					ViewBag.ErrorMessage = "Your password has been reset. Please check your email.";
					return View("Error");
				} else
				{
					ViewBag.ErrorTitle = "Reset Password";
					ViewBag.ErrorMessage = "If you have an confirmed account with us, we have send you an email with instructions to reset your password.";
					return View("Error");
				}
			}

			return View(model);
		}

		public IActionResult ResetPassword(string token, string email)
		{
			if(token == null || email == null)
			{
				ModelState.AddModelError("", "Invalid password reset token.");
			}
			ResetPasswordViewModel model = new ResetPasswordViewModel { Token = token, Email = email };
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
		{
			if (ModelState.IsValid)
			{
				User user = await _userManager.FindByEmailAsync(model.Email);
				if(user != null)
				{
					var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
					if(result.Succeeded)
					{
						ViewBag.ErrorTitle = "Reset Password Success";
						return View("Error");
					}
					foreach(var error in result.Errors)
					{
						ModelState.AddModelError("", error.Description);
					}
					return View(model);
				}
			}
			return View();
		}


		public async Task<IActionResult> ChangePassword()
		{
			User user = _userManager.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
			ChangePasswordViewModel model = new ChangePasswordViewModel() { 
					User = user
			};	

			var hassPassword = await _userManager.HasPasswordAsync(user);
			if(!hassPassword)
			{
				return View("AddPassword", model);
			}

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
		{

			if (ModelState.IsValid)
			{
				User user = await _userManager.GetUserAsync(User);
				model.User = user;
				if(user == null)
				{
					return RedirectToAction("login");
				}

				var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, 
					model.NewPassword);

				if (result.Succeeded)
				{
					ViewBag.UpdateMessage = "Update Successful";
					await _signInManager.RefreshSignInAsync(user);
				} else
				{
					foreach(var error in result.Errors)
					{
						ModelState.AddModelError("", error.Description);
					}	
				}
			}

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> AddPassword(ChangePasswordViewModel model)
		{
			if (ModelState.IsValid)
			{
				User user = await _userManager.GetUserAsync(User);
				var result = await _userManager.AddPasswordAsync(user,model.NewPassword);

				if (result.Succeeded)
				{
					ViewBag.UpdateMessage = "Update Successful";
					await _signInManager.RefreshSignInAsync(user);
				} else
				{
					foreach(var error in result.Errors)
					{
						ModelState.AddModelError("", error.Description);
					}
				}
			}
			return View(model);
		}

		[AllowAnonymous]
		public IActionResult AccessDenied()
		{
			return View();
		}
	}
}

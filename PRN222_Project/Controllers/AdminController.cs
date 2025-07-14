﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRN222_Project.Models;
using PRN222_Project.ViewModels;

namespace PRN222_Project.Controllers
{

	[Authorize(Roles = "Admin")]
	public class AdminController : Controller
	{
		private RoleManager<IdentityRole> _roleManager;
		private UserManager<User> _userManager;

		public AdminController(RoleManager<IdentityRole> roleManager,
			UserManager<User> userManager)
		{
			_roleManager = roleManager;
			_userManager = userManager;
		}

		[HttpGet]
		public IActionResult CreateUser()
		{
			return View();
		}


		[HttpGet]
		[Authorize]
		public IActionResult CreateRole()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
		{
			if (ModelState.IsValid)
			{
				IdentityRole role = new IdentityRole()
				{
					Name = model.RoleName
				};
				IdentityResult result = await _roleManager.CreateAsync(role);
				if (result.Succeeded)
				{
					return RedirectToAction("listrole", "admin");
				}
				foreach (IdentityError error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
			}
			return View(model);
		}

		[HttpGet]
		[Authorize]
		public IActionResult ListRole()
		{
			List<IdentityRole> roles = _roleManager.Roles.ToList();
			return View(roles);
		}

		[HttpGet]
		public async Task<IActionResult> EditRole(string id)
		{
			IdentityRole role = await _roleManager.FindByIdAsync(id);
			if(role != null)
			{
				EditRoleViewModel model = new EditRoleViewModel()
				{
					Id = role.Id,
					RoleName = role.Name
				};
				List<User> userList = await _userManager.Users.ToListAsync();
				foreach (User user in userList)
				{
					if (await _userManager.IsInRoleAsync(user, role.Name))
					{
						model.UserList.Add(user);
					}
				}
				
				return View(model);
			}
			


			return View("/admin/ListRole");
		}

		[HttpPost]
		public async Task<IActionResult> EditRole(EditRoleViewModel model)
		{
			IdentityRole role = await _roleManager.FindByIdAsync(model.Id);
			if(role != null)
			{
				role.Name = model.RoleName;
				var result = await _roleManager.UpdateAsync(role);
				

				if (result.Succeeded)
				{
					return RedirectToAction("listrole", "admin");
				} else
				{
					foreach(IdentityError error in result.Errors)
					{
						ModelState.AddModelError("", error.Description);
					}
				}
			} else
			{
				ModelState.AddModelError("","Role not found");
			}

			return View(model);
		}


		[HttpGet]
		[Authorize]
		public async Task<IActionResult> EditUserRole(string roleId)
		{
			List<EditUserRoleViewModel> modelList = new List<EditUserRoleViewModel>();
			IdentityRole role = await _roleManager.FindByIdAsync(roleId);
			if(role != null) {
				List<User> users = await _userManager.Users.ToListAsync();

				foreach (var item in users)
				{
					EditUserRoleViewModel model = new EditUserRoleViewModel()
					{
						UserId = item.Id,
						UserName = item.UserName,
						Email = item.Email
					};
					if(await _userManager.IsInRoleAsync(item, role.Name))
					{
						model.IsSelected = true;
					} else
					{
						model.IsSelected = false;
					}

					modelList.Add(model);
				}
			}
			ViewBag.RoleId = roleId;
			return View(modelList);
		}


		[HttpPost]
		[Authorize]
		public async Task<IActionResult> EditUserRole( 
			List<EditUserRoleViewModel> modelList,string roleId)
		{
			foreach(var item in modelList)
			{
				IdentityRole role = await _roleManager.FindByIdAsync(roleId);

				User user = await _userManager.FindByIdAsync(item.UserId);
				if(item.IsSelected && !(await _userManager.IsInRoleAsync(user, role.Name)))
				{
					await _userManager.AddToRoleAsync(user, role.Name);
				} else if(!item.IsSelected && await _userManager.IsInRoleAsync(user, role.Name))
				{
					await _userManager.RemoveFromRoleAsync(user, role.Name);
				}
			}
			return RedirectToAction("EditRole", new { Id = roleId });
		}

	}
}

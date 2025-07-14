using PRN222_Project.Services.Interfaces;
using PRN222_Project.ViewModels;

namespace PRN222_Project.RequestHandlers.ProfileHandler
{
	public class UpdateAddressHandler
	{
		public static async Task UpdateAddress(NewAddressViewModel model, 
			ITurnOffAvailableDefaultAddressService _turnOffAvailableDefaultAddressService,
			IUpdateAddressService _updateAddressService) {
			model.Address.WardCode = model.Ward.Split("#")[0];
			model.Address.WardName = model.Ward.Split("#")[1];
			model.Address.DistrictId = model.District.Split("#")[0];
			model.Address.DistrictName = model.District.Split("#")[1];
			model.Address.ProvinceId = model.Province.Split("#")[0];
			model.Address.ProvinceName = model.Province.Split("#")[1];
			if (model.Address.IsDefault == true)
			{
				await _turnOffAvailableDefaultAddressService.TurnOffAvailableDefaultAddress(model.Address.UserId);
			}

			_updateAddressService.UpdateAddress(model.Address);
		}
	}
}

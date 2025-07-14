using PRN222_Project.Services.Interfaces;
using PRN222_Project.ViewModels;

namespace PRN222_Project.RequestHandlers.ProfileHandler
{
	public class AddNewAddressHandler
	{
		public static void SaveAddress(NewAddressViewModel model, IAddNewAddressService _addNewAddressService,
										ITurnOffAvailableDefaultAddressService _turnOffAvailableDefaultAddressService)
		{
			model.Address.WardCode = model.Ward.Split("#")[0];
			model.Address.WardName = model.Ward.Split("#")[1];
			model.Address.DistrictId = model.District.Split("#")[0];
			model.Address.DistrictName = model.District.Split("#")[1];
			model.Address.ProvinceId = model.Province.Split("#")[0];
			model.Address.ProvinceName = model.Province.Split("#")[1];
			if(model.Address.IsDefault == true)
			{
				_turnOffAvailableDefaultAddressService.TurnOffAvailableDefaultAddress(model.Address.UserId);
			}
				
			_addNewAddressService.AddNewAddress(model.Address);
		}
	}
}

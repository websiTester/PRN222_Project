using PRN222_Project.Models.VnPay;

namespace PRN222_Project.Services.VnPay
{
	public interface IVnPayService
	{
		string CreatePaymentUrl(PaymentInformationModel model, HttpContext context);
		PaymentResponseModel PaymentExecute(IQueryCollection collections);

	}
}

using PRN222_Project.Services.Interfaces;

namespace PRN222_Project.RequestHandlers.AccountHandler
{
	public class SendEmailHandler
	{
		public static async Task SendConfirmationLink(IEmailSenderService emailSenderService, 
			string link, string emailTo)
		{
			string message = 
				$@"Vui lòng xác nhận tài khoản của bạn bằng cách <a href='{link}'>bấm vào đây</a>."; 
			string subject = "Confirm your email";
			await emailSenderService.SendEmailAsync(emailTo,subject, message);
		}
	}
}

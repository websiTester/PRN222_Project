using PRN222_Project.Services.Interfaces;
using System.Net;
using System.Net.Mail;

namespace PRN222_Project.Services.Implementations
{
	public class EmailSenderService : IEmailSenderService
	{
		private IConfiguration _configuration;
		public EmailSenderService(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public async Task SendEmailAsync(string emailTo, string subject, string message)
		{
			string emailFrom = _configuration["EmailSettings:Email"];
			string password = _configuration["EmailSettings:Password"];
			string host = _configuration["EmailSettings:Host"];
			int port = Convert.ToInt32(_configuration["EmailSettings:Port"]);
			var client = new SmtpClient(host, port)
			{
				EnableSsl = true,
				Credentials = new NetworkCredential(emailFrom, password)
			};

			var mailMessage = new MailMessage(emailFrom, emailTo);
			mailMessage.Subject = subject;
			mailMessage.Body = message;
			mailMessage.IsBodyHtml = true;

			await client.SendMailAsync(mailMessage);
			
		}
	}
}

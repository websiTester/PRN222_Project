﻿namespace PRN222_Project.Services.Interfaces
{
	public interface IEmailSenderService
	{
		Task SendEmailAsync(string email, string subject, string message);
	}
}

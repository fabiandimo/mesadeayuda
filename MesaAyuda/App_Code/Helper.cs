using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace MesaAyuda.App_Code
{
	public class Helper
	{
		private delegate void AsyncSendEmail(
			List<string> to,
			string subject,
			string body);

		public static void SendEmail(
			List<string> to,
			string subject,
			string body)
		{
			AsyncSendEmail emailCaller = new AsyncSendEmail(sendEmail);
			emailCaller.Invoke(to, subject, body);
		}

		private static void sendEmail(
			List<string> to,
			string subject,
			string body)
		{
			try
			{
				MailMessage mailMessage = new MailMessage();

				to.ForEach(x =>
				{
					mailMessage.To.Add(new MailAddress(x));
				});

				mailMessage.Subject = subject;
				mailMessage.IsBodyHtml = true;
				mailMessage.Body = body;

				SmtpClient smtpClient = new SmtpClient();

				smtpClient.Send(mailMessage);
			}
			catch (Exception ex)
			{
				string error = ex.ToString();
			}
		}
	}
}
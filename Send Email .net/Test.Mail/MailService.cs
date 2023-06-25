using System.Net.Mail;
using System.Security;

namespace Test.Mail
{
    public class MailService
    {
        public void Send(EmailRequest m)
        {
            MailMessage message = new MailMessage(m.From, m.To, m.Subject, m.Body);
            message.IsBodyHtml = m.IsBodyHtml;

            SmtpClient smtpClient = new SmtpClient(m.Host);
            smtpClient.Port = 587;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new System.Net.NetworkCredential(m.User, m.Pass);
            smtpClient.EnableSsl = true;

            try
            {
                smtpClient.Send(message);
                Console.WriteLine("Email sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
            }
        }

    }
}

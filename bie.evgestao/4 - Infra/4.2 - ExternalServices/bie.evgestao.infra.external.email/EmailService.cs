using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;



namespace bie.evgestao.infra.emailservice
{

    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            return configSendGridasync(message);
        }


        private async Task configSendGridasync(IdentityMessage message)
        {
            var apiKey = ConfigurationManager.AppSettings["API_SENDGRID_KEY"];
            var client = new SendGridClient(apiKey);
            var subject = message.Subject;
            var from = new EmailAddress(ConfigurationManager.AppSettings["API_SENDGRID_FROM"]);
            var to = new EmailAddress(message.Destination);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, message.Body, message.Body);

            if (ConfigurationManager.AppSettings["EMAIL_DEBUG"] != null)
            {
                msg.AddBcc(ConfigurationManager.AppSettings["EMAIL_DEBUG"], "E-mail Debug BiExpert");
            }

            var response = await client.SendEmailAsync(msg);
            if (response.StatusCode != System.Net.HttpStatusCode.Accepted) throw new Exception("Erro ao enviar o e-mail. o erro foi " + response.StatusCode.ToString());                       

        }


        public async Task SendAsyncRegular(string email, string assunto, string corpo)
        {
            var apiKey = ConfigurationManager.AppSettings["API_SENDGRID_KEY"];
            var client = new SendGridClient(apiKey);
            var subject = assunto;
            var from = new EmailAddress(ConfigurationManager.AppSettings["API_SENDGRID_FROM"]);
            var to = new EmailAddress(email);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, corpo, corpo);

            if (ConfigurationManager.AppSettings["EMAIL_DEBUG"] != null)
            {
                msg.AddBcc(ConfigurationManager.AppSettings["EMAIL_DEBUG"], "E-mail Debug BiExpert");
            }

            var response = await client.SendEmailAsync(msg);
            if (response.StatusCode != System.Net.HttpStatusCode.Accepted) throw new Exception("Erro ao enviar o e-mail. o erro foi " + response.StatusCode.ToString());


        }

    }



}

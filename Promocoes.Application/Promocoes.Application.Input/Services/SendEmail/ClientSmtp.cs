using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Promocoes.Application.Input.Services.SendEmail
{
    public class ClientSmtp
    {
        public static Task SendEmail(string email, string subject, string token)
        {
            DotNetEnv.Env.Load();
            DotNetEnv.Env.TraversePath().Load();
            
            var mail = "ramonramos.silva@outlook.com";
            var pw = "ramonramos.";
            var apiUrl = Environment.GetEnvironmentVariable("URL_API");

            var message = @$"Por favor Não compartilhe este link com ninguem
                            Clique aqui para verificar sua conta: {apiUrl}/api/user/VerifyUser?Token={token}
            ";
            
            var client = new SmtpClient("smtp-mail.outlook.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, pw)
            };
            
            return client.SendMailAsync(
                new MailMessage(from: mail,
                                to: email,
                                subject,
                                message));
        }
    }
}
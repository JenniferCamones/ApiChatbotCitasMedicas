using MimeKit;
using System.IO;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace ChatbotCitasMedicas.ApiNetCore.Util
{
    public class MailService : IMailService
    {
        private readonly IWebHostEnvironment _env;
        private readonly MailSettings _mailSettings;
        private readonly IConfiguration _configuration;
        public MailService(IOptions<MailSettings> mailSettings, IWebHostEnvironment env, IConfiguration configuration)
        {
            _env = env;
            _mailSettings = mailSettings.Value;
            _configuration = configuration;
        }
        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            //if (_configuration["EnviarCorreo"] == "NO") return;

            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            if (string.IsNullOrWhiteSpace(mailRequest.ToEmail))
            {
                foreach (var em in mailRequest.ListToEmail)
                {
                    email.To.Add(MailboxAddress.Parse(em));
                }
            }
            else
                email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            if (mailRequest.Attachments != null)
            {
                byte[] fileBytes;
                foreach (var file in mailRequest.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }
            //if (mailRequest.Adjuntos != null)
            //{
            //    foreach (var dir in mailRequest.Adjuntos)
            //    {
            //        string NombreCarpeta = "/Archivos/";
            //        string RutaRaiz = _env.ContentRootPath;
            //        string RutaCompleta = RutaRaiz + NombreCarpeta;
            //        string RutaFullCompleta = Path.Combine(RutaCompleta, dir.stNombreArchivoRuta);
            //        byte[] byteArray = File.ReadAllBytes(RutaFullCompleta);                    
            //        builder.Attachments.Add(dir.stNombreArchivo, byteArray);
            //    }
            //}
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}

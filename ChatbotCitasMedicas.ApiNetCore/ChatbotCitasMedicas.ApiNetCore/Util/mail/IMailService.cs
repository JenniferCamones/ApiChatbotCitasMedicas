using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatbotCitasMedicas.ApiNetCore.Util
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
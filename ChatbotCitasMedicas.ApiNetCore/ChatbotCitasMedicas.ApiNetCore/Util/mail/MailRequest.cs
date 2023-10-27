using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatbotCitasMedicas.ApiNetCore.Util
{
    public class MailRequest
    {
        public string ToEmail { get; set; }
        public List<string> ListToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<IFormFile> Attachments { get; set; }
        //public List<TmAdjunto> tmAdjuntos { get; set; }
    }
}

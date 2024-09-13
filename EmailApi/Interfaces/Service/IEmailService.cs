using EmailApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailApi.Interfaces.Service
{
    public interface IEmailService
    {
        Task<bool> SendEmail(EmailModel dados);
        Task<EmailModel> GetEmail(EmailModel dados);
        Task<List<EmailModel>> GetEmails(EmailModel dados);
        Task<bool> UpdateEmail(EmailModel dados);
        Task<bool> DeleteEmail(EmailModel dados);
        Task<bool> VerifySpam(EmailModel dados);
        Task<bool> GetTema(EmailModel dados);


    }
}

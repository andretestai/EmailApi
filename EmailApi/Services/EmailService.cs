using EmailApi.Interfaces.Repository;
using EmailApi.Interfaces.Service;
using EmailApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailApi.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailRepository _emailRepository;

        public EmailService(IEmailRepository emailRepository)
        {
            _emailRepository = emailRepository;
        }

        public async Task<bool> DeleteEmail(EmailModel dados)
        {
            return await _emailRepository.DeleteEmail(dados);
        }

        public async Task<EmailModel> GetEmail(EmailModel dados)
        {
            return await _emailRepository.GetEmail(dados);
        }

        public async Task<List<EmailModel>> GetEmails(EmailModel dados)
        {
            return await _emailRepository.GetEmails(dados);
        }

        public async Task<bool> GetTema(EmailModel dados)
        {
            return await _emailRepository.GetTema(dados);
        }

        public async Task<bool> SendEmail(EmailModel dados)
        {
            return await _emailRepository.SendEmail(dados);
        }

        public async Task<bool> UpdateEmail(EmailModel dados)
        {
            return await _emailRepository.UpdateEmail(dados);
        }

        public async Task<bool> VerifySpam(EmailModel dados)
        {
            return await _emailRepository.VerifySpam(dados);
        }
    }
}

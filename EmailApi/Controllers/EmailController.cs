using EmailApi.Interfaces.Service;
using EmailApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmailApi.Controllers
{
    [Route("[controller]")]
    public class EmailController : Controller
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("SendEmail")]
        public async Task<bool> SendEmail([FromBody] EmailModel dados)
        {
            var validar = await _emailService.SendEmail(dados);

            return validar;
        }

        [HttpGet("GetEmail")]
        public async Task<EmailModel> GetEmail(int id)
        {
            var email = new EmailModel()
            {
                Id= id
            };

            return await _emailService.GetEmail(email);
        }

        [HttpGet("GetEmails")]
        public async Task<List<EmailModel>> GetEmails()
        {

            return await _emailService.GetEmails();
        }

        [HttpPut("UpdateEmail")]
        public async Task<bool> UpdateEmail([FromBody] EmailModel dados)
        {
            var validar = await _emailService.UpdateEmail(dados);

            return validar;
        }

        [HttpDelete("DeleteEmail")]
        public async Task<bool> DeleteEmail(int id)
        {
            var email = new EmailModel()
            {
                Id = id
            };

            var validar = await _emailService.DeleteEmail(email);

            return validar;
        }

        [HttpGet("VerifySpam")]
        public async Task<bool> VerifySpam (string? emailDestinatario)
        {

            var email = new EmailModel()
            {
                EmailDestinatario = emailDestinatario
            };

            return await _emailService.VerifySpam(email);
        }

        [HttpGet("GetTema")]
        public async Task<TemaModel> GetTema (int? idTema)
        {
            var tema = new TemaModel()
            {
                Id = idTema
            };

            return await _emailService.GetTema(tema);
        }

        [HttpPut("UpdateTema")]
        public async Task<TemaModel> UpdateTema(int idTema)
        {
            var tema = new TemaModel()
            {
                Id = idTema
            };
            return await _emailService.UpdateTema(tema);

        }
    }
}

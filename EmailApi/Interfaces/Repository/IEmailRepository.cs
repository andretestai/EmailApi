using EmailApi.Model;

namespace EmailApi.Interfaces.Repository
{
    public interface IEmailRepository
    {
        Task<bool> SendEmail(EmailModel dados);
        Task<EmailModel> GetEmail(EmailModel dados);
        Task<List<EmailModel>> GetEmails();
        Task<bool> UpdateEmail(EmailModel dados);
        Task<bool> DeleteEmail(EmailModel dados);
        Task<bool> VerifySpam(EmailModel dados);
        Task<TemaModel> GetTema(TemaModel dados);

    }
}

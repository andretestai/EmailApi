using EmailApi.Data.Database;
using EmailApi.Interfaces.Repository;
using EmailApi.Model;
using Microsoft.EntityFrameworkCore;

namespace EmailApi.Data.Repository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly DatabaseContext _context;

        public EmailRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteEmail(EmailModel dados)
        {
            try
            {
                var validar = _context.Email.Where(at => at.Id == dados.Id).FirstOrDefault();

                if (validar != null)
                {
                    _context.Email.Remove(validar);
                    await _context.SaveChangesAsync();

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar email" + ex);
            }
        }

        public async Task<EmailModel> GetEmail(EmailModel dados)
        {
            try
            {
                return await _context.Email.Where(at => at.Id == dados.Id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao achar email" + ex);
            }
        }

        public async Task<List<EmailModel>> GetEmails()
        {

            try
            {
                return await _context.Email.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao achar emails" + ex);
            }
        }

        public async Task<bool> SendEmail(EmailModel dados)
        {
            try
            {
                var verificar = false /*await VerifySpam(dados)*/;

                if (!verificar)
                {
                    await _context.Email.AddAsync(dados);
                    await _context.SaveChangesAsync();
                }
                return true;
            }
            catch(Exception ex) 
            {
                throw new Exception("Erro ao cadastrar email" + ex);
            }
        }

        public async Task<bool> UpdateEmail(EmailModel dados)
        {
            try
            {
                var emailExistente = await _context.Email.Where(at => at.Id == dados.Id).FirstOrDefaultAsync();

                if (emailExistente != null)
                {
                    emailExistente.Id = dados.Id;
                    emailExistente.Assunto = dados.Assunto;
                    emailExistente.Mensagem = dados.Mensagem;
                    emailExistente.EmailRemetente = dados.EmailRemetente;
                    emailExistente.EmailDestinatario = dados.EmailDestinatario;
                    emailExistente.Remetente = dados.Remetente;
                    emailExistente.DataEnvio = dados.DataEnvio;
                    emailExistente.Favorito = dados.Favorito;

                    _context.Email.Update(emailExistente);
                    await _context.SaveChangesAsync();

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao editar email" + ex);
            }
        }

        public async Task<bool> VerifySpam(EmailModel dados)
        {
            try
            {
                var cincoMinutosAtras = DateTime.Now.AddMinutes(-5);

                var quantidadeEmails = await _context.Email
                    .Where(e => e.EmailDestinatario == dados.EmailDestinatario && e.DataEnvio > cincoMinutosAtras)
                    .CountAsync();

                if (quantidadeEmails > 10)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao verificar spams" + ex);
            }
        }

        public async Task<TemaModel> GetTema(TemaModel dados)
        {
            try
            {
                var tema = await _context.Tema
                    .Where(e => e.Id == dados.Id)
                    .OrderByDescending(e => e.Id)
                    .FirstOrDefaultAsync();

                if (tema == null)
                {
                    return null!; 
                };

                return tema;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao pegar tema", ex); 
            }
        }

        public async Task<TemaModel> UpdateTema(TemaModel dados)
        {
            try
            {
                var emailExistente = await _context.Tema.Where(at => at.Id == dados.Id).FirstOrDefaultAsync();

                if (emailExistente != null)
                {
                    emailExistente.Id = dados.Id;
                    emailExistente.Tema = dados.Tema;

                    _context.Tema.Update(emailExistente);
                    await _context.SaveChangesAsync();

                    return emailExistente;
                }

                return emailExistente!;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao editar email" + ex);
            }
        }
    }
}

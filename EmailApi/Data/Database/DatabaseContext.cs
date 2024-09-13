using EmailApi.Model;
using Microsoft.EntityFrameworkCore;

namespace EmailApi.Data.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<EmailModel> Email { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmailModel>(entity =>
            {
                entity.ToTable("TB_Email");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Assunto).HasMaxLength(255);
                entity.Property(e => e.Mensagem);
                entity.Property(e => e.EmailRemetente).IsRequired().HasColumnName("Email_Rementente");
                entity.Property(e => e.EmailDestinatario).IsRequired().HasColumnName("Email_Destinatario");
                entity.Property(e => e.Remetente).HasMaxLength(100);
                entity.Property(e => e.DataEnvio).HasColumnName("Data_Envio").HasColumnType("TIMESTAMP");
                entity.Property(e => e.Favorito);
                entity.Property(e => e.Tema);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
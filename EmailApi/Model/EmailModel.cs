using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailApi.Model
{
    public class EmailModel
    {
        public int? Id { get; set; }
        public string? Assunto { get; set; }
        public string? Mensagem { get; set; }
        public string? EmailRemetente { get; set; }
        public string? EmailDestinatario { get; set; }
        public string? Remetente { get; set; }
        public DateTime? DataEnvio { get; set; }
        public int? Favorito { get; set; }
    }
}

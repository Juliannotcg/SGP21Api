using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_SGP.Model
{
    public class Usuario
    {
        [Key]
        public int UsuId { get; set; }
        public int Usu_PerId { get; set; }
        public string UsuLogin { get; set; }
        public string UsuNome { get; set; }
        public string UsuSenha { get; set; }
        public int UsuCategoria { get; set; }
        public int UsuSituacao { get; set; }
        public int UsuPrazoSenha { get; set; }
        public DateTime UsuUltimaAlteracaoSenha { get; set; }
        public int Usu_CrgId { get; set; }
        public TimeSpan UsuHoraInicioExpediente { get; set; }
        public TimeSpan UsuHoraFimExpediente { get; set; }
    }
}

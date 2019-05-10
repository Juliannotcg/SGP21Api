using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_SGP.Model
{
    public class Usuario
    {
        [Key]
        public int UsuId { get; set; }
        public string UsuLogin { get; set; }
        public string UsuNome { get; set; }
        public string UsuSenha { get; set; }
        public int UsuCategoria { get; set; }
        public int UsuSituacao { get; set; }
        public int UsuPrazoSenha { get; set; }
        public DateTime UsuUltimaAlteracaoSenha { get; set; }

        [ForeignKey("Usu_CrgId")]
        public Cargo Cargo { get; set; }

        public TimeSpan UsuHoraInicioExpediente { get; set; }
        public TimeSpan UsuHoraFimExpediente { get; set; }

        [ForeignKey("Usu_PerId")]
        public virtual Perfil Perfil { get; set; }
    }
}

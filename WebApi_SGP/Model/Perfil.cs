using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_SGP.Model
{
    public class Perfil
    {
        [Key]
        public int PerId { get; set; }
        public int Per_SisId { get; set; } = 1;
        public string PerNome { get; set; }
        public string PerDescricao { get; set; }
    }
}

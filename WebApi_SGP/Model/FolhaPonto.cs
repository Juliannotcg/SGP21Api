using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_SGP.Model
{
    public class FolhaPonto
    {
        [Key]
        public int FlpId { get; set; }
        public Usuario Flp_UsuId { get; set; }
        public DateTime FlpData { get; set; }
        public int FlpEntradas { get; set; }
        public int FlpSaidas { get; set; }
        public int FlpAbonos { get; set; }
        public int FlpTrabalhadas { get; set; }
        public int FlpAbonadas { get; set; }
        public int FlpHorasPlanoIncentivo { get; set; }
        public int FlpCumpriuPlanoIncentivo { get; set; }
    }
}

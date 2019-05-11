using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_SGP.Model
{
    public class FolhaPonto
    {
        [Key]
        public int FlpId { get; set; }
        public DateTime FlpData { get; set; }
        public int FlpEntradas { get; set; }
        public int FlpSaidas { get; set; }
        public int FlpAbonos { get; set; }
        public int FlpTrabalhadas { get; set; }
        public int FlpAbonadas { get; set; }
        public int FlpHorasPlanoIncentivo { get; set; }
        public bool FlpCumpriuPlanoIncentivo { get; set; }

        [ForeignKey("Flp_UsuId")]
        public Usuario Usuario { get; set; }
    }
}

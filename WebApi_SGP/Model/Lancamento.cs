using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_SGP.Model
{
    public class Lancamento
    {
        [Key]
        public int LanId { get; set; }
        public FolhaPonto Lan_Flp { get; set; }
        public DateTime LanDataHora { get; set; }
        public int LanTipo { get; set; }
        public string LanObservacao { get; set; }
        public bool LanEdicaoManual { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_SGP.Model
{
    public class Cargo
    {
        [Key]
        public int CrgId { get; set; }
        public string CrgNome { get; set; }
    }
}

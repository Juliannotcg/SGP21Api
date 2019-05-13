using System;

namespace WebApi_SGP.Model
{
    public class Abono
    {
        public int AbnId { get; set; }
        public int AbnCriador_UsuId { get; set; }
        public int AbnBeneficiado_UsuId { get; set; }
        public DateTime AbnDataLancamento { get; set; }
        public DateTime AbnData { get; set; }
        public DateTime AbnHoraInicio { get; set; }
        public DateTime AbnHoraFim { get; set; }
        public int AbnTipo { get; set; }
        public string AbnJustificativa { get; set; }
        public bool AbnAbonaPlanoIncentivo { get; set; }
        
    }
}

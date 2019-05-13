using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi_SGP.Model;

namespace WebApi_SGP.Maps
{
    public class AbonoMap : IEntityTypeConfiguration<Abono>
    {
        public void Configure(EntityTypeBuilder<Abono> builder)
        {
            builder.ToTable("SGP21_AbnAbono");

            builder.Property(c => c.AbnCriador_UsuId)
               .HasColumnName("AbnCriador_UsuId");

            builder.Property(c => c.AbnBeneficiado_UsuId)
              .HasColumnName("AbnBeneficiado_UsuId");

            builder.Property(c => c.AbnDataLancamento)
             .HasColumnName("AbnDataLancamento");

            builder.Property(c => c.AbnData)
             .HasColumnName("AbnData");

            builder.Property(c => c.AbnHoraInicio)
             .HasColumnName("AbnHoraInicio");

            builder.Property(c => c.AbnHoraFim)
             .HasColumnName("AbnHoraFim");

            builder.Property(c => c.AbnTipo)
             .HasColumnName("AbnTipo");

            builder.Property(c => c.AbnJustificativa)
             .HasColumnName("AbnJustificativa");

            builder.Property(c => c.AbnAbonaPlanoIncentivo)
             .HasColumnName("AbnAbonaPlanoIncentivo");
        }
    }
}

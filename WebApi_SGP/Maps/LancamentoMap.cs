using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_SGP.Model;

namespace WebApi_SGP.Maps
{
    public class LancamentoMap : IEntityTypeConfiguration<Lancamento>
    {
        public void Configure(EntityTypeBuilder<Lancamento> builder)
        {
            builder.ToTable("SGP21_LanLancamento");

            builder.Property(c => c.LanId)
               .HasColumnName("LanId");

            builder.Property(c => c.LanDataHora)
              .HasColumnName("LanDataHora");

            builder.Property(c => c.LanTipo)
              .HasColumnName("LanTipo");

            builder.Property(c => c.LanObservacao)
                .HasColumnName("LanObservacao");

            builder.Property(c => c.LanEdicaoManual)
                .HasColumnName("LanEdicaoManual");
        }
    }
}
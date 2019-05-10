using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_SGP.Model;

namespace WebApi_SGP.Maps
{
    public class FolhaPontoMap : IEntityTypeConfiguration<FolhaPonto>
    {
        public void Configure(EntityTypeBuilder<FolhaPonto> builder)
        {
            builder.ToTable("SGP21_FlpFolhaPonto");

            builder.Property(c => c.FlpId)
               .HasColumnName("FlpId");

            builder.Property(c => c.FlpData)
              .HasColumnName("FlpData");

            builder.Property(c => c.FlpEntradas)
              .HasColumnName("FlpEntradas");

            builder.Property(c => c.FlpSaidas)
                .HasColumnName("FlpSaidas");

            builder.Property(c => c.FlpAbonos)
                .HasColumnName("FlpAbonos");

            builder.Property(c => c.FlpTrabalhadas)
                .HasColumnName("FlpTrabalhadas");

            builder.Property(c => c.FlpAbonadas)
                .HasColumnName("FlpAbonadas");

            builder.Property(c => c.FlpHorasPlanoIncentivo)
                .HasColumnName("FlpHorasPlanoIncentivo");

            builder.Property(c => c.FlpCumpriuPlanoIncentivo)
                .HasColumnName("FlpCumpriuPlanoIncentivo");

        }
    }
}
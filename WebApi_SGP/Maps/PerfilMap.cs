using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_SGP.Model;

namespace WebApi_SGP.Maps
{
    public class PerfilMap : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            builder.ToTable("PerPerfil");

            builder.Property(c => c.PerId)
               .HasColumnName("PerId");

            builder.Property(c => c.PerNome)
              .HasColumnName("PerNome");

            builder.Property(c => c.PerDescricao)
              .HasColumnName("PerDescricao");

            builder.Property(c => c.Per_SisId)
             .HasColumnName("Per_SisId");
        }
    }
}

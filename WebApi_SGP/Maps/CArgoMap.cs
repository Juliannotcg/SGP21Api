﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_SGP.Model;

namespace WebApi_SGP.Maps
{
    public class CargoMap : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            builder.ToTable("CrgCargo");

            builder.Property(c => c.CrgId)
               .HasColumnName("CrgId");

            builder.Property(c => c.CrgNome)
              .HasColumnName("CrgNome");
        }
    }
}

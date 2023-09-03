using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocadoraCarros.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraCarros.Infra.Data.EntitiesConfig
{
    public class AluguelConfiguration : IEntityTypeConfiguration<Aluguel>
    {
        public void Configure(EntityTypeBuilder<Aluguel> builder)
        {
            builder.HasKey(h => h.Id);
            builder.Property(p => p.DataInicio).HasColumnType("datetime");
            builder.Property(p => p.DataFim).HasColumnType("datetime");
            builder.Property(p => p.ValorAluguel).HasPrecision(10,2);
        }      
    }
}
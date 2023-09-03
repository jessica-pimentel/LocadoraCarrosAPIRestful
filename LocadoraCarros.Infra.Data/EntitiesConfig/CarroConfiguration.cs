using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocadoraCarros.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraCarros.Infra.Data.EntitiesConfig
{
    public class CarroConfiguration : IEntityTypeConfiguration<Carro>
    {
        public void Configure(EntityTypeBuilder<Carro> builder)
        {
            builder.HasKey(h => h.Id);
            builder.Property(p => p.Modelo).HasMaxLength(40);
            builder.Property(p => p.Marca).HasMaxLength(40);
            builder.Property(p => p.Ano).HasColumnType("int").HasMaxLength(4);


            builder.HasData(
                new Carro(1, "Fusca", "Volkswagen", 1970),
                new Carro(2, "Kombi", "Volkswagen", 1979),
                new Carro(3, "Ford Mustang", "Ford", 1965),
                new Carro(4, "Fiat 600", "Fiat", 1955),
                new Carro(5, "Brasília", "Volkswagen", 1975)
            );
        }
    }
}
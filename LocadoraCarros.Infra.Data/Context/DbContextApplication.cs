using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocadoraCarros.Domain;
using LocadoraCarros.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.ComponentModel;
using System.Reflection;

namespace LocadoraCarros.Infra.Data.Context
{
    public class DbContextApplication : DbContext
    {
        public DbContextApplication(DbContextOptions<DbContextApplication> options) : base(options)
        {
            
        }

        public DbSet<Carro> Carro {get; set;}
        public DbSet<Aluguel> Aluguel {get; set;}
        public DbSet<Usuario> Usuario {get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
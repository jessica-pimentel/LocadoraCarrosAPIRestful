using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocadoraCarros.Domain.Interfaces;
using LocadoraCarros.Infra.Data.Context;
using LocadoraCarros.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using LocadoraCarros.Infra.IoC;
using AutoMapper;
using LocadoraCarros.Application.Interfaces;
using LocadoraCarros.Application.Services;
using LocadoraCarros.Application.Mappings;
using MediatR;

namespace LocadoraCarros.Infra.IoC
{
    public static class InjecaoDeDependencia
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbContextApplication>
            (options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), 
            b => b.MigrationsAssembly(typeof(DbContextApplication).Assembly.FullName)));

            services.AddScoped<ICarroRepository, CarroRepository>();
            services.AddScoped<IAluguelRepository, AluguelRepository>();
            services.AddScoped<ICarroService, CarroService>();
            services.AddScoped<IAluguelService, AluguelService>();
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            var myhandlers = AppDomain.CurrentDomain.Load("LocadoraCarros.Application");
            services.AddMediatR(myhandlers);

            return services;
        }
    }
}
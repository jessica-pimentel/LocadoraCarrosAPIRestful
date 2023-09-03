using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocadoraCarros.Domain.Entities;
using LocadoraCarros.Domain.Interfaces;
using LocadoraCarros.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace LocadoraCarros.Infra.Data.Repositories
{
    public class CarroRepository : ICarroRepository
    {
        DbContextApplication _carroContext;
        public CarroRepository(DbContextApplication context)
        {
            _carroContext = context;
        }

        public async Task<Carro> Create(Carro carro)
        {
            _carroContext.Add(carro);
            await _carroContext.SaveChangesAsync();
            return carro;
        }

        public async Task<Carro> BuscaPorId(int? id)
        {
            return await _carroContext.Carro.FindAsync(id);
        }

        public async Task<IEnumerable<Carro>> GetCarros()
        {
           return await _carroContext.Carro.ToListAsync();
        }

        public async Task<Carro> Update(Carro carro)
        {
            _carroContext.Update(carro);
            await _carroContext.SaveChangesAsync();
            return carro;           
        }

        public async Task<Carro> Remove(int? id)
        {
            var carro = await _carroContext.Carro.FindAsync(id);
            if (carro != null)
            {
                _carroContext.Carro.Remove(carro);
                await _carroContext.SaveChangesAsync();
            }
            return carro;
        }

    }
}
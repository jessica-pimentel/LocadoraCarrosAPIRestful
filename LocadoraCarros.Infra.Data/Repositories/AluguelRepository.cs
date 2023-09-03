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
    public class AluguelRepository : IAluguelRepository
    {
        DbContextApplication _aluguelContext;
        public AluguelRepository(DbContextApplication context)
        {
            _aluguelContext = context;
        }
        
        public async Task<Aluguel> CreateAsync(Aluguel aluguel)
        {
            _aluguelContext.Add(aluguel);
            await _aluguelContext.SaveChangesAsync();
            return aluguel;
        }

        public async Task<Aluguel> BuscaPorIdAsync(int? id)
        {
            return await _aluguelContext.Aluguel.FindAsync(id);
        }

        public async Task<IEnumerable<Aluguel>> getAluguelAsync()
        {
           return await _aluguelContext.Aluguel.ToListAsync();
        }

        public async Task<Aluguel> getAluguelCarroAsync(int? id)
        {
            return await _aluguelContext.Aluguel.Include(c=> c.Carro).SingleOrDefaultAsync(p=> p.Id == id);
        }

        public async Task<Aluguel> UpdateAsync(Aluguel aluguel)
        {
            _aluguelContext.Update(aluguel);
            await _aluguelContext.SaveChangesAsync();
            return aluguel;           
        }

        public async Task<Aluguel> RemoveAsync(int? id)
        {
            var aluguel = await _aluguelContext.Aluguel.FindAsync(id);
            _aluguelContext.Remove(aluguel);
            await _aluguelContext.SaveChangesAsync();
            return aluguel;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocadoraCarros.Domain.Entities;

namespace LocadoraCarros.Domain.Interfaces
{
    public interface IAluguelRepository
    {
        Task<IEnumerable<Aluguel>> getAluguelAsync();
        Task<Aluguel> BuscaPorIdAsync(int? id);
        Task<Aluguel> getAluguelCarroAsync(int? id);
        Task<Aluguel> CreateAsync(Aluguel aluguel);
        Task<Aluguel> UpdateAsync(Aluguel aluguel);
        Task<Aluguel> RemoveAsync(int? id);
    }
}
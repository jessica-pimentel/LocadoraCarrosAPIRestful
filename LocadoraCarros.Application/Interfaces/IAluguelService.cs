using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocadoraCarros.Application.DTO;

namespace LocadoraCarros.Application.Interfaces
{
    public interface IAluguelService
    {
        Task<IEnumerable<AluguelDTO>> getAluguelAsync();
        Task<AluguelDTO> BuscaPorIdAsync(int? id);
        Task<AluguelDTO> getAluguelCarroAsync(int? id);
        Task Add(AluguelDTO aluguelDTO);
        Task Update(AluguelDTO aluguelDTO);
        Task Remove(int? id);
    }
}
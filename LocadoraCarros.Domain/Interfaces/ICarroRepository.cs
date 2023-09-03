using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocadoraCarros.Domain.Entities;

namespace LocadoraCarros.Domain.Interfaces
{
    public interface ICarroRepository
    {
        Task<IEnumerable<Carro>> GetCarros();
        Task<Carro> BuscaPorId(int? id);
        Task<Carro> Create(Carro carros);
        Task<Carro> Update(Carro carros);
        Task<Carro> Remove(int? id);
    }
}
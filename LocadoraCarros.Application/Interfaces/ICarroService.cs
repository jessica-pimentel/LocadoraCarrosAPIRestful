using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocadoraCarros.Application.DTO;

namespace LocadoraCarros.Application.Interfaces
{
    public interface ICarroService
    {
        Task<IEnumerable<CarroDTO>> GetCarros();
        Task<CarroDTO> BuscaPorId(int? id);
        Task Add(CarroDTO carroDto);
        Task Update(CarroDTO carroDTO);
        Task Remove(int? id);
    
}
}
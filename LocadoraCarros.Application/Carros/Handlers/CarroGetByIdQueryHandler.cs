using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocadoraCarros.Application.Carros.Querys;
using LocadoraCarros.Domain.Entities;
using LocadoraCarros.Domain.Interfaces;
using MediatR;

namespace LocadoraCarros.Application.Carros.Handlers
{
    public class CarroGetByIdQueryHandler : IRequestHandler<CarroGetByIdQuery, Carro>
    {
        private readonly ICarroRepository _carroRepository;
        
        public CarroGetByIdQueryHandler(ICarroRepository carroRepository)
        {
            _carroRepository = carroRepository;
        }

        public async Task<Carro> Handle(CarroGetByIdQuery request, CancellationToken cancellationToken)
        {
            return await _carroRepository.BuscaPorId(request.Id);
        }
    }
}
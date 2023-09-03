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
    public class CarroGetQueryHandler : IRequestHandler<CarroGetQuery, IEnumerable<Carro>>
    {
        private readonly ICarroRepository _carroRepository;

        public CarroGetQueryHandler(ICarroRepository carroRepository)
        {
            _carroRepository = carroRepository;
        }

        public async Task<IEnumerable<Carro>> Handle(CarroGetQuery request, CancellationToken cancellationToken)
        {
            return await _carroRepository.GetCarros();
        }
    }
}
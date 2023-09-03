using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocadoraCarros.Application.Carros.Commands;
using LocadoraCarros.Domain.Entities;
using LocadoraCarros.Domain.Interfaces;
using MediatR;

namespace LocadoraCarros.Application.Carros.Handlers
{
    public class CarroUpdateCommandHandler : IRequestHandler<CarroUpdateCommand, Carro>
    {
        private readonly ICarroRepository _carroRepository;
        public CarroUpdateCommandHandler(ICarroRepository carroRepository)
        {
            _carroRepository = carroRepository ??
            throw new ArgumentNullException(nameof(carroRepository));
        }

        public async Task<Carro> Handle(CarroUpdateCommand request, CancellationToken cancellationToken)
        {
            var carro = await _carroRepository.BuscaPorId(request.Id);
            if (carro == null)
            {
                throw new ApplicationException($"Carro não existe!");
            }
            else
            {
                carro.Update(request.Id, request.Marca, request.Modelo, request.Ano);
                return await _carroRepository.Update(carro);
            }
        }
    }
}
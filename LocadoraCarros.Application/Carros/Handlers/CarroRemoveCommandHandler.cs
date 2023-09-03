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
    public class CarroRemoveCommandHandler :  IRequestHandler<CarroRemoveCommand, Carro>
    {
        private readonly ICarroRepository _carroRepository;
        public CarroRemoveCommandHandler(ICarroRepository carroRepository)
        {
            _carroRepository = carroRepository ?? throw new ArgumentNullException(nameof(carroRepository));

        }

        public async Task<Carro> Handle(CarroRemoveCommand request, CancellationToken cancellationToken)
        {
            var carro = await _carroRepository.BuscaPorId(request.Id);
            if(carro == null)
            {
                throw new ApplicationException($"Carro não existe!");
            }
            else
            {
                var result = await _carroRepository.Remove(carro.Id);
                return result;
            }
        }
    }
}
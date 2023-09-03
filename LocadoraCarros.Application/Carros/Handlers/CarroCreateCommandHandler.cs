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
    public class CarroCreateCommandHandler : IRequestHandler<CarroCreateCommand, Carro>
    {
        private readonly ICarroRepository _carroRepository;
        public CarroCreateCommandHandler(ICarroRepository carroRepository)
        {
            _carroRepository = carroRepository;
        }
        public async Task<Carro> Handle(CarroCreateCommand request, CancellationToken cancellationToken)
        {
            var carro = new Carro(request.Id, request.Marca, request.Modelo, request.Ano);

            if(carro == null)
            {
                throw new ApplicationException($"Carro não existe!");
            }
            else
            {
                carro.Id = request.CarroId;
                return await _carroRepository.Create(carro);
            }
        }
    }
}
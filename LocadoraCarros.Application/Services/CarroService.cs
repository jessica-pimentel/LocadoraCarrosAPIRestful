using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LocadoraCarros.Application.DTO;
using LocadoraCarros.Application.Interfaces;
using LocadoraCarros.Application.Carros.Querys;
using LocadoraCarros.Domain.Entities;
using LocadoraCarros.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using LocadoraCarros.Application.Carros.Commands;

namespace LocadoraCarros.Application.Services
{
    public class CarroService : ICarroService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CarroService(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CarroDTO>> GetCarros()
        {
            var carroQuery = new CarroGetQuery();
            if (carroQuery == null)
                throw new Exception($"Não encontrado!");

            var result = await _mediator.Send(carroQuery);
            return _mapper.Map<IEnumerable<CarroDTO>>(result);
        }

        public async Task<CarroDTO> BuscaPorId(int? id)
        {
            var carroByIdQuery = new CarroGetByIdQuery(id.Value);
            if (carroByIdQuery == null)
                throw new Exception($"Não encontrado!");

            var result = await _mediator.Send(carroByIdQuery);
            return _mapper.Map<CarroDTO>(result);
        }

        public async Task Add(CarroDTO carroDTO)
        {
            var carroCreateCommand = _mapper.Map<CarroCreateCommand>(carroDTO);
            await _mediator.Send(carroCreateCommand);
        }

        public async Task Update(CarroDTO carroDTO)
        {
            var carroUpdateCommand = _mapper.Map<CarroUpdateCommand>(carroDTO);
            await _mediator.Send(carroUpdateCommand);
        }

        public async Task Remove(int? id)
        {
            var carroRemoveCommand = new CarroRemoveCommand(id.Value);
            if (carroRemoveCommand == null)
                throw new Exception($"Carro não foi encontrado!");
            
            await _mediator.Send(carroRemoveCommand);

        }
        
    }
}
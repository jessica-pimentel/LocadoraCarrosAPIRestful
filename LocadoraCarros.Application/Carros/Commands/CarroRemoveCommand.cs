using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocadoraCarros.Domain.Entities;
using MediatR;

namespace LocadoraCarros.Application.Carros.Commands
{
    public class CarroRemoveCommand : IRequest<Carro>
    {
        public int Id { get; set; }

        public CarroRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocadoraCarros.Domain.Entities;
using MediatR;

namespace LocadoraCarros.Application.Carros.Querys
{
    public class CarroGetQuery : IRequest<IEnumerable<Carro>>
    {
        
    }
}
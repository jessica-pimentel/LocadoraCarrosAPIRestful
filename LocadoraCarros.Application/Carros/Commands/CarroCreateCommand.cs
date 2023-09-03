using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocadoraCarros.Domain.Entities;
using MediatR;

namespace LocadoraCarros.Application.Carros.Commands
{
    public class CarroCreateCommand : IRequest<Carro>
    {
        public int CarroId { get; set; }
        public int Id {get; set;}
        public string Modelo {get; set;}
        public string Marca {get; set;}
        public int Ano {get; set;}
        public bool IsAlugado {get; set;}
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocadoraCarros.Domain.Entities;

namespace LocadoraCarros.Application.DTO
{
    public class AluguelDTO
    {
        public int Id {get; set;}
        public int CarroId { get; set; }
        public int UsuarioId {get; set;}
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; } 
        public decimal ValorAluguel {get; set;}
    }
}
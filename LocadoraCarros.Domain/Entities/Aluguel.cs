using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocadoraCarros.Domain.Validation;

namespace LocadoraCarros.Domain.Entities
{
    public class Aluguel : EntityBase
    { 
        public int UsuarioId {get; set;}
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; } 
        public decimal ValorAluguel {get; set;}

        public Aluguel(int usuarioId, DateTime dataInicio, DateTime dataFim, decimal valorAluguel) 
        {
            UsuarioId = usuarioId;
            DataInicio = dataInicio;
            DataFim = dataFim;
            ValidateDomain(valorAluguel);
        }
        public void AluguelId(DateTime dataInicio, DateTime dataFim, decimal valorAluguel)
        {
            DataInicio = dataInicio;
            DataFim = dataFim;
            ValidateDomain(valorAluguel);         
        }

        public void Update( int usuarioId, DateTime dataInicio, DateTime dataFim, decimal valorAluguel)
        {
            UsuarioId = usuarioId;
            DataInicio = dataInicio;
            DataFim = dataFim;
            ValidateDomain(valorAluguel);                   
        }

        private void ValidateDomain(decimal valorAluguel)
        {
            ValorAluguel = valorAluguel;
        }

        public int carroId {get; set;}
        public Carro Carro {get; set;}
    }
}
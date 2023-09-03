using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocadoraCarros.Domain.Validation;

namespace LocadoraCarros.Domain.Entities
{
    public class Carro : EntityBase
    {
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public int Ano {get; set; }
        public CarroStatus Status {get; set;}

        
        public enum CarroStatus
        {
            Disponivel,
            Alugado
        }
        public Carro(int id, string modelo, string marca, int ano)
        {
            Validate(id);
            Modelo = modelo;
            Marca = marca;
            Ano = ano;
        }

        public void CarroId(int id)
        {
            Validate(id);
        }

        public ICollection<Aluguel> Alugueis {get; set;}

        private void Validate(int id)
        {
            DomainValidation.When(id < 0, "Id inválido!");

            Id = id;
        }

        public void Update(int id, string marca, string modelo, int ano)
        {
            Id = id;
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
        }

    }
}
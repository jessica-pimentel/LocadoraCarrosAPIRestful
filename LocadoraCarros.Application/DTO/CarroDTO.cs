using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace LocadoraCarros.Application.DTO
{
    public enum CarroStatus
    {   
        Disponivel,
        Alugado
    }
    public class CarroDTO
    {
        public int Id {get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public int Ano {get; set; }
        public CarroStatus Status { get; set; }
    }
}
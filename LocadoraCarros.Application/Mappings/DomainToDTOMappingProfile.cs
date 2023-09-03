using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LocadoraCarros.Application.DTO;
using LocadoraCarros.Domain.Entities;

namespace LocadoraCarros.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Carro, CarroDTO>().ReverseMap();   
            CreateMap<Aluguel, AluguelDTO>().ReverseMap();  
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();  
        }
        
    }
}
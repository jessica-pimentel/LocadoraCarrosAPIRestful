using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LocadoraCarros.Application.Carros.Commands;
using LocadoraCarros.Application.DTO;

namespace LocadoraCarros.Application.Mappings
{
    public class DTOToCommandmappingProfile : Profile
    {
        public DTOToCommandmappingProfile()
        {
            CreateMap<CarroDTO, CarroCreateCommand>();
            CreateMap<CarroDTO, CarroUpdateCommand>();

        }
    }
}
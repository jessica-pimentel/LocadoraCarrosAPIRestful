using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LocadoraCarros.Application.DTO;
using LocadoraCarros.Application.Interfaces;
using LocadoraCarros.Domain.Entities;
using LocadoraCarros.Domain.Interfaces;

namespace LocadoraCarros.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        public UsuarioService(IMapper mapper, IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
            _mapper = mapper;
            
        }

        public async Task<IEnumerable<UsuarioDTO>> getUsuario()
        {
            var usuarioEntity = await _usuarioRepository.getUsuarioAsync();
            return _mapper.Map<IEnumerable<UsuarioDTO>>(usuarioEntity);
        }

        public async Task<UsuarioDTO> BuscaPorIdAsync(int? id)
        {
           var usuarioEntities = await _usuarioRepository.BuscaPorIdAsync(id);
            return _mapper.Map<UsuarioDTO>(usuarioEntities);
        }

        public async Task Add(UsuarioDTO usuarioDTO)
        {
            var usuarioEntity = _mapper.Map<Usuario>(usuarioDTO);
            await _usuarioRepository.CreateAsync(usuarioEntity);
        }

        public async Task Update(UsuarioDTO usuarioDTO)
        {
            var usuarioEntity = _mapper.Map<Usuario>(usuarioDTO);
            await _usuarioRepository.UpdateAsync(usuarioEntity);
        }

        public async Task Remove(int? id)
        {
            var usuarioEntity = _usuarioRepository.BuscaPorIdAsync(id).Result;
            await _usuarioRepository.DeleteAsync(usuarioEntity.Id);
        }
    }
}
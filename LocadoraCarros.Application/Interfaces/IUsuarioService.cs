using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocadoraCarros.Application.DTO;


namespace LocadoraCarros.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDTO>> getUsuario();
        Task<UsuarioDTO> BuscaPorIdAsync(int? id);
        Task Add(UsuarioDTO usuarioDTO);
        Task Update(UsuarioDTO usuarioDTO);
        Task Remove(int? id);
    }
}
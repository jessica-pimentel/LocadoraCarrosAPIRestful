using LocadoraCarros.Domain.Entities;
using LocadoraCarros.Domain.Interfaces;
using LocadoraCarros.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraCarros.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        DbContextApplication _usuarioContext;
        public UsuarioRepository(DbContextApplication context)
        {
            _usuarioContext = context;
        }

        public async Task<Usuario> BuscaPorIdAsync(int? id)
        {
            return await _usuarioContext.Usuario.FindAsync(id);
        }

        public async Task<Usuario> CreateAsync(Usuario usuario)
        {
            _usuarioContext.Add(usuario);
            await _usuarioContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> DeleteAsync(int? id)
        {
            var usuario = await _usuarioContext.Usuario.FindAsync(id);
            _usuarioContext.Remove(id);
            await _usuarioContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<IEnumerable<Usuario>> getUsuarioAsync()
        {
            return await _usuarioContext.Usuario.ToListAsync();
        }

        public async Task<Usuario> UpdateAsync(Usuario usuario)
        {
            _usuarioContext.Update(usuario);
            await _usuarioContext.SaveChangesAsync();
            return usuario;
        }
    }
}


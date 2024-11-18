using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaAlquileres.Model.Entities;

namespace SistemaAlquileres.Model.Dao
{
    public class UsuarioDao
    {
        private readonly SistemaAlquilerContext _context;

        public UsuarioDao()
        {
            _context = new SistemaAlquilerContext();
        }

        public async Task<List<Usuario>> GetAllUsuarios()
        {
            return await _context.Usuarios.Where(u => u.deletedAt == null).ToListAsync();
        }

        public async Task<Usuario> GetUsuarioById(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task<Usuario> GetUsuarioByName(string nombre)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.nombre == nombre && u.deletedAt == null);
        }

        public async Task<Usuario> GetUsuarioByDni(int dni)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.dni == dni && u.deletedAt == null);
        }

        // Método para obtener un usuario por su email
        public async Task<Usuario> GetUsuarioByEmail(string email)
        {
            return await _context.Usuarios
                                 .Where(u => u.email == email)
                                 .FirstOrDefaultAsync();
        }

        public async Task<List<Usuario>> GetUsuariosByMembresia(string tipoMembresia)
        {
            return await _context.Usuarios.Where(u => u.tipoMembresia == tipoMembresia && u.deletedAt == null).ToListAsync();
        }

        public async Task SoftDeleteUser(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                usuario.deletedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Usuario> CreateUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> UpdateUsuario(Usuario usuario)
        {
            await _context.SaveChangesAsync();
            return usuario;
        }
    }
}
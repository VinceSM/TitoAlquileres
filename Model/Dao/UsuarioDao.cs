using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SistemaAlquileres.Model.Entities;

namespace SistemaAlquileres.Model.Dao
{
    public class UsuarioDao
    {
        private SistemaAlquilerContext _context;

        public UsuarioDao()
        {
            _context = new SistemaAlquilerContext();
        }

        public List<Usuario> GetAllUsuarios()
        {
            return _context.Usuarios.Where(u => u.deletedAt == null).ToList();
        }

        public Usuario GetUsuarioById(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public Usuario GetUsuarioByName(string nombre)
        {
            return _context.Usuarios.FirstOrDefault(u => u.nombre == nombre && u.deletedAt == null);
        }

        public Usuario GetUsuarioByDni(int dni)
        {
            return _context.Usuarios.FirstOrDefault(u => u.dni == dni && u.deletedAt == null);
        }

        // Método para obtener un usuario por su email
        public Usuario GetUsuarioByEmail(string email)
        {
            return _context.Usuarios
                           .Where(u => u.email == email)
                           .FirstOrDefault();
        }

        public List<Usuario> GetUsuariosByMembresia(string tipoMembresia)
        {
            return _context.Usuarios.Where(u => u.tipoMembresia == tipoMembresia && u.deletedAt == null).ToList();
        }

        public void SoftDeleteUser(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario != null)
            {
                usuario.deletedAt = DateTime.Now;
                _context.SaveChanges();
            }
        }

        public Usuario CreateUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        public Usuario UpdateUsuario(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();
            return usuario;
        }
    }
}

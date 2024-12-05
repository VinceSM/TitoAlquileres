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
            return _context.Usuarios.Include(u => u.Alquileres).ToList();
        }

        public Usuario GetUsuarioById(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public Usuario GetUsuarioByName(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
                throw new ArgumentException("Name cannot be null or empty", nameof(nombre));

            return _context.Usuarios.FirstOrDefault(u => u.nombre == nombre);
        }

        public Usuario GetUsuarioByDni(int dni)
        {
            return _context.Usuarios.FirstOrDefault(u => u.dni == dni);
        }

        public Usuario GetUsuarioByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("Email cannot be null or empty", nameof(email));

            return _context.Usuarios.FirstOrDefault(u => u.email == email);
        }

        public List<Usuario> GetUsuariosByMembresia(bool membresiaPremium)
        {
            return _context.Usuarios.Where(u => u.membresiaPremium == membresiaPremium).ToList();
        }

        public void SoftDeleteUser(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            if (usuario != null)
            {
                usuario.deletedAt = DateTime.UtcNow;
                _context.SaveChanges();
            }
        }

        public Usuario CreateUsuario(Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario));

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        public Usuario UpdateUsuario(Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario));

            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();
            return usuario;
        }
    }
}

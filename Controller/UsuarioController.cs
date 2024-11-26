using Microsoft.EntityFrameworkCore;
using SistemaAlquileres.Model.Dao;
using SistemaAlquileres.Model.Entities;
using System;
using System.Collections.Generic;

namespace SistemaAlquileres.Controller
{
    internal class UsuarioController
    {
        // Instanciamos el DAO de Usuario
        private UsuarioDao usuarioDao;
        private SistemaAlquilerContext _context;

        #region Singleton
        private static UsuarioController Instance;

        public UsuarioController()
        {
            usuarioDao = new UsuarioDao();
            _context = new SistemaAlquilerContext();
        }

        public static UsuarioController getInstance()
        {
            if (Instance == null)
            {
                Instance = new UsuarioController();
            }
            return Instance;
        }
        #endregion

        // Método para crear un nuevo usuario
        public Usuario CrearUsuario(Usuario usuario)
        {
            if (usuario == null) throw new ArgumentNullException(nameof(usuario));
            return usuarioDao.CreateUsuario(usuario);
        }

        public List<Usuario> GetUsuarios()
        {
            //return usuarioDao.GetAllUsuarios();
            // En el método GetUsuarios del UsuarioController
            return _context.Usuarios.Include(u => u.Alquileres).ToList();

        }

        public Usuario GetUsuarioById(int id)
        {
            return usuarioDao.GetUsuarioById(id);
        }

        public Usuario GetUsuarioByName(string nombre)
        {
            if (string.IsNullOrEmpty(nombre)) throw new ArgumentException("Nombre cannot be null or empty", nameof(nombre));
            return usuarioDao.GetUsuarioByName(nombre);
        }

        public Usuario GetUsuarioByDni(int dni)
        {
            return usuarioDao.GetUsuarioByDni(dni);
        }

        public Usuario GetUsuarioByEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) throw new ArgumentException("Email cannot be null or empty", nameof(email));
            return usuarioDao.GetUsuarioByEmail(email);
        }

        public List<Usuario> GetUsuariosByMembresia(bool membresiaPremium)
        {
            return usuarioDao.GetUsuariosByMembresia(membresiaPremium);
        }

        public void SoftDeleteUser(int id)
        {
            usuarioDao.SoftDeleteUser(id);
        }

        public Usuario UpdateUsuario(Usuario usuario)
        {
            if (usuario == null) throw new ArgumentNullException(nameof(usuario));
            return usuarioDao.UpdateUsuario(usuario);
        }
    }
}

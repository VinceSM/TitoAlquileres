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
        public Usuario CrearUsuario(string nombre, int dni, string email, string tipoMembresia)
        {
            var usuario = new Usuario
            {
                nombre = nombre,
                dni = dni,
                email = email,
                tipoMembresia = tipoMembresia
            };

            return usuarioDao.CreateUsuario(usuario);
        }

        // Método para cargar todos los usuarios
        public List<Usuario> LoadUsuarios()
        {
            return usuarioDao.GetAllUsuarios();
        }

        // Método para obtener un usuario por su ID
        public Usuario GetUsuarioById(int id)
        {
            return usuarioDao.GetUsuarioById(id);
        }

        // Método para obtener un usuario por su nombre
        public Usuario GetUsuarioByName(string nombre)
        {
            return usuarioDao.GetUsuarioByName(nombre);
        }

        // Método para obtener un usuario por su DNI
        public Usuario GetUsuarioByDni(int dni)
        {
            return usuarioDao.GetUsuarioByDni(dni);
        }

        // Método para obtener un usuario por su email
        public Usuario GetUsuarioByEmail(string email)
        {
            return usuarioDao.GetUsuarioByEmail(email);
        }

        // Método para obtener usuarios por su tipo de membresía
        public List<Usuario> GetUsuarioByMembresia(string tipoMembresia)
        {
            return usuarioDao.GetUsuariosByMembresia(tipoMembresia);
        }

        // Método para eliminar un usuario (soft delete)
        public void SoftDeleteUser(int id)
        {
            usuarioDao.SoftDeleteUser(id);
        }

        // Método para actualizar un usuario
        public Usuario UpdateUsuario(Usuario usuario)
        {
            return usuarioDao.UpdateUsuario(usuario);
        }
    }
}

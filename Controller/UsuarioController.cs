using SistemaAlquileres.Model.Dao;
using SistemaAlquileres.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAlquileres.Controller
{
    internal class UsuarioController
    {
        // Instanciamos el DAO de Usuario
        private UsuarioDao usuarioDao = new UsuarioDao();
        private SistemaAlquilerContext _context = new SistemaAlquilerContext();

        #region Singleton
        private static UsuarioController Instance;

        public UsuarioController()
        {
            usuarioDao = new UsuarioDao();
        }

        public async Task<Usuario> CrearUsuario(string nombre, int dni, string email, string tipoMembresia)
        {
            var usuario = new Usuario
            {
                nombre = nombre,
                dni = dni,
                email = email,
                tipoMembresia = tipoMembresia
            };

            return await usuarioDao.CreateUsuario(usuario);
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

        // Método para cargar todos los usuarios
        public async Task<List<Usuario>> loadUsuarios()
        {
            return await usuarioDao.GetAllUsuarios();
        }

        // Método para obtener un usuario por su ID
        public async Task<Usuario> getUsuarioById(int id)
        {
            return await usuarioDao.GetUsuarioById(id);
        }

        // Método para obtener un usuario por su nombre
        public async Task<Usuario> getUsuarioByName(string nombre)
        {
            return await usuarioDao.GetUsuarioByName(nombre);
        }

        // Método para obtener un usuario por su DNI
        public async Task<Usuario> getUsuarioByDni(int dni)
        {
            return await usuarioDao.GetUsuarioByDni(dni);
        }

        // Método para obtener un usuario por su email
        public async Task<Usuario> getUsuarioByEmail(string email)
        {
            using (var context = new SistemaAlquilerContext()) // Asegúrate de usar el contexto correcto.
            {
                return await usuarioDao.GetUsuarioByEmail(email);
            }
        }

        // Método para obtener usuarios por su tipo de membresía
        public async Task<List<Usuario>> getUsuarioByMembresia(string tipo_membresia)
        {
            return await usuarioDao.GetUsuariosByMembresia(tipo_membresia);
        }

        // Método para eliminar un usuario (soft delete)
        public async Task softDeleteUser(int id)
        {
            await usuarioDao.SoftDeleteUser(id);
        }

        // Método para crear un nuevo usuario
        public async Task<Usuario> createUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> iniciarSesion(string email, string nombre)
        {
            return await usuarioDao.IniciarSesion(email, nombre);
        }

        // Método para actualizar un usuario
        public async Task<Usuario> updateUsuario(Usuario usuario)
        {
            return await usuarioDao.UpdateUsuario(usuario);
        }
    }
}

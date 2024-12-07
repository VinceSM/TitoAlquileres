using System;
using System.Collections.Generic;
using SistemaAlquileres.Model.Dao;
using SistemaAlquileres.Model.Entities;

namespace SistemaAlquileres.Controllers
{
    public class UsuarioController
    {
        private UsuarioDao _usuarioDao;

        public UsuarioController()
        {
            _usuarioDao = new UsuarioDao();
        }

        public void CrearUsuario(Usuario usuario)
        {
            _usuarioDao.InsertUsuario(usuario);
        }

        public void ActualizarUsuario(Usuario usuario)
        {
            _usuarioDao.UpdateUsuario(usuario);
        }

        public void EliminarUsuario(Usuario usuario)
        {
            _usuarioDao.SoftDeleteUsuario(usuario);
        }

        public List<Usuario> ObtenerTodosLosUsuarios()
        {
            return _usuarioDao.LoadAllUsuarios();
        }

        public Usuario ObtenerUsuarioPorId(int id)
        {
            return _usuarioDao.FindUsuarioById(id);
        }

        public Usuario ObtenerUsuarioPorDNI(int dni)
        {
            return _usuarioDao.FindUsuarioByDNI(dni);
        }

        public List<Usuario> BuscarUsuarios(string busqueda)
        {
            return _usuarioDao.SearchUsuarios(busqueda);
        }
    }
}


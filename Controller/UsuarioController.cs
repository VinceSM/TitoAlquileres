using System;
using System.Collections.Generic;
using TitoAlquiler.Model.Dao;
using TitoAlquiler.Model.Entities;

namespace TitoAlquiler.Controller
{
    public class UsuarioController
    {
        UsuarioDao _usuarioDao = new UsuarioDao();

        #region Singletone

        private static UsuarioController? Instance;

        private UsuarioController() { }

        public static UsuarioController getInstance()
        {
            if (Instance == null)
            {
                Instance = new UsuarioController();
            }
            return Instance;
        }
        #endregion

        public void CrearUsuario(Usuarios usuario)
        {
            _usuarioDao.InsertUsuario(usuario);
        }

        public void ActualizarUsuario(Usuarios usuario)
        {
            _usuarioDao.UpdateUsuario(usuario);
        }

        public void EliminarUsuario(Usuarios usuario)
        {
            _usuarioDao.SoftDeleteUsuario(usuario);
        }

        public List<Usuarios> ObtenerTodosLosUsuarios()
        {
            return _usuarioDao.LoadAllUsuarios();
        }

        public Usuarios ObtenerUsuarioPorId(int id)
        {
            return _usuarioDao.FindUsuarioById(id);
        }

        public Usuarios ObtenerUsuarioPorDNI(int dni)
        {
            return _usuarioDao.FindUsuarioByDNI(dni);
        }

        public List<Usuarios> BuscarUsuarios(string busqueda)
        {
            return _usuarioDao.SearchUsuarios(busqueda);
        }
    }
}


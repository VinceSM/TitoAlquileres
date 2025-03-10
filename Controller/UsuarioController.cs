﻿using System;
using System.Collections.Generic;
using TitoAlquiler.Model.Dao;
using TitoAlquiler.Model.Entities;

namespace TitoAlquiler.Controller
{
    public class UsuarioController
    {
        UsuarioDao _usuarioDao = new UsuarioDao();

        #region Singletone

        private static UsuarioController? _instance;
        public static UsuarioController Instance => _instance ??= new UsuarioController();

        private UsuarioController() { }

        #endregion

        /// <summary>
        /// Crea un nuevo usuario en la base de datos.
        /// </summary>
        /// <param name="usuario">Objeto de tipo Usuarios que contiene la información del usuario a crear.</param>
        public void CrearUsuario(Usuarios usuario)
        {
            _usuarioDao.InsertUsuario(usuario);
        }

        /// <summary>
        /// Actualiza un usuario existente en la base de datos.
        /// </summary>
        /// <param name="usuario">Objeto de tipo Usuarios con los datos actualizados del usuario.</param>
        public void ActualizarUsuario(Usuarios usuario)
        {
            _usuarioDao.UpdateUsuario(usuario);
        }

        /// <summary>
        /// Elimina un usuario de manera lógica (soft delete).
        /// </summary>
        /// <param name="usuario">Objeto de tipo Usuarios que representa el usuario a eliminar.</param>
        public void EliminarUsuario(Usuarios usuario)
        {
            _usuarioDao.SoftDeleteUsuario(usuario);
        }

        /// <summary>
        /// Obtiene todos los usuarios registrados en la base de datos.
        /// </summary>
        /// <returns>Lista de objetos Usuarios.</returns>
        public List<Usuarios> ObtenerTodosLosUsuarios()
        {
            return _usuarioDao.LoadAllUsuarios();
        }

        /// <summary>
        /// Obtiene un usuario por su identificador único.
        /// </summary>
        /// <param name="id">ID del usuario a obtener.</param>
        /// <returns>Objeto Usuarios con los detalles del usuario solicitado.</returns>
        public Usuarios ObtenerUsuarioPorId(int id)
        {
            return _usuarioDao.FindUsuarioById(id);
        }

        /// <summary>
        /// Compara si el DNI proporcionado ya está registrado en la base de datos.
        /// </summary>
        /// <param name="dni">DNI del usuario a comparar.</param>
        /// <returns>True si el DNI ya está registrado, de lo contrario False.</returns>
        public bool CompararDNI(int dni)
        {
            return _usuarioDao.CompararDNI(dni);
        }

        /// <summary>
        /// Compara si el correo electrónico proporcionado ya está registrado en la base de datos.
        /// </summary>
        /// <param name="email">Correo electrónico del usuario a comparar.</param>
        /// <returns>True si el correo electrónico ya está registrado, de lo contrario False.</returns>
        public bool CompararEmail(string email)
        {
            return _usuarioDao.CompararEmail(email);
        }

        /// <summary>
        /// Obtiene el estado de membresía premium de un usuario.
        /// </summary>
        /// <param name="id">ID del usuario cuya membresía se desea consultar.</param>
        /// <returns>True si el usuario tiene membresía premium, de lo contrario False.</returns>
        public bool getMembresiaUsuario(int id)
        {
            return _usuarioDao.getMembresiaUsuario(id);
        }
    }
}


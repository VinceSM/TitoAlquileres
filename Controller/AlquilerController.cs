using System;
using System.Collections.Generic;
using SistemaAlquileres.Model.Dao;
using SistemaAlquileres.Model.Entities;

namespace SistemaAlquileres.Controllers
{
    public class AlquilerController
    {
        AlquilerDao _alquilerDao = new AlquilerDao();

        #region Singletone

        private static AlquilerController? Instance;

        private AlquilerController() { }

        public static AlquilerController getInstance()
        {
            if (Instance == null)
            {
                Instance = new AlquilerController();
            }
            return Instance;
        }
        #endregion

        public void CrearAlquiler(Alquiler alquiler)
        {
            _alquilerDao.InsertAlquiler(alquiler);
        }

        public void ActualizarAlquiler(Alquiler alquiler)
        {
            _alquilerDao.UpdateAlquiler(alquiler);
        }

        public void EliminarAlquiler(Alquiler alquiler)
        {
            _alquilerDao.SoftDeleteAlquiler(alquiler);
        }

        public List<Alquiler> ObtenerTodosLosAlquileres()
        {
            return _alquilerDao.LoadAllAlquileres();
        }

        public Alquiler ObtenerAlquilerPorId(int id)
        {
            return _alquilerDao.FindAlquilerById(id);
        }

        public List<Alquiler> ObtenerAlquileresPorUsuario(int usuarioId)
        {
            return _alquilerDao.FindAlquileresByUsuario(usuarioId);
        }

        public List<Alquiler> ObtenerAlquileresPorItem(int itemId)
        {
            return _alquilerDao.FindAlquileresByItem(itemId);
        }
    }
}


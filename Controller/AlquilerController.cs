using SistemaAlquileres.Model.Entities;
using SistemaAlquileres.Model.Dao;
using System;
using System.Collections.Generic;
using SistemaAlquileres.Model.Strategy;
using SistemaAlquileres.Model.Factory;
using TitoAlquiler.Model.Entities;
//using TitoAlquiler.Model.Entities.Item;

namespace SistemaAlquileres.Controller
{
    public class AlquilerController
    {
        private AlquilerDao _alquilerDao = new AlquilerDao();


        #region Singleton
        private static AlquilerController _instance;
        private static readonly object _lock = new object();

        private AlquilerController()
        {
            _alquilerDao = new AlquilerDao();
        }

        public static AlquilerController GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new AlquilerController();
                    }
                }
            }
            return _instance;
        }
        #endregion

        // Método para cargar todos los alquileres
        public List<Alquiler> LoadAlquileres()
        {
            return _alquilerDao.GetAllAlquileres();
        }

        // Método para crear un nuevo alquiler
        public Alquiler CrearAlquiler(Alquiler alquiler, int dias, Item item, Usuario usuario, IEstrategiaAlquiler estrategia)
        {
            var alq = _alquilerDao.CreateAlquiler(new Alquiler
            {
                usuarioId = usuario,
                itemId = item,
                tiempoDias = dias,
                fechaInicio = DateTime.Now,
                fechaFin = DateTime.Now.AddDays(dias)
                
            });
            alq.CalcularPrecioTotal(estrategia);
            return alq;
        }

        // Obtener un alquiler por ID
        public Alquiler GetAlquilerById(int id)
        {
            return _alquilerDao.GetAlquilerById(id);
        }

        // Obtener alquileres por Item
        public List<Alquiler> GetAlquileresByItem(int itemId)
        {
            return _alquilerDao.GetAlquileresByItem(itemId);
        }

        // Obtener alquileres por Usuario
        public List<Alquiler> GetAlquileresByUsuario(int usuarioId)
        {
            return _alquilerDao.GetAlquileresByUsuario(usuarioId);
        }

        // Eliminar un alquiler de manera lógica
        public void SoftDeleteAlquiler(int id)
        {
            _alquilerDao.SoftDeleteAlquiler(id);
        }

        // Método para actualizar alquiler (si fuera necesario)
        public Alquiler UpdateAlquiler(Alquiler alquiler)
        {
            return _alquilerDao.UpdateAlquiler(alquiler);
        }
    }
}

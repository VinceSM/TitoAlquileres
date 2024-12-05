using SistemaAlquileres.Model.Entities;
using SistemaAlquileres.Model.Dao;
using System;
using System.Collections.Generic;
using SistemaAlquileres.Model.Strategy;
using SistemaAlquileres.Model.Factory;
using TitoAlquiler.Model.Entities;

namespace SistemaAlquileres.Controller
{
    public class AlquilerController
    {
        private AlquilerDao _alquilerDao = new AlquilerDao();


        #region Singleton
        private static AlquilerController? _instance;
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
        public List<Alquiler> GetAlquileres()
        {
            return _alquilerDao.GetAllAlquileres();
        }

        public Alquiler CrearAlquiler(Alquiler alquiler, int dias, Item item, Usuario usuario, IEstrategiaAlquiler estrategia)
        {
            if (alquiler == null) throw new ArgumentNullException(nameof(alquiler));
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (usuario == null) throw new ArgumentNullException(nameof(usuario));
            if (estrategia == null) throw new ArgumentNullException(nameof(estrategia));

            alquiler.item = item;
            alquiler.usuario = usuario;
            alquiler.tiempoDias = dias;
            alquiler.fechaInicio = DateTime.UtcNow;
            alquiler.fechaFin = alquiler.fechaInicio.AddDays(dias);
            alquiler.CalcularPrecioTotal(estrategia);

            return _alquilerDao.CreateAlquiler(alquiler);
        }

        public Alquiler GetAlquilerById(int id)
        {
            return _alquilerDao.GetAlquilerById(id);
        }

        public List<Alquiler> GetAlquileresByItem(int itemId)
        {
            return _alquilerDao.GetAlquileresByItem(itemId);
        }

        public List<Alquiler> GetAlquileresByUsuario(int usuarioId)
        {
            return _alquilerDao.GetAlquileresByUsuario(usuarioId);
        }

        public void SoftDeleteAlquiler(int id)
        {
            _alquilerDao.SoftDeleteAlquiler(id);
        }

        public Alquiler UpdateAlquiler(Alquiler alquiler)
        {
            if (alquiler == null) throw new ArgumentNullException(nameof(alquiler));
            return _alquilerDao.UpdateAlquiler(alquiler);
        }
    }
}

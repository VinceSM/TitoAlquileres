using System;
using System.Collections.Generic;
using System.Linq;
using TitoAlquiler.Model.Dao;
using TitoAlquiler.Model.Entities;
using TitoAlquiler.Model.Strategy;

namespace TitoAlquiler.Controller
{
    public class AlquilerController
    {
        AlquilerDao _alquilerDao = new AlquilerDao();
        Usuarios usuarios = new Usuarios();

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

        public void CrearAlquiler(Alquileres alquiler)
        {
            _alquilerDao.InsertAlquiler(alquiler);
        }

        public void ActualizarAlquiler(Alquileres alquiler)
        {
            _alquilerDao.UpdateAlquiler(alquiler);
        }

        public void EliminarAlquiler(Alquileres alquiler)
        {
            _alquilerDao.SoftDeleteAlquiler(alquiler);
        }

        public List<Alquileres> ObtenerTodosLosAlquileres()
        {
            return _alquilerDao.LoadAllAlquileres();
        }

        public Alquileres ObtenerAlquilerPorId(int id)
        {
            return _alquilerDao.FindAlquilerById(id);
        }

        public List<Alquileres> ObtenerAlquileresPorUsuario(int usuarioId)
        {
            return _alquilerDao.FindAlquileresByUsuario(usuarioId);
        }

        public List<Alquileres> ObtenerAlquileresPorItem(int itemId)
        {
            return _alquilerDao.FindAlquileresByItem(itemId);
        }

        public Alquileres CrearNuevoAlquiler(int itemId, int usuarioId, DateTime fechaInicio, DateTime fechaFin, string tipoEstrategia)
        {
            var item = ItemController.getInstance().ObtenerItemPorId(itemId);
            var usuario = UsuarioController.getInstance().ObtenerUsuarioPorId(usuarioId);

            if (item == null || usuario == null)
            {
                throw new ArgumentException("Item o Usuario no encontrado");
            }

            bool esPremium = usuario.membresiaPremium;

            var alquiler = new Alquileres
            {
                ItemID = itemId,
                UsuarioID = usuarioId,
                fechaInicio = fechaInicio,
                fechaFin = fechaFin,
                tiempoDias = (int)(fechaFin - fechaInicio).TotalDays + 1,
                tipoEstrategia = esPremium ? "EstrategiaPremium" : tipoEstrategia
            };

            alquiler.precioTotal = CalcularPrecioTotal(alquiler, item);
            alquiler.descuento = esPremium || tipoEstrategia == "EstrategiaEstacion";

            CrearAlquiler(alquiler);

            return alquiler;
        }


        public double CalcularPrecioTotal(Alquileres alquiler, Item item)
        {
            var usuario = UsuarioController.getInstance().ObtenerUsuarioPorId(alquiler.UsuarioID);
            bool esPremium = usuario?.membresiaPremium ?? false;

            IEstrategiaAlquiler estrategia = esPremium ?
                new EstrategiaPremium() :
                new EstrategiaEstacion();

            return estrategia.CalcularPrecio(alquiler, item);
        }

        public bool VerificarDisponibilidad(int itemId, DateTime fechaInicio, DateTime fechaFin)
        {
            var alquileresExistentes = ObtenerAlquileresPorItem(itemId);
            return !alquileresExistentes.Any(a =>
                (fechaInicio >= a.fechaInicio && fechaInicio < a.fechaFin) ||
                (fechaFin > a.fechaInicio && fechaFin <= a.fechaFin) ||
                (fechaInicio <= a.fechaInicio && fechaFin >= a.fechaFin));
        }
    }
}


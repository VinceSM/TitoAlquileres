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

        public Alquiler CrearNuevoAlquiler(int itemId, int usuarioId, DateTime fechaInicio, DateTime fechaFin, string tipoEstrategia)
        {
            var item = ItemController.getInstance().ObtenerItemPorId(itemId);
            var usuario = UsuarioController.getInstance().ObtenerUsuarioPorId(usuarioId);

            if (item == null || usuario == null)
            {
                throw new ArgumentException("Item o Usuario no encontrado");
            }

            var alquiler = new Alquiler
            {
                ItemID = itemId,
                UsuarioID = usuarioId,
                fechaInicio = fechaInicio,
                fechaFin = fechaFin,
                tiempoDias = (int)(fechaFin - fechaInicio).TotalDays,
                tipoEstrategia = tipoEstrategia
            };

            alquiler.precioTotal = CalcularPrecioTotal(alquiler, item, usuario);
            alquiler.descuento = tipoEstrategia != "EstrategiaNormal";

            CrearAlquiler(alquiler);

            return alquiler;
        }

        private double CalcularPrecioTotal(Alquiler alquiler, Item item, Usuarios usuario)
        {
            IEstrategiaAlquiler estrategia;

            switch (alquiler.tipoEstrategia)
            {
                case "EstrategiaDescuento":
                    estrategia = new EstrategiaDescuento();
                    break;
                case "EstrategiaPremium":
                    estrategia = new EstrategiaPremium();
                    break;
                default:
                    estrategia = new EstrategiaNormal();
                    break;
            }

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


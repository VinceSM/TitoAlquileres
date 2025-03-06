using System;
using System.Collections.Generic;
using System.Linq;
using TitoAlquiler.Model.Dao;
using TitoAlquiler.Model.Entities;
using TitoAlquiler.Model.Interfaces;
using TitoAlquiler.Model.Strategy;
using System.Windows.Forms;
using TitoAlquiler.Resources;

namespace TitoAlquiler.Controller
{
    /// <summary>
    /// Controlador para la gestión de alquileres.
    /// Maneja la creación, actualización, eliminación y consulta de alquileres.
    /// </summary>
    public class AlquilerController
    {
        private readonly AlquilerDao _alquilerDao;
        private readonly UsuarioController _usuarioController;
        private readonly ItemController _itemController;

        #region Singleton
        private static AlquilerController? _instance;
        /// <summary>
        /// Obtiene la instancia única del controlador.
        /// </summary>
        public static AlquilerController Instance => _instance ??= new AlquilerController();

        /// <summary>
        /// Constructor privado para la implementación del patrón Singleton.
        /// </summary>
        private AlquilerController()
        {
            _alquilerDao = new AlquilerDao();
            _usuarioController = UsuarioController.Instance;
            _itemController = ItemController.Instance;
        }
        #endregion

        /// <summary>
        /// Crea un nuevo alquiler con validaciones completas.
        /// </summary>
        /// <param name="alquiler">Objeto de tipo Alquileres a crear.</param>
        public void CrearAlquiler(Alquileres alquiler)
        {
            try
            {
                if (!VerificarCreacionAlquiler(alquiler)) return;

                _alquilerDao.InsertAlquiler(alquiler);
            }
            catch (Exception ex)
            {
                MessageShow.MostrarMensajeError($"Error al crear el alquiler: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Actualiza un alquiler existente.
        /// </summary>
        /// <param name="alquiler">Objeto de tipo Alquileres a actualizar.</param>
        public void ActualizarAlquiler(Alquileres alquiler)
        {
            try
            {
                ValidarFechasAlquiler(alquiler.fechaInicio, alquiler.fechaFin);
                _alquilerDao.UpdateAlquiler(alquiler);
            }
            catch (Exception ex)
            {
                MessageShow.MostrarMensajeError($"Error al actualizar el alquiler: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Cancela un alquiler (eliminación lógica).
        /// </summary>
        /// <param name="alquilerId">Identificador del alquiler a cancelar.</param>
        /// <returns>True si el alquiler fue cancelado exitosamente, de lo contrario false.</returns>
        public bool EliminarAlquiler(int alquilerId)
        {
            try
            {
                var alquiler = ObtenerAlquilerPorId(alquilerId);

                if (!PuedeCancelarAlquiler(alquiler))
                {
                    return false;
                }

                _alquilerDao.SoftDeleteAlquiler(alquiler);
                return true;
            }
            catch (Exception ex)
            {
                MessageShow.MostrarMensajeError($"Error al cancelar el alquiler: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Verifica si un alquiler puede ser cancelado.
        /// </summary>
        private bool PuedeCancelarAlquiler(Alquileres alquiler)
        {
            if (alquiler.fechaInicio <= DateTime.Now)
            {
                MessageShow.MostrarMensajeError("No se pueden cancelar alquileres que ya han comenzado.");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Obtiene todos los alquileres activos.
        /// </summary>
        /// <returns>Lista de alquileres activos.</returns>
        public List<Alquileres> ObtenerTodosLosAlquileres()
        {
            try
            {
                return _alquilerDao.LoadAllAlquileres();
            }
            catch (Exception ex)
            {
                MessageShow.MostrarMensajeError($"Error al obtener los alquileres: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene un alquiler por su ID.
        /// </summary>
        /// <param name="id">Identificador del alquiler.</param>
        /// <returns>Objeto Alquileres encontrado.</returns>
        public Alquileres ObtenerAlquilerPorId(int id)
        {
            try
            {
                return _alquilerDao.FindAlquilerById(id);
            }
            catch (Exception ex)
            {
                MessageShow.MostrarMensajeError($"Error al obtener el alquiler: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Verifica la disponibilidad de un ítem para un rango de fechas.
        /// </summary>
        /// <param name="itemId">Identificador del ítem.</param>
        /// <param name="fechaInicio">Fecha de inicio del alquiler.</param>
        /// <param name="fechaFin">Fecha de fin del alquiler.</param>
        /// <returns>True si el ítem está disponible, de lo contrario false.</returns>
        public bool VerificarDisponibilidad(int itemId, DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                return VerificarDisponibilidadItem(itemId, fechaInicio, fechaFin);
            }
            catch (Exception ex)
            {
                MessageShow.MostrarMensajeError($"Error al verificar disponibilidad: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Verifica la disponibilidad de un ítem para un rango de fechas.
        /// </summary>
        /// <param name="itemId">Identificador del ítem.</param>
        /// <param name="fechaInicio">Fecha de inicio del alquiler.</param>
        /// <param name="fechaFin">Fecha de fin del alquiler.</param>
        private bool VerificarDisponibilidadItem(int itemId, DateTime fechaInicio, DateTime fechaFin)
        {
            var alquileres = _alquilerDao.FindAlquileresByItem(itemId);
            return !alquileres.Any(a =>
                (fechaInicio >= a.fechaInicio && fechaInicio <= a.fechaFin) ||
                (fechaFin >= a.fechaInicio && fechaFin <= a.fechaFin) ||
                (fechaInicio <= a.fechaInicio && fechaFin >= a.fechaFin));
        }

        #region Métodos privados encapsulados

        /// <summary>
        /// Verifica si se puede crear un alquiler con los datos proporcionados.
        /// </summary>
        private bool VerificarCreacionAlquiler(Alquileres alquiler)
        {
            string mensaje = string.Empty;

            if (!VerificarDisponibilidadItem(alquiler.ItemID, alquiler.fechaInicio, alquiler.fechaFin))
            {
                mensaje = "El ítem no está disponible para las fechas seleccionadas.";
                return false;
            }

            var item = ObtenerItemValidado(alquiler.ItemID);

            int diasAlquiler = CalcularDiasAlquiler(alquiler.fechaInicio, alquiler.fechaFin);
            if (diasAlquiler <= 0)
            {
                mensaje = "Las fechas seleccionadas no son válidas.";
            }

            if (!string.IsNullOrEmpty(mensaje))
            {
                MessageShow.MostrarMensajeError(mensaje);
                return false;
            }

            alquiler.tiempoDias = diasAlquiler;
            ConfigurarEstrategiaYPrecio(alquiler, item.tarifaDia);

            return true;
        }

        private ItemAlquilable ObtenerItemValidado(int itemId)
        {
            var (item, _) = _itemController.ObtenerItemPorId(itemId);
            if (item == null)
            {
                throw new Exception("Item no encontrado");
            }
            return item;
        }

        private int CalcularDiasAlquiler(DateTime fechaInicio, DateTime fechaFin)
        {
            return (int)(fechaFin - fechaInicio).TotalDays + 1;
        }

        private void ConfigurarEstrategiaYPrecio(Alquileres alquiler, double tarifaDiaria)
        {
            bool tieneMembresia = _usuarioController.getMembresiaUsuario(alquiler.UsuarioID);
            IEstrategiaPrecio estrategia = DeterminarEstrategia(tieneMembresia);

            alquiler.tipoEstrategia = tieneMembresia ? "EstrategiaMembresia" : "EstrategiaEstacion";
            alquiler.precioTotal = estrategia.CalcularPrecioAlquiler(tarifaDiaria, alquiler.tiempoDias);
        }

        private IEstrategiaPrecio DeterminarEstrategia(bool tieneMembresia)
        {
            return tieneMembresia
                ? new EstrategiaMembresia()
                : new EstrategiaEstacion(EstrategiaEstacion.ObtenerEstacionActual());
        }

        private void ValidarFechasAlquiler(DateTime fechaInicio, DateTime fechaFin)
        {
            if (fechaInicio > fechaFin)
                throw new ArgumentException("La fecha de inicio no puede ser posterior a la fecha de fin.");
        }
        #endregion
    }
}

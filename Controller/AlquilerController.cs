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

        #region Crear Alquiler

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

        #endregion

        #region Actualizar Alquiler
        /// <summary>
        /// Actualiza un alquiler existente.
        /// </summary>
        /// <param name="alquiler">Objeto de tipo Alquileres a actualizar.</param>
        public void ActualizarAlquiler(Alquileres alquiler)
        {
            try
            {
                _alquilerDao.UpdateAlquiler(alquiler);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar el alquiler: {ex.Message}");
                throw; 
            }
        }

        #endregion

        #region Verificaciones Alquiler
        /// <summary>
        /// Verifica si se puede crear un alquiler con los datos proporcionados.
        /// </summary>
        private bool VerificarCreacionAlquiler(Alquileres alquiler)
        {
            bool itemValido = true;
            if (!VerificarDisponibilidadItem(alquiler.ItemID, alquiler.fechaInicio, alquiler.fechaFin))
            {
                MessageShow.MostrarMensajeInformacion("El ítem no está disponible para las fechas seleccionadas.");
                itemValido = false;
            }

            var item = ObtenerItemValidado(alquiler.ItemID);

            int diasAlquiler = CalcularDiasAlquiler(alquiler.fechaInicio, alquiler.fechaFin);

            VerificarDiasAlquiler(diasAlquiler);

            alquiler.tiempoDias = diasAlquiler;

            ConfigurarEstrategiaYPrecio(alquiler, item.tarifaDia);

            return itemValido;
        }

        public int CalcularDiasAlquiler(DateTime fechaInicio, DateTime fechaFin)
        {
            return (int)(fechaFin - fechaInicio).TotalDays + 1;
        }

        public void VerificarYCerrarAlquileresVencidos()
        {
            try
            {
                using var db = new SistemaAlquilerContext();
                var hoy = DateTime.Today;

                var alquileresVencidos = ObtenerAlquileresVencidos(db, hoy);
                CierreAutomaticoAlquileres(db, alquileresVencidos);

                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageShow.MostrarMensajeError($"Error al cerrar alquileres vencidos: {ex.Message}");
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
            if (fechaInicio < DateTime.Today || fechaFin < DateTime.Today)
            {
                MessageShow.MostrarMensajeError("Las fechas no pueden ser anteriores a la fecha actual.");
                return false;
            }

            var alquileres = _alquilerDao.FindAlquileresByItem(itemId);
            return !alquileres.Any(a =>
                (fechaInicio >= a.fechaInicio && fechaInicio <= a.fechaFin) ||
                (fechaFin >= a.fechaInicio && fechaFin <= a.fechaFin) ||
                (fechaInicio <= a.fechaInicio && fechaFin >= a.fechaFin));
        }

        private void VerificarDiasAlquiler(int diasAlquiler)
        {
            if (diasAlquiler <= 0)
            {
                MessageShow.MostrarMensajeInformacion("Las fechas seleccionadas no son válidas.");
            }
        }

        #endregion

        #region Obtener, Find, Load Alquiler

        /// <summary>
        /// Obtiene la lista de alquileres vencidos cuya fecha de finalización es anterior a la fecha actual.
        /// </summary>
        private List<Alquileres> ObtenerAlquileresVencidos(SistemaAlquilerContext db, DateTime fecha)
        {
            return db.Alquileres
                .Where(a => a.fechaFin < fecha && a.deletedAt == null)
                .ToList();
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

        private ItemAlquilable ObtenerItemValidado(int itemId)
        {
            var (item, _) = _itemController.ObtenerItemPorId(itemId);

            if (item == null)
            {
                MessageShow.MostrarMensajeError("Item no encontrado");
            }
            return item;
        }

        #endregion

        #region Cierre y Eliminacion Alquiler
        /// <summary>
        /// Marca como eliminados (soft delete) los alquileres vencidos.
        /// </summary>
        private void CierreAutomaticoAlquileres(SistemaAlquilerContext db, List<Alquileres> alquileres)
        {
            foreach (var alquiler in alquileres)
            {
                alquiler.deletedAt = DateTime.Now;
                db.Update(alquiler);
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

                _alquilerDao.SoftDeleteAlquiler(alquiler);
                return true;
            }
            catch (Exception ex)
            {
                MessageShow.MostrarMensajeError($"Error al cancelar el alquiler: {ex.Message}");
                throw;
            }
        }

        #endregion

        #region Estrategia Alquiler

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

        #endregion
    }
}

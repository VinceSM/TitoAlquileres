using System;
using System.Collections.Generic;
using System.Linq;
using TitoAlquiler.Model.Dao;
using TitoAlquiler.Model.Entities;
using TitoAlquiler.Model.Interfaces;
using TitoAlquiler.Model.Strategy;
using System.Windows.Forms;

namespace TitoAlquiler.Controller
{
    public class AlquilerController
    {
        private readonly AlquilerDao _alquilerDao;
        private readonly UsuarioController _usuarioController;
        private readonly ItemController _itemController;

        #region Singleton
        private static AlquilerController? _instance;
        public static AlquilerController Instance => _instance ??= new AlquilerController();

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
        public void CrearAlquiler(Alquileres alquiler)
        {
            try
            {
                if (!VerificarCreacionAlquiler(alquiler)) return;

                // Guardar alquiler
                _alquilerDao.InsertAlquiler(alquiler);
            }
            catch (Exception ex)
            {
                MostrarMensajeError($"Error al crear el alquiler: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Actualiza un alquiler existente.
        /// </summary>
        public void ActualizarAlquiler(Alquileres alquiler)
        {
            try
            {
                ValidarFechasAlquiler(alquiler.fechaInicio, alquiler.fechaFin);
                _alquilerDao.UpdateAlquiler(alquiler);
            }
            catch (Exception ex)
            {
                MostrarMensajeError($"Error al actualizar el alquiler: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Cancela un alquiler (eliminación lógica).
        /// </summary>
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
                MostrarMensajeError($"Error al cancelar el alquiler: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene todos los alquileres activos.
        /// </summary>
        public List<Alquileres> ObtenerTodosLosAlquileres()
        {
            try
            {
                return _alquilerDao.LoadAllAlquileres();
            }
            catch (Exception ex)
            {
                MostrarMensajeError($"Error al obtener los alquileres: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene un alquiler por su ID.
        /// </summary>
        public Alquileres ObtenerAlquilerPorId(int id)
        {
            try
            {
                return _alquilerDao.FindAlquilerById(id);
            }
            catch (Exception ex)
            {
                MostrarMensajeError($"Error al obtener el alquiler: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Verifica la disponibilidad de un ítem para un rango de fechas.
        /// </summary>
        public bool VerificarDisponibilidad(int itemId, DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                return VerificarDisponibilidadItem(itemId, fechaInicio, fechaFin);
            }
            catch (Exception ex)
            {
                MostrarMensajeError($"Error al verificar disponibilidad: {ex.Message}");
                throw;
            }
        }

        #region Métodos privados encapsulados

        /// <summary>
        /// Verifica si se puede crear un alquiler con los datos proporcionados.
        /// </summary>
        private bool VerificarCreacionAlquiler(Alquileres alquiler)
        {
            string mensaje = string.Empty;

            // Verificar disponibilidad
            if (!VerificarDisponibilidadItem(alquiler.ItemID, alquiler.fechaInicio, alquiler.fechaFin))
            {
                mensaje = "El ítem no está disponible para las fechas seleccionadas.";
            }

            // Obtener el ítem
            var item = ObtenerItemValidado(alquiler.ItemID);

            // Calcular días de alquiler
            int diasAlquiler = CalcularDiasAlquiler(alquiler.fechaInicio, alquiler.fechaFin);
            if (diasAlquiler <= 0)
            {
                mensaje = "Las fechas seleccionadas no son válidas.";
            }

            if (!string.IsNullOrEmpty(mensaje))
            {
                MostrarMensajeError(mensaje);
                return false;
            }

            alquiler.tiempoDias = diasAlquiler;

            // Configurar estrategia y calcular precio
            ConfigurarEstrategiaYPrecio(alquiler, item.tarifaDia);

            return true;
        }

        /// <summary>
        /// Obtiene un ítem por ID y valida que exista.
        /// </summary>
        private ItemAlquilable ObtenerItemValidado(int itemId)
        {
            var (item, _) = _itemController.ObtenerItemPorId(itemId);
            if (item == null)
            {
                throw new Exception("Item no encontrado");
            }
            return item;
        }

        /// <summary>
        /// Calcula los días de alquiler entre dos fechas.
        /// </summary>
        private int CalcularDiasAlquiler(DateTime fechaInicio, DateTime fechaFin)
        {
            return (int)(fechaFin - fechaInicio).TotalDays + 1;
        }

        /// <summary>
        /// Configura la estrategia de precio y calcula el precio total.
        /// </summary>
        private void ConfigurarEstrategiaYPrecio(Alquileres alquiler, double tarifaDiaria)
        {
            bool tieneMembresia = _usuarioController.getMembresiaUsuario(alquiler.UsuarioID);
            IEstrategiaPrecio estrategia = DeterminarEstrategia(tieneMembresia);

            alquiler.tipoEstrategia = tieneMembresia ? "EstrategiaMembresia" : "EstrategiaEstacion";
            alquiler.precioTotal = estrategia.CalcularPrecioAlquiler(tarifaDiaria, alquiler.tiempoDias);
        }

        /// <summary>
        /// Determina la estrategia de precio a utilizar.
        /// </summary>
        private IEstrategiaPrecio DeterminarEstrategia(bool tieneMembresia)
        {
            return tieneMembresia
                ? new EstrategiaMembresia()
                : new EstrategiaEstacion(EstrategiaEstacion.ObtenerEstacionActual());
        }

        /// <summary>
        /// Obtiene el porcentaje de ajuste según la estación.
        /// </summary>
        private string ObtenerPorcentajeEstacion(Estacion estacion)
        {
            return estacion == Estacion.Verano ? "15%" :
                   estacion == Estacion.Invierno ? "10%" :
                   estacion == Estacion.Otoño ? "5% de descuento" : "0%";
        }

        /// <summary>
        /// Valida que las fechas del alquiler sean correctas.
        /// </summary>
        private void ValidarFechasAlquiler(DateTime fechaInicio, DateTime fechaFin)
        {
            if (fechaInicio > fechaFin)
                throw new ArgumentException("La fecha de inicio no puede ser posterior a la fecha de fin.");
        }

        /// <summary>
        /// Verifica si un alquiler puede ser cancelado.
        /// </summary>
        private bool PuedeCancelarAlquiler(Alquileres alquiler)
        {
            if (alquiler.fechaInicio <= DateTime.Now)
            {
                MostrarMensajeError("No se pueden cancelar alquileres que ya han comenzado.");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Verifica la disponibilidad de un ítem para un rango de fechas.
        /// </summary>
        private bool VerificarDisponibilidadItem(int itemId, DateTime fechaInicio, DateTime fechaFin)
        {
            var alquileres = _alquilerDao.FindAlquileresByItem(itemId);
            return !alquileres.Any(a =>
                (fechaInicio >= a.fechaInicio && fechaInicio <= a.fechaFin) ||
                (fechaFin >= a.fechaInicio && fechaFin <= a.fechaFin) ||
                (fechaInicio <= a.fechaInicio && fechaFin >= a.fechaFin));
        }

        /// <summary>
        /// Muestra un mensaje de error al usuario.
        /// </summary>
        private void MostrarMensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion
    }
}
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

        #region Verificacion
        private bool VerificarCreacionAlquiler(Alquileres alquiler)
        {
            string mensaje = string.Empty;

            // Verificar disponibilidad
            if (!VerificarDisponibilidad(alquiler.ItemID, alquiler.fechaInicio, alquiler.fechaFin))
            {
                mensaje = "El ítem no está disponible para las fechas seleccionadas.";
            }

            // Obtener el ítem
            var (item, _) = _itemController.ObtenerItemPorId(alquiler.ItemID);
            if (item == null)
            {
                throw new Exception("Item no encontrado");
            }

            // Calcular días de alquiler
            int diasAlquiler = (int)(alquiler.fechaFin - alquiler.fechaInicio).TotalDays + 1;
            if (diasAlquiler <= 0)
            {
                mensaje = "Las fechas seleccionadas no son válidas.";
            }

            if (!string.IsNullOrEmpty(mensaje))
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            alquiler.tiempoDias = diasAlquiler;

            // Determinar estrategia de precio
            bool tieneMembresia = _usuarioController.getMembresiaUsuario(alquiler.UsuarioID);
            IEstrategiaPrecio estrategia = tieneMembresia
                ? new EstrategiaMembresia()
                : new EstrategiaEstacion(EstrategiaEstacion.ObtenerEstacionActual());

            alquiler.tipoEstrategia = tieneMembresia ? "EstrategiaMembresia" : "EstrategiaEstacion";

            alquiler.precioTotal = estrategia.CalcularPrecioAlquiler(item.tarifaDia, diasAlquiler);

            return true;
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

                // Mostrar información sobre el precio aplicado solo si todo fue exitoso
                MostrarInformacionPrecio(alquiler.tipoEstrategia, alquiler.precioTotal, alquiler.precioTotal / alquiler.tiempoDias);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el alquiler: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        /// <summary>
        /// Muestra información sobre el precio aplicado y el tipo de estrategia
        /// </summary>
        private void MostrarInformacionPrecio(string tipoEstrategia, double precioFinal, double precioBase)
        {
            string mensaje = "";

            switch (tipoEstrategia)
            {
                case "EstrategiaMembresia":
                    mensaje = $"Se aplicó un descuento del 10% por membresía.\nPrecio base: {precioBase:C}\nPrecio final: {precioFinal:C}";
                    break;
                case "EstrategiaEstacion":
                    var estacion = EstrategiaEstacion.ObtenerEstacionActual();
                    string porcentaje = estacion == Estacion.Verano ? "15%" : estacion == Estacion.Invierno ? "10%" :
                                        estacion == Estacion.Otoño ? "5% de descuento" : "0%";
                    mensaje = $"Se aplicó un ajuste de {porcentaje} por temporada ({estacion}).\nPrecio base: {precioBase:C}\nPrecio final: {precioFinal:C}";
                    break;
                default:
                    mensaje = $"Se aplicó el precio estándar.\nPrecio final: {precioFinal:C}";
                    break;
            }

            MessageBox.Show(mensaje, "Información de Precio", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        /// <summary>
        /// Actualiza un alquiler existente.
        /// </summary>
        public void ActualizarAlquiler(Alquileres alquiler)
        {
            try
            {
                if (alquiler.fechaInicio > alquiler.fechaFin)
                    throw new ArgumentException("La fecha de inicio no puede ser posterior a la fecha de fin.");

                _alquilerDao.UpdateAlquiler(alquiler);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el alquiler: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                var alquiler = _alquilerDao.FindAlquilerById(alquilerId);

                if (alquiler.fechaInicio <= DateTime.Now)
                {
                    MessageBox.Show($"No se pueden cancelar alquileres que ya han comenzado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                _alquilerDao.SoftDeleteAlquiler(alquiler);
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cancelar el alquiler: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"Error al obtener los alquileres: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"Error al obtener el alquiler: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                var alquileres = _alquilerDao.FindAlquileresByItem(itemId);
                return !alquileres.Any(a =>
                    (fechaInicio >= a.fechaInicio && fechaInicio <= a.fechaFin) ||
                    (fechaFin >= a.fechaInicio && fechaFin <= a.fechaFin) ||
                    (fechaInicio <= a.fechaInicio && fechaFin >= a.fechaFin));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar disponibilidad: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
    }
}


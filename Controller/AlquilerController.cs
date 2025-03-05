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
                // Validar fechas
                if (alquiler.fechaInicio > alquiler.fechaFin)
                    throw new ArgumentException("La fecha de inicio no puede ser posterior a la fecha de fin.");

                // Verificar disponibilidad
                if (!VerificarDisponibilidad(alquiler.ItemID, alquiler.fechaInicio, alquiler.fechaFin))
                    throw new ArgumentException("El ítem no está disponible para las fechas seleccionadas.");

                // Obtener el ítem
                var (item, _) = _itemController.ObtenerItemPorId(alquiler.ItemID);
                if (item == null)
                    throw new Exception("Item no encontrado");

                // Calcular días de alquiler
                int diasAlquiler = (int)(alquiler.fechaFin - alquiler.fechaInicio).TotalDays + 1;
                alquiler.tiempoDias = diasAlquiler;

                // Determinar estrategia de precio
                bool tieneMembresia = _usuarioController.getMembresiaUsuario(alquiler.UsuarioID);
                IEstrategiaPrecio estrategia;

                if (tieneMembresia)
                {
                    // Si tiene membresía, aplicar descuento del 10%
                    estrategia = new EstrategiaMembresia();
                    alquiler.tipoEstrategia = "EstrategiaMembresia";
                }
                else
                {
                    // Si no tiene membresía, aplicar estrategia según la estación
                    var estacionActual = EstrategiaEstacion.ObtenerEstacionActual();
                    estrategia = new EstrategiaEstacion(estacionActual);
                    alquiler.tipoEstrategia = "EstrategiaEstacion";
                }

                // Calcular precio total
                alquiler.precioTotal = estrategia.CalcularPrecioAlquiler(item.tarifaDia, diasAlquiler);

                // Guardar alquiler
                _alquilerDao.InsertAlquiler(alquiler);

                // Mostrar información sobre el precio aplicado
                MostrarInformacionPrecio(alquiler.tipoEstrategia, alquiler.precioTotal, item.tarifaDia * diasAlquiler);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el alquiler: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        public void EliminarAlquiler(int alquilerId)
        {
            try
            {
                var alquiler = _alquilerDao.FindAlquilerById(alquilerId);

                if (alquiler.fechaInicio <= DateTime.Now)
                {
                    MessageBox.Show($"No se pueden cancelar alquileres que ya han comenzado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _alquilerDao.SoftDeleteAlquiler(alquilerId);
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
        /// Obtiene los alquileres de un usuario.
        /// </summary>
        public List<Alquileres> ObtenerAlquileresPorUsuario(int usuarioId)
        {
            try
            {
                return _alquilerDao.FindAlquileresByUsuario(usuarioId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los alquileres del usuario: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public Alquileres ObtenerAlquilerPorItemYUsuario(string item, string usuario)
        {
            return _alquilerDao.ObtenerAlquilerPorItemYUsuario(item, usuario);
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

        /// <summary>
        /// Calcula el precio estimado de un alquiler.
        /// </summary>
        public double CalcularPrecioEstimado(int itemId, int usuarioId, int dias)
        {
            try
            {
                var (item, _) = _itemController.ObtenerItemPorId(itemId);
                if (item == null)
                    throw new Exception("Item no encontrado");

                bool tieneMembresia = _usuarioController.getMembresiaUsuario(usuarioId);
                IEstrategiaPrecio estrategia;

                if (tieneMembresia)
                {
                    estrategia = new EstrategiaMembresia();
                }
                else
                {
                    var estacionActual = EstrategiaEstacion.ObtenerEstacionActual();
                    estrategia = new EstrategiaEstacion(estacionActual);
                }

                return estrategia.CalcularPrecioAlquiler(item.tarifaDia, dias);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al calcular precio estimado: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
    }
}


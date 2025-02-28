// AlquilerController.cs
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
            _usuarioController = UsuarioController.getInstance();
            _itemController = ItemController.getInstance();
        }
        #endregion

        /// <summary>
        /// Crea un nuevo alquiler con validaciones completas.
        /// </summary>
        public void CrearAlquiler(Alquileres alquiler)
        {
            _alquilerDao.InsertAlquiler(alquiler);
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
                if (alquiler == null)
                    throw new Exception("Alquiler no encontrado.");

                if (alquiler.fechaInicio <= DateTime.Now)
                    MessageBox.Show($"No se pueden cancelar alquileres que ya han comenzado.","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                    estrategia = new EstrategiaMembresia();
                else if (EsTemporadaAlta())
                    estrategia = new EstrategiaEstacion(ObtenerEstacionActual());
                else
                    estrategia = new EstrategiaNormal();

                return estrategia.CalcularPrecioAlquiler(item.tarifaDia, dias);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al calcular precio estimado: {ex.Message}",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private bool EsTemporadaAlta()
        {
            var mes = DateTime.Now.Month;
            return mes is >= 12 or <= 2 || mes is >= 6 and <= 8;
        }

        private Estacion ObtenerEstacionActual()
        {
            return DateTime.Now.Month switch
            {
                >= 3 and <= 5 => Estacion.Primavera,
                >= 6 and <= 8 => Estacion.Verano,
                >= 9 and <= 11 => Estacion.Otoño,
                _ => Estacion.Invierno
            };
        }
    }
}
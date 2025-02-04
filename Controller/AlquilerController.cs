using System;
using System.Collections.Generic;
using System.Linq;
using TitoAlquiler.Model.Dao;
using TitoAlquiler.Model.Entities;
using TitoAlquiler.Model.Interfaces;
using TitoAlquiler.Model.Strategy;

namespace TitoAlquiler.Controller
{
    public class AlquilerController
    {
        AlquilerDao _alquilerDao = new AlquilerDao();
        UsuarioController usuarioController = UsuarioController.getInstance();
        ItemController itemController = ItemController.getInstance();

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

        /// <summary>
        /// Crea un nuevo alquiler en la base de datos.
        /// </summary>
        /// <param name="alquiler">Objeto de tipo Alquileres que contiene la información del alquiler a crear.</param>
        public void CrearAlquiler(Alquileres alquiler)
        {
            _alquilerDao.InsertAlquiler(alquiler);
        }

        /// <summary>
        /// Actualiza un alquiler existente en la base de datos.
        /// </summary>
        /// <param name="alquiler">Objeto de tipo Alquileres con los datos actualizados.</param>
        public void ActualizarAlquiler(Alquileres alquiler)
        {
            _alquilerDao.UpdateAlquiler(alquiler);
        }

        /// <summary>
        /// Elimina un alquiler de manera lógica (soft delete).
        /// </summary>
        /// <param name="alquiler">Objeto de tipo Alquileres que representa el alquiler a eliminar.</param>
        public void EliminarAlquiler(Alquileres alquiler)
        {
            _alquilerDao.SoftDeleteAlquiler(alquiler);
        }

        /// <summary>
        /// Obtiene todos los alquileres registrados.
        /// </summary>
        /// <returns>Lista de objetos Alquileres.</returns>
        public List<Alquileres> ObtenerTodosLosAlquileres()
        {
            return _alquilerDao.LoadAllAlquileres();
        }

        /// <summary>
        /// Obtiene un alquiler por su identificador.
        /// </summary>
        /// <param name="id">ID del alquiler.</param>
        /// <returns>Objeto de tipo Alquileres con los detalles del alquiler.</returns>
        public Alquileres ObtenerAlquilerPorId(int id)
        {
            return _alquilerDao.FindAlquilerById(id);
        }

        /// <summary>
        /// Obtiene los alquileres realizados por un usuario específico.
        /// </summary>
        /// <param name="usuarioId">ID del usuario.</param>
        /// <returns>Lista de objetos Alquileres asociados al usuario.</returns>
        public List<Alquileres> ObtenerAlquileresPorUsuario(int usuarioId)
        {
            return _alquilerDao.FindAlquileresByUsuario(usuarioId);
        }

        /// <summary>
        /// Obtiene los alquileres que involucran un item específico.
        /// </summary>
        /// <param name="itemId">ID del item.</param>
        /// <returns>Lista de objetos Alquileres que contienen el item.</returns>
        public List<Alquileres> ObtenerAlquileresPorItem(int itemId)
        {
            return _alquilerDao.FindAlquileresByItem(itemId);
        }

        /// <summary>
        /// Crea un nuevo alquiler con los parámetros proporcionados y calcula el precio total basado en la estrategia seleccionada.
        /// </summary>
        /// <param name="itemId">ID del item a alquilar.</param>
        /// <param name="usuarioId">ID del usuario que realiza el alquiler.</param>
        /// <param name="fechaInicio">Fecha de inicio del alquiler.</param>
        /// <param name="fechaFin">Fecha de fin del alquiler.</param>
        /// <param name="tipoEstrategia">Tipo de estrategia a aplicar (por ejemplo, "EstrategiaEstacion").</param>
        /// <returns>Objeto Alquileres con el alquiler creado y su precio calculado.</returns>
        public Alquileres CrearNuevoAlquiler(int itemId, int usuarioId, DateTime fechaInicio, DateTime fechaFin, string tipoEstrategia)
        {
            var item = itemController.ObtenerItemPorId(itemId);
            var usuario = usuarioController.ObtenerUsuarioPorId(usuarioId);

            if (item == null || usuario == null)
            {
                throw new ArgumentException("Item o Usuario no encontrado");
            }

            int dias = (int)(fechaFin - fechaInicio).TotalDays + 1;
            IEstrategiaPrecio estrategia = usuario.membresiaPremium ?
                new EstrategiaMembresia() :
                tipoEstrategia == "Estacion" ? new EstrategiaEstacion(ObtenerEstacionDelAño(fechaInicio)) :
                new EstrategiaNormal();

            var alquiler = new Alquileres(estrategia)
            {
                ItemID = itemId,
                item = item,
                UsuarioID = usuarioId,
                usuario = usuario,
                tiempoDias = dias,
                fechaInicio = fechaInicio,
                fechaFin = fechaFin,
                tipoEstrategia = tipoEstrategia
            };

            alquiler.CalcularPrecio();
            CrearAlquiler(alquiler);
            return alquiler;
        }

        private Estacion ObtenerEstacionDelAño(DateTime fecha)
        {
            int mes = fecha.Month;
            return mes switch
            {
                12 or 1 or 2 => Estacion.Verano,
                3 or 4 or 5 => Estacion.Otoño,
                6 or 7 or 8 => Estacion.Invierno,
                9 or 10 or 11 => Estacion.Primavera,
                _ => throw new ArgumentOutOfRangeException("Mes no válido")
            };
        }

        /// <summary>
        /// Verifica la disponibilidad de un item para el rango de fechas especificado.
        /// </summary>
        /// <param name="itemId">ID del item a verificar.</param>
        /// <param name="fechaInicio">Fecha de inicio del alquiler.</param>
        /// <param name="fechaFin">Fecha de fin del alquiler.</param>
        /// <returns>True si el item está disponible, False si ya está alquilado para esas fechas.</returns>
        public bool VerificarDisponibilidad(int itemId, DateTime fechaInicio, DateTime fechaFin)
        {
            var alquileresExistentes = ObtenerAlquileresPorItem(itemId);
            return !alquileresExistentes.Any(a =>
                (fechaInicio >= a.fechaInicio && fechaInicio < a.fechaFin) ||
                (fechaFin > a.fechaInicio && fechaFin <= a.fechaFin) ||
                (fechaInicio <= a.fechaInicio && fechaFin >= a.fechaFin));
        }

        /// <summary>
        /// Obtiene el nombre del usuario por alquiler.
        /// </summary>
        /// <param name="alquilerId">ID del alquiler.</param>
        /// <returns>Nombre del usuario que realizó el alquiler.</returns>
        public string ObtenerNombreUsuarioPorAlquiler(int alquilerId)
        {
            var alquiler = ObtenerAlquilerPorId(alquilerId);
            if (alquiler == null)
            {
                MessageBox.Show("Alquiler no encontrado");
            }
            var usuario = usuarioController.ObtenerUsuarioPorId(alquiler.UsuarioID);
            return usuario?.nombre ?? "Usuario no encontrado";
        }

        /// <summary>
        /// Obtiene el nombre del item por alquiler.
        /// </summary>
        /// <param name="alquilerId">ID del alquiler.</param>
        /// <returns>Nombre del item alquilado.</returns>
        public string ObtenerNombreItemPorAlquiler(int alquilerId)
        {
            var alquiler = ObtenerAlquilerPorId(alquilerId);
            if (alquiler == null)
            {
                MessageBox.Show("Alquiler no encontrado");
            }
            var item = itemController.ObtenerItemPorId(alquiler.ItemID);
            return item?.nombreItem ?? "Item no encontrado";
        }

        /// <summary>
        /// Obtiene el nombre del item y del usuario por alquiler.
        /// </summary>
        /// <param name="alquilerId">ID del alquiler.</param>
        /// <returns>Tupla con el nombre del item y el nombre del usuario.</returns>
        public (string nombreItem, string nombreUsuario) ObtenerNombreItemYUsuarioPorAlquiler(int alquilerId)
        {
            var alquiler = ObtenerAlquilerPorId(alquilerId);
            if (alquiler == null)
            {
                MessageBox.Show("Alquiler no encontrado");
            }
            var item = itemController.ObtenerItemPorId(alquiler.ItemID);
            var usuario = usuarioController.ObtenerUsuarioPorId(alquiler.UsuarioID);
            return (item?.nombreItem ?? "Item no encontrado", usuario?.nombre ?? "Usuario no encontrado");
        }
    }
}


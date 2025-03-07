// AlquilerDao.cs
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TitoAlquiler.Model.Entities;
using TitoAlquiler.Model.Interfaces;
using TitoAlquiler.Model.Strategy;
using System.Windows.Forms;
using TitoAlquiler.Controller;
using TitoAlquiler.Resources;

namespace TitoAlquiler.Model.Dao
{
    public class AlquilerDao
    {
        #region Gestion Alquiler
        /// <summary>
        /// Inserta un nuevo alquiler en la base de datos.
        /// </summary>
        /// <param name="alquiler">Objeto de tipo Alquileres a insertar.</param>
        /// <exception cref="Exception">Se lanza cuando ocurre un error durante la inserción.</exception>
        public void InsertAlquiler(Alquileres alquiler)
        {
            using var db = new SistemaAlquilerContext();
            using var transaction = db.Database.BeginTransaction();
            try
            {
                ValidarItemExistente(db, alquiler.ItemID);

                // Guardar alquiler
                db.Alquileres.Add(alquiler);
                db.SaveChanges();
                transaction.Commit();

                MessageShow.MostrarMensajeExito($"Alquiler guardado exitosamente. Precio total: {alquiler.precioTotal:C}");
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception($"Error al crear el alquiler: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Actualiza un alquiler existente.
        /// </summary>
        /// <param name="alquiler">Objeto de tipo Alquileres a actualizar.</param>
        /// <exception cref="Exception">Se lanza cuando ocurre un error durante la actualización.</exception>
        public void UpdateAlquiler(Alquileres alquiler)
        {
            using var db = new SistemaAlquilerContext();
            using var transaction = db.Database.BeginTransaction();
            try
            {
                var alquilerOriginal = ObtenerAlquilerOriginal(db, alquiler.id);

                if (HayCambioEnFechas(alquilerOriginal, alquiler))
                {
                    ValidarDisponibilidadParaNuevasFechas(db, alquiler);
                    RecalcularPrecioAlquiler(db, alquiler);
                }

                db.Update(alquiler);
                db.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception($"Error al actualizar el alquiler: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Elimina un alquiler de manera lógica (soft delete), marcando la fecha de eliminación.
        /// </summary>
        /// <param name="alquiler">Objeto de tipo Alquileres que representa el alquiler a eliminar.</param>
        /// <exception cref="Exception">Se lanza cuando ocurre un error durante la eliminación.</exception>
        public void SoftDeleteAlquiler(Alquileres alquiler)
        {
            try
            {
                using var db = new SistemaAlquilerContext();
                alquiler.deletedAt = DateTime.Now;
                db.Update(alquiler);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error soft deleting alquiler: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene todos los alquileres activos.
        /// </summary>
        /// <returns>Lista de objetos Alquileres activos.</returns>
        public List<Alquileres> LoadAllAlquileres()
        {
            using var db = new SistemaAlquilerContext();
            return ObtenerAlquileresActivos(db);
        }

        /// <summary>
        /// Busca un alquiler por su ID.
        /// </summary>
        /// <param name="id">ID del alquiler a buscar.</param>
        /// <returns>Objeto Alquileres con los detalles del alquiler encontrado.</returns>
        public Alquileres FindAlquilerById(int id)
        {
            using var db = new SistemaAlquilerContext();
            return ObtenerAlquilerPorId(db, id);
        }

        /// <summary>
        /// Obtiene los alquileres de un usuario específico.
        /// </summary>
        /// <param name="usuarioId">ID del usuario cuyos alquileres se desean obtener.</param>
        /// <returns>Lista de objetos Alquileres del usuario especificado.</returns>
        public List<Alquileres> FindAlquileresByUsuario(int usuarioId)
        {
            using var db = new SistemaAlquilerContext();
            return ObtenerAlquileresPorUsuario(db, usuarioId);
        }

        /// <summary>
        /// Obtiene los alquileres de un ítem específico.
        /// </summary>
        /// <param name="itemId">ID del ítem cuyos alquileres se desean obtener.</param>
        /// <returns>Lista de objetos Alquileres del ítem especificado.</returns>
        public List<Alquileres> FindAlquileresByItem(int itemId)
        {
            using var db = new SistemaAlquilerContext();
            return ObtenerAlquileresPorItem(db, itemId);
        }

        /// <summary>
        /// Obtiene un alquiler activo por el nombre del ítem y el nombre del usuario.
        /// </summary>
        /// <param name="nombreItem">Nombre del ítem alquilado.</param>
        /// <param name="nombreUsuario">Nombre del usuario que realizó el alquiler.</param>
        /// <returns>Objeto Alquileres si se encuentra el alquiler; de lo contrario, null.</returns>
        /// <exception cref="Exception">Se lanza cuando ocurre un error durante la consulta.</exception>
        public Alquileres ObtenerAlquilerPorItemYUsuario(string nombreItem, string nombreUsuario)
        {
            try
            {
                using var db = new SistemaAlquilerContext();
                return BuscarAlquilerPorItemYUsuario(db, nombreItem, nombreUsuario);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el alquiler: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Verifica si existe un alquiler activo para un ítem en un rango de fechas.
        /// </summary>
        /// <param name="db">Contexto de la base de datos.</param>
        /// <param name="itemId">ID del ítem a verificar.</param>
        /// <param name="fechaInicio">Fecha de inicio del rango a verificar.</param>
        /// <param name="fechaFin">Fecha de fin del rango a verificar.</param>
        /// <param name="excludeAlquilerId">ID de alquiler a excluir de la verificación (opcional).</param>
        /// <returns>True si existe un alquiler activo en el rango de fechas, de lo contrario False.</returns>
        private bool ExisteAlquilerActivo(SistemaAlquilerContext db, int itemId,
                                        DateTime fechaInicio, DateTime fechaFin, int? excludeAlquilerId = null)
        {
            var query = db.Alquileres.Where(a =>
                a.ItemID == itemId &&
                a.deletedAt == null &&
                ((fechaInicio >= a.fechaInicio && fechaInicio <= a.fechaFin) ||
                 (fechaFin >= a.fechaInicio && fechaFin <= a.fechaFin) ||
                 (fechaInicio <= a.fechaInicio && fechaFin >= a.fechaFin)));

            if (excludeAlquilerId.HasValue)
                query = query.Where(a => a.id != excludeAlquilerId.Value);

            return query.Any();
        }

        /// <summary>
        /// Obtiene todos los alquileres activos.
        /// </summary>
        /// <param name="db">Contexto de la base de datos.</param>
        /// <returns>Lista de objetos Alquileres activos.</returns>
        private List<Alquileres> ObtenerAlquileresActivos(SistemaAlquilerContext db)
        {
            return db.Alquileres
                    .Include(a => a.usuario)
                    .Include(a => a.item)
                    .Where(a => a.deletedAt == null)
                    .ToList();
        }

        /// <summary>
        /// Obtiene un alquiler por su ID.
        /// </summary>
        /// <param name="db">Contexto de la base de datos.</param>
        /// <param name="id">ID del alquiler a obtener.</param>
        /// <returns>Objeto Alquileres con los detalles del alquiler encontrado.</returns>
        private Alquileres ObtenerAlquilerPorId(SistemaAlquilerContext db, int id)
        {
            return db.Alquileres
                    .Include(a => a.usuario)
                    .Include(a => a.item)
                    .FirstOrDefault(a => a.id == id && a.deletedAt == null);
        }

        /// <summary>
        /// Obtiene los alquileres de un usuario específico.
        /// </summary>
        /// <param name="db">Contexto de la base de datos.</param>
        /// <param name="usuarioId">ID del usuario cuyos alquileres se desean obtener.</param>
        /// <returns>Lista de objetos Alquileres del usuario especificado.</returns>
        private List<Alquileres> ObtenerAlquileresPorUsuario(SistemaAlquilerContext db, int usuarioId)
        {
            return db.Alquileres
                    .Include(a => a.item)
                    .Where(a => a.UsuarioID == usuarioId && a.deletedAt == null)
                    .ToList();
        }

        /// <summary>
        /// Obtiene los alquileres de un ítem específico.
        /// </summary>
        /// <param name="db">Contexto de la base de datos.</param>
        /// <param name="itemId">ID del ítem cuyos alquileres se desean obtener.</param>
        /// <returns>Lista de objetos Alquileres del ítem especificado.</returns>
        private List<Alquileres> ObtenerAlquileresPorItem(SistemaAlquilerContext db, int itemId)
        {
            return db.Alquileres
                    .Include(a => a.usuario)
                    .Where(a => a.ItemID == itemId && a.deletedAt == null)
                    .ToList();
        }

        /// <summary>
        /// Busca un alquiler por nombre de ítem y nombre de usuario.
        /// </summary>
        /// <param name="db">Contexto de la base de datos.</param>
        /// <param name="nombreItem">Nombre del ítem alquilado.</param>
        /// <param name="nombreUsuario">Nombre del usuario que realizó el alquiler.</param>
        /// <returns>Objeto Alquileres si se encuentra el alquiler; de lo contrario, null.</returns>
        private Alquileres BuscarAlquilerPorItemYUsuario(SistemaAlquilerContext db, string nombreItem, string nombreUsuario)
        {
            return db.Alquileres
                     .Include(a => a.item)
                     .Include(a => a.usuario)
                     .FirstOrDefault(a => a.item.nombreItem == nombreItem
                                          && a.usuario.nombre == nombreUsuario
                                          && a.deletedAt == null);
        }
        #endregion

        #region Métodos privados encapsulados

        /// <summary>
        /// Valida que el ítem exista y no haya sido eliminado.
        /// </summary>
        /// <param name="db">Contexto de la base de datos.</param>
        /// <param name="itemId">ID del ítem a validar.</param>
        /// <exception cref="Exception">Se lanza cuando el ítem no existe o ha sido eliminado.</exception>
        private void ValidarItemExistente(SistemaAlquilerContext db, int itemId)
        {
            var item = db.Items
                .FirstOrDefault(i => i.id == itemId && i.deletedAt == null);

            if (item == null)
                throw new Exception("El ítem no existe o ha sido eliminado.");
        }

        /// <summary>
        /// Obtiene el alquiler original de la base de datos.
        /// </summary>
        /// <param name="db">Contexto de la base de datos.</param>
        /// <param name="alquilerId">ID del alquiler a obtener.</param>
        /// <returns>Objeto Alquileres original.</returns>
        /// <exception cref="Exception">Se lanza cuando el alquiler no existe.</exception>
        private Alquileres ObtenerAlquilerOriginal(SistemaAlquilerContext db, int alquilerId)
        {
            var alquilerOriginal = db.Alquileres
                .AsNoTracking()
                .FirstOrDefault(a => a.id == alquilerId);

            if (alquilerOriginal == null)
                throw new Exception("El alquiler no existe.");

            return alquilerOriginal;
        }

        /// <summary>
        /// Determina si hay cambios en las fechas del alquiler.
        /// </summary>
        /// <param name="alquilerOriginal">Alquiler original.</param>
        /// <param name="alquilerNuevo">Alquiler con posibles cambios.</param>
        /// <returns>True si hay cambios en las fechas, de lo contrario False.</returns>
        private bool HayCambioEnFechas(Alquileres alquilerOriginal, Alquileres alquilerNuevo)
        {
            return alquilerOriginal.fechaInicio != alquilerNuevo.fechaInicio ||
                   alquilerOriginal.fechaFin != alquilerNuevo.fechaFin;
        }

        /// <summary>
        /// Valida que el ítem esté disponible para las nuevas fechas.
        /// </summary>
        /// <param name="db">Contexto de la base de datos.</param>
        /// <param name="alquiler">Alquiler con las nuevas fechas a validar.</param>
        /// <exception cref="Exception">Se lanza cuando el ítem no está disponible para las nuevas fechas.</exception>
        private void ValidarDisponibilidadParaNuevasFechas(SistemaAlquilerContext db, Alquileres alquiler)
        {
            if (ExisteAlquilerActivo(db, alquiler.ItemID, alquiler.fechaInicio, alquiler.fechaFin, alquiler.id))
                throw new Exception("El ítem no está disponible para las nuevas fechas seleccionadas.");
        }

        /// <summary>
        /// Recalcula el precio del alquiler basado en la estrategia y las nuevas fechas.
        /// </summary>
        /// <param name="db">Contexto de la base de datos.</param>
        /// <param name="alquiler">Alquiler a recalcular.</param>
        private void RecalcularPrecioAlquiler(SistemaAlquilerContext db, Alquileres alquiler)
        {
            var item = db.Items.Find(alquiler.ItemID);
            int diasAlquiler = (int)(alquiler.fechaFin - alquiler.fechaInicio).TotalDays + 1;
            alquiler.tiempoDias = diasAlquiler;

            // Recrear la estrategia según el tipo guardado
            IEstrategiaPrecio estrategia = CrearEstrategia(alquiler.tipoEstrategia);
            alquiler.precioTotal = estrategia.CalcularPrecioAlquiler(item.tarifaDia, diasAlquiler);
        }

        /// <summary>
        /// Crea la estrategia de precio adecuada según el tipo especificado.
        /// </summary>
        /// <param name="tipoEstrategia">Tipo de estrategia a crear.</param>
        /// <returns>Instancia de la estrategia de precio correspondiente.</returns>
        private IEstrategiaPrecio CrearEstrategia(string tipoEstrategia)
        {
            return tipoEstrategia switch
            {
                "EstrategiaMembresia" => new EstrategiaMembresia(),
                "EstrategiaEstacion" => new EstrategiaEstacion(EstrategiaEstacion.ObtenerEstacionActual()),
                _ => new EstrategiaNormal()
            };
        }

        #endregion
    }
}
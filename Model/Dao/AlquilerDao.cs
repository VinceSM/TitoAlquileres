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

namespace TitoAlquiler.Model.Dao
{
    public class AlquilerDao
    {
        private readonly UsuarioController _usuarioController = UsuarioController.getInstance();

        /// <summary>
        /// Inserta un nuevo alquiler en la base de datos.
        /// </summary>
        public void InsertAlquiler(Alquileres alquiler)
        {
            using var db = new SistemaAlquilerContext();
            using var transaction = db.Database.BeginTransaction();
            try
            {
                // Validar que el ítem exista y esté disponible
                var item = db.Items
                    .Include(i => i.Alquileres)
                    .FirstOrDefault(i => i.id == alquiler.ItemID && i.deletedAt == null);

                if (item == null)
                    throw new Exception("El ítem no existe o ha sido eliminado.");

                // Verificar disponibilidad
                if (ExisteAlquilerActivo(db, alquiler.ItemID, alquiler.fechaInicio, alquiler.fechaFin))
                    throw new Exception("El ítem no está disponible para las fechas seleccionadas.");

                // Determinar estrategia de precio
                bool tieneMembresia = _usuarioController.getMembresiaUsuario(alquiler.UsuarioID);
                IEstrategiaPrecio estrategia;

                if (tieneMembresia)
                {
                    alquiler.tipoEstrategia = "EstrategiaMembresia";
                    estrategia = new EstrategiaMembresia();
                }
                else if (AplicarEstrategiaEstacional())
                {
                    alquiler.tipoEstrategia = "EstrategiaEstacion";
                    estrategia = new EstrategiaEstacion(ObtenerEstacionActual());
                }
                else
                {
                    alquiler.tipoEstrategia = "EstrategiaNormal";
                    estrategia = new EstrategiaNormal();
                }

                // Calcular precio
                int diasAlquiler = (int)(alquiler.fechaFin - alquiler.fechaInicio).TotalDays + 1;
                alquiler.tiempoDias = diasAlquiler;
                alquiler.precioTotal = estrategia.CalcularPrecioAlquiler(item.tarifaDia, diasAlquiler);

                // Guardar alquiler
                db.Alquileres.Add(alquiler);
                db.SaveChanges();
                transaction.Commit();

                MessageBox.Show($"Alquiler guardado exitosamente. Precio total: {alquiler.precioTotal:C}",
                              "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        public void UpdateAlquiler(Alquileres alquiler)
        {
            using var db = new SistemaAlquilerContext();
            using var transaction = db.Database.BeginTransaction();
            try
            {
                // Verificar si hay cambios en las fechas
                var alquilerOriginal = db.Alquileres
                    .AsNoTracking()
                    .FirstOrDefault(a => a.id == alquiler.id);

                if (alquilerOriginal == null)
                    throw new Exception("El alquiler no existe.");

                if (alquilerOriginal.fechaInicio != alquiler.fechaInicio ||
                    alquilerOriginal.fechaFin != alquiler.fechaFin)
                {
                    // Verificar disponibilidad para las nuevas fechas
                    if (ExisteAlquilerActivo(db, alquiler.ItemID, alquiler.fechaInicio, alquiler.fechaFin, alquiler.id))
                        throw new Exception("El ítem no está disponible para las nuevas fechas seleccionadas.");

                    // Recalcular precio si cambian las fechas
                    var item = db.Items.Find(alquiler.ItemID);
                    int diasAlquiler = (int)(alquiler.fechaFin - alquiler.fechaInicio).TotalDays + 1;
                    alquiler.tiempoDias = diasAlquiler;

                    IEstrategiaPrecio estrategia = alquiler.tipoEstrategia switch
                    {
                        "EstrategiaMembresia" => new EstrategiaMembresia(),
                        "EstrategiaEstacion" => new EstrategiaEstacion(ObtenerEstacionActual()),
                        _ => new EstrategiaNormal()
                    };

                    alquiler.precioTotal = estrategia.CalcularPrecioAlquiler(item.tarifaDia, diasAlquiler);
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
        /// Realiza una eliminación lógica del alquiler.
        /// </summary>
        public void SoftDeleteAlquiler(int alquilerId)
        {
            using var db = new SistemaAlquilerContext();
            try
            {
                var alquiler = db.Alquileres.Find(alquilerId);
                if (alquiler != null)
                {
                    alquiler.deletedAt = DateTime.Now;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el alquiler: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Obtiene todos los alquileres activos.
        /// </summary>
        public List<Alquileres> LoadAllAlquileres()
        {
            using var db = new SistemaAlquilerContext();
            return db.Alquileres
                    .Include(a => a.usuario)
                    .Include(a => a.item)
                    .Where(a => a.deletedAt == null)
                    .ToList();
        }

        /// <summary>
        /// Busca un alquiler por su ID.
        /// </summary>
        public Alquileres FindAlquilerById(int id)
        {
            using var db = new SistemaAlquilerContext();
            return db.Alquileres
                    .Include(a => a.usuario)
                    .Include(a => a.item)
                    .FirstOrDefault(a => a.id == id && a.deletedAt == null);
        }

        /// <summary>
        /// Obtiene los alquileres de un usuario específico.
        /// </summary>
        public List<Alquileres> FindAlquileresByUsuario(int usuarioId)
        {
            using var db = new SistemaAlquilerContext();
            return db.Alquileres
                    .Include(a => a.item)
                    .Where(a => a.UsuarioID == usuarioId && a.deletedAt == null)
                    .ToList();
        }

        /// <summary>
        /// Obtiene los alquileres de un ítem específico.
        /// </summary>
        public List<Alquileres> FindAlquileresByItem(int itemId)
        {
            using var db = new SistemaAlquilerContext();
            return db.Alquileres
                    .Include(a => a.usuario)
                    .Where(a => a.ItemID == itemId && a.deletedAt == null)
                    .ToList();
        }

        /// <summary>
        /// Verifica si existe un alquiler activo para un ítem en un rango de fechas.
        /// </summary>
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

        private bool AplicarEstrategiaEstacional()
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

        /// <summary>
        /// Obtiene un alquiler activo por el nombre del ítem y el nombre del usuario.
        /// </summary>
        /// <param name="nombreItem">Nombre del ítem alquilado.</param>
        /// <param name="nombreUsuario">Nombre del usuario que realizó el alquiler.</param>
        /// <returns>Objeto <see cref="Alquileres"/> si se encuentra el alquiler; de lo contrario, null.</returns>
        public Alquileres ObtenerAlquilerPorItemYUsuario(string nombreItem, string nombreUsuario)
        {
            try
            {
                using (var db = new SistemaAlquilerContext())
                {
                    return db.Alquileres
                             .Include(a => a.item)
                             .Include(a => a.usuario)
                             .FirstOrDefault(a => a.item.nombreItem == nombreItem
                                                  && a.usuario.nombre == nombreUsuario
                                                  && a.deletedAt == null);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el alquiler: {ex.Message}");
                throw;
            }
        }
    }
}
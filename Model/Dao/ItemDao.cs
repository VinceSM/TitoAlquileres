// ItemDao.cs
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TitoAlquiler.Model.Entities.Categorias;
using TitoAlquiler.Model.Entities;
using Microsoft.Data.SqlClient;
using System.Text.RegularExpressions;
using TitoAlquiler.Model.Interfaces;

namespace TitoAlquiler.Model.Dao
{
    public class ItemDao
    {
        #region Insertar Item

        /// <summary>
        /// Inserta un nuevo ítem y su categoría específica en la base de datos.
        /// </summary>
        /// <param name="factory">Fábrica específica para el tipo de ítem a crear.</param>
        /// <param name="nombre">Nombre del ítem.</param>
        /// <param name="marca">Marca del ítem.</param>
        /// <param name="modelo">Modelo del ítem.</param>
        /// <param name="tarifaDia">Tarifa diaria de alquiler del ítem.</param>
        /// <param name="adicionales">Parámetros adicionales específicos según el tipo de ítem.</param>
        public void InsertItem(IItemFactory factory, string nombre, string marca, string modelo, double tarifaDia, params object[] adicionales)
        {
            using var db = new SistemaAlquilerContext();
            using var transaction = db.Database.BeginTransaction();

            try
            {
                var (item, categoria) = factory.CrearAlquilable(nombre, marca, modelo, tarifaDia, adicionales);

                db.Items.Add(item);
                db.SaveChanges();

                InsertarCategoriaEspecifica(db, item.id, categoria);

                db.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception($"Error al insertar el item: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Inserta la categoría específica en la base de datos.
        /// </summary>
        private void InsertarCategoriaEspecifica(SistemaAlquilerContext db, int itemId, object categoria)
        {
            switch (categoria)
            {
                case Transporte transporte:
                    transporte.itemId = itemId;
                    db.Transportes.Add(transporte);
                    break;
                case Electrodomestico electrodomestico:
                    electrodomestico.itemId = itemId;
                    db.Electrodomesticos.Add(electrodomestico);
                    break;
                case Inmueble inmueble:
                    inmueble.itemId = itemId;
                    db.Inmuebles.Add(inmueble);
                    break;
                case Electronica electronica:
                    electronica.itemId = itemId;
                    db.Electronicas.Add(electronica);
                    break;
                case Indumentaria indumentaria:
                    indumentaria.itemId = itemId;
                    db.Indumentarias.Add(indumentaria);
                    break;
                default:
                    throw new ArgumentException("Categoría no reconocida.");
            }
        }

        #endregion

        #region Actualizar Item

        /// <summary>
        /// Actualiza un ítem y su categoría específica en la base de datos.
        /// </summary>
        /// <param name="item">Item base a actualizar</param>
        /// <param name="categoria">Objeto de categoría específica actualizado</param>
        /// <exception cref="ArgumentNullException">Se lanza cuando el ítem o la categoría son nulos.</exception>
        /// <exception cref="Exception">Se lanza cuando ocurre un error durante la actualización.</exception>
        public void UpdateItem(ItemAlquilable item, object categoria)
        {
            ArgumentNullException.ThrowIfNull(item);
            ArgumentNullException.ThrowIfNull(categoria);

            using var db = new SistemaAlquilerContext();
            using var transaction = db.Database.BeginTransaction();

            try
            {
                db.Update(item);
                ActualizarCategoriaEspecifica(db, item.id, categoria);

                db.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception($"Error al actualizar el item: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Actualiza la categoría específica en la base de datos.
        /// </summary>
        private void ActualizarCategoriaEspecifica(SistemaAlquilerContext db, int itemId, object categoria)
        {
            switch (categoria)
            {
                case Transporte transporte:
                    transporte.itemId = itemId;
                    db.Transportes.Update(transporte);
                    break;
                case Electrodomestico electrodomestico:
                    electrodomestico.itemId = itemId;
                    db.Electrodomesticos.Update(electrodomestico);
                    break;
                case Inmueble inmueble:
                    inmueble.itemId = itemId;
                    db.Inmuebles.Update(inmueble);
                    break;
                case Electronica electronica:
                    electronica.itemId = itemId;
                    db.Electronicas.Update(electronica);
                    break;
                case Indumentaria indumentaria:
                    indumentaria.itemId = itemId;
                    db.Indumentarias.Update(indumentaria);
                    break;
                default:
                    throw new ArgumentException("Categoría no reconocida.");
            }
        }

        #endregion

        #region Soft Delete Item

        /// <summary>
        /// Realiza un borrado lógico del ítem.
        /// </summary>
        /// <param name="itemId">ID del ítem a eliminar</param>
        /// <exception cref="Exception">Se lanza cuando ocurre un error durante la eliminación.</exception>
        public void SoftDeleteItem(int itemId)
        {
            try
            {
                using var db = new SistemaAlquilerContext();
                var item = db.Items.Find(itemId);
                if (item != null)
                {
                    item.deletedAt = DateTime.Now;
                    db.Update(item);
                    db.SaveChanges();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error al eliminar el item: {ex.Message}", ex);
            }
        }

        #endregion

        #region Find, Load, Obtener Items

        /// <summary>
        /// Busca un ítem y su categoría específica por ID.
        /// </summary>
        /// <param name="id">ID del ítem</param>
        /// <returns>Tupla con el item y su categoría específica</returns>
        /// <exception cref="Exception">Se lanza cuando ocurre un error durante la búsqueda.</exception>
        public (ItemAlquilable? item, object? categoria) FindItemById(int id)
        {
            try
            {
                using var db = new SistemaAlquilerContext();
                var item = ObtenerItemPorId(db, id);

                if (item == null) return (null, null);

                var categoria = ObtenerCategoriaEspecifica(db, item);

                return (item, categoria);
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error al buscar el item: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Carga todos los ítems activos con sus categorías específicas.
        /// </summary>
        /// <returns>Lista de tuplas con items y sus categorías</returns>
        /// <exception cref="Exception">Se lanza cuando ocurre un error durante la carga.</exception>
        public List<(ItemAlquilable item, object? categoria)> LoadAllItems()
        {
            try
            {
                using var db = new SistemaAlquilerContext();
                var items = ObtenerItemsActivos(db);

                return items.Select(item => (item, ObtenerCategoriaEspecifica(db, item))).ToList();
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error al cargar los items: {ex.Message}", ex);
            }
        }

        private List<ItemAlquilable> ObtenerItemsActivos(SistemaAlquilerContext db)
        {
            return db.Items
                .Where(i => i.deletedAt == null)
                .Include(i => i.categoria)
                .ToList();
        }

        private ItemAlquilable? ObtenerItemPorId(SistemaAlquilerContext db, int id)
        {
            return db.Items
                .Include(i => i.categoria)
                .FirstOrDefault(i => i.id == id && i.deletedAt == null);
        }

        private object? ObtenerCategoriaEspecifica(SistemaAlquilerContext db, ItemAlquilable item)
        {
            return item.categoriaId switch
            {
                1 => db.Transportes.FirstOrDefault(t => t.itemId == item.id),
                2 => db.Electrodomesticos.FirstOrDefault(e => e.itemId == item.id),
                3 => db.Electronicas.FirstOrDefault(e => e.itemId == item.id),
                4 => db.Inmuebles.FirstOrDefault(i => i.itemId == item.id),
                5 => db.Indumentarias.FirstOrDefault(i => i.itemId == item.id),
                _ => null
            };
        }

        /// <summary>
        /// Busca ítems por categoría.
        /// </summary>
        /// <param name="categoriaId">ID de la categoría</param>
        /// <returns>Lista de items de una categoría específica</returns>
        /// <exception cref="Exception">Se lanza cuando ocurre un error durante la búsqueda.</exception>
        public List<ItemAlquilable> FindItemsByCategoria(int categoriaId)
        {
            try
            {
                using var db = new SistemaAlquilerContext();
                return db.Items
                    .Where(x => x.categoriaId == categoriaId && x.deletedAt == null)
                    .Include(x => x.categoria)
                    .ToList();
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error al buscar items por categoría: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Verifica si el item tiene alquileres activos.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool TieneAlquileresActivos(ItemAlquilable item)
        {
            using var db = new SistemaAlquilerContext();
            return db.Alquileres
                .Any(a => a.ItemID == item.id && a.deletedAt == null && a.fechaFin > DateTime.Now);
        }

        #endregion
    }
}
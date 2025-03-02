// ItemDao.cs
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TitoAlquiler.Model.Entities.Categorias;
using TitoAlquiler.Model.Entities;

namespace TitoAlquiler.Model.Dao
{
    public class ItemDao
    {
        /// <summary>
        /// Inserta un nuevo ítem y su categoría específica en la base de datos.
        /// </summary>
        /// <param name="item">Item base a insertar</param>
        /// <param name="categoria">Objeto de categoría específica (Transporte, Electrodomestico, etc.)</param>
        public void InsertItem(Item item, object categoria)
        {
            try
            {
                using (var db = new SistemaAlquilerContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            db.Items.Add(item);
                            db.SaveChanges();

                            switch (categoria)
                            {
                                case Transporte transporte:
                                    transporte.item_id = item.id;
                                    db.Transportes.Add(transporte);
                                    break;
                                case Electrodomestico electrodomestico:
                                    electrodomestico.item_id = item.id;
                                    db.Electrodomesticos.Add(electrodomestico);
                                    break;
                                case Inmueble inmueble:
                                    inmueble.item_id = item.id;
                                    db.Inmuebles.Add(inmueble);
                                    break;
                                case Electronica electronica:
                                    electronica.item_id = item.id;
                                    db.Electronicas.Add(electronica);
                                    break;
                                case Indumentaria indumentaria:
                                    indumentaria.item_id = item.id;
                                    db.Indumentarias.Add(indumentaria);
                                    break;
                            }

                            db.SaveChanges();
                            transaction.Commit();
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al insertar el item: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Actualiza un ítem y su categoría específica en la base de datos.
        /// </summary>
        /// <param name="item">Item base a actualizar</param>
        /// <param name="categoria">Objeto de categoría específica actualizado</param>
        public void UpdateItem(Item item, object categoria)
        {
            try
            {
                using (var db = new SistemaAlquilerContext())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            db.Update(item);

                            switch (categoria)
                            {
                                case Transporte transporte:
                                    db.Transportes.Update(transporte);
                                    break;
                                case Electrodomestico electrodomestico:
                                    db.Electrodomesticos.Update(electrodomestico);
                                    break;
                                case Inmueble inmueble:
                                    db.Inmuebles.Update(inmueble);
                                    break;
                                case Electronica electronica:
                                    db.Electronicas.Update(electronica);
                                    break;
                                case Indumentaria indumentaria:
                                    db.Indumentarias.Update(indumentaria);
                                    break;
                            }

                            db.SaveChanges();
                            transaction.Commit();
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar el item: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Realiza un borrado lógico del ítem y su categoría.
        /// </summary>
        /// <param name="itemId">ID del ítem a eliminar</param>
        public void SoftDeleteItem(int itemId)
        {
            try
            {
                using (var db = new SistemaAlquilerContext())
                {
                    var item = db.Items.Find(itemId);
                    if (item != null)
                    {
                        item.deletedAt = DateTime.Now;
                        db.Update(item);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar el item: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Busca un ítem y su categoría específica por ID.
        /// </summary>
        /// <param name="id">ID del ítem</param>
        /// <returns>Tupla con el item y su categoría específica</returns>
        public (Item item, object categoria) FindItemById(int id)
        {
            try
            {
                using (var db = new SistemaAlquilerContext())
                {
                    var item = db.Items
                        .Include(i => i.categoria)
                        .FirstOrDefault(i => i.id == id && i.deletedAt == null);

                    if (item == null) return (null, null);

                    object categoria = item.categoriaId switch
                    {
                        1 => db.Transportes.FirstOrDefault(t => t.item_id == id),
                        2 => db.Electrodomesticos.FirstOrDefault(e => e.item_id == id),
                        3 => db.Electronicas.FirstOrDefault(e => e.item_id == id),
                        4 => db.Inmuebles.FirstOrDefault(i => i.item_id == id),
                        5 => db.Indumentarias.FirstOrDefault(i => i.item_id == id),
                        _ => null
                    };

                    return (item, categoria);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar el item: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Carga todos los ítems activos con sus categorías específicas.
        /// </summary>
        /// <returns>Lista de tuplas con items y sus categorías</returns>
        public List<(Item item, object categoria)> LoadAllItems()
        {
            try
            {
                using (var db = new SistemaAlquilerContext())
                {
                    var items = db.Items
                        .Where(i => i.deletedAt == null)
                        .Include(i => i.categoria)
                        .ToList();

                    var result = new List<(Item item, object categoria)>();

                    foreach (var item in items)
                    {
                        object categoria = item.categoriaId switch
                        {
                            1 => db.Transportes.FirstOrDefault(t => t.item_id == item.id),
                            2 => db.Electrodomesticos.FirstOrDefault(e => e.item_id == item.id),
                            3 => db.Electronicas.FirstOrDefault(e => e.item_id == item.id),
                            4 => db.Inmuebles.FirstOrDefault(i => i.item_id == item.id),
                            5 => db.Indumentarias.FirstOrDefault(i => i.item_id == item.id),
                            _ => null
                        };

                        result.Add((item, categoria));
                    }

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al cargar los items: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Busca ítems por categoría.
        /// </summary>
        /// <param name="categoriaId">ID de la categoría</param>
        /// <returns>Lista de tuplas con items y sus categorías</returns>
        public List<Item> FindItemsByCategoria(int categoriaId)
        {
            try
            {
                using (var db = new SistemaAlquilerContext())
                {
                    return db.Items
                        .Where(x => x.categoriaId == categoriaId && x.deletedAt == null)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error finding items by categoria: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Busca ítems por término de búsqueda en nombre, marca o modelo.
        /// </summary>
        /// <param name="searchTerm">Término de búsqueda</param>
        /// <returns>Lista de tuplas con items y sus categorías</returns>
        public List<(Item item, object categoria)> SearchItems(string searchTerm)
        {
            try
            {
                using (var db = new SistemaAlquilerContext())
                {
                    var items = db.Items
                        .Where(i => (i.nombreItem.Contains(searchTerm) ||
                                   i.marca.Contains(searchTerm) ||
                                   i.modelo.Contains(searchTerm)) &&
                                   i.deletedAt == null)
                        .Include(i => i.categoria)
                        .ToList();

                    return items.Select(item => (item, GetCategoriaForItem(db, item))).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al buscar items: {ex.Message}", ex);
            }
        }

        private object GetCategoriaForItem(SistemaAlquilerContext db, Item item)
        {
            return item.categoriaId switch
            {
                1 => db.Transportes.FirstOrDefault(t => t.item_id == item.id),
                2 => db.Electrodomesticos.FirstOrDefault(e => e.item_id == item.id),
                3 => db.Electronicas.FirstOrDefault(e => e.item_id == item.id),
                4 => db.Inmuebles.FirstOrDefault(i => i.item_id == item.id),
                5 => db.Indumentarias.FirstOrDefault(i => i.item_id == item.id),
                _ => null
            };
        }
    }
}
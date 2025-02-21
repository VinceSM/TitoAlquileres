using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TitoAlquiler.Model.Entities.Items;

namespace TitoAlquiler.Model.Dao
{
    public class ItemDao
    {
        public ItemDao() { }

        /// <summary>
        /// Inserta un nuevo ítem en la base de datos.
        /// </summary>
        /// <param name="item">Objeto de tipo <see cref="Item"/> que contiene los datos del ítem a insertar.</param>
        public void InsertItem(Item item)
        {
            try
            {
                using (var db = new SistemaAlquilerContext())
                {
                    db.Items.Add(item);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting item: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Actualiza un ítem existente en la base de datos.
        /// </summary>
        /// <param name="item">Objeto de tipo <see cref="Item"/> que contiene los datos actualizados del ítem.</param>
        public void UpdateItem(Item item)
        {
            try
            {
                using (var db = new SistemaAlquilerContext())
                {
                    db.Update(item);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating item: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Elimina un ítem de manera lógica (soft delete), marcando la fecha de eliminación.
        /// </summary>
        /// <param name="item">Objeto de tipo <see cref="Item"/> que representa el ítem a eliminar.</param>
        public void SoftDeleteItem(Item item)
        {
            try
            {
                using (var db = new SistemaAlquilerContext())
                {
                    item.deletedAt = DateTime.Now;
                    db.Update(item);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error soft deleting item: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene todos los ítems que no han sido eliminados de la base de datos.
        /// </summary>
        /// <returns>Lista de objetos <see cref="Item"/> que representan los ítems activos.</returns>
        public List<Item> LoadAllItems()
        {
            try
            {
                using (var db = new SistemaAlquilerContext())
                {
                    return db.Items
                        .Where(x => x.deletedAt == null)
                        .Include(x => x.categoria)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading all items: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Busca un ítem por su identificador único.
        /// </summary>
        /// <param name="id">ID del ítem a buscar.</param>
        /// <returns>Objeto <see cref="Item"/> con los detalles del ítem encontrado, o null si no se encuentra.</returns>
        public Item FindItemById(int id)
        {
            try
            {
                using (var db = new SistemaAlquilerContext())
                {
                    return db.Items
                        .Where(x => x.id == id && x.deletedAt == null)
                        .Include(x => x.categoria)
                        .Include(x => x.Alquileres)
                        .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error finding item by id: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Busca ítems asociados a una categoría específica.
        /// </summary>
        /// <param name="categoriaId">ID de la categoría cuyos ítems se desean buscar.</param>
        /// <returns>Lista de objetos <see cref="Item"/> asociados a la categoría proporcionada.</returns>
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
        /// Busca ítems cuyo nombre, marca o modelo coincidan con el término de búsqueda.
        /// </summary>
        /// <param name="search">Término de búsqueda que se debe encontrar en el nombre, marca o modelo de los ítems.</param>
        /// <returns>Lista de objetos <see cref="Item"/> que coinciden con el término de búsqueda.</returns>
        public List<Item> SearchItems(string search)
        {
            try
            {
                using (var db = new SistemaAlquilerContext())
                {
                    return db.Items
                        .Where(x => (x.nombreItem.Contains(search) || x.marca.Contains(search) || x.modelo.Contains(search)) && x.deletedAt == null)
                        .Include(x => x.categoria)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching items: {ex.Message}");
                throw;
            }
        }

        public string getMarca(string nombre)
        {
            using (var db = new SistemaAlquilerContext())
            {
                return db.Items
                         .Where(i => i.nombreItem == nombre)
                         .Select(i => i.marca)
                         .FirstOrDefault() ?? "Marca no encontrada";
            }
        }

        public string getModelo(string nombre)
        {
            using (var db = new SistemaAlquilerContext())
            {
                return db.Items
                         .Where(i => i.nombreItem == nombre)
                         .Select(i => i.modelo)
                         .FirstOrDefault() ?? "Modelo no encontrado";
            }
        }
    }
}


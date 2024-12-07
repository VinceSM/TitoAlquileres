using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TitoAlquiler.Model.Entities;

namespace TitoAlquiler.Model.Dao
{
    public class ItemDao
    {
        public ItemDao() { }

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
    }
}


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
            using (var db = new SistemaAlquilerContext())
            {
                db.itemsAlquilables.Add(item);
                db.SaveChanges();
            }
        }

        public void UpdateItem(Item item)
        {
            using (var db = new SistemaAlquilerContext())
            {
                db.Update(item);
                db.SaveChanges();
            }
        }

        public void SoftDeleteItem(Item item)
        {
            using (var db = new SistemaAlquilerContext())
            {
                item.deletedAt = DateTime.Now;
                db.Update(item);
                db.SaveChanges();
            }
        }

        public List<Item> LoadAllItems()
        {
            using (var db = new SistemaAlquilerContext())
            {
                return db.itemsAlquilables
                    .Where(x => x.deletedAt == null)
                    .Include(x => x.categoria)
                    .ToList();
            }
        }

        public Item FindItemById(int id)
        {
            using (var db = new SistemaAlquilerContext())
            {
                return db.itemsAlquilables
                    .Where(x => x.id == id && x.deletedAt == null)
                    .Include(x => x.categoria)
                    .Include(x => x.Alquileres)
                    .FirstOrDefault();
            }
        }

        public List<Item> FindItemsByCategoria(int categoriaId)
        {
            using (var db = new SistemaAlquilerContext())
            {
                return db.itemsAlquilables
                    .Where(x => x.categoriaId == categoriaId && x.deletedAt == null)
                    .ToList();
            }
        }

        public List<Item> SearchItems(string search)
        {
            using (var db = new SistemaAlquilerContext())
            {
                return db.itemsAlquilables
                    .Where(x => (x.nombreItem.Contains(search) || x.marca.Contains(search) || x.modelo.Contains(search)) && x.deletedAt == null)
                    .Include(x => x.categoria)
                    .ToList();
            }
        }
    }
}


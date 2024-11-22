using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TitoAlquiler.Model.Entities.Item;

namespace SistemaAlquileres.Model.Dao
{
    public class ItemDao
    {
        private readonly SistemaAlquilerContext _context;

        public ItemDao()
        {
            _context = new SistemaAlquilerContext();
        }

        public List<Item> GetAllItems()
        {
            return _context.itemsAlquilables.ToList();
        }

        public Item GetItemById(int id)
        {
            return _context.itemsAlquilables.Find(id);
        }

        public List<Item> GetItemsByName(string nombre)
        {
            return _context.itemsAlquilables.Where(i => i.nombreItem.Contains(nombre)).ToList();
        }

        public List<Item> GetItemsByMarca(string marca)
        {
            return _context.itemsAlquilables.Where(i => i.marca == marca).ToList();
        }

        public List<Item> GetItemsByModelo(string modelo)
        {
            return _context.itemsAlquilables.Where(i => i.modelo == modelo).ToList();
        }

        public Item CreateItem(Item item)
        {
            _context.itemsAlquilables.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Item UpdateItem(Item item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
            return item;
        }

        public void DeleteItem(int id)
        {
            var item = _context.itemsAlquilables.Find(id);
            if (item != null)
            {
                _context.itemsAlquilables.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}

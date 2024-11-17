using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SistemaAlquileres.Model.Entities;

namespace SistemaAlquileres.Model.Dao
{
    public class ItemDao
    {
        private readonly SistemaAlquilerContext _context;

        public ItemDao()
        {
            _context = new SistemaAlquilerContext();
        }

        public async Task<List<Item>> GetAllItems()
        {
            return await _context.itemsAlquilables.ToListAsync();
        }

        public async Task<Item> GetItemById(int id)
        {
            return await _context.itemsAlquilables.FindAsync(id);
        }

        public async Task<List<Item>> GetItemsByName(string nombre)
        {
            return await _context.itemsAlquilables.Where(i => i.nombre.Contains(nombre)).ToListAsync();
        }

        public async Task<List<Item>> GetItemsByMarca(string marca)
        {
            return await _context.itemsAlquilables.Where(i => i.marca == marca).ToListAsync();
        }

        public async Task<List<Item>> GetItemsByModelo(string modelo)
        {
            return await _context.itemsAlquilables.Where(i => i.modelo == modelo).ToListAsync();
        }

        public async Task<List<Item>> GetItemsByCategoria(string categoria)
        {
            return await _context.itemsAlquilables.Where(i => i.categoria == categoria).ToListAsync();
        }

        public async Task<Item> CreateItem(Item item)
        {
            _context.itemsAlquilables.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Item> UpdateItem(Item item)
        {
            _context.Entry(item).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task DeleteItem(int id)
        {
            var item = await _context.itemsAlquilables.FindAsync(id);
            if (item != null)
            {
                _context.itemsAlquilables.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
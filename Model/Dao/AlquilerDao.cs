using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaAlquileres.Model.Entities;

namespace SistemaAlquileres.Model.Dao
{
    public class AlquilerDao
    {
       private SistemaAlquilerContext _context = new SistemaAlquilerContext();

        public AlquilerDao()
        {
            _context = new SistemaAlquilerContext();
        }

        public async Task<List<Alquiler>> GetAllAlquileres()
        {
            return await _context.alquileres.Where(a => a.deletedAt == null).ToListAsync();
        }

        public async Task<Alquiler> CreateAlquiler(Alquiler alquiler)
        {
            _context.alquileres.Add(alquiler);
            await _context.SaveChangesAsync();
            return alquiler;
        }

        public async Task<Alquiler> GetAlquilerById(int id)
        {
            return await _context.alquileres.FindAsync(id);
        }

        public async Task<List<Alquiler>> GetAlquileresByItem(int itemId)
        {
            return await _context.alquileres
                .Where(a => a.item_id == itemId && a.deletedAt == null)
                .ToListAsync();
        }

        public async Task<List<Alquiler>> GetAlquileresByUsuario(int usuarioId)
        {
            return await _context.alquileres
                .Where(a => a.usuario_id == usuarioId && a.deletedAt == null)
                .ToListAsync();
        }

        public async Task SoftDeleteAlquiler(int id)
        {
            var alquiler = await _context.alquileres.FindAsync(id);
            if (alquiler != null)
            {
                alquiler.deletedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Alquiler> UpdateAlquiler(Alquiler alquiler)
        {
            _context.Entry(alquiler).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return alquiler;
        }
    }
}
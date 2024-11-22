using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<Alquiler> GetAllAlquileres()
        {
            return _context.alquileres.Where(a => a.deletedAt == null).ToList();
        }

        public Alquiler CreateAlquiler(Alquiler alquiler)
        {
            if (alquiler == null)
                throw new ArgumentNullException(nameof(alquiler));

            _context.alquileres.Add(alquiler);
            _context.SaveChanges();
            return alquiler;
        }

        public Alquiler GetAlquilerById(int id)
        {
            return _context.alquileres.Find(id);
        }

        public List<Alquiler> GetAlquileresByItem(int itemId)
        {
            return _context.alquileres
                .Where(a => a.itemId == itemId && a.deletedAt == null)
                .ToList();
        }

        public List<Alquiler> GetAlquileresByUsuario(int usuarioId)
        {
            return _context.alquileres
                .Where(a => a.usuarioId == usuarioId && a.deletedAt == null)
                .ToList();
        }

        public void SoftDeleteAlquiler(int id)
        {
            var alquiler = _context.alquileres.Find(id);
            if (alquiler != null)
            {
                alquiler.deletedAt = DateTime.UtcNow;
                _context.SaveChanges();
            }
        }

        public Alquiler UpdateAlquiler(Alquiler alquiler)
        {
            if (alquiler == null)
                throw new ArgumentNullException(nameof(alquiler));

            _context.Entry(alquiler).State = EntityState.Modified;
            _context.SaveChanges();
            return alquiler;
        }
    }
}

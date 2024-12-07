using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SistemaAlquileres.Model.Entities;

namespace SistemaAlquileres.Model.Dao
{
    public class AlquilerDao
    {
        public AlquilerDao() { }

        public void InsertAlquiler(Alquiler alquiler)
        {
            using (var db = new SistemaAlquilerContext())
            {
                db.alquileres.Add(alquiler);
                db.SaveChanges();
            }
        }

        public void UpdateAlquiler(Alquiler alquiler)
        {
            using (var db = new SistemaAlquilerContext())
            {
                db.Update(alquiler);
                db.SaveChanges();
            }
        }

        public void SoftDeleteAlquiler(Alquiler alquiler)
        {
            using (var db = new SistemaAlquilerContext())
            {
                alquiler.deletedAt = DateTime.Now;
                db.Update(alquiler);
                db.SaveChanges();
            }
        }

        public List<Alquiler> LoadAllAlquileres()
        {
            using (var db = new SistemaAlquilerContext())
            {
                return db.alquileres
                    .Where(x => x.deletedAt == null)
                    .Include(x => x.item)
                    .Include(x => x.usuario)
                    .ToList();
            }
        }

        public Alquiler FindAlquilerById(int id)
        {
            using (var db = new SistemaAlquilerContext())
            {
                return db.alquileres
                    .Where(x => x.id == id && x.deletedAt == null)
                    .Include(x => x.item)
                    .Include(x => x.usuario)
                    .FirstOrDefault();
            }
        }

        public List<Alquiler> FindAlquileresByUsuario(int usuarioId)
        {
            using (var db = new SistemaAlquilerContext())
            {
                return db.alquileres
                    .Where(x => x.usuarioId == usuarioId && x.deletedAt == null)
                    .Include(x => x.item)
                    .ToList();
            }
        }

        public List<Alquiler> FindAlquileresByItem(int itemId)
        {
            using (var db = new SistemaAlquilerContext())
            {
                return db.alquileres
                    .Where(x => x.itemId == itemId && x.deletedAt == null)
                    .Include(x => x.usuario)
                    .ToList();
            }
        }
    }
}


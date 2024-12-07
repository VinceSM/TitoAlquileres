using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TitoAlquiler.Model.Entities;

namespace TitoAlquiler.Model.Dao
{
    public class AlquilerDao
    {
        public AlquilerDao() { }

        public void InsertAlquiler(Alquiler alquiler)
        {
            try
            {
                using (var db = new SistemaAlquilerContext())
                {
                    db.Alquileres.Add(alquiler);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting alquiler: {ex.Message}");
                throw;
            }
        }

        public void UpdateAlquiler(Alquiler alquiler)
        {
            try
            {
                using (var db = new SistemaAlquilerContext())
                {
                    db.Update(alquiler);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating alquiler: {ex.Message}");
                throw;
            }
        }

        public void SoftDeleteAlquiler(Alquiler alquiler)
        {
            try
            {
                using (var db = new SistemaAlquilerContext())
                {
                    alquiler.deletedAt = DateTime.Now;
                    db.Update(alquiler);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error soft deleting alquiler: {ex.Message}");
                throw;
            }
        }

        public List<Alquiler> LoadAllAlquileres()
        {
            try
            {
                using (var db = new SistemaAlquilerContext())
                {
                    return db.Alquileres
                        .Where(x => x.deletedAt == null)
                        .Include(x => x.item)
                        .Include(x => x.usuario)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading all alquileres: {ex.Message}");
                throw;
            }
        }

        public Alquiler FindAlquilerById(int id)
        {
            try
            {
                using (var db = new SistemaAlquilerContext())
                {
                    return db.Alquileres
                        .Where(x => x.id == id && x.deletedAt == null)
                        .Include(x => x.item)
                        .Include(x => x.usuario)
                        .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error finding alquiler by id: {ex.Message}");
                throw;
            }
        }

        public List<Alquiler> FindAlquileresByUsuario(int usuarioId)
        {
            try
            {
                using (var db = new SistemaAlquilerContext())
                {
                    return db.Alquileres
                        .Where(x => x.usuarioId == usuarioId && x.deletedAt == null)
                        .Include(x => x.item)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error finding alquileres by usuario: {ex.Message}");
                throw;
            }
        }

        public List<Alquiler> FindAlquileresByItem(int itemId)
        {
            try
            {
                using (var db = new SistemaAlquilerContext())
                {
                    return db.Alquileres
                        .Where(x => x.itemId == itemId && x.deletedAt == null)
                        .Include(x => x.usuario)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error finding alquileres by item: {ex.Message}");
                throw;
            }
        }
    }
}


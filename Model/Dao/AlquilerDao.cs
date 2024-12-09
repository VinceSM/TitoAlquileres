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

        public void InsertAlquiler(Alquileres alquiler)
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

        public void UpdateAlquiler(Alquileres alquiler)
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

        public void SoftDeleteAlquiler(Alquileres alquiler)
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

        public List<Alquileres> LoadAllAlquileres()
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

        public Alquileres FindAlquilerById(int id)
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

        public List<Alquileres> FindAlquileresByUsuario(int usuarioId)
        {
            try
            {
                using (var db = new SistemaAlquilerContext())
                {
                    return db.Alquileres
                        .Where(x => x.UsuarioID == usuarioId && x.deletedAt == null)
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

        public List<Alquileres> FindAlquileresByItem(int itemId)
        {
            try
            {
                using (var db = new SistemaAlquilerContext())
                {
                    return db.Alquileres
                        .Where(x => x.ItemID == itemId && x.deletedAt == null)
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


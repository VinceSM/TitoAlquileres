using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SistemaAlquileres.Model.Entities;

namespace SistemaAlquileres.Model.Dao
{
    public class UsuarioDao
    {
        public UsuarioDao() { }

        public void InsertUsuario(Usuarios usuario)
        {
            try
            {
                using (var db = new SistemaAlquilerContext())
                {
                    db.Usuarios.Add(usuario);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting usuario: {ex.Message}");
                throw;
            }
        }

        public void UpdateUsuario(Usuarios usuario)
        {
            try
            {
                using (var db = new SistemaAlquilerContext())
                {
                    db.Update(usuario);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating usuario: {ex.Message}");
                throw;
            }
        }

        public void SoftDeleteUsuario(Usuarios usuario)
        {
            try
            {
                using (var db = new SistemaAlquilerContext())
                {
                    usuario.deletedAt = DateTime.Now;
                    db.Update(usuario);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error soft deleting usuario: {ex.Message}");
                throw;
            }
        }

        public List<Usuarios> LoadAllUsuarios()
        {
            try
            {
                using (var db = new SistemaAlquilerContext())
                {
                    return db.Usuarios.Where(x => x.deletedAt == null).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading all usuarios: {ex.Message}");
                throw;
            }
        }

        public Usuarios FindUsuarioById(int id)
        {
            try
            {
                using (var db = new SistemaAlquilerContext())
                {
                    return db.Usuarios
                        .Where(x => x.id == id && x.deletedAt == null)
                        .Include(x => x.Alquileres)
                        .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error finding usuario by id: {ex.Message}");
                throw;
            }
        }

        public Usuarios FindUsuarioByDNI(int dni)
        {
            try
            {
                using (var db = new SistemaAlquilerContext())
                {
                    return db.Usuarios
                        .Where(x => x.dni == dni && x.deletedAt == null)
                        .Include(x => x.Alquileres)
                        .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error finding usuario by DNI: {ex.Message}");
                throw;
            }
        }

        public List<Usuarios> SearchUsuarios(string search)
        {
            try
            {
                using (var db = new SistemaAlquilerContext())
                {
                    return db.Usuarios
                        .Where(x => (x.nombre.Contains(search) || x.email.Contains(search)) && x.deletedAt == null)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching usuarios: {ex.Message}");
                throw;
            }
        }
    }
}


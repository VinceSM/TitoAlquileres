using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TitoAlquiler.Model.Entities;

namespace TitoAlquiler.Model.Dao
{
    public class CategoriaDao
    {
        public CategoriaDao() { }

        public void InsertCategoria(Categoria categoria)
        {
            try
            {
                using (var db = new SistemaAlquilerContext())
                {
                    db.Categorias.Add(categoria);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error inserting categoria: {ex.Message}");
                throw; // Re-throw the exception to be handled by the caller
            }
        }

        public void UpdateCategoria(Categoria categoria)
        {
            try
            {
                using (var db = new SistemaAlquilerContext())
                {
                    db.Update(categoria);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating categoria: {ex.Message}");
                throw;
            }
        }

        public void SoftDeleteCategoria(Categoria categoria)
        {
            try
            {
                using (var db = new SistemaAlquilerContext())
                {
                    categoria.deletedAt = DateTime.Now;
                    db.Update(categoria);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error soft deleting categoria: {ex.Message}");
                throw;
            }
        }

        public List<Categoria> LoadAllCategorias()
        {
            try
            {
                using (var db = new SistemaAlquilerContext())
                {
                    return db.Categorias
                        .Where(x => x.deletedAt == null)
                        .Include(x => x.items)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading all categorias: {ex.Message}");
                throw;
            }
        }

        public Categoria FindCategoriaById(int id)
        {
            try
            {
                using (var db = new SistemaAlquilerContext())
                {
                    return db.Categorias
                        .Where(x => x.id == id && x.deletedAt == null)
                        .Include(x => x.items)
                        .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error finding categoria by id: {ex.Message}");
                throw;
            }
        }

        public Categoria FindCategoriaByNombre(string nombre)
        {
            try
            {
                using (var db = new SistemaAlquilerContext())
                {
                    return db.Categorias
                        .Where(x => x.nombre == nombre && x.deletedAt == null)
                        .FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error finding categoria by nombre: {ex.Message}");
                throw;
            }
        }

        public List<Categoria> SearchCategorias(string search)
        {
            try
            {
                using (var db = new SistemaAlquilerContext())
                {
                    return db.Categorias
                        .Where(x => x.nombre.Contains(search) && x.deletedAt == null)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching categorias: {ex.Message}");
                throw;
            }
        }
    }
}


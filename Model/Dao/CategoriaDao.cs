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

        /// <summary>
        /// Inserta una nueva categoría en la base de datos.
        /// </summary>
        /// <param name="categoria">Objeto de tipo <see cref="Categoria"/> que contiene los datos de la categoría a insertar.</param>
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

        /// <summary>
        /// Actualiza una categoría existente en la base de datos.
        /// </summary>
        /// <param name="categoria">Objeto de tipo <see cref="Categoria"/> que contiene los datos actualizados de la categoría.</param>
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

        /// <summary>
        /// Elimina una categoría de manera lógica (soft delete), marcando la fecha de eliminación.
        /// </summary>
        /// <param name="categoria">Objeto de tipo <see cref="Categoria"/> que representa la categoría a eliminar.</param>
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

        /// <summary>
        /// Obtiene todas las categorías que no han sido eliminadas de la base de datos.
        /// </summary>
        /// <returns>Lista de objetos <see cref="Categoria"/> que representan las categorías activas.</returns>
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

        /// <summary>
        /// Busca una categoría por su identificador único.
        /// </summary>
        /// <param name="id">ID de la categoría a buscar.</param>
        /// <returns>Objeto <see cref="Categoria"/> con los detalles de la categoría encontrada, o null si no se encuentra.</returns>
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

        /// <summary>
        /// Busca una categoría por su nombre.
        /// </summary>
        /// <param name="nombre">Nombre de la categoría a buscar.</param>
        /// <returns>Objeto <see cref="Categoria"/> con los detalles de la categoría encontrada, o null si no se encuentra.</returns>
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

        /// <summary>
        /// Busca categorías que contienen el término de búsqueda en su nombre.
        /// </summary>
        /// <param name="search">Término de búsqueda que se debe encontrar en el nombre de las categorías.</param>
        /// <returns>Lista de objetos <see cref="Categoria"/> que coinciden con el término de búsqueda.</returns>
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


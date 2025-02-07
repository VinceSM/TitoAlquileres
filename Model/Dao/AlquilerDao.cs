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

        /// <summary>
        /// Inserta un nuevo alquiler en la base de datos.
        /// </summary>
        /// <param name="alquiler">Objeto de tipo <see cref="Alquileres"/> que contiene los datos del alquiler a insertar.</param>
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

        /// <summary>
        /// Actualiza un alquiler existente en la base de datos.
        /// </summary>
        /// <param name="alquiler">Objeto de tipo <see cref="Alquileres"/> que contiene los datos actualizados del alquiler.</param>
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

        /// <summary>
        /// Elimina un alquiler de manera lógica (soft delete), marcando la fecha de eliminación.
        /// </summary>
        /// <param name="alquiler">Objeto de tipo <see cref="Alquileres"/> que representa el alquiler a eliminar.</param>
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

        /// <summary>
        /// Obtiene todos los alquileres que no han sido eliminados de la base de datos.
        /// </summary>
        /// <returns>Lista de objetos <see cref="Alquileres"/> que representan los alquileres activos.</returns>
        public List<Alquileres> LoadAllAlquileres()
        {
            using (var db = new SistemaAlquilerContext())
            {
                return db.Alquileres
                         .Include(a => a.usuario) // Cargar usuario
                         .Include(a => a.item)    // Cargar ítem asociado
                         .ToList();
            }
        }

        /// <summary>
        /// Busca un alquiler por su identificador único.
        /// </summary>
        /// <param name="id">ID del alquiler a buscar.</param>
        /// <returns>Objeto <see cref="Alquileres"/> con los detalles del alquiler encontrado, o null si no se encuentra.</returns>
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

        /// <summary>
        /// Busca todos los alquileres realizados por un usuario específico.
        /// </summary>
        /// <param name="usuarioId">ID del usuario cuyas rentas se desean consultar.</param>
        /// <returns>Lista de objetos <see cref="Alquileres"/> asociados con el usuario especificado.</returns>
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

        /// <summary>
        /// Busca todos los alquileres de un ítem específico.
        /// </summary>
        /// <param name="itemId">ID del ítem cuya renta se desea consultar.</param>
        /// <returns>Lista de objetos <see cref="Alquileres"/> asociados con el ítem especificado.</returns>
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


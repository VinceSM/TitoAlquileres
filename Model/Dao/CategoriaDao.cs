using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TitoAlquiler.Model.Entities;
using TitoAlquiler.Resources;

namespace TitoAlquiler.Model.Dao
{
    public class CategoriaDao
    {
        public CategoriaDao() { }

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
                MessageShow.MostrarMensajeError($"Error al cargar categorias: {ex.Message}");
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
                MessageShow.MostrarMensajeError($"Error al encontrar categoria by id: {ex.Message}");
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
                MessageShow.MostrarMensajeError($"Error al encontrar categoria by nombre: {ex.Message}");
                throw;
            }
        }
    }
}


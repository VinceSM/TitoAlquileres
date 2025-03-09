using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TitoAlquiler.Model.Entities;

namespace TitoAlquiler.Model.Dao
{
    public class UsuarioDao
    {
        public UsuarioDao() { }

        /// <summary>
        /// Inserta un nuevo usuario en la base de datos.
        /// </summary>
        /// <param name="usuario">Objeto de tipo <see cref="Usuarios"/> que contiene los datos del usuario a insertar.</param>
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
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Actualiza un usuario existente en la base de datos.
        /// </summary>
        /// <param name="usuario">Objeto de tipo <see cref="Usuarios"/> que contiene los datos actualizados del usuario.</param>
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
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Elimina un usuario de manera lógica (soft delete), marcando la fecha de eliminación.
        /// </summary>
        /// <param name="usuario">Objeto de tipo <see cref="Usuarios"/> que representa el usuario a eliminar.</param>
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
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtiene todos los usuarios que no han sido eliminados de la base de datos.
        /// </summary>
        /// <returns>Lista de objetos <see cref="Usuarios"/> que representan los usuarios activos.</returns>
        public List<Usuarios> LoadAllUsuarios()
        {
            try
            {
                using (var db = new SistemaAlquilerContext())
                {
                    return db.Usuarios.Where(x => x.deletedAt == null).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Busca un usuario por su identificador único.
        /// </summary>
        /// <param name="id">ID del usuario a buscar.</param>
        /// <returns>Objeto <see cref="Usuarios"/> con los detalles del usuario encontrado, o null si no se encuentra.</returns>
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
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Compara si existe un usuario con el DNI especificado.
        /// </summary>
        /// <param name="dni">Número de DNI a comparar.</param>
        /// <returns>True si existe un usuario con el DNI proporcionado, false en caso contrario.</returns>
        public bool CompararDNI(int dni)
        {
            try
            {
                using (var db = new SistemaAlquilerContext())
                {
                    return db.Usuarios.Any(u => u.dni == dni);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Compara si existe un usuario con el correo electrónico especificado.
        /// </summary>
        /// <param name="email">Correo electrónico a comparar.</param>
        /// <returns>True si existe un usuario con el correo electrónico proporcionado, false en caso contrario.</returns>
        public bool CompararEmail(string email)
        {
            try
            {
                using (var db = new SistemaAlquilerContext())
                {
                    return db.Usuarios.Any(u => u.email == email);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool getMembresiaUsuario(int usuarioId)
        {
            using (var db = new SistemaAlquilerContext())
            {
                return db.Usuarios
                         .Where(u => u.id == usuarioId)
                         .Select(u => u.membresiaPremium)
                         .FirstOrDefault();
            }
        }

    }
}


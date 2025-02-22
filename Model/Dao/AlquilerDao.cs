using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TitoAlquiler.Controller;
using TitoAlquiler.Model.Entities;
using TitoAlquiler.Model.Interfaces;
using TitoAlquiler.Model.Strategy;
using System.Windows.Forms;

namespace TitoAlquiler.Model.Dao
{
    public class AlquilerDao
    {
        private UsuarioController usuarioController = UsuarioController.getInstance();
        private IEstrategiaPrecio estrategias;

        public AlquilerDao() { }

        /// <summary>
        /// Inserta un nuevo alquiler en la base de datos.
        /// </summary>
        /// <param name="alquiler">Objeto de tipo <see cref="Alquileres"/> que contiene los datos del alquiler a insertar.</param>
        public void InsertAlquiler(Alquileres alquiler)
        {
            using (var db = new SistemaAlquilerContext())
            {
                try
                {
                    // Asegurarse de que el ítem esté cargado
                    if (alquiler.item == null)
                    {
                        alquiler.item = db.Items.Find(alquiler.ItemID);
                        if (alquiler.item == null)
                        {
                            throw new Exception("No se pudo encontrar el ítem asociado al alquiler.");
                        }
                    }

                    // Determinar estrategia
                    bool tieneMembresia = usuarioController.getMembresiaUsuario(alquiler.UsuarioID);

                    if (tieneMembresia)
                    {
                        alquiler.tipoEstrategia = "EstrategiaMembresia";
                        estrategias = new EstrategiaMembresia();
                    }
                    else if (AplicarEstrategiaEstacional())
                    {
                        alquiler.tipoEstrategia = "EstrategiaEstacion";
                        estrategias = new EstrategiaEstacion(ObtenerEstacionActual());
                    }
                    else
                    {
                        alquiler.tipoEstrategia = "EstrategiaNormal";
                        estrategias = new EstrategiaNormal();
                    }

                    // Calcular el precio del alquiler
                    int diasAlquiler = (int)(alquiler.fechaFin - alquiler.fechaInicio).TotalDays;

                    // Usar precioBase en lugar de tarifaDia
                    if (alquiler.item.tarifaDia <= 0)
                    {
                        throw new Exception("El precio base del ítem no es válido.");
                    }

                    alquiler.precioTotal = estrategias.CalcularPrecioAlquiler(alquiler.item.tarifaDia, diasAlquiler);

                    db.Alquileres.Add(alquiler);
                    int cambios = db.SaveChanges();
                    MessageBox.Show($"Alquiler guardado exitosamente. Precio total: {alquiler.precioTotal:C}. Cambios: {cambios}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar el alquiler: {ex.Message}\n{ex.InnerException?.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        public static bool AplicarEstrategiaEstacional()
        {
            var mes = DateTime.Now.Month;

            return mes is >= 12 or <= 2  // Invierno (Diciembre, Enero, Febrero)
                || mes is >= 6 and <= 8; // Verano (Junio, Julio, Agosto)
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

        private Estacion ObtenerEstacionActual()
        {
            int mes = DateTime.Now.Month;
            return mes switch
            {
                >= 3 and <= 5 => Estacion.Primavera,
                >= 6 and <= 8 => Estacion.Verano,
                >= 9 and <= 11 => Estacion.Otoño,
                _ => Estacion.Invierno
            };
        }
        /// <summary>
        /// Obtiene un alquiler activo por el nombre del ítem y el nombre del usuario.
        /// </summary>
        /// <param name="nombreItem">Nombre del ítem alquilado.</param>
        /// <param name="nombreUsuario">Nombre del usuario que realizó el alquiler.</param>
        /// <returns>Objeto <see cref="Alquileres"/> si se encuentra el alquiler; de lo contrario, null.</returns>
        public Alquileres ObtenerAlquilerPorItemYUsuario(string nombreItem, string nombreUsuario)
        {
            try
            {
                using (var db = new SistemaAlquilerContext())
                {
                    return db.Alquileres
                             .Include(a => a.item)
                             .Include(a => a.usuario)
                             .FirstOrDefault(a => a.item.nombreItem == nombreItem
                                                  && a.usuario.nombre == nombreUsuario
                                                  && a.deletedAt == null);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el alquiler: {ex.Message}");
                throw;
            }
        }

    }
}


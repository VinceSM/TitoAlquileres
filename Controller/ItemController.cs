// ItemController.cs
using System;
using System.Collections.Generic;
using TitoAlquiler.Model.Dao;
using TitoAlquiler.Model.Factory;
using System.Windows.Forms;
using TitoAlquiler.Model.Entities;
using TitoAlquiler.Model.Interfaces;
using TitoAlquiler.Controller.CategoriasController;
using TitoAlquiler.Model.Entities.Categorias;

namespace TitoAlquiler.Controller
{
    public class ItemController
    {
        private readonly ItemDao _itemDao;

        #region Singleton
        private static ItemController? _instance;
        public static ItemController Instance => _instance ??= new ItemController();

        private ItemController()
        {
            _itemDao = new ItemDao();
        }
        #endregion

        // Modificación en ItemController.cs
        public void CrearItem(IItemFactory factory, string nombre, string marca, string modelo, double tarifaDia, params object[] adicionales)
        {
            using var db = new SistemaAlquilerContext();
            using var transaction = db.Database.BeginTransaction();

            try
            {
                var (item, categoria) = factory.CrearAlquilable(nombre, marca, modelo, tarifaDia, adicionales);

                // Primero insertamos el Item base
                db.Items.Add(item);
                db.SaveChanges(); // Esto generará el ID del item

                // Ahora manejamos la categoría específica
                switch (categoria)
                {
                    case Transporte transporte:
                        transporte.itemId = item.id; // Asignamos el ID generado
                        db.Transportes.Add(transporte);
                        break;
                    case Electrodomestico electrodomestico:
                        electrodomestico.itemId = item.id;
                        db.Electrodomesticos.Add(electrodomestico);
                        break;
                    case Inmueble inmueble:
                        inmueble.itemId = item.id;
                        db.Inmuebles.Add(inmueble);
                        break;
                    case Electronica electronica:
                        electronica.itemId = item.id;
                        db.Electronicas.Add(electronica);
                        break;
                    case Indumentaria indumentaria:
                        indumentaria.itemId = item.id;
                        db.Indumentarias.Add(indumentaria);
                        break;
                    default:
                        throw new ArgumentException("Categoría no reconocida.");
                }

                db.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception($"Error al crear el item: {ex.Message}", ex);
            }
        }


        public IItemFactory ObtenerFactory(string categoria)
        {
            return categoria switch
            {
                "Transporte" => new TransporteFactory(),
                "Electrodomestico" => new ElectrodomesticoFactory(),
                "Electronica" => new ElectronicaFactory(),
                "Inmueble" => new InmuebleFactory(),
                "Indumentaria" => new IndumentariaFactory(),
                _ => throw new ArgumentException("Categoría no válida", nameof(categoria))
            };
        }


        /// <summary>
        /// Actualiza un ítem existente y su categoría.
        /// </summary>
        public void ActualizarItem(ItemAlquilable item, object categoria)
        {
            try
            {
                _itemDao.UpdateItem(item, categoria);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el item: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        /// <summary>
        /// Elimina lógicamente un ítem por su ID.
        /// </summary>
        public void EliminarItem(int itemId)
        {
            try
            {
                _itemDao.SoftDeleteItem(itemId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el item: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        /// <summary>
        /// Obtiene un ítem y su categoría por ID.
        /// </summary>
        public (ItemAlquilable item, object categoria) ObtenerItemPorId(int id)
        {
            try
            {
                return _itemDao.FindItemById(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el item: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        /// <summary>
        /// Obtiene todos los ítems activos con sus categorías.
        /// </summary>
        public List<(ItemAlquilable item, object categoria)> ObtenerTodosLosItems()
        {
            try
            {
                return _itemDao.LoadAllItems();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los items: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        /// <summary>
        /// Obtiene ítems por categoría.
        /// </summary>
        public List<ItemAlquilable> ObtenerItemsPorCategoria(int categoriaId)
        {
            return _itemDao.FindItemsByCategoria(categoriaId);
        }

        /// <summary>
        /// Busca ítems por término de búsqueda.
        /// </summary>
        public List<(ItemAlquilable item, object categoria)> BuscarItems(string searchTerm)
        {
            try
            {
                return _itemDao.SearchItems(searchTerm);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar items: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        /// <summary>
        /// Obtiene la fábrica correspondiente según la categoría.
        /// </summary>
        public IItemFactory ObtenerFactory(int categoriaId)
        {
            return categoriaId switch
            {
                1 => new TransporteFactory(),
                2 => new ElectrodomesticoFactory(),
                3 => new ElectronicaFactory(),
                4 => new InmuebleFactory(),
                5 => new IndumentariaFactory(),
                _ => throw new ArgumentException("Categoría no válida")
            };
        }

        /// <summary>
        /// Valida si un ítem puede ser eliminado (no tiene alquileres activos).
        /// </summary>
        public bool PuedeEliminarItem(int itemId)
        {
            try
            {
                var (item, _) = _itemDao.FindItemById(itemId);
                return item?.Alquileres == null || item.Alquileres.Count == 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al validar el item: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        /// <summary>
        /// Actualiza la tarifa de un ítem existente en la base de datos.
        /// </summary>
        /// <param name="itemId">ID del ítem a actualizar.</param>
        /// <param name="nuevaTarifa">Nueva tarifa para el ítem.</param>
        /// <exception cref="ArgumentException">Se lanza cuando el itemId no existe o la tarifa es inválida.</exception>
        /// <exception cref="InvalidOperationException">Se lanza cuando hay un error al actualizar el item.</exception>
        public bool ActualizarTarifaItem(int itemId, double nuevaTarifa)
        {
            try
            {
                // Validar la nueva tarifa
                if (nuevaTarifa <= 0)
                {
                    throw new ArgumentException("La tarifa debe ser mayor que cero.");
                }

                // Obtener el item y su categoría
                var (item, categoria) = _itemDao.FindItemById(itemId);

                if (item == null)
                {
                    throw new ArgumentException($"No se encontró el item con ID {itemId}.");
                }

                // Verificar si tiene alquileres activos (opcional, según requerimientos)
                if (item.Alquileres?.Any(a => a.deletedAt == null && a.fechaFin > DateTime.Now) == true)
                {
                    // Podrías lanzar una excepción aquí si no se permite actualizar items con alquileres activos
                    // O simplemente registrar una advertencia en el log
                    Console.WriteLine($"Advertencia: El item {itemId} tiene alquileres activos al actualizar su tarifa.");
                }

                // Actualizar la tarifa
                item.tarifaDia = nuevaTarifa;

                // Actualizar en la base de datos
                _itemDao.UpdateItem(item, categoria);

                return true;
            }
            catch (ArgumentException)
            {
                // Relanzar excepciones de validación
                throw;
            }
            catch (Exception ex)
            {
                // Envolver otras excepciones en una InvalidOperationException
                throw new InvalidOperationException($"Error al actualizar la tarifa del item: {ex.Message}", ex);
            }
        }
    }
}
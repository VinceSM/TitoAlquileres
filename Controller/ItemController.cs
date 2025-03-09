// ItemController.cs
using System;
using System.Collections.Generic;
using TitoAlquiler.Model.Dao;
using TitoAlquiler.Model.Factory;
using System.Windows.Forms;
using TitoAlquiler.Model.Entities;
using TitoAlquiler.Model.Interfaces;
using TitoAlquiler.Model.Entities.Categorias;
using TitoAlquiler.Resources;
using Microsoft.Data.SqlClient;

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

        #region Crear Item
        /// <summary>
        /// Crea un nuevo ítem alquilable utilizando el patrón Factory.
        /// </summary>
        /// <param name="factory">Fábrica específica para el tipo de ítem a crear.</param>
        /// <param name="nombre">Nombre del ítem.</param>
        /// <param name="marca">Marca del ítem.</param>
        /// <param name="modelo">Modelo del ítem.</param>
        /// <param name="tarifaDia">Tarifa diaria de alquiler del ítem.</param>
        /// <param name="adicionales">Parámetros adicionales específicos según el tipo de ítem.</param>
        public void CrearItem(IItemFactory factory, string nombre, string marca, string modelo, double tarifaDia, params object[] adicionales)
        {
            try
            {
                _itemDao.InsertItem(factory, nombre, marca, modelo, tarifaDia, adicionales);
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error al crear el item: {ex.Message}", ex);
            }
        }
        #endregion

        #region Actualizar Item
        /// <summary>
        /// Actualiza un ítem existente y su categoría.
        /// </summary>
        /// <param name="item">Objeto de tipo ItemAlquilable con los datos actualizados del ítem.</param>
        /// <param name="categoria">Objeto de categoría específica con los datos actualizados.</param>
        /// <exception cref="Exception">Se lanza cuando ocurre un error durante la actualización.</exception>
        public void ActualizarItem(ItemAlquilable item, object categoria)
        {
            try
            {
                _itemDao.UpdateItem(item, categoria);
            }
            catch (Exception ex)
            {
                MessageShow.MostrarMensajeError($"Error al actualizar el item: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Actualiza la tarifa de un ítem existente en la base de datos.
        /// </summary>
        /// <param name="itemId">ID del ítem a actualizar.</param>
        /// <param name="nuevaTarifa">Nueva tarifa para el ítem.</param>
        /// <returns>True si la actualización fue exitosa, de lo contrario False.</returns>
        /// <exception cref="ArgumentException">Se lanza cuando el itemId no existe o la tarifa es inválida.</exception>
        /// <exception cref="InvalidOperationException">Se lanza cuando hay un error al actualizar el item.</exception>
        public bool ActualizarTarifaItem(int itemId, double nuevaTarifa)
        {
            try
            {
                ValidarTarifa(nuevaTarifa);

                var (item, categoria) = ObtenerItemPorId(itemId);

                item.tarifaDia = nuevaTarifa;

                _itemDao.UpdateItem(item, categoria);

                return true;
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error al actualizar la tarifa del item: {ex.Message}", ex);
            }
        }

        private void ValidarTarifa(double tarifa)
        {
            if (tarifa <= 0)
            {
                throw new ArgumentException("La tarifa debe ser mayor que cero.");
            }
        }
        #endregion

        #region Obtener Items
        /// <summary>
        /// Obtiene la fábrica correspondiente según el nombre de la categoría.
        /// </summary>
        /// <param name="categoria">Nombre de la categoría para la cual se requiere la fábrica.</param>
        /// <returns>Instancia de la fábrica específica para la categoría solicitada.</returns>
        /// <exception cref="ArgumentException">Se lanza cuando la categoría no es válida.</exception>
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
        /// Obtiene un ítem y su categoría por ID.
        /// </summary>
        /// <param name="id">ID del ítem a obtener.</param>
        /// <returns>Tupla que contiene el ítem y su categoría específica.</returns>
        /// <exception cref="Exception">Se lanza cuando ocurre un error durante la consulta.</exception>
        public (ItemAlquilable item, object categoria) ObtenerItemPorId(int id)
        {
            try
            {
                return _itemDao.FindItemById(id);
            }
            catch (Exception ex)
            {
                MessageShow.MostrarMensajeError($"Error al obtener el item: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene todos los ítems activos con sus categorías.
        /// </summary>
        /// <returns>Lista de tuplas que contienen los ítems y sus categorías específicas.</returns>
        /// <exception cref="Exception">Se lanza cuando ocurre un error durante la consulta.</exception>
        public List<(ItemAlquilable item, object categoria)> ObtenerTodosLosItems()
        {
            try
            {
                return _itemDao.LoadAllItems();
            }
            catch (Exception ex)
            {
                MessageShow.MostrarMensajeError($"Error al obtener los items: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene ítems por categoría.
        /// </summary>
        /// <param name="categoriaId">ID de la categoría para filtrar los ítems.</param>
        /// <returns>Lista de ítems que pertenecen a la categoría especificada.</returns>
        public List<ItemAlquilable> ObtenerItemsPorCategoria(int categoriaId)
        {
            return _itemDao.FindItemsByCategoria(categoriaId);
        }

        /// <summary>
        /// Verifica si el item tiene alquileres activos.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool TieneAlquileresActivos(ItemAlquilable item)
        {
            return _itemDao.TieneAlquileresActivos(item);
        }

        #endregion

        #region Eliminar Item
        /// <summary>
        /// Elimina lógicamente un ítem por su ID.
        /// </summary>
        /// <param name="itemId">ID del ítem a eliminar.</param>
        /// <exception cref="Exception">Se lanza cuando ocurre un error durante la eliminación.</exception>
        public void EliminarItem(int itemId)
        {
            try
            {
                _itemDao.SoftDeleteItem(itemId);
            }
            catch (Exception ex)
            {
                MessageShow.MostrarMensajeError($"Error al eliminar el item: {ex.Message}");
                throw;
            }
        }
        #endregion
    }
}
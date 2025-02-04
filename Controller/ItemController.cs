using TitoAlquiler.Model.Dao;
using System;
using System.Collections.Generic;
using TitoAlquiler.Model.Entities;
using TitoAlquiler.Model.Factory;

namespace TitoAlquiler.Controller
{
    public class ItemController
    {
        ItemDao _itemDao = new ItemDao();

        #region Singletone

        private static ItemController? Instance;

        private ItemController() { }

        public static ItemController getInstance()
        {
            if (Instance == null)
            {
                Instance = new ItemController();
            }
            return Instance;
        }
        #endregion

        /// <summary>
        /// Crea un nuevo ítem en la base de datos.
        /// </summary>
        /// <param name="item">Objeto de tipo Item que contiene la información del ítem a crear.</param>
        public void CrearItem(ItemAlquilable item)
        {
            _itemDao.InsertItem(item);
        }

        /// <summary>
        /// Actualiza un ítem existente en la base de datos.
        /// </summary>
        /// <param name="item">Objeto de tipo Item con los datos actualizados del ítem.</param>
        public void ActualizarItem(ItemAlquilable item)
        {
            _itemDao.UpdateItem(item);
        }

        /// <summary>
        /// Elimina un ítem de manera lógica (soft delete).
        /// </summary>
        /// <param name="itemId">ID del ítem que se va a eliminar.</param>
        /// <returns>True si el ítem fue eliminado con éxito, false en caso contrario.</returns>
        public bool EliminarItem(int itemId)
        {
            try
            {
                var item = _itemDao.FindItemById(itemId);
                if (item != null)
                {
                    _itemDao.SoftDeleteItem(item);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Obtiene todos los ítems registrados en la base de datos.
        /// </summary>
        /// <returns>Lista de objetos Item.</returns>
        public List<ItemAlquilable> ObtenerTodosLosItems()
        {
            return _itemDao.LoadAllItems();
        }

        /// <summary>
        /// Obtiene un ítem por su identificador único.
        /// </summary>
        /// <param name="id">ID del ítem a obtener.</param>
        /// <returns>Objeto Item con los detalles del ítem solicitado.</returns>
        public ItemAlquilable ObtenerItemPorId(int id)
        {
            return _itemDao.FindItemById(id);
        }

        /// <summary>
        /// Obtiene una lista de ítems que pertenecen a una categoría específica.
        /// </summary>
        /// <param name="categoriaId">ID de la categoría a la que pertenecen los ítems.</param>
        /// <returns>Lista de objetos Item pertenecientes a la categoría especificada.</returns>
        public List<ItemAlquilable> ObtenerItemsPorCategoria(int categoriaId)
        {
            return _itemDao.FindItemsByCategoria(categoriaId);
        }

        /// <summary>
        /// Busca ítems que coincidan con el término de búsqueda proporcionado.
        /// </summary>
        /// <param name="busqueda">Cadena de texto para realizar la búsqueda de ítems.</param>
        /// <returns>Lista de objetos Item que coinciden con el término de búsqueda.</returns>
        public List<ItemAlquilable> BuscarItems(string busqueda)
        {
            return _itemDao.SearchItems(busqueda);
        }

        /// <summary>
        /// Obtiene la fábrica de ítems correspondiente a una categoría específica.
        /// </summary>
        /// <param name="categoriaId">El ID de la categoría para la cual se requiere la fábrica.</param>
        /// <returns>Una instancia de FabricaItems correspondiente a la categoría especificada.</returns>
        /// <exception cref="ArgumentException">Se lanza cuando se proporciona un ID de categoría no válido.</exception>
        public AlquilerFactory ObtenerFabricaSegunCategoria(int categoriaId)
        {
            return categoriaId switch
            {
                1 => new TransporteFactory(),
                2 => new ElectrodomesticoFactory(),
                3 => new ElectronicaFactory(),
                4 => new InmuebleFactory(),
                _ => throw new ArgumentException("Categoría no válida")
            };
        }

        /// <summary>
        /// Actualiza la tarifa de un ítem existente en la base de datos.
        /// </summary>
        /// <param name="itemId">ID del ítem a actualizar.</param>
        /// <param name="nuevaTarifa">Nueva tarifa para el ítem.</param>
        /// <returns>True si la actualización fue exitosa, false en caso contrario.</returns>
        public bool ActualizarTarifaItem(int itemId, double nuevaTarifa)
        {
            try
            {
                var item = _itemDao.FindItemById(itemId);
                if (item != null)
                {
                    item.tarifaDia = nuevaTarifa;
                    _itemDao.UpdateItem(item);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}


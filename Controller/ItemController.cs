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
        public void CrearItem(Item item)
        {
            _itemDao.InsertItem(item);
        }

        /// <summary>
        /// Actualiza un ítem existente en la base de datos.
        /// </summary>
        /// <param name="item">Objeto de tipo Item con los datos actualizados del ítem.</param>
        public void ActualizarItem(Item item)
        {
            _itemDao.UpdateItem(item);
        }

        /// <summary>
        /// Elimina un ítem de manera lógica (soft delete).
        /// </summary>
        /// <param name="item">Objeto de tipo Item que representa el ítem a eliminar.</param>
        public void EliminarItem(Item item)
        {
            _itemDao.SoftDeleteItem(item);
        }

        /// <summary>
        /// Obtiene todos los ítems registrados en la base de datos.
        /// </summary>
        /// <returns>Lista de objetos Item.</returns>
        public List<Item> ObtenerTodosLosItems()
        {
            return _itemDao.LoadAllItems();
        }

        /// <summary>
        /// Obtiene un ítem por su identificador único.
        /// </summary>
        /// <param name="id">ID del ítem a obtener.</param>
        /// <returns>Objeto Item con los detalles del ítem solicitado.</returns>
        public Item ObtenerItemPorId(int id)
        {
            return _itemDao.FindItemById(id);
        }

        /// <summary>
        /// Obtiene una lista de ítems que pertenecen a una categoría específica.
        /// </summary>
        /// <param name="categoriaId">ID de la categoría a la que pertenecen los ítems.</param>
        /// <returns>Lista de objetos Item pertenecientes a la categoría especificada.</returns>
        public List<Item> ObtenerItemsPorCategoria(int categoriaId)
        {
            return _itemDao.FindItemsByCategoria(categoriaId);
        }

        /// <summary>
        /// Busca ítems que coincidan con el término de búsqueda proporcionado.
        /// </summary>
        /// <param name="busqueda">Cadena de texto para realizar la búsqueda de ítems.</param>
        /// <returns>Lista de objetos Item que coinciden con el término de búsqueda.</returns>
        public List<Item> BuscarItems(string busqueda)
        {
            return _itemDao.SearchItems(busqueda);
        }

        public FabricaItems ObtenerFabricaSegunCategoria(int categoriaId)
        {
            return categoriaId switch
            {
                1 => new FabricaTransporte(),
                2 => new FabricaElectrodomesticos(),
                3 => new FabricaElectronica(),
                4 => new FabricaInmuebles(),
                _ => throw new ArgumentException("Categoría no válida")
            };
        }
    }
}


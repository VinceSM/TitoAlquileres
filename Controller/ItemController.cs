using SistemaAlquileres.Controllers;
using SistemaAlquileres.Model.Dao;
using System;
using System.Collections.Generic;
using TitoAlquiler.Model.Dao;
using TitoAlquiler.Model.Entities;

namespace TitoAlquiler.Controllers
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

        public void CrearItem(Item item)
        {
            _itemDao.InsertItem(item);
        }

        public void ActualizarItem(Item item)
        {
            _itemDao.UpdateItem(item);
        }

        public void EliminarItem(Item item)
        {
            _itemDao.SoftDeleteItem(item);
        }

        public List<Item> ObtenerTodosLosItems()
        {
            return _itemDao.LoadAllItems();
        }

        public Item ObtenerItemPorId(int id)
        {
            return _itemDao.FindItemById(id);
        }

        public List<Item> ObtenerItemsPorCategoria(int categoriaId)
        {
            return _itemDao.FindItemsByCategoria(categoriaId);
        }

        public List<Item> BuscarItems(string busqueda)
        {
            return _itemDao.SearchItems(busqueda);
        }
    }
}


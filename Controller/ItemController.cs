using System;
using System.Collections.Generic;
using TitoAlquiler.Model.Dao;
using TitoAlquiler.Model.Entities;

namespace TitoAlquiler.Controllers
{
    public class ItemController
    {
        private ItemDao _itemDao;

        public ItemController()
        {
            _itemDao = new ItemDao();
        }

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


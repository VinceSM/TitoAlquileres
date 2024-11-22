using SistemaAlquileres.Model.Dao;
using System;
using System.Collections.Generic;
using TitoAlquiler.Model.Entities;
//using TitoAlquiler.Model.Entities.Item;

namespace SistemaAlquileres.Controller
{
    internal class ItemController
    {
        // Instanciamos el DAO de Item
        private ItemDao itemDao = new ItemDao();

        #region Singleton
        private static ItemController Instance;

        private ItemController() { }

        public static ItemController GetInstance()
        {
            if (Instance == null)
            {
                Instance = new ItemController();
            }
            return Instance;
        }
        #endregion

        // Método para cargar todos los items
        public List<Item> GetItems()
        {
            return itemDao.GetAllItems();
        }

        public Item GetItemById(int id)
        {
            return itemDao.GetItemById(id);
        }

        public List<Item> GetItemsByName(string nombre)
        {
            if (string.IsNullOrEmpty(nombre)) throw new ArgumentException("Nombre cannot be null or empty", nameof(nombre));
            return itemDao.GetItemsByName(nombre);
        }

        public List<Item> GetItemsByMarca(string marca)
        {
            if (string.IsNullOrEmpty(marca)) throw new ArgumentException("Marca cannot be null or empty", nameof(marca));
            return itemDao.GetItemsByMarca(marca);
        }

        public List<Item> GetItemsByModelo(string modelo)
        {
            if (string.IsNullOrEmpty(modelo)) throw new ArgumentException("Modelo cannot be null or empty", nameof(modelo));
            return itemDao.GetItemsByModelo(modelo);
        }

        public Item CreateItem(Item item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            return itemDao.CreateItem(item);
        }

        public Item UpdateItem(Item item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            return itemDao.UpdateItem(item);
        }

        public void DeleteItem(int id)
        {
            itemDao.DeleteItem(id);
        }
    }
}

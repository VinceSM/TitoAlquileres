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
        public List<Item> LoadItems()
        {
            return itemDao.GetAllItems();
        }

        // Método para obtener un item por su ID
        public Item GetItemById(int id)
        {
            return itemDao.GetItemById(id);
        }

        // Método para obtener items por nombre
        public List<Item> GetItemsByName(string nombre)
        {
            return itemDao.GetItemsByName(nombre);
        }

        // Método para obtener items por marca
        public List<Item> GetItemsByMarca(string marca)
        {
            return itemDao.GetItemsByMarca(marca);
        }

        // Método para obtener items por modelo
        public List<Item> GetItemsByModelo(string modelo)
        {
            return itemDao.GetItemsByModelo(modelo);
        }

        // Método para crear un nuevo item
        public Item CreateItem(Item item)
        {
            return itemDao.CreateItem(item);
        }

        // Método para actualizar un item
        public Item UpdateItem(Item item)
        {
            return itemDao.UpdateItem(item);
        }

        // Método para eliminar un item
        public void DeleteItem(int id)
        {
            itemDao.DeleteItem(id);
        }
    }
}

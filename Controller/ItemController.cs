using SistemaAlquileres.Model.Dao;
using SistemaAlquileres.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAlquileres.Controller
{
    internal class ItemController
    {
        // Instanciamos el DAO de Item
        private ItemDao itemDao = new ItemDao();

        #region Singleton
        private static ItemController Instance;

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

        // Método para cargar todos los items
        public async Task<List<Item>> loadItems()
        {
            return await itemDao.GetAllItems();
        }

        // Método para obtener un item por su ID
        public async Task<Item> getItemById(int id)
        {
            return await itemDao.GetItemById(id);
        }

        // Método para obtener items por nombre
        public async Task<List<Item>> getItemByName(string nombre)
        {
            return await itemDao.GetItemsByName(nombre);
        }

        // Método para obtener items por marca
        public async Task<List<Item>> getItemByMarca(string marca)
        {
            return await itemDao.GetItemsByMarca(marca);
        }

        // Método para obtener items por modelo
        public async Task<List<Item>> getItemByModelo(string modelo)
        {
            return await itemDao.GetItemsByModelo(modelo);
        }

        // Método para obtener items por categoría
        public async Task<List<Item>> getItemByCategoria(string categoria)
        {
            return await itemDao.GetItemsByCategoria(categoria);
        }

        // Método para crear un nuevo item
        public async Task<Item> createItem(Item item)
        {
            return await itemDao.CreateItem(item);
        }

        // Método para actualizar un item
        public async Task<Item> updateItem(Item item)
        {
            return await itemDao.UpdateItem(item);
        }

        // Método para eliminar un item
        public async Task deleteItem(int id)
        {
            await itemDao.DeleteItem(id);
        }
    }
}

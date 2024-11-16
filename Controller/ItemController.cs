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
        ItemDao itemDao = new ItemDao();

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

        public List<Item> loadItems()
        {
            return null;
        }

        public Item getItemById(int id)
        {
            return null;
        }

        public Item getItemByName(string nombre)
        {
            return null;
        }

        public Item getItemByMarca(string marca)
        {
            return null;
        }
        public Item getItemByModelo(string modelo)
        {
            return null;
        }
        public Item getItemByCategoria(string categoria)
        {
            return null;
        }
    }
}

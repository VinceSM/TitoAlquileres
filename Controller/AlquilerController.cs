using System;
using SistemaAlquileres.Model.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaAlquileres.Model.Dao;

namespace SistemaAlquileres.Controller
{
    internal class AlquilerController
    {
        AlquilerDao alquilerDao = new AlquilerDao();

        #region Singleton
        private static AlquilerController Instance;

        private AlquilerController() { }

        public static AlquilerController getInstance()
        {
            if (Instance == null)
            {
                Instance = new AlquilerController();
            }
            return Instance;
        }
        #endregion

        public List<Alquiler> loadAlquileres()
        {
            return null;
        }

        public Alquiler getAlquilerById(int id)
        {
            return null;
        }

        public Alquiler getAlquilerByItem(Item item)
        {
            return null;
        }

        public Alquiler getAlquilerByUsuario(Usuario usuario)
        {
            return null;
        }

        public void softDeleteAlquiler()
        {
            
        }

        
    }
}

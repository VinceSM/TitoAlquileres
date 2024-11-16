using SistemaAlquileres.Model.Dao;
using SistemaAlquileres.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAlquileres.Controller
{
    internal class UsuarioController
    {
        UsuarioDao usuarioDao = new UsuarioDao();

        #region Singleton
        private static UsuarioController Instance;

        private UsuarioController() { }

        public static UsuarioController getInstance()
        {
            if (Instance == null)
            {
                Instance = new UsuarioController();
            }
            return Instance;
        }
        #endregion

        public List<Usuario> loadUsuarios()
        {
            return null;
        }
        public Usuario getUsuarioById(int id)
        {
            return null;
        }

        public Usuario getUsuarioByName(string nombre)
        {
            return null;
        }

        public Usuario getUsuarioByDni(int dni)
        {
            return null;
        }

        public Usuario getUsuarioByEmail(string email)
        {
            return null;
        }

        public Usuario getUsuarioByMembresia(string tipo_membresia)
        {
            return null;
        }

        public void softDeleteUser()
        {

        }
    }
}

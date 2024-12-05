using SistemaAlquileres.Controller;
using SistemaAlquileres.Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Dao;
using TitoAlquiler.Model.Entities;

namespace TitoAlquiler.Controller
{
    public class CategoriaController
    {
        private CategoriaDao _categoriaDao = new CategoriaDao();

        #region Singleton
        private static CategoriaController? _instance;
        private static readonly object _lock = new object();

        private CategoriaController()
        {
            _categoriaDao = new CategoriaDao();
        }

        public static CategoriaController GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new CategoriaController();
                    }
                }
            }
            return _instance;
        }
        #endregion

        public List<Categoria> GetCategorias()
        {
            return _categoriaDao.GetCategorias();
        }

        public Categoria GetCategoriaById(int id)
        {
            return _categoriaDao.GetCategoriaById(id);
        }

        public Categoria GetCategoriaByName(string nombre)
        {
            return _categoriaDao.GetCategoriaByName(nombre);
        }
    }
}

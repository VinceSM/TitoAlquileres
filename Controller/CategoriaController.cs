using System;
using System.Collections.Generic;
using TitoAlquiler.Model.Dao;
using TitoAlquiler.Model.Entities;

namespace TitoAlquiler.Controllers
{
    public class CategoriaController
    {
        private CategoriaDao _categoriaDao;

        public CategoriaController()
        {
            _categoriaDao = new CategoriaDao();
        }

        public void CrearCategoria(Categoria categoria)
        {
            _categoriaDao.InsertCategoria(categoria);
        }

        public void ActualizarCategoria(Categoria categoria)
        {
            _categoriaDao.UpdateCategoria(categoria);
        }

        public void EliminarCategoria(Categoria categoria)
        {
            _categoriaDao.SoftDeleteCategoria(categoria);
        }

        public List<Categoria> ObtenerTodasLasCategorias()
        {
            return _categoriaDao.LoadAllCategorias();
        }

        public Categoria ObtenerCategoriaPorId(int id)
        {
            return _categoriaDao.FindCategoriaById(id);
        }

        public Categoria ObtenerCategoriaPorNombre(string nombre)
        {
            return _categoriaDao.FindCategoriaByNombre(nombre);
        }

        public List<Categoria> BuscarCategorias(string busqueda)
        {
            return _categoriaDao.SearchCategorias(busqueda);
        }
    }
}


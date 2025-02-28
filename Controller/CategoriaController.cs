using TitoAlquiler.Model.Dao;
using System;
using System.Collections.Generic;
using TitoAlquiler.Model.Entities;

namespace TitoAlquiler.Controller
{
    public class CategoriaController
    {
        CategoriaDao _categoriaDao = new CategoriaDao();

        #region Singletone

        private static CategoriaController? Instance;

        private CategoriaController() { }

        public static CategoriaController getInstance()
        {
            if (Instance == null)
            {
                Instance = new CategoriaController();
            }
            return Instance;
        }
        #endregion


        /// <summary>
        /// Obtiene la instancia única del controlador de categorías.
        /// </summary>
        /// <returns>Instancia única de CategoriaController.</returns>
        public void CrearCategoria(Categoria categoria)
        {
            _categoriaDao.InsertCategoria(categoria);
        }

        /// <summary>
        /// Crea una nueva categoría en la base de datos.
        /// </summary>
        /// <param name="categoria">Objeto de tipo Categoria que contiene la información de la categoría a crear.</param>
        public void ActualizarCategoria(Categoria categoria)
        {
            _categoriaDao.UpdateCategoria(categoria);
        }

        /// <summary>
        /// Actualiza una categoría existente en la base de datos.
        /// </summary>
        /// <param name="categoria">Objeto de tipo Categoria con los datos actualizados de la categoría.</param>
        public void EliminarCategoria(Categoria categoria)
        {
            _categoriaDao.SoftDeleteCategoria(categoria);
        }

        /// <summary>
        /// Obtiene una categoría por su identificador único.
        /// </summary>
        /// <param name="id">ID de la categoría a obtener.</param>
        /// <returns>Objeto Categoria con los detalles de la categoría solicitada.</returns>
        public Categoria ObtenerCategoriaPorId(int id)
        {
            return _categoriaDao.FindCategoriaById(id);
        }

        /// <summary>
        /// Obtiene una categoría por su nombre.
        /// </summary>
        /// <param name="nombre">Nombre de la categoría a obtener.</param>
        /// <returns>Objeto Categoria con los detalles de la categoría solicitada.</returns>
        public Categoria ObtenerCategoriaPorNombre(string nombre)
        {
            return _categoriaDao.FindCategoriaByNombre(nombre);
        }

        /// <summary>
        /// Obtiene todas las categorías registradas en la base de datos.
        /// </summary>
        /// <returns>Lista de objetos Categoria.</returns>
        public List<Categoria> ObtenerTodasLasCategorias()
        {
            return _categoriaDao.LoadAllCategorias();
        }
    }
}


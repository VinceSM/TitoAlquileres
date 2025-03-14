﻿using TitoAlquiler.Model.Dao;
using System;
using System.Collections.Generic;
using TitoAlquiler.Model.Entities;

namespace TitoAlquiler.Controller
{
    public class CategoriaController
    {
        CategoriaDao _categoriaDao = new CategoriaDao();

        #region Singletone

        private static CategoriaController? _instance;
        public static CategoriaController Instance => _instance ??= new CategoriaController();

        private CategoriaController() { }

        #endregion

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


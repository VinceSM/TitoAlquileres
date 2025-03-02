using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Dao;
using TitoAlquiler.Model.Dao.CategoriasDao;
using TitoAlquiler.Model.Entities.Categorias;

namespace TitoAlquiler.Controller.CategoriasController
{
    public class TransporteController
    {
        private readonly TransporteDao _transporteDao;

        #region Singleton
        private static TransporteController? _instance;
        public static TransporteController Instance => _instance ??= new TransporteController();

        private TransporteController()
        {
            _transporteDao = new TransporteDao();
        }
        #endregion

        public void Agregar(Transporte transporte)
        {
            try
            {
                _transporteDao.Insert(transporte);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al agregar transporte: {ex.Message}", ex);
            }
        }

        public Transporte? ObtenerPorId(int id)
        {
            try
            {
                return _transporteDao.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener transporte: {ex.Message}", ex);
            }
        }

        public void Actualizar(Transporte transporte)
        {
            try
            {
                _transporteDao.Update(transporte);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar transporte: {ex.Message}", ex);
            }
        }
    }
}

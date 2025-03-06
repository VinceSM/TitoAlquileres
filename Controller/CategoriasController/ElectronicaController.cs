using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Dao.CategoriasDao;
using TitoAlquiler.Model.Entities.Categorias;
using TitoAlquiler.Resources;

namespace TitoAlquiler.Controller.CategoriasController
{
    public class ElectronicaController
    {
        private readonly ElectronicaDao _electronicaDao;

        #region Singleton
        private static ElectronicaController? _instance;
        public static ElectronicaController Instance => _instance ??= new ElectronicaController();

        private ElectronicaController()
        {
            _electronicaDao = new ElectronicaDao();
        }
        #endregion

        public void Agregar(Electronica electronica)
        {
            try
            {
                _electronicaDao.Insert(electronica);
            }
            catch (Exception ex)
            {
                string mensaje = $"Error al agregar electrónica: {ex.Message}";
                MessageShow.MostrarMensajeError(mensaje);
                throw new Exception(mensaje, ex);
            }
        }

        public Electronica? ObtenerPorId(int id)
        {
            try
            {
                return _electronicaDao.GetById(id);
            }
            catch (Exception ex)
            {
                string mensaje = $"Error al obtener electrónica: {ex.Message}";
                MessageShow.MostrarMensajeError(mensaje);
                throw new Exception(mensaje, ex);
            }
        }

        public void Actualizar(Electronica electronica)
        {
            try
            {
                _electronicaDao.Update(electronica);
            }
            catch (Exception ex)
            {
                string mensaje = $"Error al actualizar electrónica: {ex.Message}";
                MessageShow.MostrarMensajeError(mensaje);
                throw new Exception(mensaje, ex);
            }
        }
    }
}
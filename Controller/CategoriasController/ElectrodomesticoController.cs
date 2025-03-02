using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Dao.CategoriasDao;
using TitoAlquiler.Model.Entities.Categorias;

namespace TitoAlquiler.Controller.CategoriasController
{
    public class ElectrodomesticoController
    {
        private readonly ElectrodomesticoDao _electrodomesticoDao;

        #region Singleton
        private static ElectrodomesticoController? _instance;
        public static ElectrodomesticoController Instance => _instance ??= new ElectrodomesticoController();

        private ElectrodomesticoController()
        {
            _electrodomesticoDao = new ElectrodomesticoDao();
        }
        #endregion

        public void Agregar(Electrodomestico electrodomestico)
        {
            try
            {
                _electrodomesticoDao.Insert(electrodomestico);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al agregar electrodoméstico: {ex.Message}", ex);
            }
        }

        public Electrodomestico? ObtenerPorId(int id)
        {
            try
            {
                return _electrodomesticoDao.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener electrodoméstico: {ex.Message}", ex);
            }
        }

        public void Actualizar(Electrodomestico electrodomestico)
        {
            try
            {
                _electrodomesticoDao.Update(electrodomestico);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar electrodoméstico: {ex.Message}", ex);
            }
        }
    }
}

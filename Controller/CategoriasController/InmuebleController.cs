using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Dao.CategoriasDao;
using TitoAlquiler.Model.Entities.Categorias;

namespace TitoAlquiler.Controller.CategoriasController
{
    public class InmuebleController
    {
        private readonly InmuebleDao _inmuebleDao;

        #region Singleton
        private static InmuebleController? _instance;
        public static InmuebleController Instance => _instance ??= new InmuebleController();

        private InmuebleController()
        {
            _inmuebleDao = new InmuebleDao();
        }
        #endregion

        public void Agregar(Inmueble inmueble)
        {
            try
            {
                _inmuebleDao.Insert(inmueble);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al agregar inmueble: {ex.Message}", ex);
            }
        }

        public Inmueble? ObtenerPorId(int id)
        {
            try
            {
                return _inmuebleDao.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener inmueble: {ex.Message}", ex);
            }
        }

        public void Actualizar(Inmueble inmueble)
        {
            try
            {
                _inmuebleDao.Update(inmueble);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar inmueble: {ex.Message}", ex);
            }
        }
    }
}

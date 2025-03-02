using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Dao.CategoriasDao;
using TitoAlquiler.Model.Entities.Categorias;

namespace TitoAlquiler.Controller.CategoriasController
{
    public class IndumentariaController
    {
        private readonly IndumentariaDao _indumentariaDao;

        #region Singleton
        private static IndumentariaController? _instance;
        public static IndumentariaController Instance => _instance ??= new IndumentariaController();

        private IndumentariaController()
        {
            _indumentariaDao = new IndumentariaDao();
        }
        #endregion

        public void Agregar(Indumentaria indumentaria)
        {
            try
            {
                _indumentariaDao.Insert(indumentaria);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al agregar indumentaria: {ex.Message}", ex);
            }
        }

        public Indumentaria? ObtenerPorId(int id)
        {
            try
            {
                return _indumentariaDao.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener indumentaria: {ex.Message}", ex);
            }
        }

        public void Actualizar(Indumentaria indumentaria)
        {
            try
            {
                _indumentariaDao.Update(indumentaria);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar indumentaria: {ex.Message}", ex);
            }
        }
    }
}

using SistemaAlquileres.Model.Entities;
using SistemaAlquileres.Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAlquileres.Controller
{
    public class AlquilerController
    {

        private AlquilerDao _alquilerDao = new AlquilerDao();

        #region Singleton
        private static AlquilerController _instance;
        private static readonly object _lock = new object();

        private AlquilerController()
        {
            _alquilerDao = new AlquilerDao(); 
        }

        public static AlquilerController GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new AlquilerController();
                    }
                }
            }
            return _instance;
        }
        #endregion

        // Método para cargar todos los alquileres
        public async Task<List<Alquiler>> LoadAlquileres()
        {
            return await _alquilerDao.GetAllAlquileres();
        }

        // Método para crear un nuevo alquiler
        public async Task<Alquiler> CrearAlquiler(int usuarioId, int itemId, int dias)
        {
            
            var alquiler = await _alquilerDao.CreateAlquiler(new Alquiler
            {
                usuario_id = usuarioId,
                item_id = itemId,
                tiempo_dias = dias,
                fecha_inicio = DateTime.Now,
                fecha_fin = DateTime.Now.AddDays(dias),
                precio_total = dias * 100 // Esta es una tarifa de ejemplo, debería calcularse en función de los datos reales del item
            });

            return alquiler;
        }

        // Obtener un alquiler por ID
        public async Task<Alquiler> GetAlquilerById(int id)
        {
            return await _alquilerDao.GetAlquilerById(id);
        }

        // Obtener alquileres por Item
        public async Task<List<Alquiler>> GetAlquileresByItem(int itemId)
        {
            return await _alquilerDao.GetAlquileresByItem(itemId);
        }

        // Obtener alquileres por Usuario
        public async Task<List<Alquiler>> GetAlquileresByUsuario(int usuarioId)
        {
            return await _alquilerDao.GetAlquileresByUsuario(usuarioId);
        }

        // Eliminar un alquiler de manera lógica
        public async Task SoftDeleteAlquiler(int id)
        {
            await _alquilerDao.SoftDeleteAlquiler(id);
        }

        // Método para actualizar alquiler (si fuera necesario)
        public async Task<Alquiler> UpdateAlquiler(Alquiler alquiler)
        {
            return await _alquilerDao.UpdateAlquiler(alquiler);
        }
    }
}

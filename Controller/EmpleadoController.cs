using Microsoft.EntityFrameworkCore;
using SistemaAlquileres.Controller;
using SistemaAlquileres.Model.Dao;
using SistemaAlquileres.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Dao;
using TitoAlquiler.Model.Entities;

namespace TitoAlquiler.Controller
{
    internal class EmpleadoController
    {
        private EmpleadoDao empleadoDao;
        private SistemaAlquilerContext  _context;

        #region Singleton
        private static EmpleadoController Instance;

        public EmpleadoController()
        {
            empleadoDao = new EmpleadoDao();
            _context = new SistemaAlquilerContext();
        }

        public static EmpleadoController getInstance()
        {
            if (Instance == null)
            {
                Instance = new EmpleadoController();
            }
            return Instance;
        }
        #endregion

        public Empleado CreateEmpleado(Empleado empleado)
        {
            if (empleado == null)
                throw new ArgumentNullException(nameof(empleado));

            _context.Empleados.Add(empleado);
            _context.SaveChanges();
            return empleado;
        }

        public Empleado UpdateEmpleado(Empleado empleado)
        {
            if (empleado == null)
                throw new ArgumentNullException(nameof(empleado));

            _context.Entry(empleado).State = EntityState.Modified;
            _context.SaveChanges();
            return empleado;
        }
    }
}

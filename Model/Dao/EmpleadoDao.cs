using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitoAlquiler.Model.Dao
{
    internal class EmpleadoDao
    {
        private SistemaAlquilerContext _context;
        public EmpleadoDao() 
        {
            {
                _context = new SistemaAlquilerContext();
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities;

namespace TitoAlquiler.Model.Dao
{
    public class CategoriaDao
    {
        private SistemaAlquilerContext _context;

        public CategoriaDao() 
        {
            _context = new SistemaAlquilerContext();
        }

        public List<Categoria> GetCategorias()
        {
            return _context.categorias.ToList();
        }

        public Categoria GetCategoriaById(int id)
        {
            return _context.categorias.Find(id);
        }

        public Categoria GetCategoriaByName(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
                throw new ArgumentException("Name cannot be null or empty", nameof(nombre));

            return _context.categorias.Where(c => c.deletedAt == null).FirstOrDefault(u => u.nombre == nombre);
        }
    }
}

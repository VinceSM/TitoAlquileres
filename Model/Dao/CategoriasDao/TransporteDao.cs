using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities.Categorias;

namespace TitoAlquiler.Model.Dao.CategoriasDao
{
    public class TransporteDao
    {
        public void Insert(Transporte transporte)
        {
            using (var db = new SistemaAlquilerContext())
            {
                db.Transportes.Add(transporte);
                db.SaveChanges();
            }
        }

        public Transporte? GetById(int id)
        {
            using (var db = new SistemaAlquilerContext())
            {
                return db.Transportes.FirstOrDefault(t => t.id == id);
            }
        }

        public void Update(Transporte transporte)
        {
            using (var db = new SistemaAlquilerContext())
            {
                db.Transportes.Update(transporte);
                db.SaveChanges();
            }
        }
    }
}

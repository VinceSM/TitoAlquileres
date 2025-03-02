using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities.Categorias;

namespace TitoAlquiler.Model.Dao.CategoriasDao
{
    public class ElectronicaDao
    {
        public void Insert(Electronica electronica)
        {
            using (var db = new SistemaAlquilerContext())
            {
                db.Electronicas.Add(electronica);
                db.SaveChanges();
            }
        }

        public Electronica? GetById(int id)
        {
            using (var db = new SistemaAlquilerContext())
            {
                return db.Electronicas.FirstOrDefault(e => e.id == id);
            }
        }

        public void Update(Electronica electronica)
        {
            using (var db = new SistemaAlquilerContext())
            {
                db.Electronicas.Update(electronica);
                db.SaveChanges();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities.Categorias;

namespace TitoAlquiler.Model.Dao.CategoriasDao
{
    public class InmuebleDao
    {
        public void Insert(Inmueble inmueble)
        {
            using (var db = new SistemaAlquilerContext())
            {
                db.Inmuebles.Add(inmueble);
                db.SaveChanges();
            }
        }

        public Inmueble? GetById(int id)
        {
            using (var db = new SistemaAlquilerContext())
            {
                return db.Inmuebles.FirstOrDefault(i => i.id == id);
            }
        }

        public void Update(Inmueble inmueble)
        {
            using (var db = new SistemaAlquilerContext())
            {
                db.Inmuebles.Update(inmueble);
                db.SaveChanges();
            }
        }
    }
}

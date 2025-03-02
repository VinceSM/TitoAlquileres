using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities.Categorias;

namespace TitoAlquiler.Model.Dao.CategoriasDao
{
    public class IndumentariaDao
    {
        public void Insert(Indumentaria indumentaria)
        {
            using (var db = new SistemaAlquilerContext())
            {
                db.Indumentarias.Add(indumentaria);
                db.SaveChanges();
            }
        }

        public Indumentaria? GetById(int id)
        {
            using (var db = new SistemaAlquilerContext())
            {
                return db.Indumentarias.FirstOrDefault(i => i.id == id);
            }
        }

        public void Update(Indumentaria indumentaria)
        {
            using (var db = new SistemaAlquilerContext())
            {
                db.Indumentarias.Update(indumentaria);
                db.SaveChanges();
            }
        }
    }
}

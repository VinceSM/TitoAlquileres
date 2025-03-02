using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities.Categorias;

namespace TitoAlquiler.Model.Dao.CategoriasDao
{
    public class ElectrodomesticoDao
    {
        public void Insert(Electrodomestico electrodomestico)
        {
            using (var db = new SistemaAlquilerContext())
            {
                db.Electrodomesticos.Add(electrodomestico);
                db.SaveChanges();
            }
        }

        public Electrodomestico? GetById(int id)
        {
            using (var db = new SistemaAlquilerContext())
            {
                return db.Electrodomesticos.FirstOrDefault(e => e.id == id);
            }
        }

        public void Update(Electrodomestico electrodomestico)
        {
            using (var db = new SistemaAlquilerContext())
            {
                db.Electrodomesticos.Update(electrodomestico);
                db.SaveChanges();
            }
        }
    }
}

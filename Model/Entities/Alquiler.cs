using SistemaAlquileres.Model.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAlquileres.Model.Entities
{
    public class Alquiler
    {
        public int id { get; set; }
        public Item item_id { get; set; }
        public Usuario usuario_id { get; set; }
        public int tiempo_dias { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
        public IEstrategiaAlquiler precio_total { get; set; }
        public DateTime deletedAt { get; set; }

    }
}

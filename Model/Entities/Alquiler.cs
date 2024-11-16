using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAlquileres.Model.Entities
{
    public class Alquiler
    {
        public int id {  get; set; }
        public int item_id { get; set; }
        public int usuario_id { get; set; }
        public int tiempo_dias {  get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin {  get; set; }
        public double precio_total { get; set; }
        public DateTime deletedAt { get; set; }
    }
}

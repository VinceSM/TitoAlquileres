using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAlquileres.Model.Entities
{
    public abstract class Item
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string categoria { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public double tarifa { get; set; }

    }
}

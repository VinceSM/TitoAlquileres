using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitoAlquiler.Model.Entities.Categorias
{
    public class Inmueble
    {
        public int id { get; set; }
        public int item_id { get; set; }
        public Item item { get; set; }
        public int metrosCuadrados { get; set; }
        public string ubicacion { get; set; }

        public Inmueble() { }
        public Inmueble(Item item)
        {
            this.item = item;
            this.item_id = item.id;
        }
    }
}

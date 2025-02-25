using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities.Items;

namespace TitoAlquiler.Model.Entities.Categorias
{
    public class Inmueble
    {
        public int id { get; set; }
        public int item_id { get; set; }
        public Item item { get; set; }

        public int metrosCuadrados { get; set; }
        public string ubicacion { get; set; }

        public Inmueble(Item item, int metrosCuadrados, string ubicacion)
        {
            this.item = item;
            this.item_id = item.id;
            this.metrosCuadrados = metrosCuadrados;
            this.ubicacion = ubicacion;
        }

        public Inmueble(Item item)
        {
            this.item = item;
            this.item_id = item.id;
        }
    }
}

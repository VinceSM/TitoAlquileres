using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities.Items;

namespace TitoAlquiler.Model.Entities.Categorias
{
    // Clase Electronica
    public class Electronica
    {
        public int id { get; set; }
        public int item_id { get; set; }
        public Item item { get; set; }

        public string resolucionPantalla { get; set; }
        public int almacenamientoGB { get; set; }

        public Electronica() { }
        public Electronica(Item item, string resolucionPantalla, int almacenamientoGB)
        {
            this.item = item;
            this.item_id = item.id;
            this.resolucionPantalla = resolucionPantalla;
            this.almacenamientoGB = almacenamientoGB;
        }

        public Electronica(Item item)
        {
            this.item = item;
            this.item_id = item.id;
        }
    }
}

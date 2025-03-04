using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitoAlquiler.Model.Entities.Categorias
{
    // Clase Electronica
    public class Electronica
    {
        public int id { get; set; }
        public int itemId { get; set; }
        public ItemAlquilable item { get; set; }
        public string resolucionPantalla { get; set; }
        public int almacenamientoGB { get; set; }

        public Electronica() { }

        public Electronica(ItemAlquilable item)
        {
            this.item = item;
            this.itemId = item.id;
        }
    }
}

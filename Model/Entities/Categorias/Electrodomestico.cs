using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities.Items;

namespace TitoAlquiler.Model.Entities.Categorias
{
    // Clase Electrodomestico
    public class Electrodomestico
    {
        public int id { get; set; }
        public int item_id { get; set; }
        public Item item { get; set; }

        public int potenciaWatts { get; set; }
        public string tipoElectrodomestico { get; set; }

        public Electrodomestico(Item item, int potenciaWatts, string tipoElectrodomestico)
        {
            this.item = item;
            this.item_id = item.id;
            this.potenciaWatts = potenciaWatts;
            this.tipoElectrodomestico = tipoElectrodomestico;
        }

        public Electrodomestico (Item item)
        {
            this.item = item;
            this.item_id = item.id;
        }
    }
    
}

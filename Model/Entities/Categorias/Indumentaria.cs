using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities.Items;

namespace TitoAlquiler.Model.Entities.Categorias
{
    public class Indumentaria
    {
        public int id { get; set; }
        public int item_id { get; set; }
        public Item item { get; set; }

        public Indumentaria(Item item)
        {
            this.item = item;
            this.item_id = item.id; // Asignar el ID del ítem
        }
        public string? talla { get; set; }
        public string? material { get; set; }
    }
}

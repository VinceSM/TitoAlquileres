using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities.Items;

namespace TitoAlquiler.Model.Entities.Categorias
{
    public class Transporte
    {
        public int id { get; set; }
        public int item_id { get; set; } 
        public Item item { get; set; } 

        public Transporte(Item item)
        {
            this.item = item;
            this.item_id = item.id; // Asignar el ID del ítem
        }

        public int capacidadPasajeros { get; set; }
        public string? tipoCombustible { get; set; }
    }

}

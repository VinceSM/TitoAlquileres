using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitoAlquiler.Model.Entities.Categorias
{
    // Clase Transporte
    public class Transporte
    {
        public int id { get; set; }
        public int itemId { get; set; }
        public virtual ItemAlquilable item { get; set; } = null!;
        public int capacidadPasajeros { get; set; }
        public string? tipoCombustible { get; set; }

        public Transporte() { }

        public Transporte(ItemAlquilable item) 
        {
            this.item = item;
            this.itemId = item.id;
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitoAlquiler.Model.Entities.Categorias
{
    public class Indumentaria
    {
        public int id { get; set; }
        public int itemid { get; set; }
        public Item item { get; set; }
        public string? talla { get; set; }
        public string? material { get; set; }

        public Indumentaria() { }
        public Indumentaria(Item item)
        {
            this.item = item;
            this.itemid = item.id;
        }
    }
}

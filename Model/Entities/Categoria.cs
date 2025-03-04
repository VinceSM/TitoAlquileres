using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitoAlquiler.Model.Entities
{
    public class Categoria
    {
        public int id { get; set; }
        public string? nombre { get; set; }
        public ICollection<ItemAlquilable>? items { get; set; }
        public DateTime? deletedAt { get; set; }
    }
}

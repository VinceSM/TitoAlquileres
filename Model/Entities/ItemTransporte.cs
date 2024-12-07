using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitoAlquiler.Model.Entities
{
    public class ItemTransporte : Item
    {
        [Column("ItemId")]
        public Item? itemId {  get; set; }
        public string? descripcion { get; set; }

        public string? GetDescripcion()
        {
            return descripcion;
        }
    }
}

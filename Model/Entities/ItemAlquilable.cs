using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Interfaces;

namespace TitoAlquiler.Model.Entities
{
    //Clase Concreta que gestiona los atributos de un Item Alquilable
    public class ItemAlquilable
    {
        public int id { get; set; }
        public string? nombreItem { get; set; }
        public string? marca { get; set; }
        public string? modelo { get; set; }
        public double tarifaDia { get; set; }
        public int categoriaId { get; set; }
        public Categoria? categoria { get; set; }
        public ICollection<Alquileres>? Alquileres { get; set; }
        public DateTime? deletedAt { get; set; }
    }
}

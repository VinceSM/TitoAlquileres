using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAlquileres.Model.Entities
{
    public class Item
    {
        public int id { get; set; }
        public string categoria { get; set; }
        public string nombre { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public float tarifa { get; set; }

        // Relación de navegación
        public ICollection<Alquiler> alquileres { get; set; }

    }
}

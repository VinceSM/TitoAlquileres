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
        public string categoria { get; set; }//Transporte, Electronica, Electrodomesticos, Inmuebles, Indumentaria
        public string nombre { get; set; }//Auto, Mouse, Lavarropa, Casa, Remera
        public string marca { get; set; }//Toyota, Redragon, Samsung, Remax, Adidas
        public string modelo { get; set; }//Corolla, M608, Silver, Estancia, Iv4728 
        public float tarifa { get; set; }//$150, $10, $15, $100, $10 

    }
}

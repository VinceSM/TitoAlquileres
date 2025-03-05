using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Interfaces;
using TitoAlquiler.Model.Strategy;

namespace TitoAlquiler.Model.Entities
{
    public class Alquileres
    {
        public int id { get; set; }
        public int ItemID { get; set; }
        public ItemAlquilable? item { get; set; }
        public int UsuarioID { get; set; }
        public Usuarios? usuario { get; set; }
        public int tiempoDias { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public double precioTotal { get; set; }
        private IEstrategiaPrecio? _estrategiaPrecio {  get; set; }
        public string? tipoEstrategia { get; set; }
        public DateTime? deletedAt { get; set; }

        public Alquileres()
        {
        }

        public Alquileres(ItemAlquilable item) 
        {
            this.item = item;
            this.ItemID = item.id;
        }
    }

}

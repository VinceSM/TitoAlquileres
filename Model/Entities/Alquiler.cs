using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitoAlquiler.Model.Entities
{
    public class Alquiler
    {
        public int id { get; set; }
        public int ItemID { get; set; }
        public virtual AlquilableBase? item { get; set; }
        public int UsuarioID { get; set; }
        public virtual Usuarios? usuario { get; set; }
        public int tiempoDias { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public double precioTotal { get; set; }
        public string? tipoEstrategia { get; set; }
        public DateTime? deletedAt { get; set; }
    }
}

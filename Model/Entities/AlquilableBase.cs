using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitoAlquiler.Model.Entities
{
    //Clase Abstracta que controla las caracteristicas de un Item Alquilable
    public abstract class AlquilableBase : IAlquilable
    {
        public int id { get; set; }
        public string? nombreItem { get; set; }
        public string? marca { get; set; }
        public string? modelo { get; set; }
        public double tarifaDia { get; set; }
        public int categoriaId { get; set; }
        public virtual Categoria? categoria { get; set; }
        public virtual ICollection<Alquiler>? Alquileres { get; set; }
        public DateTime? deletedAt { get; set; }

        public abstract void Alquilar();
    }
}

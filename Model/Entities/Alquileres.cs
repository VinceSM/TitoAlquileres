using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Interfaces;

namespace TitoAlquiler.Model.Entities
{
    public class Alquileres
    {
        public int id { get; set; }
        public int ItemID { get; set; }
        public virtual ItemAlquilable? item { get; set; }
        public int UsuarioID { get; set; }
        public virtual Usuarios? usuario { get; set; }
        public int tiempoDias { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public double precioTotal { get; set; }
        public string? tipoEstrategia { get; set; }
        public DateTime? deletedAt { get; set; }

        private IEstrategiaPrecio _estrategiaPrecio;

        // Constructor con estrategia por defecto
        public Alquileres(IEstrategiaPrecio estrategia)
        {
            _estrategiaPrecio = estrategia;
        }

        // Método para cambiar la estrategia en tiempo de ejecución
        public void SetEstrategia(IEstrategiaPrecio estrategia)
        {
            _estrategiaPrecio = estrategia;
        }

        // Método para calcular el precio total basado en la estrategia seleccionada
        public void CalcularPrecio()
        {
            if (item == null) throw new Exception("No se ha asignado un ítem al alquiler.");
            precioTotal = _estrategiaPrecio.CalcularPrecioAlquiler(item.tarifaDia, tiempoDias);
        }
    }
}

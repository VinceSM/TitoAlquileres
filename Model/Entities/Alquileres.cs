using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities.Items;
using TitoAlquiler.Model.Interfaces;

namespace TitoAlquiler.Model.Entities
{
    public class Alquileres
    {
        public int id { get; set; }
        public int ItemID { get; set; }
        public virtual Item? item { get; set; }
        public int UsuarioID { get; set; }
        public virtual Usuarios? usuario { get; set; }
        public int tiempoDias { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public double precioTotal { get; set; }
        public string? tipoEstrategia { get; set; }
        public DateTime? deletedAt { get; set; }

        private IEstrategiaPrecio? _estrategiaPrecio;
        private IEstrategiaAlquiler? _estrategiaAlquiler;

        public Alquileres() { }

        public Alquileres(IEstrategiaPrecio estrategiaPrecio)
        {
            _estrategiaPrecio = estrategiaPrecio;
        }
        public void SetEstrategiaPrecio(IEstrategiaPrecio estrategiaPrecio)
        {
            _estrategiaPrecio = estrategiaPrecio;
        }

        public Alquileres(IEstrategiaAlquiler estrategiaAlquiler)
        {
            _estrategiaAlquiler = estrategiaAlquiler;
        }

        public void SetEstrategiaAlquiler(IEstrategiaAlquiler estrategiaAlquiler)
        {
            _estrategiaAlquiler = estrategiaAlquiler;
        }

        // Método para calcular el precio total basado en la estrategia seleccionada
        public void CalcularPrecio()
        {
            if (item == null) throw new Exception("No se ha asignado un ítem al alquiler.");
            if (_estrategiaPrecio == null) throw new Exception("No se ha asignado una estrategia de precio.");

            precioTotal = _estrategiaPrecio.CalcularPrecioAlquiler(item.tarifaDia, tiempoDias);
        }
    }

}

using TitoAlquiler.Model.Strategy;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TitoAlquiler.Model.Entities;

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
        public bool descuento { get; set; }
        public DateTime? deletedAt { get; set; }

        public void CalcularPrecioTotal(IEstrategiaAlquiler estrategia)
        {
            precioTotal = estrategia.CalcularPrecio(this, item);
            tipoEstrategia = estrategia.getEstrategia();
        }
    }
}
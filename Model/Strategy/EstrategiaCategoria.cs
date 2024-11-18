using SistemaAlquileres.Model.Entities;
using SistemaAlquileres.Model.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitoAlquiler.Model.Strategy
{
    public class EstrategiaCategoria : IEstrategiaAlquiler
    {
        public double CalcularPrecio(Alquiler alquiler, Item item)
        {
            return 0; //Precio por categoria (Transporte, Inmuebles, Indumentaria, Electronica, Electrodomesticos)
        }
    }
}

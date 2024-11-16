using SistemaAlquileres.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAlquileres.Model.Strategy
{
    public class EstrategiaEstandar : IEstrategiaAlquiler
    {
        public double CalcularPrecio(Alquiler alquiler, Item item)
        {
            return alquiler.tiempo_dias * item.tarifa;
        }
    }

    
}

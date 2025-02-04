using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Interfaces;

namespace TitoAlquiler.Model.Strategy
{
    public class EstrategiaMembresia : IEstrategiaPrecio
    {
        public double CalcularPrecioAlquiler(double tarifaBase, int dias)
        {
            double total = tarifaBase * dias;
            return total * 0.9; // 10% de descuento
        }
    }
}

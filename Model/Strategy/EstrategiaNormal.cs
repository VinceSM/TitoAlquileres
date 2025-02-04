using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Interfaces;

namespace TitoAlquiler.Model.Strategy
{
    public class EstrategiaNormal : IEstrategiaPrecio
    {
        public double CalcularPrecioAlquiler(double tarifaBase, int dias)
        {
            return tarifaBase * dias;
        }
    }
}

using TitoAlquiler.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitoAlquiler.Model.Strategy
{
    public interface IEstrategiaAlquiler
    {
        string getEstrategia();
        double CalcularPrecio(Alquiler alquiler, Item item);
    }
}

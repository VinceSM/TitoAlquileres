using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitoAlquiler.Model.Interfaces
{
    public interface IEstrategiaPrecio
    {
        double CalcularPrecioAlquiler(double tarifaBase, int dias);
        string getEstrategia(string nombre);
    }
}

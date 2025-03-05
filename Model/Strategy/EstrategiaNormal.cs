using System;
using TitoAlquiler.Model.Interfaces;

namespace TitoAlquiler.Model.Strategy
{
    public class EstrategiaNormal : IEstrategiaPrecio
    {
        public double CalcularPrecioAlquiler(double tarifaBase, int dias)
        {
            // Precio estándar sin descuentos ni aumentos
            return tarifaBase * dias;
        }

        public string getEstrategia(string nombre)
        {
            return nombre = "EstrategiaNormal";
        }
    }
}


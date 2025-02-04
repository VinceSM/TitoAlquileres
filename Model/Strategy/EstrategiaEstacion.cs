using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Interfaces;

namespace TitoAlquiler.Model.Strategy
{
    public enum Estacion
    {
        Primavera,
        Verano,
        Otoño,
        Invierno
    }

    public class EstrategiaEstacion : IEstrategiaPrecio
    {
        private readonly Estacion _estacion;

        public EstrategiaEstacion(Estacion estacion)
        {
            _estacion = estacion;
        }

        public double CalcularPrecioAlquiler(double tarifaBase, int dias)
        {
            double total = tarifaBase * dias;

            return _estacion switch
            {
                Estacion.Verano => total * 1.15,    // 15% de aumento en Verano
                Estacion.Invierno => total * 1.10,  // 10% de aumento en Invierno
                Estacion.Otoño => total * 0.95,     // 5% de descuento en Otoño
                Estacion.Primavera => total,        // Precio normal en Primavera
                _ => total
            };
        }
    }
}

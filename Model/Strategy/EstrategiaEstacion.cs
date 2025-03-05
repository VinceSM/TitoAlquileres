using System;
using System.Collections.Generic;
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
        private static readonly Dictionary<Estacion, double> _factoresEstacionales = new Dictionary<Estacion, double>
        {
            { Estacion.Verano, 1.15 },    // 15% de aumento en Verano
            { Estacion.Invierno, 1.10 },  // 10% de aumento en Invierno
            { Estacion.Otoño, 0.95 },     // 5% de descuento en Otoño
            { Estacion.Primavera, 1.00 }  // Precio normal en Primavera
        };

        public EstrategiaEstacion(Estacion estacion)
        {
            _estacion = estacion;
        }

        public double CalcularPrecioAlquiler(double tarifaBase, int dias)
        {
            double total = tarifaBase * dias;
            return total * _factoresEstacionales[_estacion];
        }

        public string getEstrategia(string nombre)
        {
            return nombre = "EstrategiaEstacion";
        }

        /// <summary>
        /// Obtiene la estación actual basada en el mes.
        /// </summary>
        public static Estacion ObtenerEstacionActual()
        {
            return DateTime.Now.Month switch
            {
                3 or 4 or 5 => Estacion.Otoño,
                6 or 7 or 8 => Estacion.Invierno,
                9 or 10 or 11 => Estacion.Primavera,
                _ => Estacion.Verano // 12, 1, 2
            };
        }

        /// <summary>
        /// Determina si la fecha actual corresponde a una temporada alta.
        /// </summary>
        public static bool EsTemporadaAlta()
        {
            var estacion = ObtenerEstacionActual();
            if(estacion == Estacion.Verano || estacion == Estacion.Invierno)
            {
                return true;
            }

            return false;
        }
    }
}

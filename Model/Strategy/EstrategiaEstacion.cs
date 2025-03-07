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

        /// <summary>
        /// Obtiene la estación actual basada en el mes.
        /// </summary>
        /// <returns>La estación correspondiente al mes actual.</returns>
        public static Estacion ObtenerEstacionActual()
        {
            return DateTime.Now.Month switch
            {
                >= 3 and <= 5 => Estacion.Otoño,
                >= 6 and <= 8 => Estacion.Invierno,
                >= 9 and <= 11 => Estacion.Primavera,
                _ => Estacion.Verano // 12, 1, 2
            };
        }

        /// <summary>
        /// Diccionario que contiene los factores de ajuste de precio para cada estación.
        /// </summary>
        public static readonly Dictionary<Estacion, double> _factoresEstacionales = new Dictionary<Estacion, double>
        {
            { Estacion.Verano, 1.15 },    // 15% de aumento en Verano
            { Estacion.Invierno, 1.10 },  // 10% de aumento en Invierno
            { Estacion.Otoño, 0.95 },     // 5% de descuento en Otoño
            { Estacion.Primavera, 1.00 }  // Precio normal en Primavera
        };

        /// <summary>
        /// Constructor que inicializa la estrategia con una estación específica.
        /// </summary>
        /// <param name="estacion">Estación a utilizar para el cálculo de precios.</param>
        public EstrategiaEstacion(Estacion estacion)
        {
            _estacion = estacion;
        }

        /// <summary>
        /// Calcula el precio de alquiler aplicando el factor estacional correspondiente.
        /// </summary>
        /// <param name="tarifaBase">Tarifa base diaria del ítem.</param>
        /// <param name="dias">Cantidad de días de alquiler.</param>
        /// <returns>Precio total calculado con el ajuste estacional.</returns>
        public double CalcularPrecioAlquiler(double tarifaBase, int dias)
        {
            double total = tarifaBase * dias;
            return total * _factoresEstacionales[_estacion];
        }

        /// <summary>
        /// Obtiene el nombre de la estrategia.
        /// </summary>
        /// <param name="nombre">Parámetro no utilizado.</param>
        /// <returns>Nombre de la estrategia ("EstrategiaEstacion").</returns>
        public string getEstrategia(string nombre)
        {
            return nombre = "EstrategiaEstacion";
        }
    }
}

using System;
using TitoAlquiler.Model.Interfaces;

namespace TitoAlquiler.Model.Strategy
{
    public class EstrategiaNormal : IEstrategiaPrecio
    {
        /// <summary>
        /// Calcula el precio de alquiler estándar sin modificaciones.
        /// </summary>
        /// <param name="tarifaBase">Tarifa base diaria del ítem.</param>
        /// <param name="dias">Cantidad de días de alquiler.</param>
        /// <returns>Precio total calculado sin descuentos ni aumentos.</returns>
        public double CalcularPrecioAlquiler(double tarifaBase, int dias)
        {
            // Precio estándar sin descuentos ni aumentos
            return tarifaBase * dias;
        }

        /// <summary>
        /// Obtiene el nombre de la estrategia.
        /// </summary>
        /// <param name="nombre">Parámetro no utilizado.</param>
        /// <returns>Nombre de la estrategia ("EstrategiaNormal").</returns>
        public string getEstrategia(string nombre)
        {
            return nombre = "EstrategiaNormal";
        }
    }
}


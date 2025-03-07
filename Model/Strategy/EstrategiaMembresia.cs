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
        /// <summary>
        /// Calcula el precio de alquiler aplicando un descuento del 10% para usuarios con membresía.
        /// </summary>
        /// <param name="tarifaBase">Tarifa base diaria del ítem.</param>
        /// <param name="dias">Cantidad de días de alquiler.</param>
        /// <returns>Precio total calculado con el descuento por membresía.</returns>
        public double CalcularPrecioAlquiler(double tarifaBase, int dias)
        {
            double total = tarifaBase * dias;
            return total * 0.9; // 10% de descuento
        }

        /// <summary>
        /// Obtiene el nombre de la estrategia.
        /// </summary>
        /// <param name="nombre">Parámetro no utilizado.</param>
        /// <returns>Nombre de la estrategia ("EstrategiaMembresia").</returns>
        public string getEstrategia(string nombre)
        {
            return nombre = "EstrategiaMembresia";
        }
    }
}

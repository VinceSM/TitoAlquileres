using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitoAlquiler.Model.Interfaces
{
    public interface IEstrategiaPrecio
    {
        /// <summary>
        /// Calcula el precio total de un alquiler según la estrategia implementada.
        /// </summary>
        /// <param name="tarifaBase">Tarifa base diaria del ítem.</param>
        /// <param name="dias">Cantidad de días de alquiler.</param>
        /// <returns>Precio total calculado según la estrategia específica.</returns>
        double CalcularPrecioAlquiler(double tarifaBase, int dias);

        /// <summary>
        /// Obtiene el nombre identificador de la estrategia.
        /// </summary>
        /// <param name="nombre">Parámetro de entrada que será reemplazado por el nombre de la estrategia.</param>
        /// <returns>Nombre que identifica la estrategia implementada.</returns>
        string getEstrategia(string nombre);
    }
}

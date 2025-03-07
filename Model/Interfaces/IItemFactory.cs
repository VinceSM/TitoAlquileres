using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities;

namespace TitoAlquiler.Model.Interfaces
{
    public interface IItemFactory
    {
        /// <summary>
        /// Crea un nuevo ítem alquilable con su categoría específica.
        /// </summary>
        /// <param name="nombre">Nombre del ítem a crear.</param>
        /// <param name="marca">Marca del ítem a crear.</param>
        /// <param name="modelo">Modelo del ítem a crear.</param>
        /// <param name="tarifaDia">Tarifa diaria de alquiler del ítem.</param>
        /// <param name="adicionales">Parámetros adicionales específicos según el tipo de ítem.</param>
        /// <returns>Tupla que contiene el ítem base (ItemAlquilable) y su categoría específica (object).</returns>
        (ItemAlquilable item, object categoria) CrearAlquilable(
            string nombre,
            string marca,
            string modelo,
            double tarifaDia,
            params object[] adicionales);
    }
}

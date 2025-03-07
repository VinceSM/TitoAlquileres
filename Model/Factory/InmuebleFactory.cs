using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities;
using TitoAlquiler.Model.Entities.Categorias;
using TitoAlquiler.Model.Interfaces;

namespace TitoAlquiler.Model.Factory
{
    public class InmuebleFactory : IItemFactory
    {
        /// <summary>
        /// Crea un nuevo inmueble alquilable con sus propiedades específicas.
        /// </summary>
        /// <param name="nombre">Nombre del inmueble.</param>
        /// <param name="marca">Marca o constructor del inmueble.</param>
        /// <param name="modelo">Modelo o tipo del inmueble.</param>
        /// <param name="tarifaDia">Tarifa diaria de alquiler del inmueble.</param>
        /// <param name="adicionales">Parámetros adicionales específicos para inmuebles:
        /// [0]: metrosCuadrados (int) - Superficie del inmueble en metros cuadrados.
        /// [1]: ubicacion (string) - Dirección o ubicación del inmueble.</param>
        /// <returns>Tupla que contiene el ítem base (ItemAlquilable) y el inmueble específico (Inmueble).</returns>
        public (ItemAlquilable item, object categoria) CrearAlquilable(
            string nombre,
            string marca,
            string modelo,
            double tarifaDia,
            params object[] adicionales)
        {
            var item = new ItemAlquilable
            {
                nombreItem = nombre,
                marca = marca,
                modelo = modelo,
                tarifaDia = tarifaDia,
                categoriaId = 4 // ID para Inmueble
            };

            var inmueble = new Inmueble(item)
            {
                metrosCuadrados = (int)adicionales[0],
                ubicacion = (string)adicionales[1]
            };

            return (item, inmueble);
        }
    }
}

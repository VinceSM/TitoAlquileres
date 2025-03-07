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
    public class ElectrodomesticoFactory : IItemFactory
    {
        /// <summary>
        /// Crea un nuevo electrodoméstico alquilable con sus propiedades específicas.
        /// </summary>
        /// <param name="nombre">Nombre del electrodoméstico.</param>
        /// <param name="marca">Marca del electrodoméstico.</param>
        /// <param name="modelo">Modelo del electrodoméstico.</param>
        /// <param name="tarifaDia">Tarifa diaria de alquiler del electrodoméstico.</param>
        /// <param name="adicionales">Parámetros adicionales específicos para electrodomésticos:
        /// [0]: potenciaWatts (int) - Potencia del electrodoméstico en watts.
        /// [1]: tipoElectrodomestico (string) - Tipo o categoría específica del electrodoméstico.</param>
        /// <returns>Tupla que contiene el ítem base (ItemAlquilable) y el electrodoméstico específico (Electrodomestico).</returns>
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
                categoriaId = 2 // ID para Electrodomestico
            };

            var electrodomestico = new Electrodomestico(item)
            {
                potenciaWatts = (int)adicionales[0],
                tipoElectrodomestico = (string)adicionales[1]
            };

            return (item, electrodomestico);
        }
    }
}

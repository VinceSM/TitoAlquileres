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
    public class IndumentariaFactory : IItemFactory
    {
        /// <summary>
        /// Crea una nueva indumentaria alquilable con sus propiedades específicas.
        /// </summary>
        /// <param name="nombre">Nombre de la indumentaria.</param>
        /// <param name="marca">Marca de la indumentaria.</param>
        /// <param name="modelo">Modelo o tipo de la indumentaria.</param>
        /// <param name="tarifaDia">Tarifa diaria de alquiler de la indumentaria.</param>
        /// <param name="adicionales">Parámetros adicionales específicos para indumentaria:
        /// [0]: talla (string) - Talla o tamaño de la indumentaria.
        /// [1]: material (string) - Material principal de la indumentaria.</param>
        /// <returns>Tupla que contiene el ítem base (ItemAlquilable) y la indumentaria específica (Indumentaria).</returns>
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
                categoriaId = 5 // ID para Indumentaria
            };

            var indumentaria = new Indumentaria(item)
            {
                talla = (string)adicionales[0],
                material = (string)adicionales[1]
            };

            return (item, indumentaria);
        }
    }
}

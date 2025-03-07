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
    public class ElectronicaFactory : IItemFactory
    {
        /// <summary>
        /// Crea un nuevo artículo electrónico alquilable con sus propiedades específicas.
        /// </summary>
        /// <param name="nombre">Nombre del artículo electrónico.</param>
        /// <param name="marca">Marca del artículo electrónico.</param>
        /// <param name="modelo">Modelo del artículo electrónico.</param>
        /// <param name="tarifaDia">Tarifa diaria de alquiler del artículo electrónico.</param>
        /// <param name="adicionales">Parámetros adicionales específicos para artículos electrónicos:
        /// [0]: almacenamientoGB (int) - Capacidad de almacenamiento en gigabytes.
        /// [1]: resolucionPantalla (string) - Resolución de la pantalla del dispositivo.</param>
        /// <returns>Tupla que contiene el ítem base (ItemAlquilable) y el artículo electrónico específico (Electronica).</returns>
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
                categoriaId = 3 // ID para Electronica
            };

            var electronica = new Electronica(item)
            {
                almacenamientoGB = (int)adicionales[0],
                resolucionPantalla = (string)adicionales[1]
            };

            return (item, electronica);
        }
    }
}

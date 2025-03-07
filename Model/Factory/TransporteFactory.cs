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
    public class TransporteFactory : IItemFactory
    {
        /// <summary>
        /// Crea un nuevo transporte alquilable con sus propiedades específicas.
        /// </summary>
        /// <param name="nombre">Nombre del transporte.</param>
        /// <param name="marca">Marca del transporte.</param>
        /// <param name="modelo">Modelo del transporte.</param>
        /// <param name="tarifaDia">Tarifa diaria de alquiler del transporte.</param>
        /// <param name="adicionales">Parámetros adicionales específicos para transportes:
        /// [0]: capacidadPasajeros (int) - Número máximo de pasajeros que puede transportar.
        /// [1]: tipoCombustible (string) - Tipo de combustible que utiliza el transporte.</param>
        /// <returns>Tupla que contiene el ítem base (ItemAlquilable) y el transporte específico (Transporte).</returns>
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
                categoriaId = 1 // ID para Transporte
            };

            var transporte = new Transporte(item)
            {
                capacidadPasajeros = (int)adicionales[0],
                tipoCombustible = (string)adicionales[1]
            };

            return (item, transporte);
        }
    }
}

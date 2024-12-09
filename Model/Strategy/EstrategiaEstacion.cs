using TitoAlquiler.Model.Entities;
using TitoAlquiler.Model.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitoAlquiler.Model.Strategy
{
    public class EstrategiaEstacion : IEstrategiaAlquiler
    {
        /// <summary>
        /// Implementa la estrategia de precios basada en las estaciones del año para calcular el precio del alquiler.
        /// Esta estrategia aplica descuentos según la temporada en la que se realiza el alquiler y si el usuario tiene membresía premium.
        /// </summary>


        Usuarios usuarios = new Usuarios();

        /// <summary>
        /// Calcula el precio del alquiler aplicando descuentos dependiendo de la estación del año y si el usuario tiene membresía premium.
        /// </summary>
        /// <param name="alquiler">El objeto <see cref="Alquileres"/> que contiene la información del alquiler, como la fecha de inicio y la duración.</param>
        /// <param name="item">El objeto <see cref="Item"/> que contiene la información del artículo alquilado, incluyendo la tarifa diaria.</param>
        /// <returns>El precio calculado después de aplicar el descuento de acuerdo a la estación y la membresía del usuario.</returns>
        public double CalcularPrecio(Alquileres alquiler, Item item)
        {
            if (usuarios.membresiaPremium)
            {
                return (GetDescuentosEstaciones(alquiler, item)) * 0.9;
            }
            return GetDescuentosEstaciones(alquiler, item);
        }

        /// <summary>
        /// Calcula los descuentos de acuerdo con la estación del año en la que comienza el alquiler.
        /// </summary>
        /// <param name="alquiler">El objeto <see cref="Alquileres"/> que contiene la información del alquiler.</param>
        /// <param name="item">El objeto <see cref="Item"/> que contiene la información del artículo alquilado.</param>
        /// <returns>El precio con el descuento aplicado según la estación.</returns>
        public double GetDescuentosEstaciones(Alquileres alquiler, Item item)
        {
            if (alquiler.fechaInicio.Month > 0 && alquiler.fechaInicio.Month < 4)
            {
                return getDescuentoVerano(alquiler, item);
            }
            else if (alquiler.fechaInicio.Month > 3 && alquiler.fechaInicio.Month < 7)
            {
                return getDescuentoOtoño(alquiler, item);
            }
            else if (alquiler.fechaInicio.Month > 6 && alquiler.fechaInicio.Month < 10)
            {
                return getDescuentoInvierno(alquiler, item);
            }
            else if (alquiler.fechaInicio.Month > 9 && alquiler.fechaInicio.Month < 13)
            {
                return getDescuentoPrimavera(alquiler, item);
            }

            return alquiler.tiempoDias * item.tarifaDia; // Si no entra en ningún rango (seguro para evitar errores)
        }


        public double getDescuentoVerano(Alquileres alquiler, Item item)
        {
            return (alquiler.tiempoDias * item.tarifaDia) * 0.9; //Descuento del 10% en Verano
        }

        public double getDescuentoOtoño(Alquileres alquiler, Item item)
        {
            return (alquiler.tiempoDias * item.tarifaDia) * 0.85; //Descuento del 15% en Otoño
        }

        public double getDescuentoInvierno(Alquileres alquiler, Item item)
        {
            return alquiler.tiempoDias * item.tarifaDia; // Sin descuento en Invierno
        }

        public double getDescuentoPrimavera(Alquileres alquiler, Item item)
        {
            return (alquiler.tiempoDias * item.tarifaDia) * 0.95; //Descuento del 5% en Primavera
        }

        public string getEstrategia()
        {
            return "EstrategiaEstacion";
        }
    }
}

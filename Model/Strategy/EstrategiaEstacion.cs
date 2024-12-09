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
        public double CalcularPrecio(Alquileres alquiler, Item item)
        {
            if (alquiler.fechaInicio.Month > 0 && alquiler.fechaInicio.Month < 4)
            {
                getDescuentoVerano();
            }
            else if (alquiler.fechaInicio.Month > 3 && alquiler.fechaInicio.Month < 7)
            {
                getDescuentoOtoño();
            }
            else if (alquiler.fechaInicio.Month > 5 && alquiler.fechaInicio.Month < 10)
            {
                getDescuentoInvierno();
            }
            else if (alquiler.fechaInicio.Month > 9 && alquiler.fechaInicio.Month < 13)
            {
                getDescuentoPrimavera();
            }

            return 0;
        }

        public double getDescuentoVerano()
        {
            return 0.9; //Descuento del 10%
        }

        public double getDescuentoOtoño()
        {
            return 0.85; //Descuento del 15%
        }

        public double getDescuentoInvierno()
        {
            return 1; //Sin descuento en epoca de invierno
        }

        public double getDescuentoPrimavera()
        {
            return 0.95; //Descuento del 5%
        }

        public string getEstrategia()
        {
            return "EstrategiaEstacion";
        }
    }
}

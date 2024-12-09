using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities;

namespace TitoAlquiler.Model.Strategy
{
    public class EstrategiaPremium : IEstrategiaAlquiler
    {
        EstrategiaEstacion estrategiaEstacion = new EstrategiaEstacion();
        public double CalcularPrecio(Alquileres alquiler, Item item)
        {
            return (estrategiaEstacion.GetDescuentosEstaciones(alquiler, item)) * 0.9;
        }

        public string getEstrategia()
        {
            return "EstrategiaPremium";
        }
    }
}

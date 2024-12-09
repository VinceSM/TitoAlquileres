using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities;

namespace TitoAlquiler.Model.Strategy
{
    internal class EstrategiaEstacionPremium : IEstrategiaAlquiler
    {
        EstrategiaEstacion estrategiaDescuento = new EstrategiaEstacion();
        EstrategiaPremium estrategiaPremium = new EstrategiaPremium();

        public double CalcularPrecio(Alquileres alquiler, Item item)
        {
            return (alquiler.tiempoDias * item.tarifaDia) * 
                estrategiaDescuento.CalcularPrecio(alquiler, item) * estrategiaPremium.CalcularPrecio(alquiler,item);
        }

        public string getEstrategia()
        {
            return "EstrategiaCompleta";
        }
    }
}

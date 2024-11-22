using SistemaAlquileres.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities;
//using TitoAlquiler.Model.Entities.Item;

namespace SistemaAlquileres.Model.Strategy
{
    public class EstrategiaPremium : IEstrategiaAlquiler
    {
        public double CalcularPrecio(Alquiler alquiler, Item item)
        {
            return (alquiler.tiempoDias * item.tarifaDia) * 0.9; //Precio con 10% off para usuarios premium 
        }

        public string getEstrategia()
        {
            return "Estrategia Premium";
        }
    }

    
}

using TitoAlquiler.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitoAlquiler.Model.Strategy
{
    public class EstrategiaPremium : IEstrategiaAlquiler
    {
        Usuarios usuarios = new Usuarios();
        public double CalcularPrecio(Alquileres alquiler, Item item)
        {
            if(usuarios.membresiaPremium == true)
            {
                return (alquiler.tiempoDias * item.tarifaDia) * 0.9; //Precio con 10% off para usuarios premium 
            }

            return 1;
            
        }

        public string getEstrategia()
        {
            return "EstrategiaPremium";
        }
    }

    
}

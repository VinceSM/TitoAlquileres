using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities;

namespace TitoAlquiler.Model.Factory
{
    public class ElectrodomesticoFactory : AlquilerFactory
    {
        public override IAlquilable CrearAlquilable(string nombre, string marca, string modelo, double tarifaDia)
        {
            return new Electrodomestico { nombreItem = nombre, marca = marca, modelo = modelo, tarifaDia = tarifaDia };
        }
    }
}

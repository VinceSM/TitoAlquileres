using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities.Categorias;
using TitoAlquiler.Model.Entities.Items;

namespace TitoAlquiler.Model.Factory
{
    public class ElectrodomesticoFactory : AlquilerFactory
    {
        public override Item CrearAlquilable(string nombre, string marca, string modelo, double tarifaDia, params object[] adicionales)
        {
            return new Electrodomestico { nombreItem = nombre, marca = marca, modelo = modelo, tarifaDia = tarifaDia, potenciaWatts = (int)adicionales[0], tipoElectrodomestico = (string)adicionales[1] };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities.Categorias;
using TitoAlquiler.Model.Entities.Items;

namespace TitoAlquiler.Model.Factory
{
    public class ElectrodomesticoFactory : IAlquilerFactory
    {
        public Item CrearAlquilable(string nombre, string marca, string modelo, double tarifaDia, params object[] adicionales)
        {
            int potenciaWatts = (int)adicionales[0];
            string tipoElectrodomestico = (string)adicionales[1];

            return new Electrodomestico (nombre, marca, modelo, tarifaDia, potenciaWatts, tipoElectrodomestico);
        }
    }
}

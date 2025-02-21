using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities.Categorias;
using TitoAlquiler.Model.Entities.Items;

namespace TitoAlquiler.Model.Factory
{
    public class ElectronicaFactory : IAlquilerFactory
    {
        public Item CrearAlquilable(string nombre, string marca, string modelo, double tarifaDia, params object[] adicionales)
        {
            string resolucionPantalla = (string)adicionales[0];
            int almacenamientoGB = (int)adicionales[1];

            return new Electronica (nombre, marca, modelo, tarifaDia, resolucionPantalla, almacenamientoGB);
        }
    }
}

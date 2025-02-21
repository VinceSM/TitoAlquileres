using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities.Categorias;
using TitoAlquiler.Model.Entities.Items;

namespace TitoAlquiler.Model.Factory
{
    public class TransporteFactory : IAlquilerFactory
    {
        public Item CrearAlquilable(string nombre, string marca, string modelo, double tarifaDia, params object[] adicionales)
        {
            int capacidadPasajeros = (int)adicionales[0];  
            string tipoCombustible = (string)adicionales[1];

            return new Transporte (nombre, marca, modelo, tarifaDia, capacidadPasajeros, tipoCombustible);
        }
    }
}

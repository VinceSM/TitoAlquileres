using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities.Categorias;
using TitoAlquiler.Model.Entities.Items;

namespace TitoAlquiler.Model.Factory
{
    public class InmuebleFactory : IAlquilerFactory
    {
        public Item CrearAlquilable(string nombre, string marca, string modelo, double tarifaDia, params object[] adicionales)
        {
            double metrosCuadrados = (double)adicionales[0];
            string ubicacion = (string)adicionales[1];

            return new Inmueble (nombre, marca, modelo, tarifaDia, metrosCuadrados, ubicacion);
        }
    }
}

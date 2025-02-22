using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities.Categorias;
using TitoAlquiler.Model.Entities.Items;

namespace TitoAlquiler.Model.Factory
{
    public class ElectronicaFactory : AlquilerFactory
    {
        public override Item CrearAlquilable(string nombre, string marca, string modelo, double tarifaDia, params object[] adicionales)
        {
            return new Electronica { nombreItem = nombre, marca = marca, modelo = modelo, tarifaDia = tarifaDia, 
                almacenamientoGB = (int)adicionales[0], resolucionPantalla = (string)adicionales[1] };
        }
    }
}

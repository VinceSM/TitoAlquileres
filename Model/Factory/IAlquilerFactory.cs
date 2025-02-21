using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities.Items;

namespace TitoAlquiler.Model.Factory
{
    public interface IAlquilerFactory
    {
        Item CrearAlquilable(string nombre, string marca, string modelo, double tarifaDia, params object[] adicionales);
    }

}

using SistemaAlquileres.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAlquileres.Model.Factory
{
    public class FabricaElectrodomesticos : FabricaItems
    {
        public override Item CrearItem()
        {
            return new ItemElectrodomesticos();
        }
    }
}

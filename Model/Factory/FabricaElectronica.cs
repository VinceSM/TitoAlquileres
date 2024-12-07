using TitoAlquiler.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using TitoAlquiler.Model.Entities.Item;

namespace TitoAlquiler.Model.Factory
{
    public class FabricaElectronica : FabricaItems
    {
        public override Item CrearItem()
        {
            return new ItemElectronica();
        }
    }
}

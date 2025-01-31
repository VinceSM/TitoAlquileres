using TitoAlquiler.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Susing TitoAlquiler.Model.Entities.Item;

namespace TitoAlquiler.Model.Factory
{
    public class FabricaTransporte : IFabricable
    {
        public Item CrearItem()
        {
            return new ItemTransporte();
        }
    }
}

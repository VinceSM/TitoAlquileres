using TitoAlquiler.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using TitoAlquiler.Model.Entities.Item;

namespace TitoAlquiler.Model.Factory
{
    public class FabricaInmuebles : IFabricable
    {
        public Item CrearItem()
        {
            return new ItemInmuebles();
        }
    }
}

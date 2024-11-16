using SistemaAlquileres.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAlquileres.Model.Factory
{
    public abstract class FabricaItems
    {
        public abstract Item CrearItem();
    }
}

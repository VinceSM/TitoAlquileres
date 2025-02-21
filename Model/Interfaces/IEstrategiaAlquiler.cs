using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities.Items;

namespace TitoAlquiler.Model.Interfaces
{
    public interface IEstrategiaAlquiler
    {
        void Alquilar(Item item);
    }
}

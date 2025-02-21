using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities.Items;
using TitoAlquiler.Model.Interfaces;

namespace TitoAlquiler.Model.Strategy.TipoAlquiler
{
    public class Contrato : IEstrategiaAlquiler
    {
        public void Alquilar(Item item)
        {
            Console.WriteLine($"Generando contrato para {item.nombreItem} y solicitando depósito...");
        }
    }
}

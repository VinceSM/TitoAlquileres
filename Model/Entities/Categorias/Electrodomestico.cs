using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities.Items;
using TitoAlquiler.Model.Interfaces;

namespace TitoAlquiler.Model.Entities.Categorias
{
    public class Electrodomestico : IAlquilable
    {
        public int potenciaWatts { get; set; }
        public string? tipoElectrodomestico { get; set; }
        public void Alquilar(Item item)
        {
            Console.WriteLine($"Se ha alquilado un electrodoméstico: {item.nombreItem}, Potencia: {potenciaWatts}W");
        }
    }
}

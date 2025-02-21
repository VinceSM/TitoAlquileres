using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities.Items;
using TitoAlquiler.Model.Interfaces;

namespace TitoAlquiler.Model.Entities.Categorias
{
    public class Indumentaria : IAlquilable
    {
        public string? talla { get; set; }
        public string? material { get; set; }
        public void Alquilar(Item item)
        {
            Console.WriteLine($"Se ha alquilado una prenda de indumentaria: {item.nombreItem}, Talla: {talla}");
        }
    }
}

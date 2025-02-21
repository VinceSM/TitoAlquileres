using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities.Items;
using TitoAlquiler.Model.Interfaces;

namespace TitoAlquiler.Model.Entities.Categorias
{
    public class Inmueble : IAlquilable
    {
        public int metrosCuadrados { get; set; }
        public string? ubicacion { get; set; }
        public void Alquilar(Item item)
        {
            Console.WriteLine($"Se ha alquilado un inmueble: {item.nombreItem}, Ubicación: {ubicacion}");
        }
    }
}

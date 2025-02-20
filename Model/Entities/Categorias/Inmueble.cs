using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities.Items;

namespace TitoAlquiler.Model.Entities.Categorias
{
    public class Inmueble : ItemAlquilable
    {
        public int metrosCuadrados { get; set; }
        public string? ubicacion { get; set; }
        public override void Alquilar()
        {
            Console.WriteLine($"Se ha alquilado un inmueble: {nombreItem}, Ubicación: {ubicacion}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitoAlquiler.Model.Entities
{
    public class Indumentaria : ItemAlquilable
    {
        public string? talla { get; set; }
        public string? material { get; set; }
        public override void Alquilar()
        {
            Console.WriteLine($"Se ha alquilado una prenda de indumentaria: {nombreItem}, Talla: {talla}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitoAlquiler.Model.Entities
{
    public class Electronica : ItemAlquilable
    {
        public string? resolucionPantalla { get; set; }
        public int almacenamientoGB { get; set; }
        public override void Alquilar()
        {
            Console.WriteLine($"Se ha alquilado un dispositivo electrónico: {nombreItem}, Resolución: {resolucionPantalla}");
        }
    }
}

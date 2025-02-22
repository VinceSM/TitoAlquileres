using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities.Items;

namespace TitoAlquiler.Model.Entities.Categorias
{
    public class Electronica : Item
    {
        public string? resolucionPantalla { get; set; }
        public int almacenamientoGB { get; set; }
        public override void Alquilar()
        {
            Console.WriteLine($"Se ha alquilado un dispositivo electrónico: {nombreItem}, Resolución: {resolucionPantalla}");
        }
    }
}

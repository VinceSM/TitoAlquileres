using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities.Items;

namespace TitoAlquiler.Model.Entities.Categorias
{
    public class Electrodomestico : ItemAlquilable
    {
        public int potenciaWatts { get; set; }
        public string? tipoElectrodomestico { get; set; }
        public override void Alquilar()
        {
            Console.WriteLine($"Se ha alquilado un electrodoméstico: {nombreItem}, Potencia: {potenciaWatts}W");
        }
    }
}

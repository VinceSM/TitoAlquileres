using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitoAlquiler.Model.Entities
{
    public class Electrodomestico : AlquilableBase
    {
        public int potenciaWatts { get; set; }
        public string? tipoElectrodomestico { get; set; }
        public override void Alquilar()
        {
            Console.WriteLine($"Se ha alquilado un electrodoméstico: {nombreItem}, Potencia: {potenciaWatts}W");
        }
    }
}

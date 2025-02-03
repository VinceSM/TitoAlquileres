using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitoAlquiler.Model.Entities
{
    public class Transporte : AlquilableBase
    {
        public int capacidadPasajeros { get; set; }
        public string? tipoCombustible { get; set; }
        public override void Alquilar()
        {
            Console.WriteLine($"Se ha alquilado un transporte: {nombreItem}, Capacidad: {capacidadPasajeros} pasajeros");
        }
    }
}

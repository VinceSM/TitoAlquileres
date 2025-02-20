using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities.Items;

namespace TitoAlquiler.Model.Entities.Categorias
{
    public class Transporte : ItemAlquilable
    {
        public int capacidadPasajeros { get; set; }
        public string? tipoCombustible { get; set; }
        public override void Alquilar()
        {
            Console.WriteLine($"Se ha alquilado un transporte: {nombreItem}, Capacidad: {capacidadPasajeros} pasajeros");
        }
    }
}

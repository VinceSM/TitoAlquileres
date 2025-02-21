using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities.Items;
using TitoAlquiler.Model.Interfaces;

namespace TitoAlquiler.Model.Entities.Categorias
{
    public class Transporte : IAlquilable
    {
        public int capacidadPasajeros { get; set; }
        public string? tipoCombustible { get; set; }
        public void Alquilar(Item item)
        {
            Console.WriteLine($"Se ha alquilado un transporte: {item.nombreItem}, Capacidad: {capacidadPasajeros} pasajeros");
        }
    }
}

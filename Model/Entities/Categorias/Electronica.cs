using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities.Items;
using TitoAlquiler.Model.Interfaces;

namespace TitoAlquiler.Model.Entities.Categorias
{
    public class Electronica : IAlquilable
    {
        public string? resolucionPantalla { get; set; }
        public int almacenamientoGB { get; set; }

        public Electronica(string nombre, string marca, string modelo, double tarifaDia, string resolucion, int almacenamiento)
        {
            //Hacer Constructor
            
        }
        public void Alquilar(Item item)
        {
            Console.WriteLine($"Se ha alquilado un dispositivo electrónico: {item.nombreItem}, Resolución: {resolucionPantalla}");
        }
    }
}

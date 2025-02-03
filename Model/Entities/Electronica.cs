using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitoAlquiler.Model.Entities
{
    public class Electronica : IAlquilable
    {
        public int id { get; set; }
        public string? nombreItem { get; set; }
        public string? marca { get; set; }
        public string? modelo { get; set; }
        public double tarifaDia { get; set; }
        public int categoriaId { get; set; }
        public DateTime? deletedAt { get; set; }
        public void Alquilar()
        {
            Console.WriteLine("Se ha alquilado un electronico.");
        }
    }
}

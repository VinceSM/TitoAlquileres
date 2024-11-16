using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAlquileres.Model.Entities
{
    public class Usuario
    {
        public int id {  get; set; }
        public string nombre { get; set; }
        public int dni { get; set; }
        public string email { get; set; }
        public string tipo_membresia { get; set; }
        public DateTime deletedAt { get; set; }

    }
}

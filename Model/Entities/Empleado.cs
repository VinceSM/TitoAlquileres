using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitoAlquiler.Model.Entities
{
    public class Empleado : UserType
    {
        public int userTypeId { get; set; }
        public int id { get; set; }
        public string nombre { get; set; }
        public int dni { get; set; }
        public string email { get; set; }
        public DateTime? deletedAt { get; set; }
    }
}

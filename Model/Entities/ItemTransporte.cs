﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitoAlquiler.Model.Entities
{
    public class ItemTransporte : Item
    {
        public string descripcion { get; set; }

        public string GetDescripcion()
        {
            return descripcion;
        }
    }
}

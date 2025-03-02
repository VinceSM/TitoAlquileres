﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitoAlquiler.Model.Entities.Categorias
{
    // Clase Transporte
    public class Transporte
    {
        public int id { get; set; }
        public int item_id { get; set; }
        public Item item { get; set; }
        public int capacidadPasajeros { get; set; }
        public string? tipoCombustible { get; set; }

        public Transporte() { }

        public Transporte(Item item)
        {
            this.item = item;
            this.item_id = item.id;
        }
    }

}

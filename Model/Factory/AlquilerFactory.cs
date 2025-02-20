﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities.Items;

namespace TitoAlquiler.Model.Factory
{
    public abstract class AlquilerFactory
    {
        public abstract ItemAlquilable CrearAlquilable(string nombre, string marca, string modelo, double tarifaDia);
    }
}

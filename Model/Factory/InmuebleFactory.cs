﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities.Categorias;
using TitoAlquiler.Model.Entities.Items;

namespace TitoAlquiler.Model.Factory
{
    public class InmuebleFactory : AlquilerFactory
    {
        public override ItemAlquilable CrearAlquilable(string nombre, string marca, string modelo, double tarifaDia)
        {
            return new Inmueble { nombreItem = nombre, marca = marca, modelo = modelo, tarifaDia = tarifaDia };
        }
    }
}

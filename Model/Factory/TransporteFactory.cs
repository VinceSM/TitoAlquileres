﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities.Categorias;
using TitoAlquiler.Model.Entities.Items;

namespace TitoAlquiler.Model.Factory
{
    public class TransporteFactory : AlquilerFactory
    {
        public override Item CrearAlquilable(string nombre, string marca, string modelo, double tarifaDia, params object[] adicionales)
        {
            return new Transporte { nombreItem = nombre, marca = marca, modelo = modelo, tarifaDia = tarifaDia, 
                capacidadPasajeros = (int)adicionales[0], tipoCombustible = (string)adicionales[1] };
        }
    }
}

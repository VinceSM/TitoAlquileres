﻿using SistemaAlquileres.Model.Entities;
using SistemaAlquileres.Model.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities.Item;

namespace TitoAlquiler.Model.Strategy
{
    public class EstrategiaDescuento : IEstrategiaAlquiler
    {
        public double CalcularPrecio(Alquiler alquiler, Item item)
        {
            if (alquiler.fecha_inicio.Month > 0 && alquiler.fecha_inicio.Month <= 4)
            {
                getDescuentoVerano();

            }
            else if (alquiler.fecha_inicio.Month > 4 && alquiler.fecha_inicio.Month <= 8)
            {
                getDescuentoInvierno();
            }
            else if (alquiler.fecha_inicio.Month > 8 && alquiler.fecha_inicio.Month <= 12)
            {
                getDescuentoPrimavera();
            }

            return 0;
        }

        public double getDescuentoVerano()
        {
            return 0.9; //Descuento del 10%
        }

        public double getDescuentoInvierno()
        {
            return 1; //Sin descuento en epoca de invierno
        }

        public double getDescuentoPrimavera()
        {
            return 0.95; //Descuento del 5%
        }

        public string getEstrategia()
        {
            return "Estrategia Descuento";
        }
    }
}
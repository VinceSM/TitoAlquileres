﻿using TitoAlquiler.Model.Entities;
using System;

namespace TitoAlquiler.Model.Strategy
{
    public class EstrategiaNormal : IEstrategiaAlquiler
    {
        public double CalcularPrecio(Alquileres alquiler, Item item)
        {
            return alquiler.tiempoDias * item.tarifaDia;
        }

        public string getEstrategia()
        {
            return "EstrategiaNormal";
        }
    }
}


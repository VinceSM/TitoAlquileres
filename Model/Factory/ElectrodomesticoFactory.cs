﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities;
using TitoAlquiler.Model.Entities.Categorias;
using TitoAlquiler.Model.Interfaces;

namespace TitoAlquiler.Model.Factory
{
    public class ElectrodomesticoFactory : IItemFactory
    {
        public (ItemAlquilable item, object categoria) CrearAlquilable(
            string nombre,
            string marca,
            string modelo,
            double tarifaDia,
            params object[] adicionales)
        {
            var item = new ItemAlquilable
            {
                nombreItem = nombre,
                marca = marca,
                modelo = modelo,
                tarifaDia = tarifaDia,
                categoriaId = 2 // ID para Electrodomestico
            };

            var electrodomestico = new Electrodomestico(item)
            {
                potenciaWatts = (int)adicionales[0],
                tipoElectrodomestico = (string)adicionales[1]
            };

            return (item, electrodomestico);
        }
    }
}

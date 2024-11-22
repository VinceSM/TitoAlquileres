using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities;

namespace SistemaAlquileres.Model.Factory
{
    public abstract class FabricaItems
    {
        public abstract Item CrearItem();

        public Item BuildItem(string nombreItem, int categoriaId, string marca, string modelo, double tarifaDia)
        {
            Item item = CrearItem();

            item.nombreItem = nombreItem;
            item.categoriaId = categoriaId;
            item.marca = marca;
            item.modelo = modelo;
            item.tarifaDia = tarifaDia;

            return item;
        }
    }
}

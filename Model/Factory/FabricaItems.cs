using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities.Item;

namespace SistemaAlquileres.Model.Factory
{
    public abstract class FabricaItems
    {
        public abstract Item CrearItem();

        public Item BuildItem(string nombre, string categoria, string marca, string modelo, double tarifa)
        {
            Item item = CrearItem();
            item.nombre = nombre;
            item.categoria = categoria;
            item.marca = marca;
            item.modelo = modelo;
            item.tarifa = tarifa;

            return item;
        }

    }
}

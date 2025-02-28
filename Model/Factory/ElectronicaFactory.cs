using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities.Categorias;
using TitoAlquiler.Model.Entities.Items;

namespace TitoAlquiler.Model.Factory
{
    public class ElectronicaFactory : ItemFactory
    {
        public override (Item item, object categoria) CrearAlquilable(
            string nombre,
            string marca,
            string modelo,
            double tarifaDia,
            params object[] adicionales)
        {
            var item = new Item
            {
                nombreItem = nombre,
                marca = marca,
                modelo = modelo,
                tarifaDia = tarifaDia,
                categoriaId = 3 // ID para Electronica
            };

            var electronica = new Electronica(item)
            {
                almacenamientoGB = (int)adicionales[0],
                resolucionPantalla = (string)adicionales[1]
            };

            return (item, electronica);
        }
    }
}

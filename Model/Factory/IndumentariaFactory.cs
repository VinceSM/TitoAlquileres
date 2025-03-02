using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities.Categorias;
using TitoAlquiler.Model.Entities.Items;

namespace TitoAlquiler.Model.Factory
{
    public class IndumentariaFactory : IItemFactory
    {
        public (Item item, object categoria) CrearAlquilable(
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
                categoriaId = 5 // ID para Indumentaria
            };

            var indumentaria = new Indumentaria(item)
            {
                talla = (string)adicionales[0],
                material = (string)adicionales[1]
            };

            return (item, indumentaria);
        }
    }
}

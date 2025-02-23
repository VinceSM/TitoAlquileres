using System;
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
                categoriaId = 4 // ID para Inmueble
            };

            var inmueble = new Inmueble(item)
            {
                metrosCuadrados = (int)adicionales[0],
                ubicacion = (string)adicionales[1]
            };

            return (item, inmueble);
        }
    }
}

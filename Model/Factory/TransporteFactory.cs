using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities;
using TitoAlquiler.Model.Entities.Categorias;
using TitoAlquiler.Model.Interfaces;
public class TransporteFactory : IItemFactory
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
            categoriaId = 1 // ID para Transporte
        };

        var transporte = new Transporte(item)
        {
            capacidadPasajeros = (int)adicionales[0],
            tipoCombustible = (string)adicionales[1]
        };

        return (item, transporte);
    }
}
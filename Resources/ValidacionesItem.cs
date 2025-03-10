using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitoAlquiler.Model.Entities;

namespace TitoAlquiler.Resources
{
    public static class ValidacionesItem
    {
        /// <summary>
        /// Valida los campos básicos de un ítem.
        /// </summary>
        /// <param name="nombre">Nombre del ítem.</param>
        /// <param name="marca">Marca del ítem.</param>
        /// <param name="modelo">Modelo del ítem.</param>
        /// <param name="tarifaText">Tarifa en formato texto.</param>
        /// <param name="tarifa">Tarifa convertida a double si es válida.</param>
        /// <returns>True si todos los campos son válidos; de lo contrario, False.</returns>
        public static bool ValidarCamposBasicos(string nombre, string marca, string modelo, string tarifaText, out double tarifa)
        {
            bool isValid = true;
            tarifa = 0;

            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(marca) ||
                string.IsNullOrWhiteSpace(modelo) || string.IsNullOrWhiteSpace(tarifaText))
            {
                MessageShow.MostrarMensajeAdvertencia("Todos los campos son obligatorios.");
                isValid = false;
            }

            // Validar que la tarifa sea un número válido
            if (!double.TryParse(tarifaText, out tarifa) || tarifa <= 0)
            {
                MessageShow.MostrarMensajeAdvertencia("La tarifa debe ser un valor numérico mayor que cero.");
                isValid = false;
            }

            return isValid;
        }

        /// <summary>
        /// Valida que se haya seleccionado una categoría.
        /// </summary>
        /// <param name="categoria">La categoría seleccionada.</param>
        /// <returns>True si se seleccionó una categoría válida; de lo contrario, False.</returns>
        public static bool ValidarCategoria(Categoria categoria)
        {
            bool isValid = true;

            if (categoria == null)
            {
                MessageShow.MostrarMensajeAdvertencia("Debe seleccionar una categoría.");
                isValid = false;
            }
            return isValid;
        }

        /// <summary>
        /// Convierte un texto a un valor numérico entero, con manejo de errores.
        /// </summary>
        /// <param name="texto">El texto a convertir.</param>
        /// <param name="nombreCampo">Nombre del campo para el mensaje de error.</param>
        /// <param name="valor">Valor numérico convertido.</param>
        /// <returns>True si la conversión fue exitosa; de lo contrario, False.</returns>
        public static bool TryParseInt(string texto, string nombreCampo, out int valor)
        {
            bool success = true;

            if (!int.TryParse(texto, out valor) || valor < 0)
            {
                MessageShow.MostrarMensajeAdvertencia($"El campo {nombreCampo} debe ser un número entero positivo.");
                success = false;
            }
            return success;
        }

        /// <summary>
        /// Valida los campos específicos según la categoría.
        /// </summary>
        /// <param name="categoria">Nombre de la categoría.</param>
        /// <param name="campos">Diccionario con los valores de los campos específicos.</param>
        /// <returns>True si todos los campos específicos son válidos; de lo contrario, False.</returns>
        public static bool ValidarCamposEspecificos(string categoria, Dictionary<string, string> campos)
        {
            bool isValid = true;

            switch (categoria)
            {
                case "Transporte":
                    if (!TryParseInt(campos["capacidad"], "Capacidad de pasajeros", out _))
                        isValid = false;
                    if (string.IsNullOrWhiteSpace(campos["combustible"]))
                    {
                        MessageShow.MostrarMensajeAdvertencia("El tipo de combustible es obligatorio.");
                        isValid = false;
                    }
                    break;

                case "Electrodomestico":
                    if (!TryParseInt(campos["potencia"], "Potencia en watts", out _))
                        isValid = false;
                    if (string.IsNullOrWhiteSpace(campos["tipo"]))
                    {
                        MessageShow.MostrarMensajeAdvertencia("El tipo de electrodoméstico es obligatorio.");
                        isValid = false;
                    }
                    break;

                case "Electronica":
                    if (!TryParseInt(campos["almacenamiento"], "Almacenamiento en GB", out _))
                        isValid = false;
                    if (string.IsNullOrWhiteSpace(campos["resolucion"]))
                    {
                        MessageShow.MostrarMensajeAdvertencia("La resolución de pantalla es obligatoria.");
                        isValid = false;
                    }
                    break;

                case "Inmueble":
                    if (!TryParseInt(campos["metros"], "Metros cuadrados", out _))
                        isValid = false;
                    if (string.IsNullOrWhiteSpace(campos["ubicacion"]))
                    {
                        MessageShow.MostrarMensajeAdvertencia("La ubicación es obligatoria.");
                        isValid = false;
                    }
                    break;

                case "Indumentaria":
                    if (string.IsNullOrWhiteSpace(campos["talla"]))
                    {
                        MessageShow.MostrarMensajeAdvertencia("La talla es obligatoria.");
                        isValid = false;
                    }
                    if (string.IsNullOrWhiteSpace(campos["material"]))
                    {
                        MessageShow.MostrarMensajeAdvertencia("El material es obligatorio.");
                        isValid = false;
                    }
                    break;
            }

            return isValid;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitoAlquiler.Resources
{
    public static class ValidacionesUsuario
    {
        /// <summary>
        /// Valida el formato del correo electrónico.
        /// </summary>
        /// <param name="email">Correo electrónico a validar.</param>
        /// <returns>True si el email es válido; de lo contrario, False.</returns>
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                string[] validEndings = { ".com", ".net", ".org", ".edu", ".gov", ".ar", ".es" };
                return addr.Address == email && email.Contains("@") &&
                       validEndings.Any(ending => email.EndsWith(ending, StringComparison.OrdinalIgnoreCase));
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Valida si un DNI tiene el formato correcto (8 dígitos numéricos).
        /// </summary>
        /// <param name="dniText">Texto del DNI a validar.</param>
        /// <param name="dni">DNI convertido a entero si es válido.</param>
        /// <returns>True si el DNI es válido; de lo contrario, False.</returns>
        public static bool IsValidDni(string dniText, out int dni)
        {
            return int.TryParse(dniText, out dni) && dniText.Length == 8;
        }

        /// <summary>
        /// Valida los datos básicos de un usuario.
        /// </summary>
        /// <param name="nombre">Nombre del usuario.</param>
        /// <param name="email">Email del usuario.</param>
        /// <param name="dniText">DNI en formato texto.</param>
        /// <param name="dni">DNI convertido a entero si es válido.</param>
        /// <returns>True si todos los datos son válidos; de lo contrario, False.</returns>
        public static bool ValidarDatosUsuario(string nombre, string email, string dniText, out int dni)
        {
            bool isValid = true;

            // Validar DNI
            if (!IsValidDni(dniText, out dni))
            {
                MessageShow.MostrarMensajeAdvertencia("El DNI debe ser un número válido de 8 dígitos.");
                isValid = false;
            }

            // Validar Email
            if (!IsValidEmail(email))
            {
                MessageShow.MostrarMensajeAdvertencia("El email ingresado no es válido. Asegúrate de incluir un '@' y una terminación válida como '.com'.");
                isValid = false;
            }

            // Validar Nombre (opcional, se puede expandir)
            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageShow.MostrarMensajeAdvertencia("El nombre no puede estar vacío.");
                isValid = false;
            }

            return isValid;
        }
    }
}

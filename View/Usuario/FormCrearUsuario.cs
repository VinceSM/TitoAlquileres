using TitoAlquiler.Controller;
using TitoAlquiler.Model.Entities;
using TitoAlquiler.View.Alquiler;
using System;
using System.Windows.Forms;
using Microsoft.IdentityModel.Tokens;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Net;

namespace TitoAlquiler.View.Usuario
{
    public partial class FormCrearUsuario : Form
    {
        private readonly UsuarioController usuarioController = UsuarioController.getInstance();

        public FormCrearUsuario()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Muestra un mensaje de error en un cuadro de diálogo y actualiza la etiqueta de estado.
        /// </summary>
        /// <param name="mensaje">Mensaje de error a mostrar.</param>
        private void MostrarMensajeError(string mensaje)
        {
            lblCreado.Text = "Error al crear el usuario";
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Navega al formulario de inicio de sesión.
        /// </summary>
        /// <param name="sender">El objeto que dispara el evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void linkVolverInicioSesion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormAlquilar formAlquilar = new FormAlquilar();
            formAlquilar.Show();
            this.Hide();
        }

        /// <summary>
        /// Maneja el evento de cierre del formulario, cerrando toda la aplicación si el usuario lo cierra.
        /// </summary>
        /// <param name="e">Datos del evento de cierre del formulario.</param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        #region FormUsuario

        /// <summary>
        /// Limpia los campos de entrada en el formulario.
        /// </summary>
        private void LimpiarCampos()
        {
            textBoxCrearNombre.Clear();
            textBoxCrearEmail.Clear();
            textBoxCrearDNI.Clear();
            checkBoxMembresia.Checked = false;
            lblCreado.Text = string.Empty;
        }

        /// <summary>
        /// Crea un nuevo usuario basado en los datos ingresados y los valida antes de proceder.
        /// </summary>
        /// <param name="sender">El objeto que dispara el evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            if (!ValidateInputsBoolean(out string nombre, out string email, out int dni))
            {
                MostrarMensajeError("Por favor, completa los campos correctamente");
                return;
            }

            if (!IsValidEmail(email))
            {
                MostrarMensajeError("El email ingresado no es válido. Asegúrate de incluir un '@' y una terminación válida como '.com'.");
                return;
            }

            Usuarios nuevoUsuario = new Usuarios
            {
                nombre = nombre,
                dni = dni,
                email = email,
                membresiaPremium = checkBoxMembresia.Checked
            };

            try
            {
                VerificarDniExistente(dni);
                VerificarEmailExistente(email);
                usuarioController.CrearUsuario(nuevoUsuario);
                lblCreado.Text = "Usuario creado exitosamente";
                MessageBox.Show("Usuario creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MostrarMensajeError($"Error al crear el usuario: {ex.Message}");
            }
        }

        #endregion


        #region Validate Dni

        /// <summary>
        /// Verifica si el DNI ingresado ya está registrado en el sistema.
        /// </summary>
        /// <param name="dni">El DNI a validar.</param>
        private void VerificarDniExistente(int dni)
        {
            if (usuarioController.CompararDNI(dni))
            {
                throw new Exception("El DNI ingresado ya está registrado.");
            }
        }

        /// <summary>
        /// Valida los datos de entrada del formulario para la creación de un usuario.
        /// </summary>
        /// <param name="nombre">Salida: Nombre ingresado por el usuario.</param>
        /// <param name="email">Salida: Email ingresado por el usuario.</param>
        /// <param name="dni">Salida: DNI ingresado por el usuario.</param>
        /// <returns>True si todos los datos son válidos, de lo contrario False.</returns>
        private bool ValidateInputsBoolean(out string nombre, out string email, out int dni)
        {
            nombre = textBoxCrearNombre.Text.Trim();
            email = textBoxCrearEmail.Text.Trim();
            string dniText = textBoxCrearDNI.Text.Trim();

            if (!int.TryParse(dniText, out dni))
            {
                MostrarMensajeError("El DNI debe ser un número válido.");
                return false;
            }

            if (dniText.Length != 8)
            {
                MostrarMensajeError("El DNI debe constar de 8 dígitos.");
                return false;
            }

            return true;
        }

        #endregion


        #region ValidateEmail

        /// <summary>
        /// Verifica si el correo electrónico ingresado ya está registrado en el sistema.
        /// </summary>
        /// <param name="email">El correo electrónico a validar.</param>
        private void VerificarEmailExistente(string email)
        {
            if (usuarioController.CompararEmail(email))
            {
                throw new Exception("El Email ingresado ya está registrado.");
            }
        }

        /// <summary>
        /// Valida que el correo electrónico tenga un formato válido.
        /// </summary>
        /// <param name="email">El correo electrónico a validar.</param>
        /// <returns>True si el correo tiene un formato válido, de lo contrario False.</returns>
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                string[] validEndings = { ".com", ".net", ".org", ".edu", ".gov", ".ar", ".es" };
                return addr.Address == email && validEndings.Any(ending => email.EndsWith(ending, StringComparison.OrdinalIgnoreCase));
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }
}


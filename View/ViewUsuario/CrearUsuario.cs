// CrearUsuario.cs
using System;
using System.Windows.Forms;
using TitoAlquiler.Controller;
using TitoAlquiler.Model.Entities;
using TitoAlquiler.Resources;
using TitoAlquiler.View.ViewAlquiler;

namespace TitoAlquiler.View.ViewUsuario
{
    public partial class CrearUsuario : Form
    {
        private readonly UsuarioController usuarioController = UsuarioController.Instance;

        #region FormUsuario
        public CrearUsuario()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Navega al formulario de inicio de sesión.
        /// </summary>
        /// <param name="sender">El objeto que dispara el evento.</param>
        /// <param name="e">Datos del evento.</param>
        private void linkVolverInicioSesion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CrearAlquiler formAlquilar = new CrearAlquiler();
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
        #endregion

        #region Usuario
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
            try
            {
                // Obtener y validar los datos
                string nombre = textBoxCrearNombre.Text.Trim();
                string email = textBoxCrearEmail.Text.Trim();
                string dniText = textBoxCrearDNI.Text.Trim();

                if (!ValidacionesUsuario.ValidarDatosUsuario(nombre, email, dniText, out int dni))
                {
                    return; // La validación ya mostró los mensajes de error
                }

                // Verificar si el DNI ya está registrado
                if (usuarioController.CompararDNI(dni))
                {
                    MessageShow.MostrarMensajeAdvertencia("El DNI ingresado ya está registrado.");
                    return;
                }

                // Verificar si el email ya está registrado
                if (usuarioController.CompararEmail(email))
                {
                    MessageShow.MostrarMensajeAdvertencia("El Email ingresado ya está registrado.");
                    return;
                }

                // Crear el nuevo usuario
                Usuarios nuevoUsuario = new Usuarios
                {
                    nombre = nombre,
                    dni = dni,
                    email = email,
                    membresiaPremium = checkBoxMembresia.Checked
                };

                usuarioController.CrearUsuario(nuevoUsuario);

                lblCreado.Text = "Usuario creado exitosamente";
                MessageShow.MostrarMensajeExito("Usuario creado exitosamente.");
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageShow.MostrarMensajeError($"Error al crear el usuario: {ex.Message}");
            }
        }
        #endregion
    }
}
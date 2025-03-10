// ModificarUsuario.cs
using System;
using System.Windows.Forms;
using TitoAlquiler.Controller;
using TitoAlquiler.Model.Entities;
using TitoAlquiler.Resources;
using TitoAlquiler.View.ViewAlquiler;

namespace TitoAlquiler.View.ViewUsuario
{
    public partial class ModificarUsuario : Form
    {
        private readonly UsuarioController usuarioController = UsuarioController.Instance;
        private Usuarios usuarioActual;

        #region FormModificarUser
        /// <summary>
        /// Constructor que recibe el usuario a modificar.
        /// </summary>
        /// <param name="usuario">Objeto de tipo Usuarios que se va a modificar.</param>
        public ModificarUsuario(Usuarios usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
            CargarDatosUsuario();
        }

        /// <summary>
        /// Llena los campos del formulario con los datos del usuario actual.
        /// </summary>
        private void CargarDatosUsuario()
        {
            textBoxNombre.Text = usuarioActual.nombre;
            textBoxEmail.Text = usuarioActual.email;
            textBoxDNI.Text = usuarioActual.dni.ToString();
            checkBoxMembresia.Checked = usuarioActual.membresiaPremium;
        }

        /// <summary>
        /// Evento que permite volver a la ventana CrearAlquiler.
        /// </summary>
        /// <param name="sender">Objeto que desencadena el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void linkVolver_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CrearAlquiler formAlquilar = new CrearAlquiler();
            formAlquilar.Show();
            this.Hide();
        }
        #endregion

        #region Validaciones
        /// <summary>
        /// Valida los inputs del formulario.
        /// </summary>
        /// <returns>True si los inputs son válidos; de lo contrario, False.</returns>
        private bool ValidarInputs()
        {
            string nombre = textBoxNombre.Text.Trim();
            string email = textBoxEmail.Text.Trim();
            string dniText = textBoxDNI.Text.Trim();

            return ValidacionesUsuario.ValidarDatosUsuario(nombre, email, dniText, out _);
        }
        #endregion

        #region Botones
        /// <summary>
        /// Evento del botón para modificar el usuario.
        /// </summary>
        /// <param name="sender">Objeto que desencadena el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener y validar los datos
                string nombre = textBoxNombre.Text.Trim();
                string email = textBoxEmail.Text.Trim();
                string dniText = textBoxDNI.Text.Trim();

                if (!ValidacionesUsuario.ValidarDatosUsuario(nombre, email, dniText, out int dni))
                {
                    return; // La validación ya mostró los mensajes de error
                }

                // Verificar si el email ya está en uso por otro usuario
                if (email != usuarioActual.email && usuarioController.CompararEmail(email))
                {
                    MessageShow.MostrarMensajeAdvertencia("El email ingresado ya está registrado por otro usuario.");
                    return;
                }

                // Verificar si el DNI ya está en uso por otro usuario
                if (dni != usuarioActual.dni && usuarioController.CompararDNI(dni))
                {
                    MessageShow.MostrarMensajeAdvertencia("El DNI ingresado ya está registrado por otro usuario.");
                    return;
                }

                // Actualizar el usuario
                usuarioActual.nombre = nombre;
                usuarioActual.email = email;
                usuarioActual.dni = dni;
                usuarioActual.membresiaPremium = checkBoxMembresia.Checked;

                usuarioController.ActualizarUsuario(usuarioActual);
                MessageShow.MostrarMensajeExito("Usuario actualizado exitosamente.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageShow.MostrarMensajeError($"Error al actualizar el usuario: {ex.Message}");
            }
        }
        #endregion
    }
}
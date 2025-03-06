using System;
using System.Windows.Forms;
using TitoAlquiler.Controller;
using TitoAlquiler.Model.Entities;
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
        /// <param name="nombre">Nombre del usuario.</param>
        /// <param name="email">Correo electrónico del usuario.</param>
        /// <param name="dni">DNI del usuario.</param>
        /// <returns>True si los inputs son válidos; de lo contrario, False.</returns>
        private bool ValidateInputs(out string nombre, out string email, out int dni)
        {
            nombre = textBoxNombre.Text.Trim();
            email = textBoxEmail.Text.Trim();
            string dniText = textBoxDNI.Text.Trim();

            if (!int.TryParse(dniText, out dni) || dniText.Length != 8)
            {
                MessageBox.Show("El DNI debe ser un número válido de 8 dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("El email ingresado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Valida el formato del correo electrónico.
        /// </summary>
        /// <param name="email">Correo electrónico a validar.</param>
        /// <returns>True si el email es válido; de lo contrario, False.</returns>
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email && email.Contains("@");
            }
            catch
            {
                return false;
            }
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
            if (!ValidateInputs(out string nombre, out string email, out int dni))
            {
                MessageBox.Show("Por favor, completa los campos correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            usuarioActual.nombre = nombre;
            usuarioActual.email = email;
            usuarioActual.dni = dni;
            usuarioActual.membresiaPremium = checkBoxMembresia.Checked;

            try
            {
                usuarioController.ActualizarUsuario(usuarioActual);
                MessageBox.Show("Usuario actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }

}

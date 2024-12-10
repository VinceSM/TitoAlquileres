using TitoAlquiler.Controller;
using TitoAlquiler.Model.Entities;
using TitoAlquiler.View.Alquiler;
using System;
using System.Windows.Forms;
using Microsoft.IdentityModel.Tokens;

namespace TitoAlquiler.View.Usuario
{
    public partial class FormCrearUsuario : Form
    {
        private readonly UsuarioController usuarioController = UsuarioController.getInstance();

        public FormCrearUsuario()
        {
            InitializeComponent();
        }

        private bool ValidateInputs(out string nombre, out string email, out int dni)
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

        private void MostrarMensajeError(string mensaje)
        {
            lblCreado.Text = "Error al crear el usuario";
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void LimpiarCampos()
        {
            textBoxCrearNombre.Clear();
            textBoxCrearEmail.Clear();
            textBoxCrearDNI.Clear();
            checkBoxMembresia.Checked = false;
            lblCreado.Text = string.Empty;
        }

        private void linkVolverInicioSesion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormAlquilar formAlquilar = new FormAlquilar();
            formAlquilar.Show();
            this.Hide();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }

        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            // Validate input
            if (!ValidateInputs(out string nombre, out string email, out int dni))
            {
                MessageBox.Show("Por favor, completa los campos correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar el email
            if (!IsValidEmail(email))
            {
                MessageBox.Show("El correo electrónico ingresado no es válido. Asegúrate de incluir un '@' y una terminación válida como '.com'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Usuarios nuevoUsuario = new Usuarios
            {
                nombre = textBoxCrearNombre.Text.Trim(),
                dni = dni,
                email = textBoxCrearEmail.Text.Trim(),
                membresiaPremium = checkBoxMembresia.Checked
            };

            try
            {
                ValidateDni(dni);
                VerificarEmailExistente(textBoxCrearEmail.Text);
                // Use UsuarioController singleton to create the user
                usuarioController.CrearUsuario(nuevoUsuario);

                MessageBox.Show("Usuario creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear input fields after successful creation
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ValidateDni(int dni) // Verifica que los DNI no se repitan
        {
            if (usuarioController.CompararDNI(dni))
            {
                throw new ArgumentException("El DNI ingresado ya está registrado.");
            }
        }

        private void VerificarEmailExistente(string email) // Verifica que los emails no se repitan
        {
            if (usuarioController.CompararEmail(email))
            {
                throw new ArgumentException("El Email ingresado ya está registrado.");

            }
        }


        private bool IsValidEmail(string email)
        {
            
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                // Verificar que el correo contiene el '@' y que tiene una terminación válida
                string[] validEndings = { ".com", ".net", ".org", ".edu", ".gov", ".ar", ".es" };
 
                return addr.Address == email && validEndings.Any(ending => email.EndsWith(ending, StringComparison.OrdinalIgnoreCase));
            }
            catch
            {
                return false;
            }
        }


    }
}


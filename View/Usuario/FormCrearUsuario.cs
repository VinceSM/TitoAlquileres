using SistemaAlquileres.Controllers;
using SistemaAlquileres.Model.Entities;
using SistemaAlquileres.View.Alquiler;
using System;
using System.Windows.Forms;

namespace SistemaAlquileres.View.Usuario
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

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(dniText))
            {
                MostrarMensajeError("Por favor, complete todos los campos.");
                dni = 0;
                return false;
            }

            if (!int.TryParse(dniText, out dni))
            {
                MostrarMensajeError("El DNI debe ser un número válido.");
                return false;
            }

            return true;
        }

        private void MostrarMensajeExito(int usuarioId)
        {
            lblCreado.Text = "Usuario creado exitosamente";
            MessageBox.Show($"Usuario creado con ID: {usuarioId}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (string.IsNullOrWhiteSpace(textBoxCrearNombre.Text))
            {
                MessageBox.Show("Por favor, ingrese un nombre válido.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxCrearDNI.Text) || !int.TryParse(textBoxCrearDNI.Text, out int dni))
            {
                MessageBox.Show("Por favor, ingrese un DNI válido.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxCrearEmail.Text) || !IsValidEmail(textBoxCrearEmail.Text))
            {
                MessageBox.Show("Por favor, ingrese un email válido.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create new Usuario object
            Usuarios nuevoUsuario = new Usuarios
            {
                nombre = textBoxCrearNombre.Text.Trim(),
                dni = dni,
                email = textBoxCrearEmail.Text.Trim(),
                membresiaPremium = checkBoxMembresia.Checked
            };

            try
            {
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

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}


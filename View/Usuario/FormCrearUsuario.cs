using SistemaAlquileres.Controller;
using SistemaAlquileres.Model.Entities;
using System;
using System.Windows.Forms;

namespace SistemaAlquileres.View.Usuario
{
    public partial class FormCrearUsuario : Form
    {
        private UsuarioController usuarioController = UsuarioController.getInstance();

        public FormCrearUsuario()
        {
            InitializeComponent();
        }

        private bool ValidateInputs(out string nombre, out string email, out int dni, out bool membresiaPremium)
        {
            nombre = textBoxCrearNombre.Text.Trim();
            email = textBoxCrearEmail.Text.Trim();
            string dniText = textBoxCrearDNI.Text.Trim();
            membresiaPremium = checkBoxMembresia.Checked;

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
        }

        private void linkVolverInicioSesion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormInicio formInicio = new FormInicio();
            formInicio.Show();
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
            if (!ValidateInputs(out string nombre, out string email, out int dni, out bool membresiaPremium))
            {
                return;
            }

            try
            {
                var usuarioCreado = usuarioController.CrearUsuario(new Model.Entities.Usuario
                {
                    nombre = nombre,
                    dni = dni,
                    email = email,
                    membresiaPremium = membresiaPremium
                });

                if (usuarioCreado != null)
                {
                    MostrarMensajeExito(usuarioCreado.id);
                    LimpiarCampos();
                }
                else
                {
                    MostrarMensajeError("No se pudo crear el usuario.");
                }
            }
            catch (Exception ex)
            {
                MostrarMensajeError($"Error al crear el usuario: {ex.Message}");
            }
        }
    }
}
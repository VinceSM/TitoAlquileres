using SistemaAlquileres.Controller;
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
            try
            {
                if (!ValidateInputs(out string nombre, out string email, out int dni))
                {
                    return;
                }

                bool membresiaPremium = checkBoxMembresia.Checked;

                // Verificar si ya existe un usuario con el mismo DNI
                var usuarioExistente = usuarioController.GetUsuarioByDni(dni);
                if (usuarioExistente != null)
                {
                    MostrarMensajeError("Ya existe un usuario con ese DNI.");
                    return;
                }

                // Verificar si ya existe un usuario con el mismo email
                usuarioExistente = usuarioController.GetUsuarioByEmail(email);
                if (usuarioExistente != null)
                {
                    MostrarMensajeError("Ya existe un usuario con ese email.");
                    return;
                }

                var nuevoUsuario = new Model.Entities.Usuario
                {
                    nombre = nombre,
                    dni = dni,
                    email = email,
                    membresiaPremium = membresiaPremium,
                    deletedAt = null
                };

                var usuarioCreado = usuarioController.CrearUsuario(nuevoUsuario);

                if (usuarioCreado != null && usuarioCreado.id > 0)
                {
                    MostrarMensajeExito(usuarioCreado.id);
                    LimpiarCampos();
                }
                else
                {
                    MostrarMensajeError("No se pudo crear el usuario. Verifique los datos e intente nuevamente.");
                }
            }
            catch (Exception ex)
            {
                // Obtener el mensaje de la excepción más interna
                var innerException = ex;
                while (innerException.InnerException != null)
                {
                    innerException = innerException.InnerException;
                }

                MostrarMensajeError($"Error al crear el usuario: {innerException.Message}");
            }
        }
    }
}


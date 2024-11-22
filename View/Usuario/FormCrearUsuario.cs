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

        private async void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            string nombre = textBoxCrearNombre.Text;
            string email = textBoxCrearEmail.Text;
            string dniText = textBoxCrearDNI.Text;
            string tipoMembresia = comboBoxTipoMembresia.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(dniText) || string.IsNullOrWhiteSpace(tipoMembresia))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            if (!int.TryParse(dniText, out int dni))
            {
                MessageBox.Show("El DNI debe ser un número válido.");
                return;
            }

            /*var NuevoUsuario = new Model.Entities.Usuario
            {
                nombre = nombre,
                email = email,
                dni = dni,
                tipoMembresia = tipoMembresia
            };*/

            try
            {
                var usuarioCreado = usuarioController.CrearUsuario(nombre, dni, email, tipoMembresia);
                if (usuarioCreado != null)
                {
                    lblCreado.Text = "Usuario creado exitosamente";
                    MessageBox.Show($"Usuario creado con ID: {usuarioCreado.id}");
                    LimpiarCampos();
                }
                else
                {
                    lblCreado.Text = "Error al crear el usuario";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el usuario: {ex.Message}");
            }
        }

        private void LimpiarCampos()
        {
            textBoxCrearNombre.Clear();
            textBoxCrearEmail.Clear();
            textBoxCrearDNI.Clear();
            comboBoxTipoMembresia.SelectedIndex = -1;
        }

        private void linkVolverInicioSesion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormIniciarSesion formIniciarSesion = new FormIniciarSesion();
            formIniciarSesion.Show();
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
    }
}
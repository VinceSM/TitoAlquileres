using SistemaAlquileres.Controller;
using Entities = SistemaAlquileres.Model.Entities;
using System;
using System.Windows.Forms;
using SistemaAlquileres.View.Alquiler;

namespace SistemaAlquileres.View.Usuario
{
    public partial class FormIniciarSesion : Form
    {
        private UsuarioController usuarioController = UsuarioController.getInstance();

        public FormIniciarSesion()
        {
            InitializeComponent();
        }

        private async void btnEntrar_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text.Trim();
            string email = textBox2.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Por favor, ingrese nombre y email.");
                return;
            }

            btnEntrar.Enabled = false;
            try
            {
                Entities.Usuario usuario = await usuarioController.getUsuarioByEmail(email);

                if (usuario != null && usuario.nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Inicio de sesión exitoso");
                    FormAlquilar formAlquilar = new FormAlquilar();
                    formAlquilar.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Nombre o email incorrectos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al iniciar sesión: {ex.Message}");
            }
            finally
            {
                btnEntrar.Enabled = true;
            }
        }

        private void linkCrearUsuario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormCrearUsuario formCrearUsuario = new FormCrearUsuario(); 
            formCrearUsuario.Show();
            this.Hide();
        }

        private void linkVolverInicio_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
    }
}
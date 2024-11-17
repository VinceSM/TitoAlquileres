using SistemaAlquileres.Controller;
using Entities = SistemaAlquileres.Model.Entities;
using System;
using System.Windows.Forms;
using System.Threading.Tasks;
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
                // Llamamos al controlador para iniciar sesión
                Entities.Usuario usuario = await usuarioController.getUsuarioByEmail(email);

                // Verificamos si el usuario existe
                if (usuario != null)
                {
                    MessageBox.Show("Inicio de sesión exitoso");

                    // Crear y mostrar el formulario de alquiler
                    FormAlquilar formAlquilar = new FormAlquilar();
                    formAlquilar.Show();
                    this.Hide(); // Ocultamos el formulario de inicio de sesión
                }
                else
                {
                    MessageBox.Show("Usuario o mail incorrectos");
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
            // Mostrar formulario para crear un nuevo usuario
            FormCrearUsuario formCrearUsuario = new FormCrearUsuario();
            formCrearUsuario.Show();
            this.Hide(); // Ocultar el formulario de inicio de sesión
        }

        private void linkVolverInicio_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Volver al formulario de inicio
            FormInicio formInicio = new FormInicio();
            formInicio.Show();
            this.Close(); // Cerrar el formulario de inicio de sesión
        }
    }
}

using SistemaAlquileres.Controller;
using Entities = SistemaAlquileres.Model.Entities;
using System;
using System.Windows.Forms;

namespace SistemaAlquileres.View.Usuario
{
    public partial class FormIniciarSesion : Form
    {
        private UsuarioController usuarioController= UsuarioController.getInstance();

        public FormIniciarSesion()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;
            string email = textBox2.Text;
            Entities.Usuario usuario = usuarioController.getUsuarioByEmail(email);
            if (usuario != null && usuario.nombre == nombre)
            {
                MessageBox.Show("Inicio de sesión exitoso");
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
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
            this.Close();
        }
    }
}

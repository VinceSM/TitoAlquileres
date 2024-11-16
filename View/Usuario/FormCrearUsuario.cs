using SistemaAlquileres.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaAlquileres.View.Usuario
{
    public partial class FormCrearUsuario : Form
    {

        private UsuarioController usuarioController= UsuarioController.getInstance();

        public FormCrearUsuario()
        {
            InitializeComponent();
        }

        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            string nombre = textBoxCrearNombre.Text;
            string email = textBoxCrearEmail.Text;

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            lblCreado.Text = "Usuario creado exitosamente";
        }

        private void linkVolverInicioSesion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormIniciarSesion formIniciarSesion = new FormIniciarSesion();
            formIniciarSesion.Show();
            this.Close();
        }
    }
}

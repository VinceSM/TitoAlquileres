using SistemaAlquileres.View.Usuario;
using System;
using System.Windows.Forms;

namespace SistemaAlquileres.View.Alquiler
{
    public partial class FormAlquilar : Form
    {
        public FormAlquilar()
        {
            InitializeComponent();
        }

        private void linkVolver_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TitoAlquiler.View.Alquiler;

namespace TitoAlquiler.View.Item
{
    public partial class Modificar : Form
    {
        public Modificar()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Regresa a la pantalla principal de alquiler y oculta la ventana actual.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void linkVolver_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormAlquilar formAlquilar = new FormAlquilar();
            formAlquilar.Show();
            this.Hide();
        }
    }
}

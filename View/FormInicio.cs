using SistemaAlquileres.View.Usuario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaAlquileres
{
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();
            //VerificarConexionBD();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            FormIniciarSesion formIniciarSesion = new FormIniciarSesion();
            formIniciarSesion.Show();
            this.Hide();
        }

        private void VerificarConexionBD()
        {
            using (var context = new SistemaAlquilerContext())
            {
                if (context.TestConnection())
                {
                    MessageBox.Show("Conexión a la base de datos establecida con éxito.", "Conexión Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo establecer la conexión a la base de datos.", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

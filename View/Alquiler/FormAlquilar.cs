using SistemaAlquileres.Controller;
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
            //CargarItems();
            CargarUsuarios();
        }

        private void linkVolver_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        /* private void CargarItems()
         {
             // Obtener los datos desde el controlador
             var items = ItemController.GetInstance().GetItems();

             // Llenar el DataGridView
             dataGridViewItem.DataSource = items.Select(item => new {
                 item.id,
                 item.nombreItem,
                 item.marca,
                 item.modelo,
                 item.tarifaDia
             }).ToList();
         }*/


        private void CargarUsuarios()
        {
            // Obtener los datos desde el controlador
            var usuarios = UsuarioController.getInstance().GetUsuarios();

            // Llenar el DataGridView
            dataGridViewUsuarios.DataSource = usuarios.Select(u => new
            {
                u.id,
                u.nombre,
                u.dni,
                u.email,
                u.membresiaPremium,
                DeletedAt = u.deletedAt.HasValue ? u.deletedAt.Value.ToString("yyyy-MM-dd") : "Activo",
                Alquileres = u.Alquileres.Count // Si tienes la relación de alquileres cargada
            }).ToList();
        }

    }
}
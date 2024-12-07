using TitoAlquiler.Controller;
using TitoAlquiler.View.Usuario;
using System;
using System.Windows.Forms;
using TitoAlquiler.Model.Entities;
using System.Linq;

namespace TitoAlquiler.View.Alquiler
{
    public partial class FormAlquilar : Form
    {
        UsuarioController usuarioController = UsuarioController.getInstance();
        AlquilerController alquilerController = AlquilerController.getInstance();
        ItemController itemController = ItemController.getInstance();

        public FormAlquilar()
        {
            InitializeComponent();
            CargarItems();
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

        private void CargarItems()
        {
            try
            {
                // Obtener los datos desde el controlador
                var items = itemController.ObtenerTodosLosItems();

                // Crear una lista de objetos anónimos para el DataGridView
                var itemsData = items.Select(item => new
                {
                    ID = item.id,
                    Nombre = item.nombreItem,
                    Marca = item.marca,
                    Modelo = item.modelo,
                    Tarifa = item.tarifaDia,
                    Categoria = item.categoria,
                }).ToList();

                // Asignar los datos al DataGridView
                dataGridViewItem.DataSource = itemsData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar items: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CargarUsuarios()
        {
            try
            {
                // Obtener los datos desde el controlador
                var usuarios = usuarioController.ObtenerTodosLosUsuarios();

                // Crear una lista de objetos anónimos para el DataGridView
                var usuariosData = usuarios.Select(u => new
                {
                    u.id,
                    u.nombre,
                    u.dni,
                    u.email,
                    membresiaPremium = u.membresiaPremium,
                    CantidadAlquileres = u.Alquileres?.Count ?? 0
                }).ToList();

                // Asignar los datos al DataGridView
                dataGridViewUsuarios.DataSource = usuariosData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            FormCrearUsuario formCrearUsuario = new FormCrearUsuario();
            formCrearUsuario.Show();
            this.Hide();
        }
    }
}


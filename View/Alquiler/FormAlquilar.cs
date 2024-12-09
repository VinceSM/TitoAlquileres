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
        CategoriaController categoriaController = CategoriaController.getInstance();

        public FormAlquilar()
        {
            InitializeComponent();
            CargarUsuarios();
            CargarCategorias();
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

        private void CargarItems(int categoriaId)
        {
            try
            {
                var items = itemController.ObtenerItemsPorCategoria(categoriaId);

                if (items == null || !items.Any())
                {
                    dataGridViewItems.Rows.Clear();
                    MessageBox.Show("No se encontraron items para esta categoría.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                dataGridViewItems.Rows.Clear();
                foreach (var item in items)
                {
                    dataGridViewItems.Rows.Add(
                        item.id,
                        item.nombreItem,
                        item.marca,
                        item.modelo,
                        item.tarifaDia,
                        item.categoria?.nombre ?? "N/A",
                        item.deletedAt == null ? "Activo" : "Inactivo"
                    );
                }
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

        private void CargarCategorias()
        {
            try
            {
                List<Categoria> categorias = categoriaController.ObtenerTodasLasCategorias();
                cmbCategorias.DataSource = categorias;
                cmbCategorias.DisplayMember = "nombre";
                cmbCategorias.ValueMember = "id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las categorías: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbCategorias.SelectedItem is Categoria categoriaSeleccionada)
                {
                    int categoriaId = categoriaSeleccionada.id;
                    CargarItems(categoriaId);
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione una categoría válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dateTimePickerFechaFin_ValueChanged(object sender, EventArgs e)
        {
            CondicionFechas();
        }

        private void CondicionFechas()
        {
            if (dateTimePickerFechaInicio.Value < dateTimePickerFechaFin.Value)
            {
                MessageBox.Show($"La fecha fin no puede ser menor a la fecha de inicio");
            }
            else if(dateTimePickerFechaFin.Value == dateTimePickerFechaInicio.Value)
            {
                MessageBox.Show("Las fechas de alquiler no pueden ser iguales");
            }
        }
    }
}


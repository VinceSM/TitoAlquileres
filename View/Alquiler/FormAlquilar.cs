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
                        //item.categoria?.nombre ?? "N/A",
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
                cmbCategorias.DropDownStyle = ComboBoxStyle.DropDownList;
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
            if (cmbCategorias.SelectedItem != null)
            {
                Categoria categoriaSeleccionada = (Categoria)cmbCategorias.SelectedItem;
                int categoriaId = categoriaSeleccionada.id;
                CargarItems(categoriaId);
            }
        }

        private void CondicionFechas()
        {
            if (dateTimePickerFechaInicio.Value <= dateTimePickerFechaFin.Value)
            {
                MessageBox.Show($"La fecha fin no puede ser menor o igual a la fecha de inicio");
            }
        }

        private void VerificarSeleccionFilaDataGrid()
        {
            if (dataGridViewUsuarios.SelectedRows.Count == 0 || dataGridViewItems.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un usuario y un item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                CondicionFechas();
                VerificarSeleccionFilaDataGrid();

                int itemId = (int)dataGridViewItems.SelectedRows[0].Cells["ID"].Value;
                int usuarioId = (int)dataGridViewUsuarios.SelectedRows[0].Cells["idDataGridViewTextBoxColumn"].Value;
                DateTime fechaInicio = dateTimePickerFechaInicio.Value;
                DateTime fechaFin = dateTimePickerFechaFin.Value;
                string tipoEstrategia = "EstrategiaNormal";

                if (((bool)dataGridViewUsuarios.SelectedRows[0].Cells["membresiaPremiumDataGridViewCheckBoxColumn"].Value))
                {
                    tipoEstrategia = "EstrategiaPremium";
                }

                if (!alquilerController.VerificarDisponibilidad(itemId, fechaInicio, fechaFin))
                {
                    MessageBox.Show("El item no está disponible para las fechas seleccionadas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var nuevoAlquiler = alquilerController.CrearNuevoAlquiler(itemId, usuarioId, fechaInicio, fechaFin, tipoEstrategia);

                MessageBox.Show($"Alquiler creado con éxito. Precio total: {nuevoAlquiler.precioTotal:C}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Actualizar la interfaz de usuario después de crear el alquiler
                CargarUsuarios();
                if (cmbCategorias.SelectedItem is Categoria categoriaSeleccionada)
                {
                    CargarItems(categoriaSeleccionada.id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el alquiler: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

